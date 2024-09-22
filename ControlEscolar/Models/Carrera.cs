using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Carrera
    {
        public int CarreraId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Alumno> Alumnos { get; set; }
    }

}