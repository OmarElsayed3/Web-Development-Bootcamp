using API_Task1.Data;
using API_Task1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Task1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var employees = await context.Employees
            .Include(e => e.Department)
            .Include(e => e.Role)
            .ToListAsync(cancellationToken);

        return Ok(mapper.Map<List<EmployeeDto>>(employees));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var employee = await context.Employees
            .Include(e => e.Department)
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (employee == null)
            return NotFound();

        return Ok(mapper.Map<EmployeeDto>(employee));
    }
    
    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create(EmployeeDto employeeDto, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Employee>(employeeDto);
        context.Employees.Add(employee);
        await context.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, mapper.Map<EmployeeDto>(employee));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EmployeeDto employeeDto, CancellationToken cancellationToken)
    {
        var employee = await context.Employees.FindAsync(new object[] { id }, cancellationToken);
        if (employee == null)
            return NotFound();

        mapper.Map(employeeDto, employee);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var employee = await context.Employees.FindAsync(new object[] { id }, cancellationToken);
        if (employee == null)
            return NotFound();

        context.Employees.Remove(employee);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}