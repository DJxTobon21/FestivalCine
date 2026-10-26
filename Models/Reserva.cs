using System.ComponentModel.DataAnnotations;

namespace FestivalCine.Models;

public class Reserva
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(60)]
    [Display(Name = "Nombre del asistente")]
    public string NombreAsistente { get; set; } = "";

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo no válido")]
    public string Correo { get; set; } = "";

    [Required(ErrorMessage = "Selecciona una película")]
    public int PeliculaId { get; set; }

    [Range(1, 10, ErrorMessage = "Entre 1 y 10 boletos")]
    [Display(Name = "Cantidad de boletos")]
    public int CantidadBoletos { get; set; } = 1;

    public decimal Total { get; set; }
}