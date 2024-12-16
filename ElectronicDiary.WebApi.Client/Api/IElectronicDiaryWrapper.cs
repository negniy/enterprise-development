namespace ElectronicDiary.WebApi.Client.Api;

using System.Collections.Generic;
using System.Threading.Tasks;
public interface IElectronicDiaryWrapper
{
    Task CreateStudent(StudentDto newClass);
    Task UpdateStudent(int id, StudentDto updatedClass);
    Task DeleteStudent(int id);
    Task<Student> GetStudent(int id);
    Task<IEnumerable<Student>> GetAllStudents();

    Task CreateSubject(SubjectDto newClass);
    Task UpdateSubject(int id, SubjectDto updatedClass);
    Task DeleteSubject(int id);
    Task<Subject> GetSubject(int id);
    Task<IEnumerable<Subject>> GetAllSubjects();

    Task CreateClass(ClassDto newClass);
    Task UpdateClass(int id, ClassDto updatedClass);
    Task DeleteClass(int id);
    Task<Class> GetClass(int id);
    Task<IEnumerable<Class>> GetAllClasses();

    Task CreateGrade(GradeDto newGrade);
    Task UpdateGrade(int id, GradeDto updatedGrade);
    Task DeleteGrade(int id);
    Task<Grade> GetGrade(int id);
    Task<IEnumerable<Grade>> GetAllGrades();

    Task<IEnumerable<Subject>> GetAllSubjectsQuery();
    Task<IEnumerable<Student>> GetStudentsInClass(int classId);
    Task<IEnumerable<StudentGradesDto>> GetStudentsByDate(System.DateOnly date);
    Task<IEnumerable<StudentAverageGradeDto>> GetTop5StudentsByAverage();
    Task<IEnumerable<StudentAverageGradeDto>> GetStudentsWithMaxAverageByPeriod(System.DateOnly startDate, System.DateOnly endDate);
    Task<IEnumerable<SubjectGradeStatisticsDto>> GetSubjectGradesStatistics();
}