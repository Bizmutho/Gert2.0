namespace Modulos
{
    partial class Prestamos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prestamos));
            this.label3 = new System.Windows.Forms.Label();
            this.prestamosSinAbrir = new System.Windows.Forms.TabControl();
            this.sinAbrir = new System.Windows.Forms.TabPage();
            this.dataSocios = new System.Windows.Forms.DataGridView();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Activos = new System.Windows.Forms.TabPage();
            this.dataActivos = new System.Windows.Forms.DataGridView();
            this.pictureSalir = new System.Windows.Forms.PictureBox();
            this.pictureRefresh = new System.Windows.Forms.PictureBox();
            this.prestamosSinAbrir.SuspendLayout();
            this.sinAbrir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSocios)).BeginInit();
            this.Activos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataActivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1103, 30);
            this.label3.TabIndex = 23;
            this.label3.Text = "PRÉSTAMOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prestamosSinAbrir
            // 
            this.prestamosSinAbrir.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.prestamosSinAbrir.Controls.Add(this.sinAbrir);
            this.prestamosSinAbrir.Controls.Add(this.Activos);
            this.prestamosSinAbrir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prestamosSinAbrir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.prestamosSinAbrir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.prestamosSinAbrir.Location = new System.Drawing.Point(0, 30);
            this.prestamosSinAbrir.Multiline = true;
            this.prestamosSinAbrir.Name = "prestamosSinAbrir";
            this.prestamosSinAbrir.SelectedIndex = 0;
            this.prestamosSinAbrir.Size = new System.Drawing.Size(1103, 574);
            this.prestamosSinAbrir.TabIndex = 24;
            // 
            // sinAbrir
            // 
            this.sinAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.sinAbrir.Controls.Add(this.dataSocios);
            this.sinAbrir.Controls.Add(this.button7);
            this.sinAbrir.Controls.Add(this.button6);
            this.sinAbrir.Controls.Add(this.button5);
            this.sinAbrir.Controls.Add(this.button4);
            this.sinAbrir.Controls.Add(this.buttonEliminar);
            this.sinAbrir.Controls.Add(this.button2);
            this.sinAbrir.Controls.Add(this.button1);
            this.sinAbrir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sinAbrir.Location = new System.Drawing.Point(4, 29);
            this.sinAbrir.Name = "sinAbrir";
            this.sinAbrir.Padding = new System.Windows.Forms.Padding(3);
            this.sinAbrir.Size = new System.Drawing.Size(1095, 541);
            this.sinAbrir.TabIndex = 0;
            this.sinAbrir.Text = "PRÉSTAMOS SIN ABRIR";
            this.sinAbrir.Click += new System.EventHandler(this.sinAbrir_Click);
            // 
            // dataSocios
            // 
            this.dataSocios.AllowUserToOrderColumns = true;
            this.dataSocios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.dataSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSocios.Location = new System.Drawing.Point(8, 14);
            this.dataSocios.Name = "dataSocios";
            this.dataSocios.RowTemplate.Height = 25;
            this.dataSocios.Size = new System.Drawing.Size(927, 519);
            this.dataSocios.TabIndex = 20;
            this.dataSocios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSocios_CellClick);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button7.Enabled = false;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.Location = new System.Drawing.Point(947, 443);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(135, 43);
            this.button7.TabIndex = 19;
            this.button7.Text = "Exportar";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button6.Enabled = false;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.Location = new System.Drawing.Point(947, 373);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(135, 43);
            this.button6.TabIndex = 19;
            this.button6.Text = "Tarjetón";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button5.Enabled = false;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(947, 307);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(135, 43);
            this.button5.TabIndex = 18;
            this.button5.Text = "Comp. Contrato";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button4.Enabled = false;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(947, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 43);
            this.button4.TabIndex = 17;
            this.button4.Text = "Contrato";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.buttonEliminar.Enabled = false;
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.buttonEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.Location = new System.Drawing.Point(947, 171);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(135, 43);
            this.buttonEliminar.TabIndex = 16;
            this.buttonEliminar.Text = "Cancelar";
            this.buttonEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(947, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 43);
            this.button2.TabIndex = 15;
            this.button2.Text = "Editar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(97)))), ((int)(((byte)(85)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(947, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 43);
            this.button1.TabIndex = 14;
            this.button1.Text = "Agregar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Activos
            // 
            this.Activos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.Activos.Controls.Add(this.dataActivos);
            this.Activos.Location = new System.Drawing.Point(4, 29);
            this.Activos.Name = "Activos";
            this.Activos.Padding = new System.Windows.Forms.Padding(3);
            this.Activos.Size = new System.Drawing.Size(1095, 541);
            this.Activos.TabIndex = 1;
            this.Activos.Text = "PRÉSTAMOS ACTIVOS";
            // 
            // dataActivos
            // 
            this.dataActivos.AllowUserToOrderColumns = true;
            this.dataActivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.dataActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataActivos.Location = new System.Drawing.Point(8, 14);
            this.dataActivos.Name = "dataActivos";
            this.dataActivos.RowTemplate.Height = 25;
            this.dataActivos.Size = new System.Drawing.Size(1079, 519);
            this.dataActivos.TabIndex = 21;
            // 
            // pictureSalir
            // 
            this.pictureSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.pictureSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureSalir.Image = ((System.Drawing.Image)(resources.GetObject("pictureSalir.Image")));
            this.pictureSalir.Location = new System.Drawing.Point(1075, 0);
            this.pictureSalir.Name = "pictureSalir";
            this.pictureSalir.Size = new System.Drawing.Size(28, 27);
            this.pictureSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSalir.TabIndex = 25;
            this.pictureSalir.TabStop = false;
            this.pictureSalir.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureSalir.MouseHover += new System.EventHandler(this.pictureSalir_MouseHover);
            // 
            // pictureRefresh
            // 
            this.pictureRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.pictureRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pictureRefresh.Image")));
            this.pictureRefresh.Location = new System.Drawing.Point(4, 0);
            this.pictureRefresh.Name = "pictureRefresh";
            this.pictureRefresh.Size = new System.Drawing.Size(28, 27);
            this.pictureRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureRefresh.TabIndex = 26;
            this.pictureRefresh.TabStop = false;
            this.pictureRefresh.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureRefresh.MouseHover += new System.EventHandler(this.pictureRefresh_MouseHover);
            // 
            // Prestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1103, 604);
            this.Controls.Add(this.pictureRefresh);
            this.Controls.Add(this.pictureSalir);
            this.Controls.Add(this.prestamosSinAbrir);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Prestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestamos";
            this.Load += new System.EventHandler(this.Prestamos_Load);
            this.prestamosSinAbrir.ResumeLayout(false);
            this.sinAbrir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSocios)).EndInit();
            this.Activos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataActivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label3;
        private TabControl prestamosSinAbrir;
        private TabPage sinAbrir;
        private TabPage Activos;
        private PictureBox pictureSalir;
        private Button button4;
        private Button buttonEliminar;
        private Button button2;
        private Button button1;
        private Button button5;
        private Button button7;
        private Button button6;
        private DataGridView dataActivos;
        private PictureBox pictureRefresh;
        public DataGridView dataSocios;
    }
}