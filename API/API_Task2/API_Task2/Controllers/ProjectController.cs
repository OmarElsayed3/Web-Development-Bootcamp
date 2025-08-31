using API_Task2.Data;
using API_Task2.Dto;
using API_Task2.Interfaces;
using API_Task2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Task2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Project> projectRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromForm] ProjectDto projectDto, CancellationToken cancellationToken)
    {
        var project = mapper.Map<Project>(projectDto);
        projectRepository.Add(project);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetProjectById), new { id = project.DepartmentId }, project);
    }

    [HttpGet]
    public IActionResult GetProjects([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
    {
        var projects = projectRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok(projects);
    }

    [HttpGet("get-by-id")]
    public IActionResult GetProjectById(int id)
    {
        var project = projectRepository.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
        
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProject(int id)
    {
        var project = projectRepository.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        projectRepository.Delete(project);
        context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateProject(int id, ProjectDto updatedProjectDto)
    {
        var project = projectRepository.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        mapper.Map(updatedProjectDto, project);
        projectRepository.Update(project);
        context.SaveChanges();
        return NoContent();
    }

}