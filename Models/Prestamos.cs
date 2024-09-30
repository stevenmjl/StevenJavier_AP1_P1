using System.ComponentModel.DataAnnotations;

namespace StevenJavier_AP1_P1.Models;

public class Prestamos
{
    [Key]
    public int PrestamosId { get; set; }

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no debe exceder los 50 caracteres.")]
    public string? Deudor { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(1000, ErrorMessage = "La descripción no debe exceder los 1000 caracteres.")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "Debe escribir el monto de la deuda.")]
    [Range(1, 100000000, ErrorMessage = "La de debe estar entre 1 y 100,000,000.")]
    public double Monto { get; set; }
}