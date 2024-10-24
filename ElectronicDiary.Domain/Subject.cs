﻿namespace ElectronicDiary.Domain;

public class Subject
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Название предмета
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Год обучения
    /// </summary>
    public required string StudyYear { get; set; }
}
