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
    public partial class Depositos : Form
    {
        public Depositos()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "dd/MM/yyyy";
            dtpStart.Value = new DateTime(2017,1,1);

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "dd/MM/yyyy";

            DataTable dtDepositos = new DataTable();
            dtDepositos.Columns.Add("Contrato");
            dtDepositos.Columns.Add("Socio");
            dtDepositos.Columns.Add("Oficial");
            dtDepositos.Columns.Add("Banco");
            dtDepositos.Columns.Add("Fecha");
            dtDepositos.Columns.Add("Folio");
            dtDepositos.Columns.Add("Monto");

            adgvDepositos.DataSource = dtDepositos;
            adgvDepositos.RowHeadersVisible = false;

            adgvDepositos.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[0].Width = 80;

            adgvDepositos.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            adgvDepositos.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            adgvDepositos.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[3].Width = 110;

            adgvDepositos.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[4].Width = 70;

            adgvDepositos.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[5].Width = 100;

            adgvDepositos.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[6].Width = 70;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void txbBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar();
            }
        }

        private void buscar()
        {
            Clases.Depositos_Controller dc = new Clases.Depositos_Controller();
            adgvDepositos.DataSource = dc.depositos(dtpStart.Value, dtpEnd.Value, txbBuscar.Text);
        }

        private void adgvDepositos_FilterStringChanged(object sender, EventArgs e)
        {
            ((DataView)adgvDepositos.DataSource).RowFilter = adgvDepositos.FilterString;
        }

        private void adgvDepositos_SortStringChanged(object sender, EventArgs e)
        {
            ((DataView)adgvDepositos.DataSource).Sort = adgvDepositos.SortString;
        }
    }
}
