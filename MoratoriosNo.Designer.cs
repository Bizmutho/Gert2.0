namespace Moratorios
{
    partial class MoratoriosNo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMoratorios = new System.Windows.Forms.DataGridView();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtContrato = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txbOperacion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSocioNombres = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOficialNombres = new System.Windows.Forms.Label();
            this.lblSocioApellidos = new System.Windows.Forms.Label();
            this.lblOficialApellidos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbPorcentaje = new System.Windows.Forms.TextBox();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoratorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMoratorios
            // 
            this.dgvMoratorios.AllowUserToAddRows = false;
            this.dgvMoratorios.AllowUserToDeleteRows = false;
            this.dgvMoratorios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMoratorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoratorios.Location = new System.Drawing.Point(12, 12);
            this.dgvMoratorios.Name = "dgvMoratorios";
            this.dgvMoratorios.ReadOnly = true;
            this.dgvMoratorios.RowTemplate.Height = 25;
            this.dgvMoratorios.Size = new System.Drawing.Size(494, 550);
            this.dgvMoratorios.TabIndex = 2;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcular.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalcular.Location = new System.Drawing.Point(635, 34);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(119, 23);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtContrato
            // 
            this.txtContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrato.Location = new System.Drawing.Point(512, 34);
            this.txtContrato.Name = "txtContrato";
            this.txtContrato.Size = new System.Drawing.Size(117, 23);
            this.txtContrato.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(512, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contrato:";
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(512, 113);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.RowTemplate.Height = 25;
            this.dgvResultados.Size = new System.Drawing.Size(242, 130);
            this.dgvResultados.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(512, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Gastos de operación:";
            // 
            // txbOperacion
            // 
            this.txbOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbOperacion.Location = new System.Drawing.Point(512, 84);
            this.txbOperacion.Name = "txbOperacion";
            this.txbOperacion.Size = new System.Drawing.Size(117, 23);
            this.txbOperacion.TabIndex = 7;
            this.txbOperacion.TextChanged += new System.EventHandler(this.txbOperacion_TextChanged);
            this.txbOperacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbOperacion_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.Location = new System.Drawing.Point(635, 84);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(512, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Socio:";
            // 
            // lblSocioNombres
            // 
            this.lblSocioNombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSocioNombres.AutoSize = true;
            this.lblSocioNombres.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSocioNombres.Location = new System.Drawing.Point(512, 265);
            this.lblSocioNombres.Name = "lblSocioNombres";
            this.lblSocioNombres.Size = new System.Drawing.Size(0, 19);
            this.lblSocioNombres.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(512, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Oficial de credito:";
            // 
            // lblOficialNombres
            // 
            this.lblOficialNombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOficialNombres.AutoSize = true;
            this.lblOficialNombres.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOficialNombres.Location = new System.Drawing.Point(512, 322);
            this.lblOficialNombres.Name = "lblOficialNombres";
            this.lblOficialNombres.Size = new System.Drawing.Size(0, 19);
            this.lblOficialNombres.TabIndex = 12;
            // 
            // lblSocioApellidos
            // 
            this.lblSocioApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSocioApellidos.AutoSize = true;
            this.lblSocioApellidos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSocioApellidos.Location = new System.Drawing.Point(512, 284);
            this.lblSocioApellidos.Name = "lblSocioApellidos";
            this.lblSocioApellidos.Size = new System.Drawing.Size(0, 19);
            this.lblSocioApellidos.TabIndex = 13;
            // 
            // lblOficialApellidos
            // 
            this.lblOficialApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOficialApellidos.AutoSize = true;
            this.lblOficialApellidos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOficialApellidos.Location = new System.Drawing.Point(512, 341);
            this.lblOficialApellidos.Name = "lblOficialApellidos";
            this.lblOficialApellidos.Size = new System.Drawing.Size(0, 19);
            this.lblOficialApellidos.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Porcentaje moratorios:";
            // 
            // txbPorcentaje
            // 
            this.txbPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPorcentaje.Location = new System.Drawing.Point(512, 447);
            this.txbPorcentaje.Name = "txbPorcentaje";
            this.txbPorcentaje.Size = new System.Drawing.Size(127, 23);
            this.txbPorcentaje.TabIndex = 16;
            this.txbPorcentaje.Text = "30";
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtras.Location = new System.Drawing.Point(679, 539);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 17;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // Moratorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 574);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.txbPorcentaje);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblOficialApellidos);
            this.Controls.Add(this.lblSocioApellidos);
            this.Controls.Add(this.lblOficialNombres);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSocioNombres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txbOperacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.dgvMoratorios);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtContrato);
            this.Controls.Add(this.label1);
            this.Name = "Moratorios";
            this.Text = "Moratorios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Moratorios_FormClosing);
            this.Load += new System.EventHandler(this.Moratorios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoratorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvMoratorios;
        private Button btnCalcular;
        private TextBox txtContrato;
        private Label label1;
        private DataGridView dgvResultados;
        private Label label2;
        private TextBox txbOperacion;
        private Button btnAgregar;
        private Label label3;
        private Label lblSocioNombres;
        private Label label5;
        private Label lblOficialNombres;
        private Label lblSocioApellidos;
        private Label lblOficialApellidos;
        private Label label4;
        private TextBox txbPorcentaje;
        private Button btnAtras;
    }
}