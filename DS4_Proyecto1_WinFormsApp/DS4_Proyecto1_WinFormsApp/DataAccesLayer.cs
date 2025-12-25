using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DS4_Proyecto1_WinFormsApp
{
    public class DataAccesLayer
    {
        private readonly string connectionString;

        public DataAccesLayer()
        {
            
            connectionString = ConfigurationManager.ConnectionStrings["CalculadoraDBConnection"].ConnectionString;
        }

        public void GuardarCalculo(string operacion, double resultado)
        {
            
            string query = "INSERT INTO CalculosHistorico (Operacion, Resultado) VALUES (@Operacion, @Resultado)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@Operacion", operacion);
                    command.Parameters.AddWithValue("@Resultado", resultado);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery(); 
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error al guardar cálculo: " + ex.Message);
                    }
                }
            }
        }

        public DataTable ObtenerCalculos()
        {
            string query = "SELECT Id, Operacion, Resultado, Fecha FROM CalculosHistorico ORDER BY Id DESC";
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error al obtener cálculos: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}
