using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtA.Text.Trim(), out decimal a) ||
                !decimal.TryParse(txtB.Text.Trim(), out decimal b) ||
                !decimal.TryParse(txtC.Text.Trim(), out decimal c))
            {
                MessageBox.Show("Ingrese valores numéricos válidos para los tres lados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Triangulo t = new Triangulo();

            if (!t.EsTrianguloValido(a, b, c))
            {
                MessageBox.Show("Los lados ingresados no forman un triángulo válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal s = t.CalcularSemiperimetro(a, b, c);
            decimal area = t.CalcularArea(a, b, c);

            txtS.Text = s.ToString("N2");
            txtArea.Text = area.ToString("N2");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtS.Clear();
            txtArea.Clear();
            txtA.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
