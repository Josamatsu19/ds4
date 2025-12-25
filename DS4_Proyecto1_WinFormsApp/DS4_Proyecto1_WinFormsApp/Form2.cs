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
    public partial class Form2 : Form
    {
        public Form2(DataTable historialCalculos)
        {
            InitializeComponent();

            this.Text = "Historial de Cálculos Guardados";

            if (dgvHistorial != null)
            {
                dgvHistorial.DataSource = historialCalculos;

                dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHistorial.ReadOnly = true;
                dgvHistorial.AllowUserToAddRows = false;
            }
        }
    }
}
