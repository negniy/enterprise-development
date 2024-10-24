using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain;
using ElectronicDiary.Domain.Repositories;
using Newtonsoft.Json.Linq;
using AutoMapper;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController(IRepository<Class, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Returned list of all classes
    /// </summary>
    /// <returns>List of all classes and http status</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Class>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Get class wiht such index
    /// </summary>
    /// <param name="id">Indev of needed class</param>
    /// <returns>class and http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Class> Get(int id)
    {
        var student = repository.Get(id);

        if (student == null) {
            return NotFound();
        }

        return Ok(student);
    }

    /// <summary>
    /// Add class in collection
    /// </summary>
    /// <param name="value">Exemplar of class which needed to be add in collection</param>
    [HttpPost]
    public IActionResult Post([FromBody] ClassDto value)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var classVal = mapper.Map<Class>(value);
        repository.Post(classVal);
        return Ok();
    }

    /// <summary>
    /// Replace class with such index in collection 
    /// </summary>
    /// <param name="value">New exemplar of class that we are replacing the old one with</param>
    /// <param name="id">Index of replacing class</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClassDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var classVal = mapper.Map<Class>(value);
        classVal.Id = id;
        if (!repository.Put(classVal, id)) return NotFound();
        return Ok();
    }

    /// <summary>
    /// Delete class with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting class</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
