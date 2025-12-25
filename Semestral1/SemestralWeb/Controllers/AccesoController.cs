using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using SemestralWeb.Models;

namespace SemestralWeb.Controllers
{
    public class AccesoController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            string apiUrl = "https://localhost:44316/api/login"; // CAMBIA EL PUERTO
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new { Email = email, Password = password });
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var usuario = new JavaScriptSerializer().Deserialize<UsuarioSesion>(result);

                    Session["Usuario"] = usuario;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                ViewBag.Error = "Credenciales incorrectas";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login");
        }
    }
}