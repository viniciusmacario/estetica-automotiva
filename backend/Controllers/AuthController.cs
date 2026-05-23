using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);

        await _context.SaveChangesAsync();

        return Ok(usuario);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(Usuario login)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(x =>
                x.Email == login.Email &&
                x.Senha == login.Senha);

        if (usuario == null)
            return Unauthorized("Usuário inválido");

        var tokenHandler = new JwtSecurityTokenHandler();

        var chave =
            Encoding.ASCII.GetBytes(
    "MINHA_CHAVE_SUPER_SECRETA_JWT_2026_ESTETICA_AUTOMOTIVA");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Email)
            }),

            Expires = DateTime.UtcNow.AddHours(2),

            SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(chave),
                    SecurityAlgorithms.HmacSha256Signature)
        };

        var token =
            tokenHandler.CreateToken(tokenDescriptor);

        return Ok(new
        {
            token = tokenHandler.WriteToken(token)
        });
    }
}