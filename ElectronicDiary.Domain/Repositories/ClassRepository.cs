namespace ElectronicDiary.Domain.Repositories;

public class ClassRepository : IRepository<Class, int>
{
    private readonly List<Class> _classes = [];
    private int _id = 1;

    public bool Delete(int id)
    {
        var value = Get(id);

        if (value != null)
        {
            _classes.Remove(value);
            return true;
        }
        return false;
    }

    public Class? Get(int id) => _classes.Find(s => s.Id == id);

    public IEnumerable<Class> GetAll() => _classes;

    public void Post(Class obj)
    {
        var classVal = obj;
        classVal.Id = _id++;
        _classes.Add(classVal);
    }

    public bool Put(Class obj, int id)
    {
        var oldValue = Get(id);
        if (oldValue != null)
        {
            oldValue.Number = obj.Number;
            oldValue.Letters = obj.Letters;
            return true;
        }
        return false;
    }
}
