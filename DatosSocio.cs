using Modulos.Clases;
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
    public partial class DatosSocio : Form
    {
        List<(String, String)> socios;
        List<(String, String)> sociosFiltrados;
        DatosSocio_Controller ds;
        public DatosSocio()
        {
            InitializeComponent();
            ds = new DatosSocio_Controller();
            socios = ds.listaSocios();

            socios.ForEach(s =>
            {
                cbSocios.Items.Add(s.Item1 + " - " + s.Item2);
            });

        }

        private void cbSocios_TextUpdate(object sender, EventArgs e)
        {
            String txt = cbSocios.Text;

            sociosFiltrados = socios.FindAll(s => s.Item1.ToLower().Contains(txt.ToLower()) || s.Item2.ToLower().Contains(txt.ToLower()));

            cbSocios.Items.Clear();

            sociosFiltrados.ForEach(s =>
            {
                cbSocios.Items.Add(s.Item1 + " - " + s.Item2);
            });

            cbSocios.DroppedDown = true;

            cbSocios.IntegralHeight = false;

            cbSocios.SelectedIndex = -1;

            cbSocios.Text = txt;

            cbSocios.SelectionStart = txt.Length;

            cbSocios.SelectionLength = 0;

            cbSocios.DropDownHeight = 150;
        }

        private void cbSocios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cbSocios.SelectedIndex = (cbSocios.SelectedIndex < 0)? 0 : cbSocios.SelectedIndex;

                String[] socio = ds.datosSocio((sociosFiltrados != null) ? sociosFiltrados[cbSocios.SelectedIndex].Item1 : socios[cbSocios.SelectedIndex].Item1);

                lblSocio.Text = socio[0];
                lblTelefono.Text = socio[1];
                lblDireccion.Text = socio[2];
                lblAval.Text = socio[3];
                lblAvalTelefono.Text = socio[4];
                lblAvalDireccion.Text = socio[5];
                lblRFC.Text = socio[6];
            }
        }
    }
}
