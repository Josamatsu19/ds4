using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS4_Proyecto1_WinFormsApp
{
    public partial class Form1 : Form
    {
        private double primerNumero = 0;
        private string operacionActual = "";
        private bool esNuevaEntrada = true;
        private readonly DataAccesLayer dataAccesLayer;

        public Form1()
        {
            InitializeComponent();
            dataAccesLayer = new DataAccesLayer();
            txtDisplay.Text = "0";
        }
        private void Boton_Numero_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            if (esNuevaEntrada)
            {
                txtDisplay.Text = boton.Text;
                esNuevaEntrada = false;
            }
            else
            {
                if (txtDisplay.Text == "0" && boton.Text != ".")
                {
                    txtDisplay.Text = boton.Text;
                }
                else
                {
                    txtDisplay.Text += boton.Text;
                }
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
                esNuevaEntrada = false;
            }
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double valorActual))
            {
                txtDisplay.Text = (-valorActual).ToString();
            }
        }
        private void Boton_Operador_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            if (!esNuevaEntrada && operacionActual != "")
            {
                btnIgual_Click(sender, e);
            }

            if (double.TryParse(txtDisplay.Text, out primerNumero))
            {
                operacionActual = boton.Tag.ToString();
                esNuevaEntrada = true;
            }
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double num))
            {
                try
                {
                    double resultado = CalculadoraLogic.ElevarAlCuadrado(num);
                    string operacion = $"{num}^2";
                    txtDisplay.Text = resultado.ToString();
                    dataAccesLayer.GuardarCalculo(operacion, resultado);
                    esNuevaEntrada = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error de Cálculo");
                    LimpiarTodo();
                }
            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double num))
            {
                try
                {
                    double resultado = CalculadoraLogic.RaizCuadrada(num);
                    string operacion = $"Sqrt({num})";
                    txtDisplay.Text = resultado.ToString();
                    dataAccesLayer.GuardarCalculo(operacion, resultado);
                    esNuevaEntrada = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error de Cálculo");
                    LimpiarTodo();
                }
            }
        }

        private void btnPotencia_Click(object sender, EventArgs e) => Boton_Operador_Click(sender, e);
        private void btnModulo_Click(object sender, EventArgs e) => Boton_Operador_Click(sender, e);

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (operacionActual == "" || esNuevaEntrada) return;

            double segundoNumero = double.Parse(txtDisplay.Text);
            double resultado = 0;
            string operacionDisplay = $"{primerNumero} {operacionActual} {segundoNumero}";

            try
            {
                switch (operacionActual)
                {
                    case "+":
                        resultado = CalculadoraLogic.Sumar(primerNumero, segundoNumero);
                        break;
                    case "-":
                        resultado = CalculadoraLogic.Restar(primerNumero, segundoNumero);
                        break;
                    case "X":
                        resultado = CalculadoraLogic.Multiplicar(primerNumero, segundoNumero);
                        break;
                    case "/":
                        resultado = CalculadoraLogic.Dividir(primerNumero, segundoNumero);
                        break;
                    case "^": 
                        resultado = CalculadoraLogic.Potencia(primerNumero, segundoNumero);
                        break;
                    case "%": 
                        resultado = CalculadoraLogic.Modulo(primerNumero, segundoNumero);
                        break;
                    default:
                        return;
                }

                txtDisplay.Text = resultado.ToString();

                dataAccesLayer.GuardarCalculo(operacionDisplay, resultado);

                primerNumero = resultado;
                operacionActual = "";
                esNuevaEntrada = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Cálculo");
                LimpiarTodo();
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            esNuevaEntrada = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void LimpiarTodo()
        {
            primerNumero = 0;
            operacionActual = "";
            txtDisplay.Text = "0";
            esNuevaEntrada = true;
        }


        private void btnMostrarCalculos_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable historial = dataAccesLayer.ObtenerCalculos();

                Form2 historialForm = new Form2(historial);
                historialForm.Show(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el historial: " + ex.Message, "Error de Base de Datos");
            }
        }
    }
}
