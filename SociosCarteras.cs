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
using Modulos;
using DocumentFormat.OpenXml.Office2013.Excel;

namespace Modulos.Modelos
{
    public partial class SociosCarteras : Form
    {
        


        public SociosCarteras()
        {
            InitializeComponent();

            

            StartPosition = FormStartPosition.CenterScreen;

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SociosCarteras_Load(object sender, EventArgs e)
        {
                     


        }


        private void button1_Click(object sender, EventArgs e)
        {
            SociosCarteras_controller sc2 = new SociosCarteras_controller();
            sc2.ConsultaTabla(tablaSocios, listaOficial.SelectedIndex);

        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SociosCarteras_controller sc3 = new SociosCarteras_controller();
            sc3.exportarTabla(tablaSocios);
        }

        private void tablaSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
           nombre1.Text = this.tablaSocios.CurrentRow.Cells["Nombre"].Value.ToString();
            



        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            
            Modulos.ProcesoJuridico pj = new Modulos.ProcesoJuridico();
            pj.Show();
            pj.NoContrato.Text = this.tablaSocios.CurrentRow.Cells["Id"].Value.ToString();
            pj.Show();

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureBox2, "SALIR");
        }
    }
}
