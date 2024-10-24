using System.ComponentModel.DataAnnotations;

namespace Server.DTO;

public class ClassDto
{
    /// <summary>
    /// Номер
    /// </summary>
    [Range(1, 11)]
    public required int Number { get; set; }
    /// <summary>
    /// Литера
    /// </summary>
    [StringLength(6, MinimumLength = 1)]
    public required string Letters { get; set; }
}
