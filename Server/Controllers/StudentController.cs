using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain;
using ElectronicDiary.Domain.Repositories;
using AutoMapper;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IRepository<Student, int> repository, IRepository<Class, int> classRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Returned list of all students
    /// </summary>
    /// <returns>List of all students and http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> Get()
    {
        var students = await repository.GetAll();
        return Ok(students);
    }

    /// <summary>
    /// Get student with such index
    /// </summary>
    /// <param name="id">Index of needed student</param>
    /// <returns>Student and http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> Get(int id)
    {
        var student = await repository.Get(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    /// <summary>
    /// Add student to collection
    /// </summary>
    /// <param name="value">Exemplar of student to add</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var student = mapper.Map<Student>(value);

        var classVal = await classRepository.Get(value.ClassId);
        if (classVal == null) return NotFound("Class not found");
        student.Class = classVal;

        await repository.Post(student);

        return Ok();
    }

    /// <summary>
    /// Replace student with such index in collection 
    /// </summary>
    /// <param name="id">Index of replacing student</param>
    /// <param name="value">New exemplar of student</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StudentDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingStudent = await repository.Get(id);
        if (existingStudent == null) return NotFound();

        var student = mapper.Map<Student>(value);
        student.Id = id;

        var classVal = await classRepository.Get(value.ClassId);
        if (classVal == null) return NotFound("Class not found");
        student.Class = classVal;

        await repository.Put(student, id);

        return Ok();
    }

    /// <summary>
    /// Delete student with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting student</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await repository.Get(id);
        if (student == null) return NotFound();

        await repository.Delete(id);
        return Ok();
    }
}
