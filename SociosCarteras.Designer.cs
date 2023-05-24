namespace Modulos.Modelos
{
    partial class SociosCarteras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SociosCarteras));
            this.listaOficial = new System.Windows.Forms.ComboBox();
            this.tablaSocios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nombre1 = new System.Windows.Forms.TextBox();
            this.btnProceso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaSocios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // listaOficial
            // 
            this.listaOficial.FormattingEnabled = true;
            this.listaOficial.Items.AddRange(new object[] {
            "VALENTINA PALOMO ARAUJO",
            "JUAN ORDOÑEZ LUMBRERAS",
            "MARTINA SANCHEZ RAMIREZ",
            "MARTINA RAMIREZ LAGUNA",
            "OFICINA CORPORATIVO PROPIOS",
            "JAVIER ALEJANDRO GOMEZ TURRUBIATES",
            "VICENTE BALDAZO MENDOZA",
            "NORMA PATRICIA MARTINEZ AGUILAR",
            "SILVIA MARGARITA XIMENEZ PEREZ",
            "AMALIA IBETH MARTINEZ TREJO",
            "LUDIVINA VAZQUEZ TURRUBIATES",
            "OFICINA ALDAMA GERT",
            "OFICINA PRESTAMOS PERSONAL",
            "OFICINA PADILLA GERT",
            "MAGDA CATALINA SILVA MARTINEZ",
            "GLADYS YUDITH GALLEGOS HERNADEZ",
            "LUIS ALEJANDRO HIGUERA  RODRIGUEZ",
            "OFICINA BARRETAL GERT",
            "HERMELINDA CAMACHO  MIRELES",
            "KAREN VANESA ZUÑIGA RAMIREZ",
            "OFICINA  ABASOLO GERT",
            "CINTHIA GUADALUPE SEGOVIA GONZALEZ",
            "KAREN MORA .",
            "CINTHIA MORA .",
            "ABASOLO MORA .",
            "CORPORATIVO PROPIOS MORA",
            "GLADYS MORA .",
            "ALDAMA MORA .",
            "NORMA MORA .",
            "BRANDON ALEJANDRO GALLEGOS RODRIGUEZ",
            "JORGE ALFONSO RUIZ OSORIO",
            "JESUS ARMANDO DUQUE LOA",
            "NANCY ANALY CASTRO VARGAS",
            "JUAN DANIEL HERNANDEZ MALDONADO",
            "OFICINA  LLERA GERT",
            "OFICINA LLERA MORA",
            "OFICINA GOMEZ FARIAS GERT",
            "OFICINA GOMEZ FARIAS MORA",
            "OFICINA LLERA REGULARES",
            "OFICINA GOMEZ FARIAS REGULARES",
            "OFICINA VICTORIA GERT",
            "OFICINA VICTORIA MORA",
            "OFICINA VICTORIA REGULARES",
            "CINTHIA MORA (BRANDON)",
            "CINTHIA MORA (JESUS)",
            "YARITHZA ",
            "YARITHZA REGULARES",
            "MONSERRAT",
            "MONSERRAT REGULARES",
            "MONSERRAT MORA",
            "JUAN CARLOS",
            "JUAN CARLOS REGULARES",
            "JUAN CARLOS MORA",
            "LUIS ENRIQUE MENA"});
            this.listaOficial.Location = new System.Drawing.Point(93, 39);
            this.listaOficial.Name = "listaOficial";
            this.listaOficial.Size = new System.Drawing.Size(258, 23);
            this.listaOficial.TabIndex = 0;
            this.listaOficial.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tablaSocios
            // 
            this.tablaSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaSocios.Location = new System.Drawing.Point(12, 81);
            this.tablaSocios.Name = "tablaSocios";
            this.tablaSocios.RowTemplate.Height = 25;
            this.tablaSocios.Size = new System.Drawing.Size(1060, 410);
            this.tablaSocios.TabIndex = 1;
            this.tablaSocios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaSocios_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(29, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Oficial:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsultar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConsultar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConsultar.Location = new System.Drawing.Point(377, 38);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(95, 23);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportar.Location = new System.Drawing.Point(478, 38);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(95, 23);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1084, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Socios Cartera";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1060, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // nombre1
            // 
            this.nombre1.Enabled = false;
            this.nombre1.Location = new System.Drawing.Point(631, 38);
            this.nombre1.Name = "nombre1";
            this.nombre1.Size = new System.Drawing.Size(266, 23);
            this.nombre1.TabIndex = 9;
            // 
            // btnProceso
            // 
            this.btnProceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnProceso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProceso.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProceso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProceso.Location = new System.Drawing.Point(913, 38);
            this.btnProceso.Name = "btnProceso";
            this.btnProceso.Size = new System.Drawing.Size(155, 23);
            this.btnProceso.TabIndex = 10;
            this.btnProceso.Text = "PROCESO JURIDICO";
            this.btnProceso.UseVisualStyleBackColor = false;
            this.btnProceso.Click += new System.EventHandler(this.btnProceso_Click);
            // 
            // SociosCarteras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1084, 503);
            this.Controls.Add(this.btnProceso);
            this.Controls.Add(this.nombre1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablaSocios);
            this.Controls.Add(this.listaOficial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SociosCarteras";
            this.Text = "SociosCarteras";
            this.Load += new System.EventHandler(this.SociosCarteras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaSocios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox listaOficial;
        private Label label1;
        private Button btnConsultar;
        private Button btnExportar;
        private Label label3;
        private PictureBox pictureBox2;
        private TextBox nombre1;
        private Button btnProceso;
        public DataGridView tablaSocios;
    }
}