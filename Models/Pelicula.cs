namespace FestivalCine.Models;

public class Pelicula
{
    public int Id { get; set; }
    public string Titulo { get; set; } = "";
    public string Director { get; set; } = "";
    public string Genero { get; set; } = "";
    public int DuracionMinutos { get; set; }
    public DateTime Funcion { get; set; }
    public decimal PrecioBoleto { get; set; }
}
