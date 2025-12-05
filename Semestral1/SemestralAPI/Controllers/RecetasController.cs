using SemestralAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace SemestralAPI.Controllers
{
    public class RecetasController : ApiController
    {
        string cs = "Data Source=JOSELUNA;Initial Catalog=GestorRecetasDB;Integrated Security=True;";

        // LOGIN
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(LoginRequest login)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "SELECT Id, Nombre FROM Usuarios WHERE Email=@e AND Password=@p";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@e", login.Email);
                cmd.Parameters.AddWithValue("@p", login.Password);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read()) return Ok(new { Id = r["Id"], Nombre = r["Nombre"] });
                else return Unauthorized();
            }
        }

        // 2. OBTENER RECETAS
        [HttpGet]
        [Route("api/recetas")]
        public IHttpActionResult GetRecetas(int? usuarioId = null, bool populares = false)
        {
            List<RecetaModelo> lista = new List<RecetaModelo>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "SELECT TOP 10 * FROM Recetas"; 

                if (usuarioId != null) q = "SELECT * FROM Recetas WHERE UsuarioId = " + usuarioId;
                if (populares) q = "SELECT TOP 3 * FROM Recetas ORDER BY Id DESC"; 

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lista.Add(new RecetaModelo
                    {
                        Id = (int)r["Id"],
                        Nombre = r["Nombre"].ToString(),
                        Instrucciones = r["Instrucciones"].ToString(),
                        Porciones = (int)r["PorcionesBase"]
                    });
                }
            }
            return Ok(lista);
        }

        // 3. CALCULAR (Lógica matemática de porciones)
        [HttpGet]
        [Route("api/recetas/calcular")]
        public IHttpActionResult Calcular(int id, int nuevasPorciones)
        {
            List<IngredienteCalculado> lista = new List<IngredienteCalculado>();

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // Consulta SQL que une las 3 tablas para obtener:
                    // Nombre del ingrediente, Unidad, Cantidad Base y Porciones Base de la receta
                    string query = @"
                SELECT i.Nombre, i.UnidadMedida, ri.Cantidad, r.PorcionesBase
                FROM RecetaIngredientes ri
                JOIN Ingredientes i ON ri.IngredienteId = i.Id
                JOIN Recetas r ON ri.RecetaId = r.Id
                WHERE ri.RecetaId = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Recuperamos los datos crudos
                        decimal cantBase = Convert.ToDecimal(reader["Cantidad"]);
                        int porcionesBase = Convert.ToInt32(reader["PorcionesBase"]);

                        // Regla de tres: (CantidadBase / PorcionesOriginales) * NuevasPersonas
                        decimal cantNueva = (cantBase / porcionesBase) * nuevasPorciones;

                        lista.Add(new IngredienteCalculado
                        {
                            Nombre = reader["Nombre"].ToString(),
                            Unidad = reader["UnidadMedida"].ToString(),
                            CantidadOriginal = cantBase,
                            // Redondeamos a 2 decimales para que no salgan números locos
                            CantidadNueva = Math.Round(cantNueva, 2)
                        });
                    }
                }

                return Ok(lista); // Devolvemos la lista en formato JSON
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // 4. CREAR RECETA
        [HttpPost]
        [Route("api/recetas/crear")]
        public IHttpActionResult Crear(RecetaModelo receta)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "INSERT INTO Recetas (Nombre, Instrucciones, PorcionesBase, UsuarioId, CategoriaId) VALUES (@n, @i, @p, @u, 1)";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@n", receta.Nombre);
                cmd.Parameters.AddWithValue("@i", receta.Instrucciones);
                cmd.Parameters.AddWithValue("@p", receta.Porciones);
                cmd.Parameters.AddWithValue("@u", 1); 
                cmd.ExecuteNonQuery();
            }
            return Ok();
        }

        // 5. FAVORITOS 
        [HttpPost]
        [Route("api/favoritos/agregar")]
        public IHttpActionResult AddFavorito(int usuarioId, int recetaId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                // Evitar duplicados
                string check = "SELECT COUNT(*) FROM Favoritos WHERE UsuarioId=@u AND RecetaId=@r";
                SqlCommand cmdCheck = new SqlCommand(check, con);
                cmdCheck.Parameters.AddWithValue("@u", usuarioId);
                cmdCheck.Parameters.AddWithValue("@r", recetaId);
                if ((int)cmdCheck.ExecuteScalar() == 0)
                {
                    string q = "INSERT INTO Favoritos (UsuarioId, RecetaId) VALUES (@u, @r)";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@u", usuarioId);
                    cmd.Parameters.AddWithValue("@r", recetaId);
                    cmd.ExecuteNonQuery();
                }
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/favoritos/{usuarioId}")]
        public IHttpActionResult GetFavoritos(int usuarioId)
        {
            List<RecetaModelo> lista = new List<RecetaModelo>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "SELECT r.* FROM Recetas r JOIN Favoritos f ON r.Id = f.RecetaId WHERE f.UsuarioId = @u";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@u", usuarioId);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lista.Add(new RecetaModelo
                    {
                        Id = (int)r["Id"],
                        Nombre = r["Nombre"].ToString(),
                        Instrucciones = r["Instrucciones"].ToString(),
                        Porciones = (int)r["PorcionesBase"]
                    });
                }
            }
            return Ok(lista);
        }

        // 6. BORRAR RECETA
        [HttpDelete]
        [Route("api/recetas/{id}")]
        public IHttpActionResult Borrar(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                // Primero borrar relaciones
                new SqlCommand("DELETE FROM RecetaIngredientes WHERE RecetaId=" + id, con).ExecuteNonQuery();
                new SqlCommand("DELETE FROM Favoritos WHERE RecetaId=" + id, con).ExecuteNonQuery();
                // Borrar receta
                new SqlCommand("DELETE FROM Recetas WHERE Id=" + id, con).ExecuteNonQuery();
            }
            return Ok();
        }

        // 7. REPORTE: Ingredientes más usados
        [HttpGet]
        [Route("api/reportes/ingredientes")]
        public IHttpActionResult ReporteIngredientes()
        {
            List<ReporteIngrediente> lista = new List<ReporteIngrediente>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string q = "SELECT TOP 5 i.Nombre, COUNT(*) as Total FROM RecetaIngredientes ri JOIN Ingredientes i ON ri.IngredienteId = i.Id GROUP BY i.Nombre ORDER BY Total DESC";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read()) lista.Add(new ReporteIngrediente { Ingrediente = r["Nombre"].ToString(), VecesUtilizado = (int)r["Total"] });
            }
            return Ok(lista);
        }
    }

    // Clase para devolver los datos calculados
    public class IngredienteCalculado
    {
        public string Nombre { get; set; }
        public decimal CantidadOriginal { get; set; }
        public decimal CantidadNueva { get; set; }
        public string Unidad { get; set; }
    }
}