using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Persona
    {
        public int ID { get; set; }
        [Required]
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        [Required(ErrorMessage="Se Necesita numero de DPI")]
        public int DPI { get; set; }
        public String Ciudad { get; set; }

    }
}