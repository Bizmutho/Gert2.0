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
    public partial class Moratorios : Form
    {
        public Moratorios()
        {
            InitializeComponent();
            dtpIni.CustomFormat = "dd/MM/YYYY";
            dtpFin.CustomFormat = "dd/MM/YYYY";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Moratorios_Controller mc = new Moratorios_Controller();
            dgvMoratorios.DataSource = mc.moratorios(dtpIni.Value, dtpFin.Value);
            dgvMoratorios.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in dgvMoratorios.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvMoratorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMoratorios.Refresh();
        }
    }
}
