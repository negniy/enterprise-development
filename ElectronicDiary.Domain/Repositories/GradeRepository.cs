using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Domain.Repositories;

public class GradeRepository(ElectronicDiaryDbContext context) : IRepository<Grade, int>
{
    public async Task Delete(int id)
    {
        var value = await Get(id);

        if (value == null)
            return;

        context.Grades.Remove(value);
        await context.SaveChangesAsync();
    }

    public async Task<Grade?> Get(int id) => await context.Grades.FindAsync(id);

    public async Task<IEnumerable<Grade>> GetAll() => await context.Grades.ToListAsync();

    public async Task Post(Grade obj)
    {
        await context.Grades.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Put(Grade obj, int id)
    {
        var oldValue = await Get(id);
        if (oldValue == null)
            return;

        oldValue.Subject = obj.Subject;
        oldValue.Student = obj.Student;
        oldValue.Date = obj.Date;
        oldValue.GradeValue = obj.GradeValue;

        context.Grades.Update(oldValue);
        await context.SaveChangesAsync();
    }
}
