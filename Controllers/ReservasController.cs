using FestivalCine.Models;
using FestivalCine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FestivalCine.Controllers;

public class ReservasController : Controller
{
    private readonly FestivalService _servicio;

    public ReservasController(FestivalService servicio)
    {
        _servicio = servicio;
    }

    [HttpGet]
    public IActionResult Crear(int? peliculaId)
    {
        CargarPeliculas();
        return View(new Reserva { PeliculaId = peliculaId ?? 0 });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(Reserva reserva)
    {
        var pelicula = _servicio.ObtenerPelicula(reserva.PeliculaId);
        if (pelicula == null)
        {
            ModelState.AddModelError("PeliculaId", "La película no existe");
        }

        if (!ModelState.IsValid)
        {
            CargarPeliculas();
            return View(reserva);
        }

        var guardada = _servicio.AgregarReserva(reserva, pelicula!);
        return RedirectToAction(nameof(Confirmacion), new { id = guardada.Id });
    }

    public IActionResult Confirmacion(int id)
    {
        var reserva = _servicio.ObtenerReserva(id);
        if (reserva == null)
        {
            return NotFound();
        }

        ViewBag.Pelicula = _servicio.ObtenerPelicula(reserva.PeliculaId);
        return View(reserva);
    }

    private void CargarPeliculas()
    {
        ViewBag.Peliculas = new SelectList(_servicio.ObtenerPeliculas(), "Id", "Titulo");
    }
}