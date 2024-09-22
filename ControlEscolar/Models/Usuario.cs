using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlEscolar.Models
{
    public class Usuario
    {
        [Key] // Define que esta es la clave primaria
        public int UsuarioId { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contrasena { get; set; }

        // Otras propiedades de la entidad...
    }


}