using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Pago
    {
        public int PagoId { get; set; }
        public string NumeroConsecutivo { get; set; }
        public string ConceptoPago { get; set; }
        public decimal Importe { get; set; }
        public DateTime FechaPago { get; set; }

        public int AlumnoId { get; set; }
        public virtual Alumno Alumno { get; set; }
    }


}