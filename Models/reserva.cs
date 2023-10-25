using System.ComponentModel.DataAnnotations;

namespace Wanderley_Flores_WF_Examen.Models
{
    public class reserva
    {
        [Key]
        public int dias { get; set; }
        [Required]
        public String nombre { get; set; }
        [Range(0.01, 9999.99)]
        public int precio { get; set; }
        public String apellido { get; set; }
    }
}
