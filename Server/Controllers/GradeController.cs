using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain;
using ElectronicDiary.Domain.Repositories;
using Newtonsoft.Json.Linq;
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
    public ActionResult<IEnumerable<Grade>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Get grade wiht such index
    /// </summary>
    /// <param name="id">Indev of needed grade</param>
    /// <returns>grade and http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Grade> Get(int id)
    {
        var student = repository.Get(id);

        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    /// <summary>
    /// Add grade in collection
    /// </summary>
    /// <param name="value">Exemplar of grade which needed to be add in collection</param>
    [HttpPost]
    public IActionResult Post([FromBody] GradeDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var grade = mapper.Map<Grade>(value);

        var subject = subjectRepository.Get(value.SubjectId);
        if (subject == null) return NotFound("Subject not found");
        grade.Subject = subject;

        var student = studentRepository.Get(value.StudentId);
        if (student == null) return NotFound("Student not found");
        grade.Student = student;

        repository.Post(grade);

        return Ok();
    }

    /// <summary>
    /// Replace grade with such index in collection 
    /// </summary>
    /// <param name="value">New exemplar of grade that we are replacing the old one with</param>
    /// <param name="id">Index of replacing grade</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GradeDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var grade = mapper.Map<Grade>(value);

        grade.Id = id;

        var subject = subjectRepository.Get(value.SubjectId);
        if (subject == null) return NotFound("Subject not found");
        grade.Subject = subject;

        var student = studentRepository.Get(value.StudentId);
        if(student == null) return NotFound("Student not found");
        grade.Student = student;

        if (!repository.Put(grade, id)) return NotFound();

        return Ok();
    }

    /// <summary>
    /// Delete grade with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting grade</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
