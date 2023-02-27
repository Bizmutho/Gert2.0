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
            this.adgvJuridico = new ADGV.AdvancedDataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
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
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(505, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Editar proceso";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.adgvJuridico.DateWithTime = false;
            this.adgvJuridico.Location = new System.Drawing.Point(12, 88);
            this.adgvJuridico.Name = "adgvJuridico";
            this.adgvJuridico.ReadOnly = true;
            this.adgvJuridico.RowTemplate.Height = 25;
            this.adgvJuridico.Size = new System.Drawing.Size(999, 350);
            this.adgvJuridico.TabIndex = 4;
            this.adgvJuridico.TimeFilter = false;
            this.adgvJuridico.SortStringChanged += new System.EventHandler(this.adgvJuridico_SortStringChanged_1);
            this.adgvJuridico.FilterStringChanged += new System.EventHandler(this.adgvJuridico_FilterStringChanged);
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
            // Estatus_Juridico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1023, 450);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.adgvJuridico);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboLawyer);
            this.Name = "Estatus_Juridico";
            this.Text = "Estatus_Juridico";
            ((System.ComponentModel.ISupportInitialize)(this.adgvJuridico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox comboLawyer;
        private Button button1;
        private Button button2;
        private ADGV.AdvancedDataGridView adgvJuridico;
        private Button btnEliminar;
    }
}