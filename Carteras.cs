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
    public partial class Carteras : Form
    {
        List<(String, String)> carteras;
        List<(String, String)> carterasFiltradas;
        Carteras_Controller cc;
        bool filtrado = false;
        DataTable dtm;
        int sActivos;
        double aRecuperar, recuperado, pRecuperar, porcentaje;

        public Carteras()
        {
            InitializeComponent();

            cc = new Carteras_Controller();

            cbPagos.Appearance = System.Windows.Forms.Appearance.Button;
            cbPagos.Checked = true;
            cbGeneral.Appearance = System.Windows.Forms.Appearance.Button;
            cbPorcentajes.Appearance = System.Windows.Forms.Appearance.Button;

            DateTime qncAct = DateTime.Now;

            if (qncAct.Day < 15)
            {
                if (qncAct.Day < 12)
                {
                    qncAct = new DateTime((qncAct.Month == 1) ? qncAct.Year - 1 : qncAct.Year, (qncAct.Month == 1) ? 12 : (qncAct.Month - 1), DateTime.DaysInMonth((qncAct.Month == 1) ? qncAct.Year - 1 : qncAct.Year, (qncAct.Month == 1) ? 12 : (qncAct.Month - 1)));
                }
                else
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, 15);
                }
            }
            else
            {
                if (qncAct.Day >= (DateTime.DaysInMonth(qncAct.Year, qncAct.Month) - 3))
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, DateTime.DaysInMonth(qncAct.Year, qncAct.Month));
                }
                else
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, 15);
                }
            }

            qncAct = new DateTime(2022,2,15);

            lblQuincena.Text = "Quincena activa: " + qncAct.Year + "/" + qncAct.Month.ToString("00") + "/" + qncAct.Day.ToString("00");

            carteras = cc.carteras();

            carteras.ForEach(cartera =>
            {
                cbCarteras.Items.Add(cartera.Item1 + " - " + cartera.Item2);
            });
            cbCarteras.SelectedIndex = 0;

            formatoTabla();

            dgvCartera.DataSource = dtm;
            dgvCartera.RowHeadersVisible = false;

            dgvCartera.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCartera.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCartera.Columns[0].Width = 90;

            dgvCartera.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;


            dgvCartera.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCartera.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCartera.Columns[2].Width = 70;

            dgvCartera.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCartera.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCartera.Columns[3].Width = 80;

            dgvCartera.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCartera.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCartera.Columns[4].Width = 80;

            dgvCartera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCartera.Refresh();
        }

        public void formatoTabla()
        {
            dtm = new DataTable();
            dtm.Columns.Add("No. Contrato");
            dtm.Columns.Add("Socio");
            dtm.Columns.Add("Pago");
            dtm.Columns.Add("Pagado");
            dtm.Columns.Add("Diferencia");
        }

        private void cbCarteras_TextUpdate(object sender, EventArgs e)
        {
            String txt = cbCarteras.Text.ToLower();

            carterasFiltradas = carteras.FindAll(cartera => cartera.Item1.ToLower().Contains(txt) || cartera.Item2.ToLower().Contains(txt));

            cbCarteras.Items.Clear();

            carterasFiltradas.ForEach(cartera =>
            {
                cbCarteras.Items.Add(cartera.Item1 + " - " + cartera.Item2);
            });

            cbCarteras.DroppedDown = true;

            cbCarteras.IntegralHeight = false;

            cbCarteras.SelectedIndex = -1;

            cbCarteras.Text = txt;

            cbCarteras.SelectionStart = txt.Length;

            cbCarteras.SelectionLength = 0;

            cbCarteras.DropDownHeight = 150;

            filtrado = true;
        }

        private void cbCarteras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cbCarteras.SelectedIndex < 0)
                {
                    cbCarteras.SelectedIndex = 0;
                }

                List<(int, String, double, double)> socios;
                sActivos = 0;
                if (filtrado)
                {
                    socios = cc.socios(Convert.ToInt32(carterasFiltradas[cbCarteras.SelectedIndex].Item1));
                } else
                {
                    socios = cc.socios(Convert.ToInt32(carteras[cbCarteras.SelectedIndex].Item1));
                }

                formatoTabla();
                if (socios != null) { 
                    socios.ForEach(socios =>
                    {
                        dtm.Rows.Add(socios.Item1, socios.Item2, "$"+Math.Round(socios.Item3, 2), "$" + Math.Round(socios.Item4, 2), "$" + Math.Round(((socios.Item3 - socios.Item4) < 0) ? 0 : (socios.Item3 - socios.Item4), 2));
                        sActivos++;
                        aRecuperar += socios.Item3;
                        recuperado += socios.Item4;
                    });

                    pRecuperar = aRecuperar - recuperado;

                    porcentaje = (recuperado / aRecuperar) * 100;

                    dgvCartera.DataSource = dtm;
                    dgvCartera.Refresh();

                    lblSocios.Text = "Socios activos: " + sActivos;
                    lblPorcentaje.Text = "Porcentaje: " + Math.Round(porcentaje, 2) + "%";
                    lblRecuperar.Text = "Cantidad a recuperar: " + "$" + Math.Round(aRecuperar,2);
                    lblRecuperado.Text = "Recuperado: " + "$" + Math.Round(recuperado, 2);
                    lblFaltante.Text = "Por recuperar: " + "$" + Math.Round(pRecuperar, 2);
                
                    sActivos = 0;
                    aRecuperar = 0;
                    recuperado = 0;
                    pRecuperar = 0;
                    porcentaje = 0;
                } else
                {
                    lblSocios.Text = "Socios activos: 0";
                }
            }
        }
    }
}