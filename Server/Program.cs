using ElectronicDiary.Domain;
using ElectronicDiary.Domain.Repositories;
using ElectronicDiary.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:MySql"];

builder.Services.AddDbContext<ElectronicDiaryDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateConverter());
});
builder.Services.AddTransient<IRepository<Student, int>, StudentRepository>();
builder.Services.AddTransient<IRepository<Subject, int>, SubjectRepository>();
builder.Services.AddTransient<IRepository<Class, int>, ClassRepository>();
builder.Services.AddTransient<IRepository<Grade, int>, GradeRepository>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
