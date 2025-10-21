using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtNota1.Text.Trim(), out decimal n1) ||
                !decimal.TryParse(txtNota2.Text.Trim(), out decimal n2) ||
                !decimal.TryParse(txtNota3.Text.Trim(), out decimal n3))
            {
                MessageBox.Show("Ingrese valores numéricos válidos para las tres notas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (n1 < 0 || n2 < 0 || n3 < 0 || n1 > 100 || n2 > 100 || n3 > 100)
            {
                MessageBox.Show("Las notas deben estar entre 0 y 100.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Notas notas = new Notas();
            decimal promedio = notas.CalcularPromedio(n1, n2, n3);

            txtPromedio.Text = promedio.ToString("N2");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtPromedio.Clear();
            txtNota1.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
