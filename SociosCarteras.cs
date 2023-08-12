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
using DocumentFormat.OpenXml.Office2013.Excel;
using Modulos.Clases;

namespace Modulos.Modelos
{
    public partial class SociosCarteras : Form
    {
        List<(int, String)> oficiales;

        public SociosCarteras()
        {
            InitializeComponent();

            

            StartPosition = FormStartPosition.CenterScreen;

            obtenerOficiales();
            listaOficial.SelectedIndex = 0;
        }

        private void obtenerOficiales()
        {
            oficiales = new List<(int, string)>();
            MorosidadCartera_Controller mcc = new MorosidadCartera_Controller();
            oficiales = mcc.obtenerOficiales();

            listaOficial.Items.Clear();

            if (oficiales.Count != 0)
            {
                oficiales.ForEach(oficiales => listaOficial.Items.Add(oficiales.Item2));

            }
            else
            {
                listaOficial.Items.Add("Sin datos.");
            }
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
            sc2.ConsultaTabla(tablaSocios, oficiales[listaOficial.SelectedIndex].Item1);
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
            
            Modulos.ProcesoJuridico pj = new Modulos.ProcesoJuridico(0);
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
