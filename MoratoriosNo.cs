using Modulos.Clases;
using System.Data;
using System.Globalization;

namespace Moratorios
{
    public partial class MoratoriosNo : Form
    {
        public MoratoriosNo()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            MoratoriosNo_Controller cal = new MoratoriosNo_Controller();
            cal.consulta(Convert.ToInt32(txtContrato.Text), dgvMoratorios, dgvResultados, Convert.ToInt64(txbPorcentaje.Text));
            dgvMoratorios.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in dgvMoratorios.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvMoratorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMoratorios.Refresh();

            dgvResultados.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in dgvResultados.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.Refresh();

            cal.nombres(lblSocioNombres, lblSocioApellidos,lblOficialNombres, lblOficialApellidos, Convert.ToInt32(txtContrato.Text));
        }
        private void Moratorios_Load(object sender, EventArgs e)
        {

        }

        private void rtbResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbOperacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataTable dtm = new DataTable();
            int columnCount = dgvResultados.Columns.Count;
            string[] outputCsv = new string[dgvResultados.Rows.Count + 1];

            for (int i = 0; i < columnCount; i++)
            {
                dtm.Columns.Add(dgvResultados.Columns[i].HeaderText.ToString());
            }

            string desc;
            float mon, Tmon = 0, gOpe = 0;
            for (int i = 1; (i - 1) < dgvResultados.Rows.Count; i++)
            {
                desc = dgvResultados.Rows[i - 1].Cells[0].Value.ToString();
                float value;
                if ((desc == "Total" || desc == "Gastos de operación"))
                {
                    if(txbOperacion.Text != "") { 
                        if (float.Parse(txbOperacion.Text, CultureInfo.InvariantCulture.NumberFormat) != 0)
                        {
                            gOpe = float.Parse(txbOperacion.Text, CultureInfo.InvariantCulture.NumberFormat);
                            dtm.Rows.Add("Gastos de operación", Math.Round(gOpe, 2));
                        }
                    }
                    dtm.Rows.Add("Total", Math.Round((Tmon + gOpe), 2));
                    i++;
                } else { 

                if (float.TryParse(dgvResultados.Rows[i-1].Cells[1].Value.ToString(), out value))
                {
                    mon = value;
                }
                else
                {
                    mon = 0;
                }
                dtm.Rows.Add(desc, Math.Round(mon,2));
                Tmon += mon;
                mon = 0;
                desc = "";
                }
            }
            dgvResultados.DataSource = dtm;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            this.Dispose();
        }

        private void Moratorios_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}