namespace Modulos
{
    partial class ActualizarOficial
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
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tbOficialId = new System.Windows.Forms.TextBox();
            this.rtbContratos = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(156, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(142, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // tbOficialId
            // 
            this.tbOficialId.Location = new System.Drawing.Point(12, 12);
            this.tbOficialId.Name = "tbOficialId";
            this.tbOficialId.Size = new System.Drawing.Size(138, 23);
            this.tbOficialId.TabIndex = 2;
            // 
            // rtbContratos
            // 
            this.rtbContratos.Location = new System.Drawing.Point(12, 41);
            this.rtbContratos.Name = "rtbContratos";
            this.rtbContratos.Size = new System.Drawing.Size(286, 268);
            this.rtbContratos.TabIndex = 4;
            this.rtbContratos.Text = "";
            // 
            // ActualizarOficial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 321);
            this.Controls.Add(this.rtbContratos);
            this.Controls.Add(this.tbOficialId);
            this.Controls.Add(this.btnActualizar);
            this.Name = "ActualizarOficial";
            this.Text = "Actualizar_Oficial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnActualizar;
        private TextBox tbOficialId;
        private RichTextBox rtbContratos;
    }
}