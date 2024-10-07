using ElectronicDiary.Domain;

namespace ElectronicDiary.Tests;

/// <summary>
/// Подготовка тестовых данных
/// </summary>
public class ElectronicDiaryFixture
{
    public List<Grade> GradesList;

    public ElectronicDiaryFixture()
    {
        // Инициализация данных из файла
        GradesList = ElectronicDiaryFileReader.ReadGrades(Path.Combine("Date", "data.csv"));
    }
}
