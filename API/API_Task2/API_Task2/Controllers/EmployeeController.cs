using API_Task2.Data;
using API_Task2.Dto;
using API_Task2.Interfaces;
using API_Task2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Task2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Employee> employeeRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromForm]EmployeeDto employeeDto, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Employee>(employeeDto);
        employeeRepository.Add(employee);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
    }
    [HttpGet]
    public IActionResult GetEmployee([FromQuery]int pageSize = 10, [FromQuery]int pageNumber = 1)
    {
        var employees = employeeRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok(employees);
    }

    [HttpGet("get-by-id")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
    
        employeeRepository.Delete(employee);
        context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateEmployee(int id, EmployeeDto updatedEmployee)
    {
        var employee = employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
    
        var newEmployee = mapper.Map(updatedEmployee, employee);
        employeeRepository.Update(newEmployee);
        context.SaveChanges();
    
        return Ok(employee);
    }
}