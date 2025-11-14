using System;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; } // Armazene hash, não texto puro
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}