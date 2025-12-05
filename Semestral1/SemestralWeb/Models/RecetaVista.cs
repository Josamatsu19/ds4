namespace SemestralWeb.Models
{
    public class RecetaVista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Instrucciones { get; set; }
        public int Porciones { get; set; }
    }

    public class UsuarioSesion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}