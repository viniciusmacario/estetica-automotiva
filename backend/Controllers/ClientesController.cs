using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return NotFound();

        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Post(Cliente cliente)
    {
        _context.Clientes.Add(cliente);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById),
            new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cliente cliente)
    {
        if (id != cliente.Id)
            return BadRequest();

        _context.Entry(cliente).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return NotFound();

        _context.Clientes.Remove(cliente);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}