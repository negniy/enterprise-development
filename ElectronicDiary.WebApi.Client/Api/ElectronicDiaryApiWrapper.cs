using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElectronicDiary.WebApi.Client.Api;

public class ElectronicDiaryApiWrapper(IConfiguration configuration) : IElectronicDiaryWrapper
{
    private readonly ElectronicDiaryApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());
    private readonly ElectronicDiaryApi1 _client1 = new(configuration["OpenApi:ServerUrl"], new HttpClient());
    private readonly ElectronicDiaryApi2 _client2 = new(configuration["OpenApi:ServerUrl"], new HttpClient());
    private readonly ElectronicDiaryApi3 _client3 = new(configuration["OpenApi:ServerUrl"], new HttpClient());
    private readonly ElectronicDiaryApi4 _client4 = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task CreateStudent(StudentDto newStudent) => await _client.StudentPOSTAsync(newStudent);
    public async Task UpdateStudent(int id, StudentDto updatedStudent) => await _client.StudentPUTAsync(id, updatedStudent);
    public async Task DeleteStudent(int id) => await _client.StudentDELETEAsync(id);
    public async Task<Student> GetStudent(int id) => await _client.StudentGETAsync(id);
    public async Task<IEnumerable<Student>> GetAllStudents() => await _client.StudentAllAsync();

    public async Task CreateSubject(SubjectDto newSubject) => await _client.SubjectPOSTAsync(newSubject);
    public async Task UpdateSubject(int id, SubjectDto updatedSubject) => await _client.SubjectPUTAsync(id, updatedSubject);
    public async Task DeleteSubject(int id) => await _client.SubjectDELETEAsync(id);
    public async Task<Subject> GetSubject(int id) => await _client.SubjectGETAsync(id);
    public async Task<IEnumerable<Subject>> GetAllSubjects() => await _client.SubjectAllAsync();

    public async Task CreateClass(ClassDto newClass) => await _client.ClassPOSTAsync(newClass);
    public async Task UpdateClass(int id, ClassDto updatedClass) => await _client.ClassPUTAsync(id, updatedClass);
    public async Task DeleteClass(int id) => await _client.ClassDELETEAsync(id);
    public async Task<Class> GetClass(int id) => await _client.ClassGETAsync(id);
    public async Task<IEnumerable<Class>> GetAllClasses() => await _client.ClassAllAsync();

    public async Task CreateGrade(GradeDto newGrade) => await _client.GradePOSTAsync(newGrade);
    public async Task UpdateGrade(int id, GradeDto updatedGrade) => await _client.GradePUTAsync(id, updatedGrade);
    public async Task DeleteGrade(int id) => await _client.GradeDELETEAsync(id);
    public async Task<Grade> GetGrade(int id) => await _client.GradeGETAsync(id);
    public async Task<IEnumerable<Grade>> GetAllGrades() => await _client.GradeAllAsync();

    public async Task<IEnumerable<Subject>> GetAllSubjectsQuery() => await _client1.SubjectsAsync();
    public async Task<IEnumerable<Student>> GetStudentsInClass(int classId) => await _client2.ClassAsync(classId);
    public async Task<IEnumerable<StudentGradesDto>> GetStudentsByDate(System.DateOnly date)
    {
        DateTime dt = date.ToDateTime(TimeOnly.MinValue);
        DateTimeOffset dto = new DateTimeOffset(dt, TimeSpan.Zero);
        return await _client3.DateAsync(dto);
    }
    public async Task<IEnumerable<StudentAverageGradeDto>> GetTop5StudentsByAverage() => await _client3.AverageAsync();
    public async Task<IEnumerable<StudentAverageGradeDto>> GetStudentsWithMaxAverageByPeriod(System.DateOnly startDate, System.DateOnly endDate)
    {
        DateTime sdt = startDate.ToDateTime(TimeOnly.MinValue);
        DateTimeOffset sdto = new DateTimeOffset(sdt, TimeSpan.Zero);

        DateTime edt = endDate.ToDateTime(TimeOnly.MinValue);
        DateTimeOffset edto = new DateTimeOffset(edt, TimeSpan.Zero);

        return await _client3.PeriodAsync(sdto, edto);
    }
    public async Task<IEnumerable<SubjectGradeStatisticsDto>> GetSubjectGradesStatistics() => await _client4.StatisticsAsync();
}
