using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Domain.Repositories;

public class SubjectRepository(ElectronicDiaryDbContext context) : IRepository<Subject, int>
{
    public async Task Delete(int id)
    {
        var value = await Get(id);

        if (value != null)
        {
            context.Subjects.Remove(value);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Subject?> Get(int id) => await context.Subjects.FindAsync(id);

    public async Task<IEnumerable<Subject>> GetAll() => await context.Subjects.ToListAsync();

    public async Task Post(Subject obj)
    {
        await context.Subjects.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Put(Subject obj, int id)
    {
        var oldValue = await Get(id);

        if (oldValue != null)
        {
            oldValue.Name = obj.Name;
            oldValue.StudyYear = obj.StudyYear;

            context.Subjects.Update(oldValue);
            await context.SaveChangesAsync();
        }
    }
}
