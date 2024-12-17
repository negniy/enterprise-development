using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain.Repositories;
using ElectronicDiary.Domain;
using Server.DTO;

namespace EnterpriseStatistics.Server;

[Route("api/[controller]")]
[ApiController]
public class QueryController(
    IRepository<Student, int> studentRepository,
    IRepository<Subject, int> subjectRepository,
    IRepository<Grade, int> gradeRepository
) : ControllerBase
{
    /// <summary>
    /// Query 1: Retrieve information about all subjects
    /// </summary>
    [HttpGet("allSubjects")]
    public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
    {
        var subjects = await subjectRepository.GetAll();
        return Ok(subjects);
    }

    /// <summary>
    /// Query 2: Retrieve information about all students in a specified class by its identifier, sorted by full name
    /// </summary>
    /// <param name="classId">Class identifier</param>
    [HttpGet("studentsInClass")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsInClass(int classId)
    {
        var students = (await studentRepository.GetAll())
            .Where(student => student.Class.Id == classId)
            .OrderBy(student => student.Surname)
            .ThenBy(student => student.Name)
            .ThenBy(student => student.Patronymic)
            .ToList();

        return Ok(students);
    }

    /// <summary>
    /// Query 3: Retrieve information about all students who received grades on a specified date
    /// </summary>
    /// <param name="date">Date of the grades</param>
    [HttpGet("studentsByDate")]
    public async Task<ActionResult<IEnumerable<StudentGradesDto>>> GetStudentsByDate(DateOnly date)
    {
        var studentsWithGrades = (await gradeRepository.GetAll())
            .Where(grade => grade.Date == date)
            .Select(grade => new StudentGradesDto
            {
                StudentId = grade.Student.Id,
                Surname = grade.Student.Surname,
                Name = grade.Student.Name,
                Patronymic = grade.Student.Patronymic,
                Subject = grade.Subject.Name,
                Grade = grade.GradeValue,
                Date = grade.Date
            })
            .ToList();

        return Ok(studentsWithGrades);
    }

    /// <summary>
    /// Query 4: Retrieve the top 5 students by average grade
    /// </summary>
    [HttpGet("top5StudentsByAverage")]
    public async Task<ActionResult<IEnumerable<StudentAverageGradeDto>>> GetTop5StudentsByAverage()
    {
        var topStudents = (from student in await studentRepository.GetAll()
                           join grade in await gradeRepository.GetAll()
                           on student.Id equals grade.Student.Id into studentGrades
                           from sg in studentGrades.DefaultIfEmpty()
                           group sg by new { student.Id, student.Surname, student.Name, student.Patronymic } into grouped
                           select new StudentAverageGradeDto
                           {
                               StudentId = grouped.Key.Id,
                               Surname = grouped.Key.Surname,
                               Name = grouped.Key.Name,
                               Patronymic = grouped.Key.Patronymic,
                               AverageGrade = grouped.Average(g => g != null ? (double?)g.GradeValue : null) ?? 0
                           })
                          .OrderByDescending(dto => dto.AverageGrade)
                          .Take(5)
                          .ToList();

        return Ok(topStudents);
    }


    /// <summary>
    /// Query 5: Retrieve students with the highest average grade over a specified period
    /// </summary>
    /// <param name="startDate">Start date of the period</param>
    /// <param name="endDate">End date of the period</param>
    [HttpGet("studentsWithMaxAverageByPeriod")]
    public async Task<ActionResult<IEnumerable<StudentAverageGradeDto>>> GetStudentsWithMaxAverageByPeriod(DateOnly startDate, DateOnly endDate)
    {
        var studentsWithAverages = (from student in await studentRepository.GetAll()
                                    join grade in await gradeRepository.GetAll()
                                    on student.Id equals grade.Student.Id into studentGrades
                                    from sg in studentGrades.DefaultIfEmpty()
                                    where sg == null || (sg.Date >= startDate && sg.Date <= endDate)
                                    group sg by new { student.Id, student.Surname, student.Name, student.Patronymic } into grouped
                                    select new
                                    {
                                        Student = grouped.Key,
                                        AverageGrade = grouped
                                            .Where(g => g != null)
                                            .Average(g => (double?)g.GradeValue) ?? 0
                                    }).ToList();

        var maxAverage = studentsWithAverages.Max(x => x.AverageGrade);

        var topStudents = studentsWithAverages
            .Where(x => x.AverageGrade == maxAverage)
            .Select(x => new StudentAverageGradeDto
            {
                StudentId = x.Student.Id,
                Surname = x.Student.Surname,
                Name = x.Student.Name,
                Patronymic = x.Student.Patronymic,
                AverageGrade = x.AverageGrade
            })
            .ToList();

        return Ok(topStudents);
    }


    /// <summary>
    /// Query 6: Retrieve information on the minimum, average, and maximum grade for each subject
    /// </summary>
    [HttpGet("subjectGradesStatistics")]
    public async Task<ActionResult<IEnumerable<SubjectGradeStatisticsDto>>> GetSubjectGradesStatistics()
    {
        var grades = await gradeRepository.GetAll();

        var subjectStatistics = (await subjectRepository.GetAll())
            .Select(subject => new SubjectGradeStatisticsDto
            {
                SubjectName = subject.Name,
                MinGrade = grades
                    .Where(grade => grade.Subject.Id == subject.Id)
                    .Min(grade => (int)grade.GradeValue),
                MaxGrade = grades
                    .Where(grade => grade.Subject.Id == subject.Id)
                    .Max(grade => (int)grade.GradeValue),
                AverageGrade = grades
                    .Where(grade => grade.Subject.Id == subject.Id)
                    .Average(grade => (int)grade.GradeValue)
            })
            .ToList();

        return Ok(subjectStatistics);
    }
}
