using System.ComponentModel.DataAnnotations;

namespace Server.DTO;

public class SubjectDto
{
    /// <summary>
    /// Название предмета
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Год обучения
    /// </summary>
    [RegularExpression(@"\d\d\d\d-\d\d\d\d")]
    public required string StudyYear { get; set; }
}
