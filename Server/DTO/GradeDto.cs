using ElectronicDiary.Domain;
using System.ComponentModel.DataAnnotations;

namespace Server.DTO;

public class GradeDto
{
    /// <summary>
    /// Предмет
    /// </summary>
    public required int SubjectId { get; set; }
    /// <summary>
    /// Ученик
    /// </summary>
    public required int StudentId { get; set; }
    /// <summary>
    /// Оценка
    /// </summary>
    [EnumDataType(typeof(GradeType))]
    public required int GradeValue { get; set; }
    /// <summary>
    /// Дата получения
    /// </summary>
    public required DateOnly Date { get; set; }
}
