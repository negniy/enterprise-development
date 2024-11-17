using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain;
using ElectronicDiary.Domain.Repositories;
using AutoMapper;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController(IRepository<Grade, int> repository, IRepository<Subject, int> subjectRepository, IRepository<Student, int> studentRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Returned list of all grades
    /// </summary>
    /// <returns>List of all grades and http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Grade>>> Get()
    {
        var grades = await repository.GetAll();
        return Ok(grades);
    }

    /// <summary>
    /// Get grade with such index
    /// </summary>
    /// <param name="id">Index of needed grade</param>
    /// <returns>Grade and http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Grade>> Get(int id)
    {
        var grade = await repository.Get(id);
        if (grade == null) return NotFound();
        return Ok(grade);
    }

    /// <summary>
    /// Add grade to collection
    /// </summary>
    /// <param name="value">Exemplar of grade to add to collection</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GradeDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var grade = mapper.Map<Grade>(value);

        var subject = await subjectRepository.Get(value.SubjectId);
        if (subject == null) return NotFound("Subject not found");
        grade.Subject = subject;

        var student = await studentRepository.Get(value.StudentId);
        if (student == null) return NotFound("Student not found");
        grade.Student = student;

        await repository.Post(grade);

        return Ok();
    }

    /// <summary>
    /// Replace grade with such index in collection 
    /// </summary>
    /// <param name="value">New exemplar of grade to replace the old one</param>
    /// <param name="id">Index of replacing grade</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GradeDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingGrade = await repository.Get(id);
        if (existingGrade == null) return NotFound();

        var grade = mapper.Map<Grade>(value);
        grade.Id = id;

        var subject = await subjectRepository.Get(value.SubjectId);
        if (subject == null) return NotFound("Subject not found");
        grade.Subject = subject;

        var student = await studentRepository.Get(value.StudentId);
        if (student == null) return NotFound("Student not found");
        grade.Student = student;

        await repository.Put(grade, id);

        return Ok();
    }

    /// <summary>
    /// Delete grade with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting grade</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var grade = await repository.Get(id);
        if (grade == null) return NotFound();

        await repository.Delete(id);
        return Ok();
    }
}
