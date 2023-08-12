namespace Modulos
{
    partial class Estatus_Juridico
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
            this.comboLawyer = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.adgvJuridico = new ADGV.AdvancedDataGridView();
            this.FechaOficio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Municipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Socio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oficial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ultimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuertePrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GastosAbogado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abogado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Liquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalDemanda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.adgvJuridico)).BeginInit();
            this.SuspendLayout();
            // 
            // comboLawyer
            // 
            this.comboLawyer.FormattingEnabled = true;
            this.comboLawyer.Location = new System.Drawing.Point(12, 35);
            this.comboLawyer.Name = "comboLawyer";
            this.comboLawyer.Size = new System.Drawing.Size(299, 23);
            this.comboLawyer.TabIndex = 1;
            this.comboLawyer.Text = "Abogado";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(342, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(505, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Editar proceso";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.Location = new System.Drawing.Point(659, 34);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(136, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // adgvJuridico
            // 
            this.adgvJuridico.AllowUserToAddRows = false;
            this.adgvJuridico.AllowUserToDeleteRows = false;
            this.adgvJuridico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adgvJuridico.AutoGenerateContextFilters = true;
            this.adgvJuridico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvJuridico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaOficio,
            this.NoContrato,
            this.Empresa,
            this.Municipio,
            this.Socio,
            this.Oficial,
            this.Inicio,
            this.Ultimo,
            this.Anio,
            this.SuertePrincipal,
            this.Mora,
            this.GastosAbogado,
            this.Total,
            this.Abogado,
            this.Estatus,
            this.Liquido,
            this.Observaciones});
            this.adgvJuridico.DateWithTime = false;
            this.adgvJuridico.Location = new System.Drawing.Point(12, 64);
            this.adgvJuridico.Name = "adgvJuridico";
            this.adgvJuridico.ReadOnly = true;
            this.adgvJuridico.RowTemplate.Height = 25;
            this.adgvJuridico.Size = new System.Drawing.Size(999, 391);
            this.adgvJuridico.TabIndex = 6;
            this.adgvJuridico.TimeFilter = false;
            this.adgvJuridico.SortStringChanged += new System.EventHandler(this.adgvJuridico_SortStringChanged);
            this.adgvJuridico.FilterStringChanged += new System.EventHandler(this.adgvJuridico_FilterStringChanged_1);
            this.adgvJuridico.EnabledChanged += new System.EventHandler(this.adgvJuridico_EnabledChanged);
            // 
            // FechaOficio
            // 
            this.FechaOficio.HeaderText = "Fecha Oficio";
            this.FechaOficio.MinimumWidth = 22;
            this.FechaOficio.Name = "FechaOficio";
            this.FechaOficio.ReadOnly = true;
            this.FechaOficio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // NoContrato
            // 
            this.NoContrato.HeaderText = "No Contrato";
            this.NoContrato.MinimumWidth = 22;
            this.NoContrato.Name = "NoContrato";
            this.NoContrato.ReadOnly = true;
            this.NoContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Empresa
            // 
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.MinimumWidth = 22;
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Municipio
            // 
            this.Municipio.HeaderText = "Muinicipio";
            this.Municipio.MinimumWidth = 22;
            this.Municipio.Name = "Municipio";
            this.Municipio.ReadOnly = true;
            this.Municipio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Socio
            // 
            this.Socio.HeaderText = "Socio";
            this.Socio.MinimumWidth = 22;
            this.Socio.Name = "Socio";
            this.Socio.ReadOnly = true;
            this.Socio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Oficial
            // 
            this.Oficial.HeaderText = "Oficial";
            this.Oficial.MinimumWidth = 22;
            this.Oficial.Name = "Oficial";
            this.Oficial.ReadOnly = true;
            this.Oficial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Inicio
            // 
            this.Inicio.HeaderText = "Inicio";
            this.Inicio.MinimumWidth = 22;
            this.Inicio.Name = "Inicio";
            this.Inicio.ReadOnly = true;
            this.Inicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ultimo
            // 
            this.Ultimo.HeaderText = "Ultimo Pago";
            this.Ultimo.MinimumWidth = 22;
            this.Ultimo.Name = "Ultimo";
            this.Ultimo.ReadOnly = true;
            this.Ultimo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Anio
            // 
            this.Anio.HeaderText = "Año";
            this.Anio.MinimumWidth = 22;
            this.Anio.Name = "Anio";
            this.Anio.ReadOnly = true;
            this.Anio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SuertePrincipal
            // 
            this.SuertePrincipal.HeaderText = "Suerte Principal";
            this.SuertePrincipal.MinimumWidth = 22;
            this.SuertePrincipal.Name = "SuertePrincipal";
            this.SuertePrincipal.ReadOnly = true;
            this.SuertePrincipal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Mora
            // 
            this.Mora.HeaderText = "Intereses Moratorios";
            this.Mora.MinimumWidth = 22;
            this.Mora.Name = "Mora";
            this.Mora.ReadOnly = true;
            this.Mora.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // GastosAbogado
            // 
            this.GastosAbogado.HeaderText = "Gastos Abogado";
            this.GastosAbogado.MinimumWidth = 22;
            this.GastosAbogado.Name = "GastosAbogado";
            this.GastosAbogado.ReadOnly = true;
            this.GastosAbogado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total Demanda";
            this.Total.MinimumWidth = 22;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Abogado
            // 
            this.Abogado.HeaderText = "Abogado";
            this.Abogado.MinimumWidth = 22;
            this.Abogado.Name = "Abogado";
            this.Abogado.ReadOnly = true;
            this.Abogado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Estatus
            // 
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.MinimumWidth = 22;
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Liquido
            // 
            this.Liquido.HeaderText = "Liquido con";
            this.Liquido.MinimumWidth = 22;
            this.Liquido.Name = "Liquido";
            this.Liquido.ReadOnly = true;
            this.Liquido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Observaciones
            // 
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.MinimumWidth = 22;
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(743, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total en demanda:";
            // 
            // txtTotalDemanda
            // 
            this.txtTotalDemanda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDemanda.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTotalDemanda.ForeColor = System.Drawing.SystemColors.Control;
            this.txtTotalDemanda.Location = new System.Drawing.Point(891, 458);
            this.txtTotalDemanda.Name = "txtTotalDemanda";
            this.txtTotalDemanda.Size = new System.Drawing.Size(120, 17);
            this.txtTotalDemanda.TabIndex = 8;
            this.txtTotalDemanda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Estatus_Juridico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1023, 484);
            this.Controls.Add(this.txtTotalDemanda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adgvJuridico);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboLawyer);
            this.Name = "Estatus_Juridico";
            this.Text = "Estatus_Juridico";
            ((System.ComponentModel.ISupportInitialize)(this.adgvJuridico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox comboLawyer;
        private Button button1;
        private Button button2;
        private Button btnEliminar;
        private ADGV.AdvancedDataGridView adgvJuridico;
        private DataGridViewTextBoxColumn FechaOficio;
        private DataGridViewTextBoxColumn NoContrato;
        private DataGridViewTextBoxColumn Empresa;
        private DataGridViewTextBoxColumn Municipio;
        private DataGridViewTextBoxColumn Socio;
        private DataGridViewTextBoxColumn Oficial;
        private DataGridViewTextBoxColumn Inicio;
        private DataGridViewTextBoxColumn Ultimo;
        private DataGridViewTextBoxColumn Anio;
        private DataGridViewTextBoxColumn SuertePrincipal;
        private DataGridViewTextBoxColumn Mora;
        private DataGridViewTextBoxColumn GastosAbogado;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Abogado;
        private DataGridViewTextBoxColumn Estatus;
        private DataGridViewTextBoxColumn Liquido;
        private DataGridViewTextBoxColumn Observaciones;
        private Label label1;
        private Label txtTotalDemanda;
    }
}