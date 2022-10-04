using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Modulos
{
    public partial class ProcesoJuridico : Form
    {
        Conexion Con;
        public ProcesoJuridico()
        {
            InitializeComponent();
            Con = new Conexion();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NoContrato_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void totalDemanda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números");
                e.Handled = true;
                return;
            }
            
        }

        private void listAbogado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ProcesoJuridico_Load(object sender, EventArgs e)
        {
            SociosCarteras_controller sc = new SociosCarteras_controller();
            sc.comboAbogado(listAbogado);
        }

        private void cancelarJuridico_Click(object sender, EventArgs e)
        {
            fechaOficio.Text = "";
            totalDemanda.Text = "";
            listAbogado.Text = "";
            listStatus.Text = "";
        }

        private void cancelarJuridico_MouseHover(object sender, EventArgs e)
        {
            cancelarJuridico.Size = new System.Drawing.Size(92, 92);

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.cancelarJuridico, "CANCELAR");

        }

        private void cancelarJuridico_MouseLeave(object sender, EventArgs e)
        {
            cancelarJuridico.Size = new System.Drawing.Size(82, 82);
        }

        private void guardarJuridico_MouseHover(object sender, EventArgs e)
        {
            guardarJuridico.Size = new System.Drawing.Size(92, 92);

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.guardarJuridico, "GUARDAR");
        }

        private void guardarJuridico_MouseLeave(object sender, EventArgs e)
        {
            guardarJuridico.Size = new System.Drawing.Size(82, 82);
        }

        private void salir_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.salir, "SALIR");
        }

        private void listAbogado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void guardarJuridico_Click(object sender, EventArgs e)
        {
            Con.crearConexion();
            Con.OpenConnection();
           
            string query = ("INSERT INTO emprendedor.estatus_juridico(IdPrestamo, FechaOficio, TotalDemanda, Abogado, Estatus) VALUES" +
                "('"+NoContrato.Text+"', '"+fechaOficio.Text+"', '"+totalDemanda.Text+"', '"+listAbogado.SelectedValue+"', '"+listStatus.Text+"');");
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());
           
            cmd.ExecuteNonQuery();

            
            MessageBox.Show("REGISTRO EXITOSO");

      
            NoContrato.Text = "";
            fechaOficio.Text = "";
            totalDemanda.Text = "";
            listAbogado.Text = "";
            listStatus.Text = "";


        }

        private void listAbogado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
    }
}
