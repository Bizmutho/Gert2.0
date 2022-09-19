using iTextSharp.text.pdf;
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
    public partial class PorcentajesAtz : Form
    {
        public PorcentajesAtz()
        {
            InitializeComponent();

            dtpMes.Format = DateTimePickerFormat.Custom;
            dtpMes.CustomFormat = "yyyy-MM";

            cbOficiales.SelectedIndex = 0;

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            PorcentajesAtz_Controller pa = new PorcentajesAtz_Controller();
            DateTime fechaI = dtpMes.Value;
            DataTable informacion = pa.PorcentajeOficiales(fechaI.Year, fechaI.Month, cbOficiales.SelectedIndex);
            dgvPorcentajesAtz.DataSource = informacion;
            dgvPorcentajesAtz.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in dgvPorcentajesAtz.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvPorcentajesAtz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPorcentajesAtz.Refresh();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook();


            var ws = wb.AddWorksheet("Porcentajes");

            for (int i = 0; i < dgvPorcentajesAtz.ColumnCount; i++)
            {
                ws.Cell(1, i + 1).Value = dgvPorcentajesAtz.Columns[i].HeaderText.ToString();
            }

            for (int i = 0; i < dgvPorcentajesAtz.ColumnCount; i++)
            {
                for (int x = 0; x < dgvPorcentajesAtz.RowCount; x++)
                {
                    ws.Cell(x + 2, i + 1).Value = (dgvPorcentajesAtz.Rows[x].Cells[i].Value != null) ? dgvPorcentajesAtz.Rows[x].Cells[i].Value.ToString() : "";
                }
            }
            wb.SaveAs("C:/doc/NewExcelFile.xlsx");
        }


        private void PorcentajesAtz_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
