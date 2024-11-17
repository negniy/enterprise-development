using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Domain;

public class ElectronicDiaryDbContext(DbContextOptions<ElectronicDiaryDbContext> options) : DbContext(options)
{
    public DbSet<Class> Classes { get; set; }

    public DbSet<Grade> Grades { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Class>()
            .Property(c => c.Letters)
            .HasMaxLength(10)
            .IsRequired();

        modelBuilder.Entity<Class>()
            .Property(c => c.Number)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Class)
            .WithMany()
            .HasForeignKey(s => s.Class.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>()
            .Property(s => s.Passport)
            .HasMaxLength(100);

        modelBuilder.Entity<Student>()
            .Property(s => s.Name)
            .HasMaxLength(45)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.Surname)
            .HasMaxLength(45)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.Patronymic)
            .HasMaxLength(45);

        modelBuilder.Entity<Student>()
            .Property(s => s.Birthday)
            .IsRequired();

        modelBuilder.Entity<Subject>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Subject>()
            .Property(s => s.Name)
            .HasMaxLength(45)
            .IsRequired();

        modelBuilder.Entity<Subject>()
            .Property(s => s.StudyYear)
            .IsRequired();


        modelBuilder.Entity<Grade>()
            .HasKey(g => g.Id);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student)
            .WithMany()
            .HasForeignKey(g => g.Student.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Subject)
            .WithMany()
            .HasForeignKey(g => g.Subject.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Grade>()
            .Property(g => g.GradeValue)
            .IsRequired()
            .HasConversion(
                grade => (int)grade,
                grade => (GradeType)grade
            );

        modelBuilder.Entity<Grade>()
            .Property(g => g.Date)
            .IsRequired();
    }

}
