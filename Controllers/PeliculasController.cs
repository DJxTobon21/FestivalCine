using FestivalCine.Services;
using Microsoft.AspNetCore.Mvc;

namespace FestivalCine.Controllers;

public class PeliculasController : Controller
{
    private readonly FestivalService _servicio;

    public PeliculasController(FestivalService servicio)
    {
        _servicio = servicio;
    }

    public IActionResult Index()
    {
        return View(_servicio.ObtenerPeliculas());
    }
}