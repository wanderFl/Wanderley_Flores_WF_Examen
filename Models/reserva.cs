using System;
using System.ComponentModel.DataAnnotations;

namespace Wanderley_Flores_WF_Examen.Models
{
    public class reserva
    {
        [Key]
        public int dias { get; set; }
        [Required]
        public String nombre { get; set; }
        [VerificarRango]
        public decimal Precio { get; set; }
        [MaxLength(100)]
        public String apellido { get; set; }
        [MaxLength(100)]
        public String reservar { get; set; }
    }
    public class VerificarRango: ValidationAttribute {
        public override bool IsValid(object? value)
        {
            decimal valor =(decimal)value;
            if (valor < 10)
            {
                return false;
            }
            return true;
        }
        
        

    }
}
