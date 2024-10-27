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
    [RegularExpression(@"\d{4}-\d{4}")]
    public required string StudyYear { get; set; }
}
