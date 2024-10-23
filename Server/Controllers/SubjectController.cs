using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain;
using ElectronicDiary.Domain.Repositories;
using AutoMapper;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController(IRepository<Subject, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Returned list of all subjects
    /// </summary>
    /// <returns>List of all subjects and http status</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Subject>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Get subject wiht such index
    /// </summary>
    /// <param name="id">Indev of needed subject</param>
    /// <returns>Subject and http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Subject> Get(int id)
    {
        var student = repository.Get(id);

        if (student == null) {
            return NotFound();
        }

        return Ok(student);
    }

    /// <summary>
    /// Add subject in collection
    /// </summary>
    /// <param name="value">Exampler which need to add</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] SubjectDto value)
    {
        var subject = mapper.Map<Subject>(value);
        repository.Post(subject);
        return Ok();
    }

    /// <summary>
    /// Replase 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SubjectDto value)
    {
        var subject = mapper.Map<Subject>(value);
        subject.Id = id;
        if (!repository.Put(subject, id)) return NotFound();
        return Ok();
    }

    /// <summary>
    /// Delete subject with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting subject</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
