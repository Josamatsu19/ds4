using System.Collections.Generic;

namespace SemestralWeb.Models
{
    public class RecetaVista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Instrucciones { get; set; }
        public int Porciones { get; set; }
        public List<IngredienteDTO> ListaIngredientes { get; set; }
    }
    public class IngredienteDTO 
    {
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; }
    }
    public class UsuarioSesion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class RecetaDetalleViewModel
    {
        public RecetaVista Receta { get; set; } 
        public List<SemestralWeb.Controllers.HomeController.ResultadoCalculo> Ingredientes { get; set; }
        public int PersonasInput { get; set; }
    }
}