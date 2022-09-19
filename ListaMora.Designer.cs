namespace Moratorios
{
    partial class ListaMora
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
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cbOficiales = new System.Windows.Forms.ComboBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.dgvListaMora = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMora)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsultar.Location = new System.Drawing.Point(219, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 27);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cbOficiales
            // 
            this.cbOficiales.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbOficiales.FormattingEnabled = true;
            this.cbOficiales.Items.AddRange(new object[] {
            "ABASOLO",
            "ALDAMA",
            "ALDAMA MORA",
            "BARRETAL",
            "CINTHIA",
            "GLADYS",
            "HERMELINDA",
            "JAVIER",
            "JUAN",
            "KAREN",
            "MAGDA",
            "MAGUE",
            "MARTINA R.",
            "MARTINA S.",
            "NORMA",
            "PADILLA",
            "PERSONAL",
            "PROPIOS",
            "VALENTINA",
            "VICENTE"});
            this.cbOficiales.Location = new System.Drawing.Point(73, 12);
            this.cbOficiales.Name = "cbOficiales";
            this.cbOficiales.Size = new System.Drawing.Size(121, 27);
            this.cbOficiales.TabIndex = 1;
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAtras.Location = new System.Drawing.Point(12, 411);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 27);
            this.btnAtras.TabIndex = 2;
            this.btnAtras.Text = "Salir";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // dgvListaMora
            // 
            this.dgvListaMora.AllowUserToAddRows = false;
            this.dgvListaMora.AllowUserToDeleteRows = false;
            this.dgvListaMora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMora.Location = new System.Drawing.Point(12, 45);
            this.dgvListaMora.Name = "dgvListaMora";
            this.dgvListaMora.ReadOnly = true;
            this.dgvListaMora.RowTemplate.Height = 25;
            this.dgvListaMora.Size = new System.Drawing.Size(776, 360);
            this.dgvListaMora.TabIndex = 3;
            this.dgvListaMora.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvListaMora_CellPainting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Oficial:";
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.Location = new System.Drawing.Point(688, 411);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 27);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // ListaMora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListaMora);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.cbOficiales);
            this.Controls.Add(this.btnConsultar);
            this.Name = "ListaMora";
            this.Text = "ListaMora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaMora_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConsultar;
        private ComboBox cbOficiales;
        private Button btnAtras;
        private DataGridView dgvListaMora;
        private Label label1;
        private Button btnExportar;
    }
}