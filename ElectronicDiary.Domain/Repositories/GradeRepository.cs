namespace ElectronicDiary.Domain.Repositories;

public class GradeRepository : IRepository<Grade, int>
{
    private readonly List<Grade> _grades = [];
    private int _id = 1;

    public bool Delete(int id)
    {
        var value = Get(id);

        if (value != null)
        {
            _grades.Remove(value);
            return true;
        }
        return false;
    }

    public Grade? Get(int id) => _grades.Find(s => s.Id == id);

    public IEnumerable<Grade> GetAll() => _grades;

    public void Post(Grade obj)
    {
        var grade = obj;
        grade.Id = _id++;
        _grades.Add(grade);
    }

    public bool Put(Grade obj, int id)
    {
        var oldValue = Get(id);
        if (oldValue != null)
        {
            oldValue.Subject = obj.Subject;
            oldValue.Student = obj.Student;
            oldValue.Date = obj.Date;
            oldValue.GradeValue = obj.GradeValue;
            return true;
        }
        return false;
    }
}
