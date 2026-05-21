namespace backend.Models;

public class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Veiculo { get; set; } = null!;
}