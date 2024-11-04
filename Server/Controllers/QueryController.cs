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
    /// Запрос 1: Вывести информацию обо всех предметах.
    /// </summary>
    [HttpGet("all_subjects")]
    public ActionResult<IEnumerable<Subject>> GetAllSubjects()
    {
        var subjects = subjectRepository.GetAll().ToList();
        return Ok(subjects);
    }

    /// <summary>
    /// Запрос 2: Вывести информацию обо всех учениках в указанном классе по его идентификатору, упорядочить по ФИО.
    /// </summary>
    /// <param name="classId">Идентификатор класса</param>
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
    /// Запрос 3: Вывести информацию обо всех учениках, получивших оценки в указанный день.
    /// </summary>
    /// <param name="date">Дата получения оценок</param>
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
    /// Запрос 4: Вывести топ 5 учеников по среднему баллу.
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
    /// Запрос 5: Вывести учеников с максимальным средним баллом за указанный период.
    /// </summary>
    /// <param name="startDate">Дата начала периода</param>
    /// <param name="endDate">Дата окончания периода</param>
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
    /// Запрос 6: Вывести информацию о минимальном, среднем и максимальном балле по каждому предмету.
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
