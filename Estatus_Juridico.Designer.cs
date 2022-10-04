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
            this.dataGridProcesos = new System.Windows.Forms.DataGridView();
            this.comboLawyer = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcesos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridProcesos
            // 
            this.dataGridProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProcesos.Location = new System.Drawing.Point(12, 76);
            this.dataGridProcesos.Name = "dataGridProcesos";
            this.dataGridProcesos.RowTemplate.Height = 25;
            this.dataGridProcesos.Size = new System.Drawing.Size(776, 318);
            this.dataGridProcesos.TabIndex = 0;
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
            this.button1.Location = new System.Drawing.Point(342, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(505, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Editar proceso";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Estatus_Juridico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboLawyer);
            this.Controls.Add(this.dataGridProcesos);
            this.Name = "Estatus_Juridico";
            this.Text = "Estatus_Juridico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcesos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridProcesos;
        private ComboBox comboLawyer;
        private Button button1;
        private Button button2;
    }
}