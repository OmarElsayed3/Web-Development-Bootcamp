using API_Task2.Data;
using API_Task2.Dto;
using API_Task2.Interfaces;
using API_Task2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Task2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DependentController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Dependent> dependentRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDependent([FromForm] DependentDto dependentDto, CancellationToken cancellationToken)
    {
        var dependent = mapper.Map<Dependent>(dependentDto);
        dependentRepository.Add(dependent);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetDependentById), new { id = dependent.DependentId }, dependent);
    }

    [HttpGet]
    public IActionResult GetDependents([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
    {
        var dependents = dependentRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok(dependents);
    }

    [HttpGet("get-by-id")]
    public IActionResult GetDependentById(int id)
    {
        var dependent = dependentRepository.GetById(id);
        if (dependent == null)
        {
            return NotFound();
        }

        return Ok(dependent);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteDependent(int id)
    {
        var dependent = dependentRepository.GetById(id);
        if (dependent == null)
        {
            return NotFound();
        }

        dependentRepository.Delete(dependent);
        context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateDependent(int id, DependentDto updatedDependentDto)
    {
        var dependent = dependentRepository.GetById(id);
        if (dependent == null)
        {
            return NotFound();
        }

        mapper.Map(updatedDependentDto, dependent);
        dependentRepository.Update(dependent);
        context.SaveChanges();
        return NoContent();
    }
}