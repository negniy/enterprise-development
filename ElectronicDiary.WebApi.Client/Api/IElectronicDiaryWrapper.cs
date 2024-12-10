namespace ElectronicDiary.WebApi.Client.Api;

using System.Collections.Generic;
using System.Threading.Tasks;
public interface IElectronicDiaryWrapper
{
    Task CreateClass(ClassDto newClass);
    Task UpdateClass(int id, ClassDto updatedClass);
    Task DeleteClass(int id);
    Task<Class> GetClass(int id);
    Task<IList<Class>> GetAllClasses();


    Task CreateStudent(StudentDto newStudent);
    Task UpdateStudent(int id, StudentDto updatedStudent);
    Task DeleteStudent(int id);
    Task<Student> GetStudent(int id);
    Task<IList<Student>> GetAllStudents();

    Task CreateSubject(SubjectDto newSubject);
    Task UpdateSubject(int id, SubjectDto updatedSubject);
    Task DeleteSubject(int id);
    Task<Subject> GetSubject(int id);
    Task<IList<Subject>> GetAllSubjects();

    Task CreateGrade(GradeDto newGrade);
    Task UpdateGrade(int id, GradeDto updatedGrade);
    Task DeleteGrade(int id);
    Task<Grade> GetGrade(int id);
    Task<IList<Grade>> GetAllGrades();

    Task<IList<SubjectDto>> GetAllSubjectsQuery();
    Task<IList<StudentDto>> GetStudentsInClass(int classId);
    Task<IList<StudentGradesDto>> GetStudentsByDate(System.DateOnly date);
    Task<IList<StudentAverageGradeDto>> GetTop5StudentsByAverage();
    Task<IList<StudentAverageGradeDto>> GetStudentsWithMaxAverageByPeriod(System.DateOnly startDate, System.DateOnly endDate);
    Task<IList<SubjectGradeStatisticsDto>> GetSubjectGradesStatistics();
}