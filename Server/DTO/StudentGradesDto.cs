using ElectronicDiary.Domain;

namespace Server.DTO;

/// <summary>
/// DTO for representing information about a student's grades on a specific day
/// </summary>
public class StudentGradesDto
{
    /// <summary>
    /// Student's identifier
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// Student's surname
    /// </summary>
    public required string Surname { get; set; }

    /// <summary>
    /// Student's first name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Student's patronymic
    /// </summary>
    public required string Patronymic { get; set; }

    /// <summary>
    /// Name of the subject for which the grade was received
    /// </summary>
    public required string Subject { get; set; }

    /// <summary>
    /// Student's grade value
    /// </summary>
    public GradeType Grade { get; set; }

    /// <summary>
    /// Date when the grade was received
    /// </summary>
    public DateOnly Date { get; set; }
}
