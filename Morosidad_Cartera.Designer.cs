namespace Modulos
{
    partial class Morosidad_Cartera
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbOficiales = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.adgvMorosos = new ADGV.AdvancedDataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.adgvMorosos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oficial:";
            // 
            // cbOficiales
            // 
            this.cbOficiales.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbOficiales.FormattingEnabled = true;
            this.cbOficiales.Location = new System.Drawing.Point(73, 12);
            this.cbOficiales.Name = "cbOficiales";
            this.cbOficiales.Size = new System.Drawing.Size(305, 25);
            this.cbOficiales.TabIndex = 1;
            this.cbOficiales.SelectedIndexChanged += new System.EventHandler(this.cbOficiales_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Location = new System.Drawing.Point(384, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // adgvMorosos
            // 
            this.adgvMorosos.AllowUserToAddRows = false;
            this.adgvMorosos.AllowUserToDeleteRows = false;
            this.adgvMorosos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adgvMorosos.AutoGenerateContextFilters = true;
            this.adgvMorosos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvMorosos.DateWithTime = false;
            this.adgvMorosos.Location = new System.Drawing.Point(12, 43);
            this.adgvMorosos.Name = "adgvMorosos";
            this.adgvMorosos.ReadOnly = true;
            this.adgvMorosos.RowTemplate.Height = 25;
            this.adgvMorosos.Size = new System.Drawing.Size(950, 395);
            this.adgvMorosos.TabIndex = 3;
            this.adgvMorosos.TimeFilter = false;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.Location = new System.Drawing.Point(490, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(92, 25);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // Morosidad_Cartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.adgvMorosos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbOficiales);
            this.Controls.Add(this.label1);
            this.Name = "Morosidad_Cartera";
            this.Text = "Morosidad_Cartera";
            ((System.ComponentModel.ISupportInitialize)(this.adgvMorosos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cbOficiales;
        private Button btnBuscar;
        private ADGV.AdvancedDataGridView adgvMorosos;
        private Button btnExportar;
    }
}