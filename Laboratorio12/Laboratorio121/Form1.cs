using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio121
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtVelocidad.Text.Trim(), out decimal velocidad))
            {
                MessageBox.Show("Ingrese una velocidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVelocidad.Focus();
                return;
            }

            if (!decimal.TryParse(txtTiempo.Text.Trim(), out decimal tiempo))
            {
                MessageBox.Show("Ingrese un tiempo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTiempo.Focus();
                return;
            }

            Movimiento mov = new Movimiento();
            decimal distancia = mov.CalcularDistancia(velocidad, tiempo);

            txtDistancia.Text = distancia.ToString("N2");
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtVelocidad.Clear();
            txtTiempo.Clear();
            txtDistancia.Clear();
            txtVelocidad.Focus();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
