using System.Collections.Generic;

namespace SemestralAPI.Models
{
    public class IngredienteDTO
    {
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; }
    }

    public class RecetaModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Instrucciones { get; set; }
        public int Porciones { get; set; }

        public List<IngredienteDTO> ListaIngredientes { get; set; }
    }
}