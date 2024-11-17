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
    public async Task<ActionResult<IEnumerable<Subject>>> Get()
    {
        var subjects = await repository.GetAll();
        return Ok(subjects);
    }

    /// <summary>
    /// Get subject with such index
    /// </summary>
    /// <param name="id">Index of needed subject</param>
    /// <returns>Subject and http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Subject>> Get(int id)
    {
        var subject = await repository.Get(id);

        if (subject == null) return NotFound();

        return Ok(subject);
    }

    /// <summary>
    /// Add subject to collection
    /// </summary>
    /// <param name="value">Exemplar of subject to add</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SubjectDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var subject = mapper.Map<Subject>(value);
        await repository.Post(subject);

        return Ok();
    }

    /// <summary>
    /// Replace subject with such index in collection
    /// </summary>
    /// <param name="id">Index of replacing subject</param>
    /// <param name="value">New exemplar of subject</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SubjectDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingSubject = await repository.Get(id);
        if (existingSubject == null) return NotFound();

        var subject = mapper.Map<Subject>(value);
        subject.Id = id;

        await repository.Put(subject, id);

        return Ok();
    }

    /// <summary>
    /// Delete subject with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting subject</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var subject = await repository.Get(id);
        if (subject == null) return NotFound();

        await repository.Delete(id);

        return Ok();
    }
}
