using Modulos.Clases;
using Modulos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moratorios
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

        }

        private void Moratorios_Click(object sender, EventArgs e)
        {
            MoratoriosNo mor = new MoratoriosNo();
            mor.Show();
        }

        private void btnInversion_Click(object sender, EventArgs e)
        {
            Inversion inv = new Inversion();
            inv.Show();
        }

        private void btnPoAtz_Click(object sender, EventArgs e)
        {
            PorcentajesAtz pa = new PorcentajesAtz();
            pa.Show();
        }

        private void btnPorMaj_Click(object sender, EventArgs e)
        {
            PorcentajesMaj pm = new PorcentajesMaj();
            pm.Show();
        }

        private void btnListaMora_Click(object sender, EventArgs e)
        {
            ListaMora lm = new ListaMora();
            lm.Show();
        }

        private void btnRfc_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Todas las ventanas se cerraran, Seguro que quieres salir?", "Salir",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                Application.ExitThread();
                Application.Exit();
            } else
            {
                e.Cancel = true;
            }
        }

        private void btnCaptura_Click(object sender, EventArgs e)
        {
            Modulos.Captura cap = new Modulos.Captura();
            cap.Show();
        }

        private void btnSonia_Click(object sender, EventArgs e)
        {
            Modulos.DatosSocio ds = new Modulos.DatosSocio();
            ds.Show();
        }

        private void btnCarteras_Click(object sender, EventArgs e)
        {
            Modulos.Carteras car = new Modulos.Carteras();
            car.Show();
        }

        private void btnContpaq_Click(object sender, EventArgs e)
        {
            Modulos.Contpaq contpaq = new Modulos.Contpaq();
            contpaq.Show();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            Modulos.Cerrar_creditos cc = new Modulos.Cerrar_creditos();
            cc.Show();
        }

        private void btnDepositos_Click(object sender, EventArgs e)
        {
            Modulos.Depositos depositos = new Modulos.Depositos();
            depositos.Show();
        }

        private void btnPagosQuincena_Click(object sender, EventArgs e)
        {
            Modulos.PagosQuincena pq = new Modulos.PagosQuincena();
            pq.Show();
        }

        private void btnMorosidadCarteras_Click(object sender, EventArgs e)
        {
            Modulos.Morosidad_Cartera mc = new Modulos.Morosidad_Cartera();
            mc.Show();
        }

        private void btnCirculoCredito_Click(object sender, EventArgs e)
        {
            CirculoCredito_Controller ccc = new CirculoCredito_Controller();
            ccc.reporte();
        }

        private void btnMoratorios_Click(object sender, EventArgs e)
        {
            Modulos.Moratorios moratorios = new Modulos.Moratorios();
            moratorios.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SociosCarteras sc = new SociosCarteras();
            sc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modulos.Estatus_Juridico ej= new Modulos.Estatus_Juridico();
            ej.Show();
        }
    }
}
