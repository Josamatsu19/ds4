using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using SemestralWeb.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

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

            try
            {
                ViewBag.Populares = LlamarApi<List<RecetaVista>>("recetas?populares=true");
                ViewBag.MisRecetas = LlamarApi<List<RecetaVista>>($"recetas?usuarioId={usuario.Id}");
                ViewBag.Favoritos = LlamarApi<List<RecetaVista>>($"favoritos/{usuario.Id}");
                ViewBag.Reporte = LlamarApi<List<object>>("reportes/ingredientes");
            }
            catch
            {
                // Evita que la página se rompa si el API está apagado
                ViewBag.Error = "No se pudo conectar al API.";
                ViewBag.Populares = new List<RecetaVista>();
                ViewBag.MisRecetas = new List<RecetaVista>();
                ViewBag.Favoritos = new List<RecetaVista>();
                ViewBag.Reporte = new List<object>();
            }

            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(RecetaVista modelo)
        {
            if (Session["Usuario"] == null) return RedirectToAction("Login", "Acceso");
            var usuario = (UsuarioSesion)Session["Usuario"];

            // Bypass de certificado SSL para desarrollo
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            using (var client = new HttpClient(handler))
            {
                string urlBaseLimpia = baseUrl.Replace("api/", "");
                client.BaseAddress = new Uri(urlBaseLimpia);

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var json = new JavaScriptSerializer().Serialize(modelo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Enviamos los datos al API
                var resp = await client.PostAsync("api/recetas/crear", content);
                resp.EnsureSuccessStatusCode();
            }

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

        // 1. GET: Carga la vista con instrucciones pero tabla vacía
        [HttpGet]
        public ActionResult Calcular(int id)
        {
            // 1. Traer datos de la receta (Nombre, Instrucciones)
            var receta = LlamarApi<RecetaVista>($"recetas/detalle/{id}");

            // 2. Preparar el modelo
            var modelo = new RecetaDetalleViewModel
            {
                Receta = receta,
                Ingredientes = new List<ResultadoCalculo>(),
                PersonasInput = receta.Porciones
            };

            return View(modelo);
        }

        // 2. POST: Carga instrucciones Y calcula ingredientes
        [HttpPost]
        public ActionResult Calcular(int id, int personas)
        {
            // 1. Traer datos de la receta otra vez
            var receta = LlamarApi<RecetaVista>($"recetas/detalle/{id}");

            // 2. Calcular ingredientes
            List<ResultadoCalculo> ingredientesCalc = new List<ResultadoCalculo>();
            try
            {
                string endpoint = $"recetas/calcular?id={id}&nuevasPorciones={personas}";
                ingredientesCalc = LlamarApi<List<ResultadoCalculo>>(endpoint);
            }
            catch { ViewBag.Error = "Error al calcular."; }

            // 3. Empaquetar todo
            var modelo = new RecetaDetalleViewModel
            {
                Receta = receta,
                Ingredientes = ingredientesCalc,
                PersonasInput = personas
            };

            return View(modelo);
        }
    }
}