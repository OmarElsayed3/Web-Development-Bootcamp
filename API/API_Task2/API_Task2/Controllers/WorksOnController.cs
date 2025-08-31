using API_Task2.Data;
using API_Task2.Interfaces;
using API_Task2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Task2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorksOnController(ApplicationDbContext dbContext, IGenericRepository<WorksOn> worksOnRepository) : ControllerBase
{
    [HttpPost("assign")]
    public async Task<IActionResult> AssignEmployeeToProject([FromForm] int empId, [FromForm] int projectId, CancellationToken cancellationToken)
    {
        var worksOn = new WorksOn
        {
            EmployeeId = empId,
            ProjectId = projectId
        };
        worksOnRepository.Add(worksOn);
        await dbContext.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(AssignEmployeeToProject), new { id = worksOn.EmployeeId }, worksOn);
    }
    [HttpGet("employees-by-project")]
    public async Task<IActionResult> GetEmployeesByProjectId([FromQuery] int projectId,CancellationToken cancellationToken)
    {
        var employees = await dbContext.WorksOns
            .Include(wo => wo.Employee) 
            .Where(wo => wo.ProjectId == projectId)
            .Select(wo => wo.Employee.Name)
            .ToListAsync(cancellationToken);

        if (!employees.Any())
            return NotFound("No employees assigned to this project.");

        return Ok(employees);
    }
    [HttpDelete("unassign")]
    public IActionResult UnassignEmployeeFromProject([FromQuery] int empId, [FromQuery] int projectId)
    {
        var worksOn = worksOnRepository.GetAll()
            .FirstOrDefault(wo => wo.EmployeeId == empId && wo.ProjectId == projectId);
        if (worksOn == null)
        {
            return NotFound();
        }

        worksOnRepository.Delete(worksOn);
        dbContext.SaveChanges();
        return NoContent();
    }
}