using API_Task1.Data;
using API_Task1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Task1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LoginController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoginDto>>> GetAll(CancellationToken cancellationToken)
    {
        var login = await context.Logins.ToListAsync(cancellationToken);
        return Ok(mapper.Map<List<LoginDto>>(login));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LoginDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var login = await context.Logins.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        if (login == null)
            return NotFound();
        return Ok(mapper.Map<LoginDto>(login));
    }

    [HttpPost]
    public async Task<ActionResult<LoginDto>> Post(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var login = mapper.Map<Login>(loginDto);
        context.Logins.Add(login);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = login.Id }, mapper.Map<LoginDto>(login));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, LoginDto loginDto, CancellationToken cancellationToken)
    {
        var login = await context.Logins.FindAsync(new object[] { id }, cancellationToken);
        if (login == null)
            return NotFound();

        mapper.Map(loginDto, login);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var login = await context.Logins.FindAsync(new object[] { id }, cancellationToken);
        if (login == null)
            return NotFound();
        
        context.Logins.Remove(login);
        await context.SaveChangesAsync(cancellationToken);
        
        return NoContent();
    }
}