using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServicosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Servico>>> Get()
    {
        return await _context.Servicos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Servico>> GetById(int id)
    {
        var servico = await _context.Servicos.FindAsync(id);

        if (servico == null)
            return NotFound();

        return servico;
    }

    [HttpPost]
    public async Task<ActionResult<Servico>> Post(Servico servico)
    {
        _context.Servicos.Add(servico);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById),
            new { id = servico.Id }, servico);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Servico servico)
    {
        if (id != servico.Id)
            return BadRequest();

        _context.Entry(servico).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var servico = await _context.Servicos.FindAsync(id);

        if (servico == null)
            return NotFound();

        _context.Servicos.Remove(servico);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}