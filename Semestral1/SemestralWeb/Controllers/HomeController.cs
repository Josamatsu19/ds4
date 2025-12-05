using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using SemestralWeb.Models;

namespace SemestralWeb.Controllers
{
    public class HomeController : Controller
    {
        string baseUrl = "https://localhost:44316/api/"; 

        private T LlamarApi<T>(string endpoint)
        {
            var request = (HttpWebRequest)WebRequest.Create(baseUrl + endpoint);
            request.Method = "GET";
            request.ContentType = "application/json";
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return new JavaScriptSerializer().Deserialize<T>(reader.ReadToEnd());
            }
        }

        private void LlamarApiAccion(string endpoint, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(baseUrl + endpoint);
            request.Method = method;
            request.ContentLength = 0;
            request.GetResponse();
        }

        public ActionResult Index()
        {
            if (Session["Usuario"] == null) return RedirectToAction("Login", "Acceso");
            var usuario = (UsuarioSesion)Session["Usuario"];

            ViewBag.Populares = LlamarApi<List<RecetaVista>>("recetas?populares=true");

            ViewBag.MisRecetas = LlamarApi<List<RecetaVista>>($"recetas?usuarioId={usuario.Id}");

            ViewBag.Favoritos = LlamarApi<List<RecetaVista>>($"favoritos/{usuario.Id}");

            ViewBag.Reporte = LlamarApi<List<object>>("reportes/ingredientes");

            return View();
        }

        public ActionResult Crear() { return View(); }

        [HttpPost]
        public ActionResult Crear(string nombre, string instrucciones, int porciones)
        {
            var usuario = (UsuarioSesion)Session["Usuario"];
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "recetas/crear");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    Nombre = nombre,
                    Instrucciones = instrucciones,
                    Porciones = porciones
                });
                streamWriter.Write(json);
            }
            httpWebRequest.GetResponse();
            return RedirectToAction("Index");
        }

        // Agregar a Favoritos
        public ActionResult AgregarFavorito(int id)
        {
            var usuario = (UsuarioSesion)Session["Usuario"];
            LlamarApiAccion($"favoritos/agregar?usuarioId={usuario.Id}&recetaId={id}", "POST");
            return RedirectToAction("Index");
        }

        // Borrar Receta
        public ActionResult Borrar(int id)
        {
            LlamarApiAccion($"recetas/{id}", "DELETE");
            return RedirectToAction("Index");
        }

        public class ResultadoCalculo
        {
            public string Nombre { get; set; }
            public decimal CantidadNueva { get; set; }
            public string Unidad { get; set; }
        }

        [HttpGet]
        public ActionResult Calcular(int id)
        {
            ViewBag.RecetaId = id;
            ViewBag.Personas = 1; 
            return View(new List<ResultadoCalculo>());
        }

        [HttpPost]
        public ActionResult Calcular(int id, int personas)
        {
            ViewBag.RecetaId = id;
            ViewBag.Personas = personas;

            List<ResultadoCalculo> ingredientes = new List<ResultadoCalculo>();

            try
            {
                string endpoint = $"recetas/calcular?id={id}&nuevasPorciones={personas}";

                ingredientes = LlamarApi<List<ResultadoCalculo>>(endpoint);
            }
            catch
            {
                ViewBag.Error = "No se pudo conectar al servidor de cálculo.";
            }

            return View(ingredientes);
        }

    }
}