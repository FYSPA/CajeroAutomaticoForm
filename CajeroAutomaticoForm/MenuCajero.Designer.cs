
namespace CajeroAutomaticoForm
{
    partial class MenuCajero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCajero));
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labTitular = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnConsultarSaldo = new System.Windows.Forms.Button();
            this.btnRetirarSaldo = new System.Windows.Forms.Button();
            this.Transferencia = new System.Windows.Forms.Button();
            this.btnConsultaNoCuenta = new System.Windows.Forms.Button();
            this.btnConsultaPuntos = new System.Windows.Forms.Button();
            this.btnCanjearPuntos = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.labh = new System.Windows.Forms.Label();
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.AutoSize = true;
            this.btnEnter.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnter.BackgroundImage")));
            this.btnEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnter.Location = new System.Drawing.Point(335, 638);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(77, 30);
            this.btnEnter.TabIndex = 10;
            this.btnEnter.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Location = new System.Drawing.Point(330, 612);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 29);
            this.btnClear.TabIndex = 12;
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.Location = new System.Drawing.Point(330, 587);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 31);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(179, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Seleccione su transaccion\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(96, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Consultar Saldo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Blue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(96, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Retirar Saldo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Blue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(96, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Transferencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Blue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(96, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Consulta no. de Cuenta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Blue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(364, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Consultar de Puntos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Blue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(387, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Canjear Puntos";
            // 
            // labTitular
            // 
            this.labTitular.AutoSize = true;
            this.labTitular.BackColor = System.Drawing.Color.Blue;
            this.labTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitular.ForeColor = System.Drawing.Color.White;
            this.labTitular.Location = new System.Drawing.Point(212, 96);
            this.labTitular.Name = "labTitular";
            this.labTitular.Size = new System.Drawing.Size(36, 13);
            this.labTitular.TabIndex = 20;
            this.labTitular.Text = "Titular";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Blue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(397, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Cerrar Sesion";
            // 
            // btnConsultarSaldo
            // 
            this.btnConsultarSaldo.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultarSaldo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultarSaldo.BackgroundImage")));
            this.btnConsultarSaldo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsultarSaldo.Location = new System.Drawing.Point(47, 106);
            this.btnConsultarSaldo.Margin = new System.Windows.Forms.Padding(0);
            this.btnConsultarSaldo.Name = "btnConsultarSaldo";
            this.btnConsultarSaldo.Size = new System.Drawing.Size(38, 41);
            this.btnConsultarSaldo.TabIndex = 1;
            this.btnConsultarSaldo.UseVisualStyleBackColor = false;
            // 
            // btnRetirarSaldo
            // 
            this.btnRetirarSaldo.BackColor = System.Drawing.Color.Transparent;
            this.btnRetirarSaldo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRetirarSaldo.BackgroundImage")));
            this.btnRetirarSaldo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRetirarSaldo.Location = new System.Drawing.Point(47, 181);
            this.btnRetirarSaldo.Margin = new System.Windows.Forms.Padding(0);
            this.btnRetirarSaldo.Name = "btnRetirarSaldo";
            this.btnRetirarSaldo.Size = new System.Drawing.Size(38, 41);
            this.btnRetirarSaldo.TabIndex = 2;
            this.btnRetirarSaldo.UseVisualStyleBackColor = false;
            // 
            // Transferencia
            // 
            this.Transferencia.BackColor = System.Drawing.Color.Transparent;
            this.Transferencia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Transferencia.BackgroundImage")));
            this.Transferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transferencia.Location = new System.Drawing.Point(47, 253);
            this.Transferencia.Margin = new System.Windows.Forms.Padding(0);
            this.Transferencia.Name = "Transferencia";
            this.Transferencia.Size = new System.Drawing.Size(38, 41);
            this.Transferencia.TabIndex = 3;
            this.Transferencia.UseVisualStyleBackColor = false;
            // 
            // btnConsultaNoCuenta
            // 
            this.btnConsultaNoCuenta.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultaNoCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultaNoCuenta.BackgroundImage")));
            this.btnConsultaNoCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsultaNoCuenta.Location = new System.Drawing.Point(47, 323);
            this.btnConsultaNoCuenta.Margin = new System.Windows.Forms.Padding(0);
            this.btnConsultaNoCuenta.Name = "btnConsultaNoCuenta";
            this.btnConsultaNoCuenta.Size = new System.Drawing.Size(38, 41);
            this.btnConsultaNoCuenta.TabIndex = 4;
            this.btnConsultaNoCuenta.UseVisualStyleBackColor = false;
            // 
            // btnConsultaPuntos
            // 
            this.btnConsultaPuntos.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultaPuntos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultaPuntos.BackgroundImage")));
            this.btnConsultaPuntos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsultaPuntos.Location = new System.Drawing.Point(498, 106);
            this.btnConsultaPuntos.Margin = new System.Windows.Forms.Padding(0);
            this.btnConsultaPuntos.Name = "btnConsultaPuntos";
            this.btnConsultaPuntos.Size = new System.Drawing.Size(38, 41);
            this.btnConsultaPuntos.TabIndex = 5;
            this.btnConsultaPuntos.UseVisualStyleBackColor = false;
            // 
            // btnCanjearPuntos
            // 
            this.btnCanjearPuntos.BackColor = System.Drawing.Color.Transparent;
            this.btnCanjearPuntos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCanjearPuntos.BackgroundImage")));
            this.btnCanjearPuntos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCanjearPuntos.Location = new System.Drawing.Point(498, 181);
            this.btnCanjearPuntos.Margin = new System.Windows.Forms.Padding(0);
            this.btnCanjearPuntos.Name = "btnCanjearPuntos";
            this.btnCanjearPuntos.Size = new System.Drawing.Size(38, 41);
            this.btnCanjearPuntos.TabIndex = 6;
            this.btnCanjearPuntos.UseVisualStyleBackColor = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.BackgroundImage")));
            this.btnCerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarSesion.Location = new System.Drawing.Point(498, 323);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(38, 41);
            this.btnCerrarSesion.TabIndex = 7;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // labh
            // 
            this.labh.AutoSize = true;
            this.labh.BackColor = System.Drawing.Color.Blue;
            this.labh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labh.ForeColor = System.Drawing.Color.White;
            this.labh.Location = new System.Drawing.Point(261, 393);
            this.labh.Name = "labh";
            this.labh.Size = new System.Drawing.Size(42, 13);
            this.labh.TabIndex = 22;
            this.labh.Text = "HMTT";
            this.labh.Click += new System.EventHandler(this.labHora_Click);
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Interval = 1000;
            // 
            // MenuCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CajeroAutomaticoForm.Properties.Resources.Diseño_sin_título_removebg_preview;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(583, 730);
            this.Controls.Add(this.labh);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnCanjearPuntos);
            this.Controls.Add(this.btnConsultaPuntos);
            this.Controls.Add(this.btnConsultaNoCuenta);
            this.Controls.Add(this.Transferencia);
            this.Controls.Add(this.btnRetirarSaldo);
            this.Controls.Add(this.btnConsultarSaldo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labTitular);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSalir);
            this.DoubleBuffered = true;
            this.Name = "MenuCajero";
            this.Text = "MenuCajero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labTitular;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnConsultarSaldo;
        private System.Windows.Forms.Button btnRetirarSaldo;
        private System.Windows.Forms.Button Transferencia;
        private System.Windows.Forms.Button btnConsultaNoCuenta;
        private System.Windows.Forms.Button btnConsultaPuntos;
        private System.Windows.Forms.Button btnCanjearPuntos;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label labh;
        private System.Windows.Forms.Timer hora;
    }
}