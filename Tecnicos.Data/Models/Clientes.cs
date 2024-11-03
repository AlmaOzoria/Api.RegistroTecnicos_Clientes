using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Data.Models;

public class Clientes
{
    [Key]

    [Required(ErrorMessage = "El Campo Cliente es obligatorio")]
    public int ClientesId { get; set; }

    [Required(ErrorMessage = "El Campo Nombre es obligatorio")]
    public string? Nombres { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El campo WhatsApp es obligatorio.")]
    public string? WhatsApp { get; set; }
}
