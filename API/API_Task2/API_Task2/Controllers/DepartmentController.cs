using API_Task2.Data;
using API_Task2.Dto;
using API_Task2.Interfaces;
using API_Task2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Task2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DepartmentController(ApplicationDbContext dbContext, IMapper mapper, IGenericRepository<Department> departmentRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromForm] DepartmentDto departmentDto, CancellationToken cancellationToken)
    {
        var department = mapper.Map<Department>(departmentDto);
        departmentRepository.Add(department);
        await dbContext.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetDepartmentById), new { id = department.DepartmentId }, department);
    }

    [HttpGet]
    public IActionResult GetDepartments([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
    {
        var departments = departmentRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok(departments);
    }

    [HttpGet("get-by-id")]
    public IActionResult GetDepartmentById(int id)
    {
        var department = departmentRepository.GetById(id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteDepartment(int id)
    {
        var department = departmentRepository.GetById(id);
        if (department == null)
        {
            return NotFound();
        }

        departmentRepository.Delete(department);
        dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateDepartment(int id, Department updatedDepartment)
    {
        var department = departmentRepository.GetById(id);
        if (department == null)
        {
            return NotFound();
        }

        department.Name = updatedDepartment.Name;
        department.Location = updatedDepartment.Location;

        departmentRepository.Update(department);
        dbContext.SaveChanges();
        return NoContent();
    }
}