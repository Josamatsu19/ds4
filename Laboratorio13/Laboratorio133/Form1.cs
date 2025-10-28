using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio133 
{
    public partial class Form1 : Form
    {
        string connectionString =
            @"Server=JOSELUNA;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                 conexion.Open();
                 MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
                
                ListarProductos();

                 conexion.Close(); 
                 MessageBox.Show("Se cerró la conexión.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexión: " + ex.Message);
            }
        }

        private void ListarProductos()
        {
            string query = "SELECT ProductName FROM [dbo].[Products]";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                try
                {
                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        listBox1.Items.Clear();

                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader["ProductName"].ToString());
                        }

                        MessageBox.Show("Productos listados con éxito.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                }
            }
        }
    }
}