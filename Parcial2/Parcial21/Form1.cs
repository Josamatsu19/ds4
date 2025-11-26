using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial21
{
    public partial class Form1 : Form
    {
        List<string> historial = new List<string>();
        string conexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }
        private void GuardarEnBD(string escalaOrigen, double valorEntrada, double f, double c, double k)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "INSERT INTO Historial (EscalaOrigen, ValorEntrada, Fahrenheit, Celsius, Kelvin) " +
                                   "VALUES (@Escala, @Valor, @F, @C, @K)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Escala", escalaOrigen);
                        cmd.Parameters.AddWithValue("@Valor", valorEntrada);
                        cmd.Parameters.AddWithValue("@F", f);
                        cmd.Parameters.AddWithValue("@C", c);
                        cmd.Parameters.AddWithValue("@K", k);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en base de datos: " + ex.Message);
            }
        }
        private void btnFarenheit_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtFahrenheitEntrada.Text, out double f))
            {
                double c = (f - 32) * 5 / 9;
                double k = c + 273.15;

                txtFahrenheit_F.Text = f.ToString("F2");
                txtFahrenheit_C.Text = c.ToString("F2");
                txtFahrenheit_K.Text = k.ToString("F2");

                historial.Add($"{f} °F = {c:F2} °C = {k:F2} K");
                GuardarEnBD("Fahrenheit", f, f, c, k);
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido en Fahrenheit.");
            }

        }

        private void btnCelsius_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtCelsiusEntrada.Text, out double c))
            {
                double f = (c * 9 / 5) + 32;
                double k = c + 273.15;

                txtCelsius_F.Text = f.ToString("F2");
                txtCelsius_C.Text = c.ToString("F2");
                txtCelsius_K.Text = k.ToString("F2");

                historial.Add($"{c} °C = {f:F2} °F = {k:F2} K");
                GuardarEnBD("Celsius", c, f, c, k);
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido en Celsius.");
            }

        }

        private void btnKelvin_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtKelvinEntrada.Text, out double k))
            {
                double c = k - 273.15;
                double f = (c * 9 / 5) + 32;

                txtKelvin_F.Text = f.ToString("F2");
                txtKelvin_C.Text = c.ToString("F2");
                txtKelvin_K.Text = k.ToString("F2");

                historial.Add($"{k} K = {c:F2} °C = {f:F2} °F");
                GuardarEnBD("Kelvin", k, f, c, k);
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido en Kelvin.");
            }

        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT * FROM Historial ORDER BY Fecha DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string resultado = "";
                        while (reader.Read())
                        {
                            resultado += $"{reader["Fecha"]}: {reader["EscalaOrigen"]} {reader["ValorEntrada"]} → " +
                                         $"F={reader["Fahrenheit"]}, C={reader["Celsius"]}, K={reader["Kelvin"]}\n";
                        }

                        MessageBox.Show(resultado.Length > 0 ? resultado : "No hay registros en el historial.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }

        }

        private void CargarHistorial()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT Fecha, EscalaOrigen, ValorEntrada, Fahrenheit, Celsius, Kelvin FROM Historial ORDER BY Fecha DESC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    dgvHistorial.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message);
            }
        }
    }
}
