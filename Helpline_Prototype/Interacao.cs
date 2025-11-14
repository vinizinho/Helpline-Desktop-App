using System;

public class Interacao
{
    public int Id { get; set; }
    public int ChamadoId { get; set; }
    public string Texto { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public int UsuarioId { get; set; }
}