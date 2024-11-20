using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Domain.Repositories;

public class ClassRepository(ElectronicDiaryDbContext context) : IRepository<Class, int>
{
    public async Task Delete(int id)
    {
        var value = await Get(id);

        if (value == null)
            return;

        context.Classes.Remove(value);
        await context.SaveChangesAsync();
    }

    public async Task<Class?> Get(int id) => await context.Classes.FindAsync(id);


    public async Task<IEnumerable<Class>> GetAll() => await context.Classes.ToListAsync();

    public async Task Post(Class obj)
    {
        await context.Classes.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Put(Class obj, int id)
    {
        var oldValue = await Get(id);
        if (oldValue == null)
            return;

        oldValue.Number = obj.Number;
        oldValue.Letters = obj.Letters;
        context.Classes.Update(oldValue);
        await context.SaveChangesAsync();
    }
}
