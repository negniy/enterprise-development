using System.Security.Cryptography;

namespace ElectronicDiary.Domain.Repositories;

public class SubjectRepository : IRepository<Subject, int>
{
    private readonly List<Subject> _subjects = [];
    private int _id = 1;

    public bool Delete(int id)
    {
        var value = Get(id);

        if (value != null)
        {
            _subjects.Remove(value);
            return true;
        }
        return false;
    }

    public Subject? Get(int id) => _subjects.Find(s => s.Id == id);

    public IEnumerable<Subject> GetAll() => _subjects;

    public void Post(Subject obj)
    {
        var subject = obj;
        subject.Id = _id++;
        _subjects.Add(subject);
    }

    public bool Put(Subject obj, int id)
    {
        var oldValue = Get(id);
        if (oldValue != null)
        {
            oldValue.Name = obj.Name;
            oldValue.StudyYear = obj.StudyYear;
            return true;
        }
        return false;
    }
}
