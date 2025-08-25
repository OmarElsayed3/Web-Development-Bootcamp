using API_Task1.Data;
using API_Task1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Task1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RoleController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll(CancellationToken cancellationToken)
    {
        var roles = await context.Roles.ToListAsync(cancellationToken);
        return Ok(mapper.Map<List<RoleDto>>(roles));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        if (role == null)
            return NotFound();
        return Ok(mapper.Map<RoleDto>(role));
    }

    [HttpPost]
    public async Task<ActionResult<RoleDto>> Post(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = mapper.Map<Role>(roleDto);
        context.Roles.Add(role);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = role.Id }, mapper.Map<RoleDto>(role));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = await context.Roles.FindAsync(new object[] { id }, cancellationToken);
        if (role == null)
            return NotFound();

        mapper.Map(roleDto, role);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var role = await context.Roles.FindAsync(new object[] { id }, cancellationToken);
        if (role == null)
            return NotFound();
        
        context.Roles.Remove(role);
        await context.SaveChangesAsync(cancellationToken);
        
        return NoContent();
    }
    

}