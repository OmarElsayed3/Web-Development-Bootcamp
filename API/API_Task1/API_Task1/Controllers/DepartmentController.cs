using API_Task1.Data;
using API_Task1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Task1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DepartmentController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll(CancellationToken cancellationToken)
    {
        var departments = await context.Departments.ToListAsync(cancellationToken);
        return Ok(mapper.Map<List<DepartmentDto>>(departments));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var department = await context.Departments.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        if (department == null)
            return NotFound();
        return Ok(mapper.Map<DepartmentDto>(department));
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentDto>> Create(DepartmentDto departmentDto,
        CancellationToken cancellationToken)
    {
        var department = mapper.Map<Department>(departmentDto);
        context.Departments.Add(department);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = department.Id }, mapper.Map<DepartmentDto>(department));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, DepartmentDto departmentDto, CancellationToken cancellationToken)
    {
        var department = await context.Departments.FindAsync(new object[] { id }, cancellationToken);
        if (department == null)
            return NotFound();

        mapper.Map(departmentDto, department);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var department = await context.Departments.FindAsync(new object[] { id }, cancellationToken);
        if (department == null)
            return NotFound();

        context.Departments.Remove(department);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}