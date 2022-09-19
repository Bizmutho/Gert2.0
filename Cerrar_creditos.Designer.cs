namespace Modulos
{
    partial class Cerrar_creditos
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
            this.dgvCreditos = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbLimite = new System.Windows.Forms.TextBox();
            this.dgvQuincenas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDepositos = new System.Windows.Forms.DataGridView();
            this.btnTerminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuincenas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCreditos
            // 
            this.dgvCreditos.AllowUserToAddRows = false;
            this.dgvCreditos.AllowUserToDeleteRows = false;
            this.dgvCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreditos.Location = new System.Drawing.Point(12, 43);
            this.dgvCreditos.Name = "dgvCreditos";
            this.dgvCreditos.RowTemplate.Height = 25;
            this.dgvCreditos.Size = new System.Drawing.Size(327, 479);
            this.dgvCreditos.TabIndex = 0;
            this.dgvCreditos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCreditos_CellClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Location = new System.Drawing.Point(250, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(89, 25);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Deuda debajo de:";
            // 
            // txbLimite
            // 
            this.txbLimite.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txbLimite.Location = new System.Drawing.Point(140, 12);
            this.txbLimite.Name = "txbLimite";
            this.txbLimite.Size = new System.Drawing.Size(104, 25);
            this.txbLimite.TabIndex = 4;
            // 
            // dgvQuincenas
            // 
            this.dgvQuincenas.AllowUserToAddRows = false;
            this.dgvQuincenas.AllowUserToDeleteRows = false;
            this.dgvQuincenas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuincenas.Location = new System.Drawing.Point(345, 63);
            this.dgvQuincenas.Name = "dgvQuincenas";
            this.dgvQuincenas.ReadOnly = true;
            this.dgvQuincenas.RowTemplate.Height = 25;
            this.dgvQuincenas.Size = new System.Drawing.Size(347, 211);
            this.dgvQuincenas.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(345, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quincenas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(345, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Depositos:";
            // 
            // dgvDepositos
            // 
            this.dgvDepositos.AllowUserToAddRows = false;
            this.dgvDepositos.AllowUserToDeleteRows = false;
            this.dgvDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepositos.Location = new System.Drawing.Point(345, 297);
            this.dgvDepositos.Name = "dgvDepositos";
            this.dgvDepositos.ReadOnly = true;
            this.dgvDepositos.RowTemplate.Height = 25;
            this.dgvDepositos.Size = new System.Drawing.Size(347, 194);
            this.dgvDepositos.TabIndex = 8;
            // 
            // btnTerminar
            // 
            this.btnTerminar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTerminar.Location = new System.Drawing.Point(345, 497);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(347, 25);
            this.btnTerminar.TabIndex = 10;
            this.btnTerminar.Text = "Terminar creditos";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // Cerrar_creditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 534);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.dgvDepositos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvQuincenas);
            this.Controls.Add(this.txbLimite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvCreditos);
            this.Name = "Cerrar_creditos";
            this.Text = "Cerrar_creditos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuincenas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepositos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvCreditos;
        private Button btnBuscar;
        private Label label1;
        private TextBox txbLimite;
        private DataGridView dgvQuincenas;
        private Label label2;
        private Label label3;
        private DataGridView dgvDepositos;
        private Button btnTerminar;
    }
}