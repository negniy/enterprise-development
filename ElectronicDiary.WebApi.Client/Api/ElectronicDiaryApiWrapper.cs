using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElectronicDiary.WebApi.Client.Api;

public class ElectronicDiaryApiWrapper(IConfiguration configuration) : IElectronicDiaryWrapper
{
    private readonly ElectronicDiaryApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    // Classes
    public async Task CreateClass(ClassDto newClass) => await _client.ClassPOSTAsync(newClass);
    public async Task UpdateClass(int id, ClassDto updatedClass) => await _client.ClassPUTAsync(id, updatedClass);
    public async Task DeleteClass(int id) => await _client.ClassDELETEAsync(id);
    public async Task<Class> GetClass(int id) => await _client.ClassGETAsync(id);
    public async Task<IList<Class>> GetAllClasses() => (await _client.ClassAllAsync()).ToList();

    // Students
    public async Task CreateStudent(StudentDto newStudent) => await _client.StudentPOSTAsync(newStudent);
    public async Task UpdateStudent(int id, StudentDto updatedStudent) => await _client.StudentPUTAsync(id, updatedStudent);
    public async Task DeleteStudent(int id) => await _client.StudentDELETEAsync(id);
    public async Task<Student> GetStudent(int id) => await _client.StudentGETAsync(id);
    public async Task<IList<Student>> GetAllStudents() => (await _client.StudentAllAsync()).ToList();

    // Subjects
    public async Task CreateSubject(SubjectDto newSubject) => await _client.SubjectPOSTAsync(newSubject);
    public async Task UpdateSubject(int id, SubjectDto updatedSubject) => await _client.SubjectPUTAsync(id, updatedSubject);
    public async Task DeleteSubject(int id) => await _client.SubjectDELETEAsync(id);
    public async Task<Subject> GetSubject(int id) => await _client.SubjectGETAsync(id);
    public async Task<IList<Subject>> GetAllSubjects() => (await _client.SubjectAllAsync()).ToList();

    // Grades
    public async Task CreateGrade(GradeDto newGrade) => await _client.GradePOSTAsync(newGrade);
    public async Task UpdateGrade(int id, GradeDto updatedGrade) => await _client.GradePUTAsync(id, updatedGrade);
    public async Task DeleteGrade(int id) => await _client.GradeDELETEAsync(id);
    public async Task<Grade> GetGrade(int id) => await _client.GradeGETAsync(id);
    public async Task<IList<Grade>> GetAllGrades() => (await _client.GradeAllAsync()).ToList();

    // Queries
    public async Task<IList<SubjectDto>> GetAllSubjectsQuery() => (await _client.SubjectsAsync()).ToList();
    public async Task<IList<StudentDto>> GetStudentsInClass(int classId) => (await _client.ClassAsync(classId)).ToList();
    public async Task<IList<StudentGradesDto>> GetStudentsByDate(System.DateOnly date)
    {
        DateTime dt = date.ToDateTime(TimeOnly.MinValue);
        DateTimeOffset dto = new DateTimeOffset(dt, TimeSpan.Zero);
        return (await _client.DateAsync(dto)).ToList();
    }
    public async Task<IList<StudentAverageGradeDto>> GetTop5StudentsByAverage() => (await _client.AverageAsync()).ToList();
    public async Task<IList<StudentAverageGradeDto>> GetStudentsWithMaxAverageByPeriod(System.DateOnly startDate, System.DateOnly endDate)
    {
        DateTime sdt = startDate.ToDateTime(TimeOnly.MinValue);
        DateTimeOffset sdto = new DateTimeOffset(sdt, TimeSpan.Zero);

        DateTime edt = endDate.ToDateTime(TimeOnly.MinValue);
        DateTimeOffset edto = new DateTimeOffset(edt, TimeSpan.Zero);

        return (await _client.PeriodAsync(sdto, edto)).ToList();
    }
    public async Task<IList<SubjectGradeStatisticsDto>> GetSubjectGradesStatistics() => (await _client.StatisticsAsync()).ToList();
}
