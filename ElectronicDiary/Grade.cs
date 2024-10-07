namespace ElectronicDiary.Domain;

public class Grade
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    public required Subject IdSubject { get; set; }
    /// <summary>
    /// Идентификатор ученика
    /// </summary>
    public required Student IdStudent { get; set; }
    /// <summary>
    /// Оценка
    /// </summary>
    public required GradesTypes GradeValue { get; set; }
    /// <summary>
    /// Дата получения
    /// </summary>
    public required DateOnly Date { get; set; }
}
