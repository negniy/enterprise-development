using ElectronicDiary.Domain;

namespace Server.DTO;

/// <summary>
/// DTO для представления информации об оценках ученика за определенный день
/// </summary>
public class StudentGradesDto
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
    public required string Patronymic { get; set; }

    /// <summary>
    /// Название предмета, по которому была получена оценка
    /// </summary>
    public required string Subject { get; set; }

    /// <summary>
    /// Значение оценки ученика
    /// </summary>
    public GradeType Grade { get; set; }

    /// <summary>
    /// Дата, когда была получена оценка
    /// </summary>
    public DateOnly Date { get; set; }
}