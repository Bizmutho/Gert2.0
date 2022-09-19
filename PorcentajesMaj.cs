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

namespace Moratorios
{
    public partial class PorcentajesMaj : Form
    {
        public PorcentajesMaj()
        {
            InitializeComponent();
            cbOficiales.SelectedIndex = 0;

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            PorcentajesMaj_Controller pm = new PorcentajesMaj_Controller();
            DataTable informacion = pm.PorcentajeOficiales(cbOficiales.SelectedIndex);
            dgvPorcentajesMaj.DataSource = informacion;
            dgvPorcentajesMaj.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in dgvPorcentajesMaj.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvPorcentajesMaj.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPorcentajesMaj.Refresh();
        }

        private void PorcentajesMaj_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dgvPorcentajesMaj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
