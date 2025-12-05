using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Parcial3.Models;

namespace Parcial3.Controllers
{
    public class PasaporteController : Controller
    {
        private string stringConexion = ConfigurationManager.ConnectionStrings["PassportConn"].ConnectionString;

        public ActionResult Index()
        {
            List<SolicitudModelo> lista = new List<SolicitudModelo>();

            try
            {
                using (SqlConnection con = new SqlConnection(stringConexion))
                {
                    string query = "SELECT s.IdSolicitud, p.Nombre, p.Apellido, p.DNI, s.Estado, s.FechaSolicitud " +
                                   "FROM Solicitudes s INNER JOIN Solicitantes p ON s.IdSolicitante = p.IdSolicitante " +
                                   "ORDER BY s.FechaSolicitud DESC"; 

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        lista.Add(new SolicitudModelo
                        {
                            IdSolicitud = Convert.ToInt32(rdr["IdSolicitud"]),
                            Nombre = rdr["Nombre"].ToString(),
                            Apellido = rdr["Apellido"].ToString(),
                            DNI = rdr["DNI"].ToString(),
                            Estado = rdr["Estado"].ToString(),
                            FechaSolicitud = Convert.ToDateTime(rdr["FechaSolicitud"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error de conexión: " + ex.Message;
            }

            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SolicitudModelo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(stringConexion))
                    {
                        con.Open();
                        int idSolicitante = 0;

                        string queryCheck = "SELECT IdSolicitante FROM Solicitantes WHERE DNI = @DNI";
                        SqlCommand cmdCheck = new SqlCommand(queryCheck, con);
                        cmdCheck.Parameters.AddWithValue("@DNI", model.DNI);

                        object resultado = cmdCheck.ExecuteScalar();

                        if (resultado != null)
                        {
                            idSolicitante = Convert.ToInt32(resultado);
                        }
                        else
                        {
                            string queryPersona = "INSERT INTO Solicitantes (DNI, Nombre, Apellido, FechaNacimiento, Email) " +
                                                  "VALUES (@DNI, @Nombre, @Apellido, @FechaNacimiento, @Email); " +
                                                  "SELECT SCOPE_IDENTITY();";

                            SqlCommand cmdP = new SqlCommand(queryPersona, con);
                            cmdP.Parameters.AddWithValue("@DNI", model.DNI);
                            cmdP.Parameters.AddWithValue("@Nombre", model.Nombre);
                            cmdP.Parameters.AddWithValue("@Apellido", model.Apellido);
                            cmdP.Parameters.AddWithValue("@FechaNacimiento", model.FechaNacimiento);
                            cmdP.Parameters.AddWithValue("@Email", model.Email ?? "");

                            idSolicitante = Convert.ToInt32(cmdP.ExecuteScalar());
                        }

                        string querySolicitud = "INSERT INTO Solicitudes (IdSolicitante, Estado) VALUES (@IdRef, 'Pendiente')";
                        SqlCommand cmdS = new SqlCommand(querySolicitud, con);
                        cmdS.Parameters.AddWithValue("@IdRef", idSolicitante);
                        cmdS.ExecuteNonQuery();
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error en base de datos: " + ex.Message);
                }
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            SolicitudModelo modelo = new SolicitudModelo();

            using (SqlConnection con = new SqlConnection(stringConexion))
            {
                string query = "SELECT s.IdSolicitud, p.DNI, p.Nombre, p.Apellido, s.Estado, s.FechaSolicitud " +
                               "FROM Solicitudes s INNER JOIN Solicitantes p ON s.IdSolicitante = p.IdSolicitante " +
                               "WHERE s.IdSolicitud = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    modelo.IdSolicitud = Convert.ToInt32(rdr["IdSolicitud"]);
                    modelo.DNI = rdr["DNI"].ToString();
                    modelo.Nombre = rdr["Nombre"].ToString();
                    modelo.Apellido = rdr["Apellido"].ToString();
                    modelo.Estado = rdr["Estado"].ToString();
                    modelo.FechaSolicitud = Convert.ToDateTime(rdr["FechaSolicitud"]);
                    modelo.FechaNacimiento = DateTime.Now;
                }
            }
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Edit(SolicitudModelo model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(stringConexion))
                {
                    string query = "UPDATE Solicitudes SET Estado = @Estado WHERE IdSolicitud = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Estado", model.Estado);
                    cmd.Parameters.AddWithValue("@Id", model.IdSolicitud);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}