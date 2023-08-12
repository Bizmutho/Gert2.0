namespace Moratorios
{
    partial class PorcentajesMaj
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvPorcentajesMaj = new System.Windows.Forms.DataGridView();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorcentajesMaj)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOficiales
            // 
            this.cbOficiales.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbOficiales.FormattingEnabled = true;
            this.cbOficiales.Items.AddRange(new object[] {
            "TODOS",
            "JUAN",
            "MAGDA",
            "MARTINA R.",
            "MARTINA S.",
            "MAGUE",
            "VALENTINA",
            "VICENTE",
            "HERMELINDA",
            "JAVIER",
            "CINTHIA",
            "KAREN",
            "PADILLA",
            "PERSONAL",
            "ALDAMA",
            "PROPIOS",
            "ABASOLO",
            "ALFONSO",
            "BRANDON",
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
            "JUAN CARLOS REGULARES",
            "JUAN CARLOS MORA",
            "LUIS ENRIQUE MENA"});
            this.cbOficiales.Location = new System.Drawing.Point(98, 12);
            this.cbOficiales.Name = "cbOficiales";
            this.cbOficiales.Size = new System.Drawing.Size(121, 27);
            this.cbOficiales.TabIndex = 0;
            this.cbOficiales.SelectedIndexChanged += new System.EventHandler(this.cbOficiales_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oficial(es):";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsultar.Location = new System.Drawing.Point(225, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 27);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvPorcentajesMaj
            // 
            this.dgvPorcentajesMaj.AllowUserToAddRows = false;
            this.dgvPorcentajesMaj.AllowUserToDeleteRows = false;
            this.dgvPorcentajesMaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPorcentajesMaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorcentajesMaj.Location = new System.Drawing.Point(12, 45);
            this.dgvPorcentajesMaj.Name = "dgvPorcentajesMaj";
            this.dgvPorcentajesMaj.ReadOnly = true;
            this.dgvPorcentajesMaj.RowTemplate.Height = 25;
            this.dgvPorcentajesMaj.Size = new System.Drawing.Size(680, 360);
            this.dgvPorcentajesMaj.TabIndex = 3;
            this.dgvPorcentajesMaj.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPorcentajesMaj_CellContentClick);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAtras.Location = new System.Drawing.Point(12, 411);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 27);
            this.btnAtras.TabIndex = 4;
            this.btnAtras.Text = "Salir";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // PorcentajesMaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.dgvPorcentajesMaj);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOficiales);
            this.Name = "PorcentajesMaj";
            this.Text = "PorcentajesMaj";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PorcentajesMaj_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorcentajesMaj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbOficiales;
        private Label label1;
        private Button btnConsultar;
        private DataGridView dgvPorcentajesMaj;
        private Button btnAtras;
    }
}