using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain;
using ElectronicDiary.Domain.Repositories;
using Newtonsoft.Json.Linq;
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
    public ActionResult<IEnumerable<Student>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Get student wiht such index
    /// </summary>
    /// <param name="id">Indev of needed student</param>
    /// <returns>grade and http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
        var student = repository.Get(id);

        if (student == null) {
            return NotFound();
        }

        return Ok(student);
    }

    /// <summary>
    /// Add student in collection
    /// </summary>
    /// <param name="value">Exemplar of student which needed to be add in collection</param>
    [HttpPost]
    public IActionResult Post([FromBody] StudentDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var student = mapper.Map<Student>(value);

        var classVal = classRepository.Get(value.ClassId);
        if (classVal == null) return NotFound("Class not found");
        student.Class = classVal;

        repository.Post(student);

        return Ok();
    }

    /// <summary>
    /// Replace student with such index in collection 
    /// </summary>
    /// <param name="value">New exemplar of student that we are replacing the old one with</param>
    /// <param name="id">Index of replacing student</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] StudentDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var student = mapper.Map<Student>(value);

        student.Id = id;

        var classVal = classRepository.Get(value.ClassId);
        if (classVal == null) return NotFound("Class not found");
        student.Class = classVal;

        if (!repository.Put(student, id)) return NotFound();

        return Ok();
    }

    /// <summary>
    /// Delete student with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting student</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
