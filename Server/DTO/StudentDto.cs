using ElectronicDiary.Domain;

namespace Server.DTO;

public class StudentDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public required string Surname { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    public required string Patronymic { get; set; }
    /// <summary>
    /// Идентификатор класса
    /// </summary>
    public required int ClassId { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public required DateOnly Birthday { get; set; }
    /// <summary>
    /// Паспорт
    /// </summary>
    public required string Passport { get; set; }
}
