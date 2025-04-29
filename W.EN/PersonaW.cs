using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W.EN
{
    public class PersonaW
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "El Nombre es obligatorio ")]
        [MaxLength(50)]

        public string NombreW { get; set; }

        public string ApellidoW { get; set; }

        public DateTime FechaNacimientoW { get; set; }

        public decimal SueldoW { get; set; }

        public byte EstatusW { get; set; }

        public string? ComentarioW  { get; set; }
    }
    //bhhikan
}
