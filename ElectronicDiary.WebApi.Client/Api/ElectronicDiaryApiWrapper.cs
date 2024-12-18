using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElectronicDiary.WebApi.Client.Api;

public class ElectronicDiaryApiWrapper(IConfiguration configuration) : IElectronicDiaryWrapper
{
    private readonly ElectronicDiaryApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

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

    public async Task<IEnumerable<Subject>> GetAllSubjectsQuery() => await _client.AllSubjectsAsync();
    public async Task<IEnumerable<Student>> GetStudentsInClass(int classId) => await _client.StudentsInClassAsync(classId);
    public async Task<IEnumerable<StudentGradesDto>> GetStudentsByDate(System.DateOnly date)
    {
        var dt = date.ToDateTime(TimeOnly.MinValue);
        var dto = new DateTimeOffset(dt, TimeSpan.Zero);
        return await _client.StudentsByDateAsync(dto);
    }
    public async Task<IEnumerable<StudentAverageGradeDto>> GetTop5StudentsByAverage() => await _client.Top5StudentsByAverageAsync();
    public async Task<IEnumerable<StudentAverageGradeDto>> GetStudentsWithMaxAverageByPeriod(System.DateOnly startDate, System.DateOnly endDate)
    {
        var sdt = startDate.ToDateTime(TimeOnly.MinValue);
        var sdto = new DateTimeOffset(sdt, TimeSpan.Zero);

        var edt = endDate.ToDateTime(TimeOnly.MinValue);
        var edto = new DateTimeOffset(edt, TimeSpan.Zero);

        return await _client.StudentsWithMaxAverageByPeriodAsync(sdto, edto);
    }
    public async Task<IEnumerable<SubjectGradeStatisticsDto>> GetSubjectGradesStatistics() => await _client.SubjectGradesStatisticsAsync();
}
