using Microsoft.AspNetCore.Mvc;
using ElectronicDiary.Domain;
using ElectronicDiary.Domain.Repositories;
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
    public async Task<ActionResult<IEnumerable<Class>>> Get()
    {
        var classes = await repository.GetAll();

        return Ok(classes);
    }

    /// <summary>
    /// Get class wiht such index
    /// </summary>
    /// <param name="id">Indev of needed class</param>
    /// <returns>class and http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Class>> Get(int id)
    {
        var classVal = await repository.Get(id);

        if (classVal == null) return NotFound();

        return Ok(classVal);
    }

    /// <summary>
    /// Add class in collection
    /// </summary>
    /// <param name="value">Exemplar of class which needed to be add in collection</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClassDto value)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var classVal = mapper.Map<Class>(value);
        await repository.Post(classVal);
        return Ok();
    }

    /// <summary>
    /// Replace class with such index in collection 
    /// </summary>
    /// <param name="value">New exemplar of class that we are replacing the old one with</param>
    /// <param name="id">Index of replacing class</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ClassDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id < 0) return BadRequest();
        
        var checkClass = await repository.Get(id);
        if (checkClass == null) return BadRequest();

        var classVal = mapper.Map<Class>(value);
        classVal.Id = id;
        
        await repository.Put(classVal, id);

        return Ok();
    }

    /// <summary>
    /// Delete class with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting class</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 0) return BadRequest();

        await repository.Delete(id);

        return Ok();
    }
}
