using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain.Repositories;
using ElectronicDiary.Domain;
using Server.DTO;

namespace EnterpriseStatistics.Server;

[Route("api/[controller]")]
[ApiController]
public class QueryController(IRepository<Student, int> studentRepository, IRepository<Subject, int> subjectRepository, IRepository<Grade, int> gradeRepository) : ControllerBase
{
    /// <summary>
    /// Query 1: Retrieve information about all subjects
    /// </summary>
    [HttpGet("all_subjects")]
    public ActionResult<IEnumerable<Subject>> GetAllSubjects()
    {
        var subjects = subjectRepository.GetAll().ToList();
        return Ok(subjects);
    }

    /// <summary>
    /// Query 2: Retrieve information about all students in a specified class by its identifier, sorted by full name
    /// </summary>
    /// <param name="classId">Class identifier</param>
    [HttpGet("students_in_class")]
    public ActionResult<IEnumerable<Student>> GetStudentsInClass(int classId)
    {
        var students = studentRepository.GetAll()
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
    [HttpGet("students_by_date")]
    public ActionResult<IEnumerable<StudentGradesDto>> GetStudentsByDate(DateOnly date)
    {
        var studentsWithGrades = gradeRepository.GetAll()
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
    [HttpGet("top_5_students_by_average")]
    public ActionResult<IEnumerable<StudentAverageGradeDto>> GetTop5StudentsByAverage()
    {
        var topStudents = studentRepository.GetAll()
            .Select(student => new StudentAverageGradeDto
            {
                StudentId = student.Id,
                Surname = student.Surname,
                Name = student.Name,
                Patronymic = student.Patronymic,
                AverageGrade = gradeRepository.GetAll()
                    .Where(grade => grade.Student.Id == student.Id)
                    .Average(grade => (int)grade.GradeValue)
            })
            .OrderByDescending(student => student.AverageGrade)
            .Take(5)
            .ToList();

        return Ok(topStudents);
    }

    /// <summary>
    /// Query 5: Retrieve students with the highest average grade over a specified period
    /// </summary>
    /// <param name="startDate">Start date of the period</param>
    /// <param name="endDate">End date of the period</param>
    [HttpGet("students_with_max_average_by_period")]
    public ActionResult<IEnumerable<StudentAverageGradeDto>> GetStudentsWithMaxAverageByPeriod(DateOnly startDate, DateOnly endDate)
    {
        var studentAverages = studentRepository.GetAll()
            .Select(student => new
            {
                Student = student,
                AverageGrade = gradeRepository.GetAll()
                    .Where(grade => grade.Student.Id == student.Id && grade.Date >= startDate && grade.Date <= endDate)
                    .Average(grade => (int)grade.GradeValue)
            })
            .ToList();

        var maxAverage = studentAverages.Max(x => x.AverageGrade);
        var topStudents = studentAverages
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
    [HttpGet("subject_grades_statistics")]
    public ActionResult<IEnumerable<SubjectGradeStatisticsDto>> GetSubjectGradesStatistics()
    {
        var subjectStatistics = subjectRepository.GetAll()
            .Select(subject => new SubjectGradeStatisticsDto
            {
                SubjectName = subject.Name,
                MinGrade = gradeRepository.GetAll()
                    .Where(grade => grade.Subject.Id == subject.Id)
                    .Min(grade => (int)grade.GradeValue),
                MaxGrade = gradeRepository.GetAll()
                    .Where(grade => grade.Subject.Id == subject.Id)
                    .Max(grade => (int)grade.GradeValue),
                AverageGrade = gradeRepository.GetAll()
                    .Where(grade => grade.Subject.Id == subject.Id)
                    .Average(grade => (int)grade.GradeValue)
            })
            .ToList();

        return Ok(subjectStatistics);
    }
}
