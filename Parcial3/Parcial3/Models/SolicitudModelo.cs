using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial3.Models
{
    public class SolicitudModelo
    {
        public int IdSolicitante { get; set; }

        [Required]
        [Display(Name = "Cédula / DNI")]
        public string DNI { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; }

        public int IdSolicitud { get; set; }
        public string Estado { get; set; }

        [Display(Name = "Fecha Solicitud")]
        public DateTime FechaSolicitud { get; set; }
    }
}