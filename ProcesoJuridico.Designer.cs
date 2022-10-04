namespace Modulos
{
    partial class ProcesoJuridico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesoJuridico));
            this.label3 = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.PictureBox();
            this.NoContrato = new System.Windows.Forms.TextBox();
            this.contrato = new System.Windows.Forms.Label();
            this.Fecha = new System.Windows.Forms.Label();
            this.fechaOficio = new System.Windows.Forms.DateTimePicker();
            this.TotalDem = new System.Windows.Forms.Label();
            this.totalDemanda = new System.Windows.Forms.TextBox();
            this.abogado = new System.Windows.Forms.Label();
            this.listAbogado = new System.Windows.Forms.ComboBox();
            this.listStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guardarJuridico = new System.Windows.Forms.PictureBox();
            this.cancelarJuridico = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guardarJuridico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelarJuridico)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(489, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Proceso Jurídico";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salir.Image = ((System.Drawing.Image)(resources.GetObject("salir.Image")));
            this.salir.Location = new System.Drawing.Point(465, 1);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(24, 21);
            this.salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.salir.TabIndex = 9;
            this.salir.TabStop = false;
            this.salir.Click += new System.EventHandler(this.pictureBox2_Click);
            this.salir.MouseHover += new System.EventHandler(this.salir_MouseHover);
            // 
            // NoContrato
            // 
            this.NoContrato.Enabled = false;
            this.NoContrato.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoContrato.Location = new System.Drawing.Point(154, 58);
            this.NoContrato.Name = "NoContrato";
            this.NoContrato.Size = new System.Drawing.Size(200, 22);
            this.NoContrato.TabIndex = 10;
            this.NoContrato.TextChanged += new System.EventHandler(this.NoContrato_TextChanged);
            // 
            // contrato
            // 
            this.contrato.AutoSize = true;
            this.contrato.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.contrato.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.contrato.Location = new System.Drawing.Point(46, 62);
            this.contrato.Name = "contrato";
            this.contrato.Size = new System.Drawing.Size(101, 19);
            this.contrato.TabIndex = 11;
            this.contrato.Text = "No. Contrato:";
            // 
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Fecha.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Fecha.Location = new System.Drawing.Point(29, 121);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(118, 19);
            this.Fecha.TabIndex = 12;
            this.Fecha.Text = "Fecha de Oficio:";
            // 
            // fechaOficio
            // 
            this.fechaOficio.CustomFormat = "yyyy-MM-dd";
            this.fechaOficio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaOficio.Location = new System.Drawing.Point(154, 118);
            this.fechaOficio.Name = "fechaOficio";
            this.fechaOficio.Size = new System.Drawing.Size(200, 23);
            this.fechaOficio.TabIndex = 13;
            // 
            // TotalDem
            // 
            this.TotalDem.AutoSize = true;
            this.TotalDem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TotalDem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalDem.Location = new System.Drawing.Point(12, 187);
            this.TotalDem.Name = "TotalDem";
            this.TotalDem.Size = new System.Drawing.Size(136, 19);
            this.TotalDem.TabIndex = 15;
            this.TotalDem.Text = "Total de Demanda:";
            // 
            // totalDemanda
            // 
            this.totalDemanda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalDemanda.Location = new System.Drawing.Point(154, 183);
            this.totalDemanda.Name = "totalDemanda";
            this.totalDemanda.Size = new System.Drawing.Size(200, 22);
            this.totalDemanda.TabIndex = 14;
            this.totalDemanda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.totalDemanda_KeyPress);
            // 
            // abogado
            // 
            this.abogado.AutoSize = true;
            this.abogado.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.abogado.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.abogado.Location = new System.Drawing.Point(74, 261);
            this.abogado.Name = "abogado";
            this.abogado.Size = new System.Drawing.Size(73, 19);
            this.abogado.TabIndex = 17;
            this.abogado.Text = "Abogado:";
            // 
            // listAbogado
            // 
            this.listAbogado.FormattingEnabled = true;
            this.listAbogado.Location = new System.Drawing.Point(154, 257);
            this.listAbogado.Name = "listAbogado";
            this.listAbogado.Size = new System.Drawing.Size(200, 23);
            this.listAbogado.TabIndex = 18;
            this.listAbogado.SelectedIndexChanged += new System.EventHandler(this.listAbogado_SelectedIndexChanged);
            this.listAbogado.SelectionChangeCommitted += new System.EventHandler(this.listAbogado_SelectionChangeCommitted);
            this.listAbogado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listAbogado_KeyPress);
            // 
            // listStatus
            // 
            this.listStatus.FormattingEnabled = true;
            this.listStatus.Items.AddRange(new object[] {
            "PARA NOTIFICAR",
            "PARA CATEO",
            "ESTA ABONANDO",
            "NO SE ECONTRÓ",
            "EN ESPERA",
            "CONVENIO"});
            this.listStatus.Location = new System.Drawing.Point(154, 326);
            this.listStatus.Name = "listStatus";
            this.listStatus.Size = new System.Drawing.Size(200, 23);
            this.listStatus.TabIndex = 20;
            this.listStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listStatus_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(91, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Status:";
            // 
            // guardarJuridico
            // 
            this.guardarJuridico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardarJuridico.Image = ((System.Drawing.Image)(resources.GetObject("guardarJuridico.Image")));
            this.guardarJuridico.Location = new System.Drawing.Point(387, 62);
            this.guardarJuridico.Name = "guardarJuridico";
            this.guardarJuridico.Size = new System.Drawing.Size(82, 82);
            this.guardarJuridico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guardarJuridico.TabIndex = 21;
            this.guardarJuridico.TabStop = false;
            this.guardarJuridico.Click += new System.EventHandler(this.guardarJuridico_Click);
            this.guardarJuridico.MouseLeave += new System.EventHandler(this.guardarJuridico_MouseLeave);
            this.guardarJuridico.MouseHover += new System.EventHandler(this.guardarJuridico_MouseHover);
            // 
            // cancelarJuridico
            // 
            this.cancelarJuridico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelarJuridico.Image = ((System.Drawing.Image)(resources.GetObject("cancelarJuridico.Image")));
            this.cancelarJuridico.Location = new System.Drawing.Point(384, 227);
            this.cancelarJuridico.Name = "cancelarJuridico";
            this.cancelarJuridico.Size = new System.Drawing.Size(82, 82);
            this.cancelarJuridico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancelarJuridico.TabIndex = 23;
            this.cancelarJuridico.TabStop = false;
            this.cancelarJuridico.Click += new System.EventHandler(this.cancelarJuridico_Click);
            this.cancelarJuridico.MouseLeave += new System.EventHandler(this.cancelarJuridico_MouseLeave);
            this.cancelarJuridico.MouseHover += new System.EventHandler(this.cancelarJuridico_MouseHover);
            // 
            // ProcesoJuridico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(489, 404);
            this.Controls.Add(this.cancelarJuridico);
            this.Controls.Add(this.guardarJuridico);
            this.Controls.Add(this.listStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listAbogado);
            this.Controls.Add(this.abogado);
            this.Controls.Add(this.TotalDem);
            this.Controls.Add(this.totalDemanda);
            this.Controls.Add(this.fechaOficio);
            this.Controls.Add(this.Fecha);
            this.Controls.Add(this.contrato);
            this.Controls.Add(this.NoContrato);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProcesoJuridico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceso Juridico";
            this.Load += new System.EventHandler(this.ProcesoJuridico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guardarJuridico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelarJuridico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label3;
        private PictureBox salir;
        public TextBox NoContrato;
        public Label contrato;
        public Label Fecha;
        private DateTimePicker fechaOficio;
        public Label TotalDem;
        public TextBox totalDemanda;
        public Label abogado;
        private ComboBox listAbogado;
        private ComboBox listStatus;
        public Label label1;
        public PictureBox guardarJuridico;
        public PictureBox cancelarJuridico;
    }
}