using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    // Models/Alumno.cs
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaAlta { get; set; }

        public int CarreraId { get; set; }
        public virtual Carrera Carreras { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }


}