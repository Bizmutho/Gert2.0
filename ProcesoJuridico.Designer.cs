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
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObsBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.salir)).BeginInit();
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
            this.NoContrato.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoContrato.Location = new System.Drawing.Point(177, 53);
            this.NoContrato.Name = "NoContrato";
            this.NoContrato.Size = new System.Drawing.Size(200, 25);
            this.NoContrato.TabIndex = 10;
            this.NoContrato.TextChanged += new System.EventHandler(this.NoContrato_TextChanged);
            // 
            // contrato
            // 
            this.contrato.AutoSize = true;
            this.contrato.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contrato.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.contrato.Location = new System.Drawing.Point(69, 57);
            this.contrato.Name = "contrato";
            this.contrato.Size = new System.Drawing.Size(97, 20);
            this.contrato.TabIndex = 11;
            this.contrato.Text = "No. Contrato:";
            // 
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Fecha.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Fecha.Location = new System.Drawing.Point(52, 105);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(115, 20);
            this.Fecha.TabIndex = 12;
            this.Fecha.Text = "Fecha de Oficio:";
            // 
            // fechaOficio
            // 
            this.fechaOficio.CustomFormat = "yyyy-MM-dd";
            this.fechaOficio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fechaOficio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaOficio.Location = new System.Drawing.Point(177, 102);
            this.fechaOficio.Name = "fechaOficio";
            this.fechaOficio.Size = new System.Drawing.Size(200, 25);
            this.fechaOficio.TabIndex = 13;
            // 
            // TotalDem
            // 
            this.TotalDem.AutoSize = true;
            this.TotalDem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TotalDem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalDem.Location = new System.Drawing.Point(82, 150);
            this.TotalDem.Name = "TotalDem";
            this.TotalDem.Size = new System.Drawing.Size(85, 20);
            this.TotalDem.TabIndex = 15;
            this.TotalDem.Text = "Moratorios:";
            // 
            // totalDemanda
            // 
            this.totalDemanda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalDemanda.Location = new System.Drawing.Point(177, 150);
            this.totalDemanda.Name = "totalDemanda";
            this.totalDemanda.Size = new System.Drawing.Size(200, 25);
            this.totalDemanda.TabIndex = 14;
            this.totalDemanda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.totalDemanda_KeyPress);
            // 
            // abogado
            // 
            this.abogado.AutoSize = true;
            this.abogado.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.abogado.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.abogado.Location = new System.Drawing.Point(97, 202);
            this.abogado.Name = "abogado";
            this.abogado.Size = new System.Drawing.Size(75, 20);
            this.abogado.TabIndex = 17;
            this.abogado.Text = "Abogado:";
            // 
            // listAbogado
            // 
            this.listAbogado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listAbogado.FormattingEnabled = true;
            this.listAbogado.Location = new System.Drawing.Point(177, 198);
            this.listAbogado.Name = "listAbogado";
            this.listAbogado.Size = new System.Drawing.Size(200, 25);
            this.listAbogado.TabIndex = 18;
            this.listAbogado.SelectedIndexChanged += new System.EventHandler(this.listAbogado_SelectedIndexChanged);
            this.listAbogado.SelectionChangeCommitted += new System.EventHandler(this.listAbogado_SelectionChangeCommitted);
            this.listAbogado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listAbogado_KeyPress);
            // 
            // listStatus
            // 
            this.listStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listStatus.FormattingEnabled = true;
            this.listStatus.Items.AddRange(new object[] {
            "1.- DEMANDA EN PROCESO",
            "2.- VERIFICACION DE DOMICILIO",
            "3.- INGRESO DEMANDA AL JUZGADO",
            "4.- EMPLAZAMIENTO",
            "5.- SENTENCIA",
            "6.- REQUERIMIENTO VOLUNTARIO",
            "7.- EJECUCION FORZOSA 1",
            "8.- EJECUCION FORZOSA 2",
            "9.- CONVENIO",
            "10.- EXTRAJUDICIAL",
            "11.- LIQUIDADA",
            "12.- DEVOLUCION DEL EXPEDIENTE",
            "13.- OTRO"});
            this.listStatus.Location = new System.Drawing.Point(177, 249);
            this.listStatus.Name = "listStatus";
            this.listStatus.Size = new System.Drawing.Size(200, 25);
            this.listStatus.TabIndex = 20;
            this.listStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listStatus_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(109, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Estatus:";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.buttonGuardar.FlatAppearance.BorderSize = 0;
            this.buttonGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.buttonGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.Location = new System.Drawing.Point(77, 354);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(135, 43);
            this.buttonGuardar.TabIndex = 34;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(265, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 43);
            this.button1.TabIndex = 33;
            this.button1.Text = "Cancelar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(59, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Observaciones:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtObsBox
            // 
            this.txtObsBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtObsBox.Location = new System.Drawing.Point(177, 295);
            this.txtObsBox.Name = "txtObsBox";
            this.txtObsBox.Size = new System.Drawing.Size(200, 25);
            this.txtObsBox.TabIndex = 36;
            // 
            // ProcesoJuridico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(489, 424);
            this.Controls.Add(this.txtObsBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.button1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label3;
        private PictureBox salir;
        public TextBox NoContrato;
        public Label contrato;
        public Label Fecha;
        public Label TotalDem;
        public TextBox totalDemanda;
        public Label abogado;
        public Label label1;
        private Button buttonGuardar;
        private Button button1;
        public DateTimePicker fechaOficio;
        public ComboBox listAbogado;
        public ComboBox listStatus;
        public Label label2;
        public TextBox txtObsBox;
    }
}