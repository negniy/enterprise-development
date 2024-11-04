namespace Server.DTO;

/// <summary>
/// DTO for representing a student's average grade
/// </summary>
public class StudentAverageGradeDto
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
    /// Student's average grade
    /// </summary>
    public double AverageGrade { get; set; }
}
