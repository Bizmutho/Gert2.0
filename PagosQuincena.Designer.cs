namespace Modulos
{
    partial class PagosQuincena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagosQuincena));
            this.adgvPagos = new ADGV.AdvancedDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpQuincena = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOficiales = new System.Windows.Forms.ComboBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnQncAtras = new System.Windows.Forms.Button();
            this.btnQncAdelante = new System.Windows.Forms.Button();
            this.lblQuincena = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.adgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // adgvPagos
            // 
            this.adgvPagos.AllowUserToAddRows = false;
            this.adgvPagos.AllowUserToDeleteRows = false;
            this.adgvPagos.AutoGenerateContextFilters = true;
            this.adgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvPagos.DateWithTime = false;
            this.adgvPagos.Location = new System.Drawing.Point(12, 77);
            this.adgvPagos.Name = "adgvPagos";
            this.adgvPagos.ReadOnly = true;
            this.adgvPagos.RowTemplate.Height = 25;
            this.adgvPagos.Size = new System.Drawing.Size(494, 355);
            this.adgvPagos.TabIndex = 0;
            this.adgvPagos.TimeFilter = false;
            this.adgvPagos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvPagos_CellContentDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(43, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quincena:";
            // 
            // dtpQuincena
            // 
            this.dtpQuincena.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpQuincena.Location = new System.Drawing.Point(43, 29);
            this.dtpQuincena.Name = "dtpQuincena";
            this.dtpQuincena.Size = new System.Drawing.Size(91, 25);
            this.dtpQuincena.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Location = new System.Drawing.Point(356, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(69, 25);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(171, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oficial:";
            // 
            // cbOficiales
            // 
            this.cbOficiales.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbOficiales.FormattingEnabled = true;
            this.cbOficiales.Items.AddRange(new object[] {
            "ABASOLO",
            "ABASOLO MORA",
            "ALDAMA",
            "ALDAMA MORA",
            "BRANDON",
            "CINTHIA",
            "CORP PROPIOS MORA",
            "GLADYS",
            "GLADYS MORA",
            "HERMELINDA",
            "JAVIER",
            "ALFONSO",
            "JUAN ORDOñES",
            "KAREN",
            "KAREN MORA",
            "MAGDA",
            "MARTINA RAMIREZ",
            "MARTINA SANCHEZ",
            "NORMA MORA",
            "PADILLA",
            "VALENTINA",
            "VICENTE",
            "JESUS",
            "NANCY",
            "CINTHIA MORA (BRANDON)",
            "CINTHIA MORA (JESUS)",
            "LLERA GERT",
            "LLERA REGULARES",
            "LLERA MORA",
            "GOMEZ FARIAS GERT",
            "GOMEZ FARIAS REGULARES",
            "GOMEZ FARIAS MORA",
            "VICTORIA GERT",
            "VICTORIA REGULARES",
            "VICTORIA MORA",
            "YARITHZA",
            "MONSERRAT",
            "MONSERRAT REGULARES",
            "MONSERRAT MORA",
            "JUAN CARLOS",
            "JUAN CARLOS (REGULARES)",
            "JUAN CARLOS (MORA)"});
            this.cbOficiales.Location = new System.Drawing.Point(171, 29);
            this.cbOficiales.Name = "cbOficiales";
            this.cbOficiales.Size = new System.Drawing.Size(179, 25);
            this.cbOficiales.TabIndex = 2;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.Location = new System.Drawing.Point(431, 28);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 25);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnQncAtras
            // 
            this.btnQncAtras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQncAtras.BackgroundImage")));
            this.btnQncAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQncAtras.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQncAtras.Location = new System.Drawing.Point(12, 29);
            this.btnQncAtras.Name = "btnQncAtras";
            this.btnQncAtras.Size = new System.Drawing.Size(25, 25);
            this.btnQncAtras.TabIndex = 7;
            this.btnQncAtras.UseVisualStyleBackColor = true;
            this.btnQncAtras.Click += new System.EventHandler(this.btnQncAtras_Click);
            // 
            // btnQncAdelante
            // 
            this.btnQncAdelante.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQncAdelante.BackgroundImage")));
            this.btnQncAdelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQncAdelante.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQncAdelante.Location = new System.Drawing.Point(140, 29);
            this.btnQncAdelante.Name = "btnQncAdelante";
            this.btnQncAdelante.Size = new System.Drawing.Size(25, 25);
            this.btnQncAdelante.TabIndex = 8;
            this.btnQncAdelante.UseVisualStyleBackColor = true;
            this.btnQncAdelante.Click += new System.EventHandler(this.btnQncAdelante_Click);
            // 
            // lblQuincena
            // 
            this.lblQuincena.AutoSize = true;
            this.lblQuincena.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuincena.Location = new System.Drawing.Point(12, 57);
            this.lblQuincena.Name = "lblQuincena";
            this.lblQuincena.Size = new System.Drawing.Size(140, 17);
            this.lblQuincena.TabIndex = 9;
            this.lblQuincena.Text = "Pagos a la quincena:";
            // 
            // PagosQuincena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 444);
            this.Controls.Add(this.lblQuincena);
            this.Controls.Add(this.btnQncAdelante);
            this.Controls.Add(this.btnQncAtras);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dtpQuincena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbOficiales);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adgvPagos);
            this.Name = "PagosQuincena";
            this.Text = "PagosQuincena";
            ((System.ComponentModel.ISupportInitialize)(this.adgvPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ADGV.AdvancedDataGridView adgvPagos;
        private Label label1;
        private ComboBox cbOficiales;
        private Button btnBuscar;
        private Label label2;
        private DateTimePicker dtpQuincena;
        private Button btnExportar;
        private Button btnQncAtras;
        private Button btnQncAdelante;
        private Label lblQuincena;
    }
}