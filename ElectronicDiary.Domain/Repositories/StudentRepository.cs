using System.Security.Cryptography;

namespace ElectronicDiary.Domain.Repositories;

public class StudentRepository : IRepository<Student, int>
{
    private readonly List<Student> _students = [];
    private int _id = 1;

    public bool Delete(int id)
    {
        var value = Get(id);

        if (value != null) { 
            _students.Remove(value);
            return true;
        }
        return false;
    }

    public Student? Get(int id) => _students.Find(s => s.Id == id);

    public IEnumerable<Student> GetAll() => _students;

    public void Post(Student obj)
    {
        var student = obj;
        student.Id = _id++;
        _students.Add(student);
    }

    public bool Put(Student obj, int id)
    {
        var oldValue = Get(id);
        if (oldValue != null) { 
            oldValue.Birthday = obj.Birthday;
            oldValue.Surname = obj.Surname;
            oldValue.Name = obj.Name;
            oldValue.Patronymic = obj.Patronymic;
            oldValue.Passport = obj.Passport;
            oldValue.Class = obj.Class;
            return true;
        }
        return false;
    }
}
