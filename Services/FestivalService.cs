using FestivalCine.Models;

namespace FestivalCine.Services;

public class FestivalService
{
    private readonly List<Pelicula> _peliculas = new()
    {
        new() { Id = 1, Titulo = "Sombras del Alba", Director = "L. Restrepo", Genero = "Drama", DuracionMinutos = 112, Funcion = new DateTime(2026, 11, 12, 19, 0, 0), PrecioBoleto = 18000 },
        new() { Id = 2, Titulo = "Cumbia Espacial", Director = "M. Ocampo", Genero = "Ciencia ficción", DuracionMinutos = 98, Funcion = new DateTime(2026, 11, 13, 20, 30, 0), PrecioBoleto = 20000 },
        new() { Id = 3, Titulo = "El Último Proyector", Director = "A. Vélez", Genero = "Documental", DuracionMinutos = 75, Funcion = new DateTime(2026, 11, 14, 17, 0, 0), PrecioBoleto = 15000 },
    };

    private readonly List<Reserva> _reservas = new();

    public List<Pelicula> ObtenerPeliculas() => _peliculas;

    public Pelicula? ObtenerPelicula(int id) => _peliculas.FirstOrDefault(p => p.Id == id);

    public Reserva? ObtenerReserva(int id) => _reservas.FirstOrDefault(r => r.Id == id);

    public Reserva AgregarReserva(Reserva reserva, Pelicula pelicula)
    {
        reserva.Id = _reservas.Count + 1;
        reserva.Total = reserva.CantidadBoletos * pelicula.PrecioBoleto;
        _reservas.Add(reserva);
        return reserva;
    }
}