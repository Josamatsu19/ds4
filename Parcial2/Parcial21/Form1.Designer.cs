namespace Parcial21
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Farenheit1 = new System.Windows.Forms.Label();
            this.Celsius1 = new System.Windows.Forms.Label();
            this.Kelvin1 = new System.Windows.Forms.Label();
            this.txtFahrenheitEntrada = new System.Windows.Forms.TextBox();
            this.txtCelsiusEntrada = new System.Windows.Forms.TextBox();
            this.txtKelvinEntrada = new System.Windows.Forms.TextBox();
            this.btnFarenheit = new System.Windows.Forms.Button();
            this.btnCelsius = new System.Windows.Forms.Button();
            this.btnKelvin = new System.Windows.Forms.Button();
            this.txtFahrenheit_F = new System.Windows.Forms.TextBox();
            this.txtFahrenheit_C = new System.Windows.Forms.TextBox();
            this.txtFahrenheit_K = new System.Windows.Forms.TextBox();
            this.txtCelsius_K = new System.Windows.Forms.TextBox();
            this.txtCelsius_C = new System.Windows.Forms.TextBox();
            this.txtCelsius_F = new System.Windows.Forms.TextBox();
            this.txtKelvin_K = new System.Windows.Forms.TextBox();
            this.txtKelvin_C = new System.Windows.Forms.TextBox();
            this.txtKelvin_F = new System.Windows.Forms.TextBox();
            this.Farenheit2 = new System.Windows.Forms.Label();
            this.Celsius2 = new System.Windows.Forms.Label();
            this.Kelvin2 = new System.Windows.Forms.Label();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // Farenheit1
            // 
            this.Farenheit1.AutoSize = true;
            this.Farenheit1.Location = new System.Drawing.Point(77, 68);
            this.Farenheit1.Name = "Farenheit1";
            this.Farenheit1.Size = new System.Drawing.Size(63, 16);
            this.Farenheit1.TabIndex = 0;
            this.Farenheit1.Text = "Farenheit";
            // 
            // Celsius1
            // 
            this.Celsius1.AutoSize = true;
            this.Celsius1.Location = new System.Drawing.Point(80, 121);
            this.Celsius1.Name = "Celsius1";
            this.Celsius1.Size = new System.Drawing.Size(51, 16);
            this.Celsius1.TabIndex = 1;
            this.Celsius1.Text = "Celsius";
            // 
            // Kelvin1
            // 
            this.Kelvin1.AutoSize = true;
            this.Kelvin1.Location = new System.Drawing.Point(80, 178);
            this.Kelvin1.Name = "Kelvin1";
            this.Kelvin1.Size = new System.Drawing.Size(43, 16);
            this.Kelvin1.TabIndex = 2;
            this.Kelvin1.Text = "Kelvin";
            // 
            // txtFahrenheitEntrada
            // 
            this.txtFahrenheitEntrada.Location = new System.Drawing.Point(140, 68);
            this.txtFahrenheitEntrada.Name = "txtFahrenheitEntrada";
            this.txtFahrenheitEntrada.Size = new System.Drawing.Size(100, 22);
            this.txtFahrenheitEntrada.TabIndex = 3;
            // 
            // txtCelsiusEntrada
            // 
            this.txtCelsiusEntrada.Location = new System.Drawing.Point(140, 121);
            this.txtCelsiusEntrada.Name = "txtCelsiusEntrada";
            this.txtCelsiusEntrada.Size = new System.Drawing.Size(100, 22);
            this.txtCelsiusEntrada.TabIndex = 4;
            // 
            // txtKelvinEntrada
            // 
            this.txtKelvinEntrada.Location = new System.Drawing.Point(140, 171);
            this.txtKelvinEntrada.Name = "txtKelvinEntrada";
            this.txtKelvinEntrada.Size = new System.Drawing.Size(100, 22);
            this.txtKelvinEntrada.TabIndex = 5;
            // 
            // btnFarenheit
            // 
            this.btnFarenheit.Location = new System.Drawing.Point(260, 66);
            this.btnFarenheit.Name = "btnFarenheit";
            this.btnFarenheit.Size = new System.Drawing.Size(75, 23);
            this.btnFarenheit.TabIndex = 6;
            this.btnFarenheit.Text = "->";
            this.btnFarenheit.UseVisualStyleBackColor = true;
            this.btnFarenheit.Click += new System.EventHandler(this.btnFarenheit_Click);
            // 
            // btnCelsius
            // 
            this.btnCelsius.Location = new System.Drawing.Point(260, 121);
            this.btnCelsius.Name = "btnCelsius";
            this.btnCelsius.Size = new System.Drawing.Size(75, 23);
            this.btnCelsius.TabIndex = 7;
            this.btnCelsius.Text = "->";
            this.btnCelsius.UseVisualStyleBackColor = true;
            this.btnCelsius.Click += new System.EventHandler(this.btnCelsius_Click);
            // 
            // btnKelvin
            // 
            this.btnKelvin.Location = new System.Drawing.Point(260, 170);
            this.btnKelvin.Name = "btnKelvin";
            this.btnKelvin.Size = new System.Drawing.Size(75, 23);
            this.btnKelvin.TabIndex = 8;
            this.btnKelvin.Text = "->";
            this.btnKelvin.UseVisualStyleBackColor = true;
            this.btnKelvin.Click += new System.EventHandler(this.btnKelvin_Click);
            // 
            // txtFahrenheit_F
            // 
            this.txtFahrenheit_F.Location = new System.Drawing.Point(362, 67);
            this.txtFahrenheit_F.Name = "txtFahrenheit_F";
            this.txtFahrenheit_F.Size = new System.Drawing.Size(100, 22);
            this.txtFahrenheit_F.TabIndex = 9;
            // 
            // txtFahrenheit_C
            // 
            this.txtFahrenheit_C.Location = new System.Drawing.Point(469, 67);
            this.txtFahrenheit_C.Name = "txtFahrenheit_C";
            this.txtFahrenheit_C.Size = new System.Drawing.Size(100, 22);
            this.txtFahrenheit_C.TabIndex = 10;
            // 
            // txtFahrenheit_K
            // 
            this.txtFahrenheit_K.Location = new System.Drawing.Point(576, 67);
            this.txtFahrenheit_K.Name = "txtFahrenheit_K";
            this.txtFahrenheit_K.Size = new System.Drawing.Size(100, 22);
            this.txtFahrenheit_K.TabIndex = 11;
            // 
            // txtCelsius_K
            // 
            this.txtCelsius_K.Location = new System.Drawing.Point(576, 122);
            this.txtCelsius_K.Name = "txtCelsius_K";
            this.txtCelsius_K.Size = new System.Drawing.Size(100, 22);
            this.txtCelsius_K.TabIndex = 14;
            // 
            // txtCelsius_C
            // 
            this.txtCelsius_C.Location = new System.Drawing.Point(469, 122);
            this.txtCelsius_C.Name = "txtCelsius_C";
            this.txtCelsius_C.Size = new System.Drawing.Size(100, 22);
            this.txtCelsius_C.TabIndex = 13;
            // 
            // txtCelsius_F
            // 
            this.txtCelsius_F.Location = new System.Drawing.Point(362, 122);
            this.txtCelsius_F.Name = "txtCelsius_F";
            this.txtCelsius_F.Size = new System.Drawing.Size(100, 22);
            this.txtCelsius_F.TabIndex = 12;
            // 
            // txtKelvin_K
            // 
            this.txtKelvin_K.Location = new System.Drawing.Point(576, 175);
            this.txtKelvin_K.Name = "txtKelvin_K";
            this.txtKelvin_K.Size = new System.Drawing.Size(100, 22);
            this.txtKelvin_K.TabIndex = 17;
            // 
            // txtKelvin_C
            // 
            this.txtKelvin_C.Location = new System.Drawing.Point(469, 175);
            this.txtKelvin_C.Name = "txtKelvin_C";
            this.txtKelvin_C.Size = new System.Drawing.Size(100, 22);
            this.txtKelvin_C.TabIndex = 16;
            // 
            // txtKelvin_F
            // 
            this.txtKelvin_F.Location = new System.Drawing.Point(362, 175);
            this.txtKelvin_F.Name = "txtKelvin_F";
            this.txtKelvin_F.Size = new System.Drawing.Size(100, 22);
            this.txtKelvin_F.TabIndex = 15;
            // 
            // Farenheit2
            // 
            this.Farenheit2.AutoSize = true;
            this.Farenheit2.Location = new System.Drawing.Point(362, 45);
            this.Farenheit2.Name = "Farenheit2";
            this.Farenheit2.Size = new System.Drawing.Size(63, 16);
            this.Farenheit2.TabIndex = 18;
            this.Farenheit2.Text = "Farenheit";
            // 
            // Celsius2
            // 
            this.Celsius2.AutoSize = true;
            this.Celsius2.Location = new System.Drawing.Point(469, 45);
            this.Celsius2.Name = "Celsius2";
            this.Celsius2.Size = new System.Drawing.Size(51, 16);
            this.Celsius2.TabIndex = 19;
            this.Celsius2.Text = "Celsius";
            // 
            // Kelvin2
            // 
            this.Kelvin2.AutoSize = true;
            this.Kelvin2.Location = new System.Drawing.Point(576, 44);
            this.Kelvin2.Name = "Kelvin2";
            this.Kelvin2.Size = new System.Drawing.Size(43, 16);
            this.Kelvin2.TabIndex = 20;
            this.Kelvin2.Text = "Kelvin";
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(83, 26);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(75, 23);
            this.btnHistorial.TabIndex = 21;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(80, 235);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.RowTemplate.Height = 24;
            this.dgvHistorial.Size = new System.Drawing.Size(607, 150);
            this.dgvHistorial.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.Kelvin2);
            this.Controls.Add(this.Celsius2);
            this.Controls.Add(this.Farenheit2);
            this.Controls.Add(this.txtKelvin_K);
            this.Controls.Add(this.txtKelvin_C);
            this.Controls.Add(this.txtKelvin_F);
            this.Controls.Add(this.txtCelsius_K);
            this.Controls.Add(this.txtCelsius_C);
            this.Controls.Add(this.txtCelsius_F);
            this.Controls.Add(this.txtFahrenheit_K);
            this.Controls.Add(this.txtFahrenheit_C);
            this.Controls.Add(this.txtFahrenheit_F);
            this.Controls.Add(this.btnKelvin);
            this.Controls.Add(this.btnCelsius);
            this.Controls.Add(this.btnFarenheit);
            this.Controls.Add(this.txtKelvinEntrada);
            this.Controls.Add(this.txtCelsiusEntrada);
            this.Controls.Add(this.txtFahrenheitEntrada);
            this.Controls.Add(this.Kelvin1);
            this.Controls.Add(this.Celsius1);
            this.Controls.Add(this.Farenheit1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Farenheit1;
        private System.Windows.Forms.Label Celsius1;
        private System.Windows.Forms.Label Kelvin1;
        private System.Windows.Forms.TextBox txtFahrenheitEntrada;
        private System.Windows.Forms.TextBox txtCelsiusEntrada;
        private System.Windows.Forms.TextBox txtKelvinEntrada;
        private System.Windows.Forms.Button btnFarenheit;
        private System.Windows.Forms.Button btnCelsius;
        private System.Windows.Forms.Button btnKelvin;
        private System.Windows.Forms.TextBox txtFahrenheit_F;
        private System.Windows.Forms.TextBox txtFahrenheit_C;
        private System.Windows.Forms.TextBox txtFahrenheit_K;
        private System.Windows.Forms.TextBox txtCelsius_K;
        private System.Windows.Forms.TextBox txtCelsius_C;
        private System.Windows.Forms.TextBox txtCelsius_F;
        private System.Windows.Forms.TextBox txtKelvin_K;
        private System.Windows.Forms.TextBox txtKelvin_C;
        private System.Windows.Forms.TextBox txtKelvin_F;
        private System.Windows.Forms.Label Farenheit2;
        private System.Windows.Forms.Label Celsius2;
        private System.Windows.Forms.Label Kelvin2;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}

