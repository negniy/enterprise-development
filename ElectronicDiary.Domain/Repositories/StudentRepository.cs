using System.Security.Cryptography;

namespace ElectronicDiary.Domain.Repositories;

public class StudentRepository : IRepository<Student, int>
{
    private readonly List<Student> _students = [];
    private int _id = 1;

    public bool Delete(int id)
    {
        var value = Get(id);

        if (value == null)
        { 
            return false;
        }
        _students.Remove(value);
        return true;
    }

    public Student? Get(int id) => _students.Find(s => s.Id == id);

    public IEnumerable<Student> GetAll() => _students;

    public void Post(Student obj)
    {
        obj.Id = _id++;
        _students.Add(obj);
    }

    public bool Put(Student obj, int id)
    {
        var oldValue = Get(id);
        if (oldValue == null)
        { 
            
            return false;
        }
        oldValue.Birthday = obj.Birthday;
        oldValue.Surname = obj.Surname;
        oldValue.Name = obj.Name;
        oldValue.Patronymic = obj.Patronymic;
        oldValue.Passport = obj.Passport;
        oldValue.Class = obj.Class;
        return true;
    }
}
