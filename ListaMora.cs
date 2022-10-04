using ClosedXML.Excel;
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
    public partial class ListaMora : Form
    {
        public ListaMora()
        {
            InitializeComponent();
            cbOficiales.SelectedIndex = 0;

            StartPosition = FormStartPosition.CenterScreen;

            DataTable dtm = new DataTable();
            dtm.Columns.Add("No. Credito");
            dtm.Columns.Add("Socio");
            dtm.Columns.Add("Oficial");
            dtm.Columns.Add("No. Pago");
            dtm.Columns.Add("Quincena");
            dtm.Columns.Add("Pendiente");

            dgvListaMora.DataSource = dtm;
            dgvListaMora.RowHeadersVisible = false;

            dgvListaMora.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvListaMora.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvListaMora.Columns[0].Width = 80;

            dgvListaMora.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvListaMora.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvListaMora.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvListaMora.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvListaMora.Columns[3].Width = 50;

            dgvListaMora.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvListaMora.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvListaMora.Columns[4].Width = 70;

            dgvListaMora.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvListaMora.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvListaMora.Columns[5].Width = 70;


            dgvListaMora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaMora.Refresh();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ListaMora_Controller lm = new ListaMora_Controller();
            lm.consulta(cbOficiales.SelectedIndex, dgvListaMora);
            dgvListaMora.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in dgvListaMora.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvListaMora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaMora.Refresh();
        }

        private void dgvListaMora_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            else
            {
                e.AdvancedBorderStyle.Top = dgvListaMora.AdvancedCellBorderStyle.Top;
            }

            if (e.Value.ToString() == "Total")
            {
                e.AdvancedBorderStyle.Top = dgvListaMora.AdvancedCellBorderStyle.Top;
                e.AdvancedBorderStyle.Bottom = dgvListaMora.AdvancedCellBorderStyle.Bottom;
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

            } else if (e.ColumnIndex > 0 && totalRow(e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = dgvListaMora.AdvancedCellBorderStyle.Top;
                e.AdvancedBorderStyle.Bottom = dgvListaMora.AdvancedCellBorderStyle.Bottom;
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            }
            else if (e.Value.ToString() == "")
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }

        }

        bool totalRow(int row)
        {
            DataGridViewCell cell1 = dgvListaMora[0, row];
            if (cell1.Value.ToString() == "Total")
            {
                return true;
            }
            return false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvListaMora.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLSX (*.xlsx)|*.xlsx";
                sfd.FileName = "Lista de mora.xlsx";
                bool fileError = false;
                String value;
                int rangeMarge = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("No se puede escribir en el disco" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        XLWorkbook wb = new XLWorkbook();

                        var ws = wb.AddWorksheet("Hoja 1");
                        ws.Columns().AdjustToContents();
                        ws.Rows().AdjustToContents();

                        for (int i = 0; i < dgvListaMora.ColumnCount; i++)
                        {
                            ws.Cell(1, i + 1).Value = dgvListaMora.Columns[i].HeaderText.ToString();
                            ws.Cell(1, i + 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 210, 210, 208));

                            ws.Cell(1, i + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(1, i + 1).Style.Font.FontName = "Arial";

                            ws.Cell(1, i + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Column(1).Width = 11.30;
                        ws.Column(2).Width = 13;
                        ws.Column(3).Width = 10;
                        ws.Column(4).Width = 8;
                        ws.Column(5).Width = 13;
                        ws.Column(6).Width = 10;

                        for (int i = 0; i < dgvListaMora.ColumnCount; i++)
                        {
                            for (int x = 0; x < dgvListaMora.RowCount; x++)
                            {
                                value = (dgvListaMora.Rows[x].Cells[i].Value != null) ? dgvListaMora.Rows[x].Cells[i].Value.ToString() : "";
                                ws.Cell(x + 2, i + 1).Value = value;
                                ws.Cell(x + 2, i + 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0,234, 234, 234));

                                if (i == dgvListaMora.ColumnCount - 1)
                                {
                                    ws.Cell(x + 2, i + 1).Style.NumberFormat.Format = "$0.00";
                                    ws.Cell(x + 2, i + 1).DataType = XLDataType.Number;
                                }

                                if (value == "Total")
                                {
                                    ws.Range(ws.Cell(rangeMarge, i + 1), ws.Cell((x + 1), i + 1)).Merge();
                                    ws.Cell(rangeMarge, i + 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                    ws.Cell(rangeMarge, i + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                    ws.Cell(rangeMarge, i + 1).Style.Font.FontName = "Arial";
                                    ws.Cell(rangeMarge, i + 1).Style.Alignment.WrapText = true;

                                    ws.Range(ws.Cell(rangeMarge, i + 2), ws.Cell((x + 1), i + 2)).Merge();
                                    ws.Cell(rangeMarge, i + 2).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                    ws.Cell(rangeMarge, i + 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                    ws.Cell(rangeMarge, i + 2).Style.Font.FontName = "Arial";
                                    ws.Cell(rangeMarge, i + 2).Style.Alignment.WrapText = true;

                                    ws.Range(ws.Cell(rangeMarge, i + 3), ws.Cell((x + 1), i + 3)).Merge();
                                    ws.Cell(rangeMarge, i + 3).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                    ws.Cell(rangeMarge, i + 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                    ws.Cell(rangeMarge, i + 3).Style.Font.FontName = "Arial";
                                    ws.Cell(rangeMarge, i + 3).Style.Alignment.WrapText = true;

                                    ws.Range(ws.Cell(x + 2, i + 1), ws.Cell(x + 2, dgvListaMora.ColumnCount - 1)).Merge();

                                    ws.Range(ws.Cell(x + 2, i + 1), ws.Cell(x + 2, dgvListaMora.ColumnCount - 1)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                    ws.Range(ws.Cell(x + 2, i + 1), ws.Cell(x + 2, dgvListaMora.ColumnCount - 1)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                    ws.Range(ws.Cell(x + 2, i + 1), ws.Cell(x + 2, dgvListaMora.ColumnCount - 1)).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                    ws.Cell(x + 2, i + 6).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                    ws.Cell(x + 2, i + 6).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                    ws.Cell(x + 2, i + 6).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                    rangeMarge = x + 3;

                                } else if (ws.Cell(x + 2, 1).Value != "Total")
                                {
                                    ws.Cell(x + 2, i + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                    ws.Cell(x + 2, i + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                    ws.Cell(x + 2, i + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                    ws.Cell(x + 2, i + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                }
                            }
                        }

                        wb.SaveAs(sfd.FileName);
                    }
                }
            }
        }

        private void ListaMora_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void cbOficiales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvListaMora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
