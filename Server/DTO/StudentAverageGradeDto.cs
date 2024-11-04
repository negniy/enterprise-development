namespace Server.DTO;

/// <summary>
/// DTO для представления средней оценки ученика
/// </summary>
public class StudentAverageGradeDto
{
    /// <summary>
    /// Идентификатор ученика
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// Фамилия ученика
    /// </summary>
    public required string Surname { get; set; }

    /// <summary>
    /// Имя ученика
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Отчество ученика
    /// </summary>
    public  required string Patronymic { get; set; }

    /// <summary>
    /// Средний балл ученика
    /// </summary>
    public double AverageGrade { get; set; }
}
