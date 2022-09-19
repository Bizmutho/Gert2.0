namespace Modulos
{
    partial class Contpaq
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtpIni = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvContpaq = new System.Windows.Forms.DataGridView();
            this.dgvTotales = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContpaq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(267, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de fin:";
            // 
            // dtpIni
            // 
            this.dtpIni.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpIni.Location = new System.Drawing.Point(129, 12);
            this.dtpIni.Name = "dtpIni";
            this.dtpIni.Size = new System.Drawing.Size(132, 25);
            this.dtpIni.TabIndex = 2;
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpFin.Location = new System.Drawing.Point(365, 12);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(132, 25);
            this.dtpFin.TabIndex = 3;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConsultar.Location = new System.Drawing.Point(503, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(109, 25);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvContpaq
            // 
            this.dgvContpaq.AllowUserToAddRows = false;
            this.dgvContpaq.AllowUserToDeleteRows = false;
            this.dgvContpaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContpaq.Location = new System.Drawing.Point(12, 43);
            this.dgvContpaq.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dgvContpaq.Name = "dgvContpaq";
            this.dgvContpaq.ReadOnly = true;
            this.dgvContpaq.RowTemplate.Height = 25;
            this.dgvContpaq.Size = new System.Drawing.Size(742, 369);
            this.dgvContpaq.TabIndex = 5;
            // 
            // dgvTotales
            // 
            this.dgvTotales.AllowUserToAddRows = false;
            this.dgvTotales.AllowUserToDeleteRows = false;
            this.dgvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotales.Location = new System.Drawing.Point(12, 412);
            this.dgvTotales.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dgvTotales.Name = "dgvTotales";
            this.dgvTotales.ReadOnly = true;
            this.dgvTotales.RowTemplate.Height = 25;
            this.dgvTotales.Size = new System.Drawing.Size(742, 26);
            this.dgvTotales.TabIndex = 6;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.Location = new System.Drawing.Point(618, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 25);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // Contpaq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvTotales);
            this.Controls.Add(this.dgvContpaq);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpIni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Contpaq";
            this.Text = "Contpaq";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContpaq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpIni;
        private DateTimePicker dtpFin;
        private Button btnConsultar;
        private DataGridView dgvContpaq;
        private DataGridView dgvTotales;
        private Button btnExportar;
    }
}