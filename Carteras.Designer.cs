namespace Modulos
{
    partial class Carteras
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
            this.cbCarteras = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFaltante = new System.Windows.Forms.Label();
            this.lblRecuperado = new System.Windows.Forms.Label();
            this.lblRecuperar = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblSocios = new System.Windows.Forms.Label();
            this.dgvCartera = new System.Windows.Forms.DataGridView();
            this.cbPorcentajes = new System.Windows.Forms.CheckBox();
            this.cbPagos = new System.Windows.Forms.CheckBox();
            this.cbGeneral = new System.Windows.Forms.CheckBox();
            this.lblQuincena = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartera)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCarteras
            // 
            this.cbCarteras.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbCarteras.FormattingEnabled = true;
            this.cbCarteras.Location = new System.Drawing.Point(12, 12);
            this.cbCarteras.Name = "cbCarteras";
            this.cbCarteras.Size = new System.Drawing.Size(368, 25);
            this.cbCarteras.TabIndex = 0;
            this.cbCarteras.TextUpdate += new System.EventHandler(this.cbCarteras_TextUpdate);
            this.cbCarteras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCarteras_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQuincena);
            this.groupBox1.Controls.Add(this.lblFaltante);
            this.groupBox1.Controls.Add(this.lblRecuperado);
            this.groupBox1.Controls.Add(this.lblRecuperar);
            this.groupBox1.Controls.Add(this.lblPorcentaje);
            this.groupBox1.Controls.Add(this.lblSocios);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 397);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos generales:";
            // 
            // lblFaltante
            // 
            this.lblFaltante.AutoSize = true;
            this.lblFaltante.Location = new System.Drawing.Point(6, 89);
            this.lblFaltante.Name = "lblFaltante";
            this.lblFaltante.Size = new System.Drawing.Size(104, 17);
            this.lblFaltante.TabIndex = 4;
            this.lblFaltante.Text = "Por recuperar:";
            // 
            // lblRecuperado
            // 
            this.lblRecuperado.AutoSize = true;
            this.lblRecuperado.Location = new System.Drawing.Point(6, 72);
            this.lblRecuperado.Name = "lblRecuperado";
            this.lblRecuperado.Size = new System.Drawing.Size(92, 17);
            this.lblRecuperado.TabIndex = 3;
            this.lblRecuperado.Text = "Recuperado:";
            // 
            // lblRecuperar
            // 
            this.lblRecuperar.AutoSize = true;
            this.lblRecuperar.Location = new System.Drawing.Point(6, 55);
            this.lblRecuperar.Name = "lblRecuperar";
            this.lblRecuperar.Size = new System.Drawing.Size(150, 17);
            this.lblRecuperar.TabIndex = 2;
            this.lblRecuperar.Text = "Cantidad a recuperar:";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(6, 38);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(83, 17);
            this.lblPorcentaje.TabIndex = 1;
            this.lblPorcentaje.Text = "Porcentaje:";
            // 
            // lblSocios
            // 
            this.lblSocios.AutoSize = true;
            this.lblSocios.Location = new System.Drawing.Point(6, 21);
            this.lblSocios.Name = "lblSocios";
            this.lblSocios.Size = new System.Drawing.Size(105, 17);
            this.lblSocios.TabIndex = 0;
            this.lblSocios.Text = "Socios activos:";
            // 
            // dgvCartera
            // 
            this.dgvCartera.AllowUserToAddRows = false;
            this.dgvCartera.AllowUserToDeleteRows = false;
            this.dgvCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartera.Location = new System.Drawing.Point(260, 51);
            this.dgvCartera.Name = "dgvCartera";
            this.dgvCartera.ReadOnly = true;
            this.dgvCartera.RowTemplate.Height = 25;
            this.dgvCartera.Size = new System.Drawing.Size(516, 387);
            this.dgvCartera.TabIndex = 2;
            // 
            // cbPorcentajes
            // 
            this.cbPorcentajes.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbPorcentajes.Location = new System.Drawing.Point(650, 8);
            this.cbPorcentajes.Name = "cbPorcentajes";
            this.cbPorcentajes.Size = new System.Drawing.Size(126, 33);
            this.cbPorcentajes.TabIndex = 3;
            this.cbPorcentajes.Text = "Porcentajes";
            this.cbPorcentajes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbPorcentajes.UseVisualStyleBackColor = true;
            // 
            // cbPagos
            // 
            this.cbPagos.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbPagos.Location = new System.Drawing.Point(386, 8);
            this.cbPagos.Name = "cbPagos";
            this.cbPagos.Size = new System.Drawing.Size(126, 33);
            this.cbPagos.TabIndex = 4;
            this.cbPagos.Text = "Socios/Pagos";
            this.cbPagos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbPagos.UseVisualStyleBackColor = true;
            // 
            // cbGeneral
            // 
            this.cbGeneral.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbGeneral.Location = new System.Drawing.Point(518, 8);
            this.cbGeneral.Name = "cbGeneral";
            this.cbGeneral.Size = new System.Drawing.Size(126, 33);
            this.cbGeneral.TabIndex = 5;
            this.cbGeneral.Text = "Generales";
            this.cbGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGeneral.UseVisualStyleBackColor = true;
            // 
            // lblQuincena
            // 
            this.lblQuincena.AutoSize = true;
            this.lblQuincena.Location = new System.Drawing.Point(6, 377);
            this.lblQuincena.Name = "lblQuincena";
            this.lblQuincena.Size = new System.Drawing.Size(117, 17);
            this.lblQuincena.TabIndex = 5;
            this.lblQuincena.Text = "Quincena activa:";
            // 
            // Carteras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbGeneral);
            this.Controls.Add(this.cbPagos);
            this.Controls.Add(this.cbPorcentajes);
            this.Controls.Add(this.dgvCartera);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbCarteras);
            this.Name = "Carteras";
            this.Text = "Carteras";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbCarteras;
        private GroupBox groupBox1;
        private DataGridView dgvCartera;
        private CheckBox cbPorcentajes;
        private CheckBox cbPagos;
        private CheckBox cbGeneral;
        private Label lblFaltante;
        private Label lblRecuperado;
        private Label lblRecuperar;
        private Label lblPorcentaje;
        private Label lblSocios;
        private Label lblQuincena;
    }
}