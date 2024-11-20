using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Domain.Repositories;

public class StudentRepository(ElectronicDiaryDbContext context) : IRepository<Student, int>
{
    public async Task Delete(int id)
    {
        var value = await Get(id);

        if (value == null)
            return;

        context.Students.Remove(value);
        await context.SaveChangesAsync();
    }

    public async Task<Student?> Get(int id) => await context.Students.FindAsync(id);

    public async Task<IEnumerable<Student>> GetAll() => await context.Students.ToListAsync();

    public async Task Post(Student obj)
    {
        await context.Students.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Put(Student obj, int id)
    {
        var oldValue = await Get(id);
        if (oldValue == null)
            return;

        oldValue.Birthday = obj.Birthday;
        oldValue.Surname = obj.Surname;
        oldValue.Name = obj.Name;
        oldValue.Patronymic = obj.Patronymic;
        oldValue.Passport = obj.Passport;
        oldValue.Class = obj.Class;

        context.Students.Update(oldValue);
        await context.SaveChangesAsync();
    }
}
