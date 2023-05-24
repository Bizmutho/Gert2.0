namespace Moratorios
{
    partial class PorcentajesAtz
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
            this.cbOficiales = new System.Windows.Forms.ComboBox();
            this.dtpMes = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvPorcentajesAtz = new System.Windows.Forms.DataGridView();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorcentajesAtz)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOficiales
            // 
            this.cbOficiales.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbOficiales.FormattingEnabled = true;
            this.cbOficiales.Items.AddRange(new object[] {
            "TODOS",
            "VICENTE",
            "MAGUE",
            "JAVIER",
            "VALENTINA",
            "MARTINA RAMIREZ",
            "CINTHIA",
            "NORMA PATRICIA",
            "NORMA PATRICIA MORA",
            "OF. CORPORATIVO",
            "OF. CORPORATIVO",
            "MAGDA",
            "GLADYS",
            "GLADYS MORA",
            "KAREN",
            "KAREN MORA",
            "ALDAMA",
            "ALDAMA MORA",
            "PADILLA",
            "BARRETAL",
            "HERMELINDA",
            "JUAN",
            "MARTINA SANCHEZ",
            "ABASOLO",
            "ABASOLO MORA",
            "BRANDON",
            "ALFONSO",
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
            "JUAN CARLOS (MORA)",
            "LUIS ENRIQUE MENA"});
            this.cbOficiales.Location = new System.Drawing.Point(232, 12);
            this.cbOficiales.Name = "cbOficiales";
            this.cbOficiales.Size = new System.Drawing.Size(215, 27);
            this.cbOficiales.TabIndex = 0;
            // 
            // dtpMes
            // 
            this.dtpMes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpMes.Location = new System.Drawing.Point(55, 12);
            this.dtpMes.Name = "dtpMes";
            this.dtpMes.Size = new System.Drawing.Size(85, 27);
            this.dtpMes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(146, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Oficial(es):";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsultar.Location = new System.Drawing.Point(453, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 27);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.Location = new System.Drawing.Point(517, 411);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 27);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvPorcentajesAtz
            // 
            this.dgvPorcentajesAtz.AllowUserToAddRows = false;
            this.dgvPorcentajesAtz.AllowUserToDeleteRows = false;
            this.dgvPorcentajesAtz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPorcentajesAtz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorcentajesAtz.Location = new System.Drawing.Point(12, 45);
            this.dgvPorcentajesAtz.Name = "dgvPorcentajesAtz";
            this.dgvPorcentajesAtz.ReadOnly = true;
            this.dgvPorcentajesAtz.RowTemplate.Height = 25;
            this.dgvPorcentajesAtz.Size = new System.Drawing.Size(605, 360);
            this.dgvPorcentajesAtz.TabIndex = 6;
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtras.BackColor = System.Drawing.SystemColors.Control;
            this.btnAtras.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAtras.Location = new System.Drawing.Point(12, 411);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 27);
            this.btnAtras.TabIndex = 7;
            this.btnAtras.Text = "Salir";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // PorcentajesAtz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 450);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.dgvPorcentajesAtz);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpMes);
            this.Controls.Add(this.cbOficiales);
            this.Name = "PorcentajesAtz";
            this.Text = "PorcentajesAtz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PorcentajesAtz_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorcentajesAtz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbOficiales;
        private DateTimePicker dtpMes;
        private Label label1;
        private Label label2;
        private Button btnConsultar;
        private Button btnExportar;
        private DataGridView dgvPorcentajesAtz;
        private Button btnAtras;
    }
}