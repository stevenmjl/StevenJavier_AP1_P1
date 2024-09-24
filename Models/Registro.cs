using System.ComponentModel.DataAnnotations;

namespace StevenJavier_AP1_P1.Models;

public class Registro
{
    [Key]
    public int RegistroId { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string? Nombre { get; set; }
}
