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
    public required string StudyYear { get; set; }
}
