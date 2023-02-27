using Microsoft.Office.Interop.Excel;
using Modulos.Clases;
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
        int i = 0;
       
        public ProcesoJuridico(int ix)
        {
            InitializeComponent();
            Con = new Conexion();
            i = ix;
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
            
        }

        private void cancelarJuridico_MouseHover(object sender, EventArgs e)
        {
            //cancelarJuridico.Size = new System.Drawing.Size(92, 92);

            //System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            //ToolTip1.SetToolTip(this.cancelarJuridico, "CANCELAR");

        }

        private void cancelarJuridico_MouseLeave(object sender, EventArgs e)
        {
            //cancelarJuridico.Size = new System.Drawing.Size(82, 82);
        }

        private void guardarJuridico_MouseHover(object sender, EventArgs e)
        {
            //guardarJuridico.Size = new System.Drawing.Size(92, 92);

            //System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            //ToolTip1.SetToolTip(this.guardarJuridico, "GUARDAR");
        }

        private void guardarJuridico_MouseLeave(object sender, EventArgs e)
        {
            //guardarJuridico.Size = new System.Drawing.Size(82, 82);
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
         

        }

        private void listAbogado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (i==0)
            {
                Con.crearConexion();
                Con.OpenConnection();

                String queryCheckExist = "SELECT IdPrestamo FROM estatus_juridico where IdPrestamo = "+ NoContrato.Text + " and Activo = 1;";
                MySqlCommand cmdCheck = new MySqlCommand(queryCheckExist, Con.GetConnection());
                cmdCheck.CommandTimeout = 100000;
                MySqlDataReader data = cmdCheck.ExecuteReader();
                Boolean exist = !data.HasRows;

                Con.CloseConnection();
                Con.crearConexion();
                Con.OpenConnection();

                if (exist)
                {
                    string query = ("INSERT INTO estatus_juridico(IdPrestamo, FechaOficio, TotalDemanda, Abogado, Estatus, Observacion) VALUES" +
                    "('" + NoContrato.Text + "', '" + fechaOficio.Text + "', '" + totalDemanda.Text + "', '" + listAbogado.SelectedValue + "', '" + listStatus.Text + "' , '" + txtObsBox.Text + "', 1);");
                    MySqlCommand cmdJuridico = new MySqlCommand(query, Con.GetConnection());
                    cmdJuridico.CommandTimeout = 100000;
                    cmdJuridico.ExecuteNonQuery();


                    MessageBox.Show("REGISTRO EXITOSO");
                    Console.WriteLine("i= " + i);

                    NoContrato.Text = "";
                    fechaOficio.Text = "";
                    totalDemanda.Text = "";
                    listAbogado.Text = "";
                    listStatus.Text = "";
                    txtObsBox.Text = "";
                } else
                {
                    MessageBox.Show("EL SOCIO YA SE ENCUENTRA EN PROCESO JURIDICO");
                }
            } else
            {
                Console.WriteLine("Entró al update");
                string f = fechaOficio.Text;
                string d = totalDemanda.Text;
                string s = listStatus.Text;
                string i = NoContrato.Text;
                string o = txtObsBox.Text;
                EstatusJuridico_Controller ej = new EstatusJuridico_Controller();
                ej.updateJuridico(f, d, s, i, o);
                this.Close();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
