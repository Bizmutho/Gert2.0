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

namespace Modulos
{
    public partial class Contpaq : Form
    {
        DataTable dtm;
        DataTable dtmTotal;
        SaveFileDialog saveFileDialog;

        public Contpaq()
        {
            InitializeComponent();
            dtpIni.Format = DateTimePickerFormat.Custom;
            dtpFin.Format = DateTimePickerFormat.Custom;

            dtpIni.CustomFormat = "dd/MM/yyyy";
            dtpFin.CustomFormat = "dd/MM/yyyy";

            StartPosition = FormStartPosition.CenterScreen;


            dtm = new DataTable();
            dtm.Columns.Add("FECHA");
            dtm.Columns.Add("CODIGO");
            dtm.Columns.Add("MOVIMIENTO");
            dtm.Columns.Add("CARGO");
            dtm.Columns.Add("ABONO");
            dtm.Columns.Add("REFERENCIA");
            dtm.Columns.Add("SOCIO");
            dtm.Columns.Add("CONCEPTO");
            dtm.Columns.Add("BANCO");


            dtmTotal = new DataTable();
            dtmTotal.Columns.Add("FECHA");
            dtmTotal.Columns.Add("CODIGO");
            dtmTotal.Columns.Add("MOVIMIENTO");
            dtmTotal.Columns.Add("CARGO");
            dtmTotal.Columns.Add("ABONO");
            dtmTotal.Columns.Add("REFERENCIA");
            dtmTotal.Columns.Add("SOCIO");
            dtmTotal.Columns.Add("CONCEPTO");
            dtmTotal.Columns.Add("BANCO");


            creatTablas();
        }

        private void creatTablas()
        {
            dgvContpaq.DataSource = dtm;
            dgvContpaq.RowHeadersVisible = false;

            dgvContpaq.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContpaq.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvContpaq.Columns[0].Resizable = DataGridViewTriState.False;
            dgvContpaq.Columns[0].Width = 70;

            dgvContpaq.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContpaq.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvContpaq.Columns[1].Resizable = DataGridViewTriState.False;
            dgvContpaq.Columns[1].Width = 65;

            dgvContpaq.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContpaq.Columns[2].Resizable = DataGridViewTriState.False;

            dgvContpaq.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContpaq.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvContpaq.Columns[3].Resizable = DataGridViewTriState.False;
            dgvContpaq.Columns[3].Width = 65;

            dgvContpaq.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContpaq.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvContpaq.Columns[4].Resizable = DataGridViewTriState.False;
            dgvContpaq.Columns[4].Width = 65;

            dgvContpaq.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContpaq.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvContpaq.Columns[5].Resizable = DataGridViewTriState.False;
            dgvContpaq.Columns[5].Width = 78;

            dgvContpaq.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContpaq.Columns[7].Resizable = DataGridViewTriState.False;

            dgvContpaq.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContpaq.Columns[8].Resizable = DataGridViewTriState.False;

            dgvContpaq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTotales.DataSource = dtmTotal;
            dgvTotales.RowHeadersVisible = false;

            dgvTotales.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTotales.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTotales.Columns[0].Resizable = DataGridViewTriState.False;
            dgvTotales.Columns[0].Width = 70;

            dgvTotales.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTotales.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTotales.Columns[1].Resizable = DataGridViewTriState.False;
            dgvTotales.Columns[1].Width = 65;

            dgvTotales.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTotales.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTotales.Columns[2].Resizable = DataGridViewTriState.False;
            dgvTotales.Columns[2].Width = 100;

            dgvTotales.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTotales.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTotales.Columns[3].Resizable = DataGridViewTriState.False;
            dgvTotales.Columns[3].Width = 65;

            dgvTotales.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTotales.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTotales.Columns[4].Resizable = DataGridViewTriState.False;
            dgvTotales.Columns[4].Width = 65;

            dgvTotales.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTotales.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTotales.Columns[5].Resizable = DataGridViewTriState.False;
            dgvTotales.Columns[5].Width = 78;

            dgvTotales.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTotales.Columns[7].Resizable = DataGridViewTriState.False;

            dgvTotales.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTotales.Columns[8].Resizable = DataGridViewTriState.False;

            dgvTotales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTotales.ColumnHeadersVisible = false;
            dgvTotales.RowHeadersVisible = false;

            if (dgvContpaq.RowCount > 0)
            {
                dtmTotal.Clear();
                //double t1 = 0, t2 = 0;
                //for (int i = 0; i < dgvContpaq.RowCount; i++)
                //{
                //    t1 += Convert.ToDouble(((String)dgvContpaq.Rows[i].Cells[3].Value).Replace("$", "").Replace(" ", ""));
                //    t2 += Convert.ToDouble(((String)dgvContpaq.Rows[i].Cells[4].Value).Replace("$", "").Replace(" ", ""));
                //}

                dtmTotal.Rows.Add("Totales", "", "", "$ " + Math.Round(StorageClass.contpaqCargo, 2), "$ " + Math.Round(StorageClass.contpaqAbono, 2), "", "", "");
            }

            dgvContpaq.Refresh();
            dgvTotales.Refresh();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Contpaq_controller cc = new Contpaq_controller();

            StorageClass.contpaqIni = dtpIni.Value;
            StorageClass.contpaqFin = dtpFin.Value;
            StorageClass.contpaqData = dtm;

            dgvContpaq.DataSource = null;
            dgvTotales.DataSource = null;

            using (dialogCarga dc = new dialogCarga("Cargando datos...", cc.contpaq))
            {
                dc.ShowDialog(this);
            }

            creatTablas();
        }

        public void btnExportar_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XLSX (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "Reporte contpaq.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (dialogCarga dc = new dialogCarga("Exportando...", exportar))
                {
                    dc.ShowDialog(this);
                }
            }
        }

        public void exportar()
        {

            if (dgvContpaq.Rows.Count > 0)
            {
                bool fileError = false;
                String value;
                int rangeMarge = 2;

                    if (File.Exists(saveFileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(saveFileDialog.FileName);
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
                        int r = 0;
                        var ws = wb.AddWorksheet("Hoja 1");
                        ws.Columns().AdjustToContents();
                        ws.Rows().AdjustToContents();

                        for (int i = 0; i < dgvContpaq.ColumnCount; i++)
                        {
                            ws.Cell(1, i + 1).Value = dgvContpaq.Columns[i].HeaderText.ToString();
                            ws.Cell(1, i + 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 210, 210, 208));

                            ws.Cell(1, i + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(1, i + 1).Style.Font.FontName = "Arial";

                            ws.Cell(1, i + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Column(1).Width = 11.30;
                        ws.Column(2).Width = 11;
                        ws.Column(3).Width = 23;
                        ws.Column(4).Width = 15;
                        ws.Column(5).Width = 15;
                        ws.Column(6).Width = 15;
                        ws.Column(7).Width = 31;
                        ws.Column(8).Width = 18;
                        ws.Column(9).Width = 16;

                    for (int i = 0; i < dgvContpaq.ColumnCount; i++)
                        {
                            for (int x = 0; x < dgvContpaq.RowCount; x++)
                            {
                                value = (dgvContpaq.Rows[x].Cells[i].Value != null) ? dgvContpaq.Rows[x].Cells[i].Value.ToString() : "";

                                if (i == 3 || i == 4)
                                {
                                    value = value.Replace("$", "");
                                    value = value.Replace(" ", "");
                                }

                                ws.Cell(x + 2, i + 1).Value = value;
                                ws.Cell(x + 2, i + 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 234, 234, 234));

                                if (i == 3 || i == 4)
                                {
                                    ws.Cell(x + 2, i + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                                }
                                else
                                {
                                    ws.Cell(x + 2, i + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                }
                                ws.Cell(x + 2, i + 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Cell(x + 2, i + 1).Style.Font.FontName = "Arial";
                                ws.Cell(x + 2, i + 1).Style.Alignment.WrapText = true;
                                ws.Cell(x + 2, i + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                ws.Cell(x + 2, i + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(x + 2, i + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(x + 2, i + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                                if (i == 3 || i == 4)
                                {
                                    ws.Cell(x + 2, i + 1).Style.NumberFormat.Format = "$ 0.00";
                                    ws.Cell(x + 2, i + 1).DataType = XLDataType.Number;
                                }

                            }
                        }

                        r = dgvContpaq.RowCount;

                        for (int i = 0; i < dgvTotales.ColumnCount; i++)
                        {
                            for (int x = 0; x < dgvTotales.RowCount; x++)
                            {
                                value = (dgvTotales.Rows[x].Cells[i].Value != null) ? dgvTotales.Rows[x].Cells[i].Value.ToString() : "";

                                if (i == 3 || i == 4)
                                {
                                    value = value.Replace("$", "");
                                    value = value.Replace(" ", "");
                                }

                                ws.Cell((x + r) + 2, i + 1).Value = value;
                                ws.Cell((x + r) + 2, i + 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 234, 234, 234));

                                if (i == 3 || i == 4)
                                {
                                    ws.Cell((x + r) + 2, i + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                                }
                                else
                                {
                                    ws.Cell((x + r) + 2, i + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                }
                                ws.Cell((x + r) + 2, i + 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Cell((x + r) + 2, i + 1).Style.Font.FontName = "Arial";
                                ws.Cell((x + r) + 2, i + 1).Style.Alignment.WrapText = true;
                                ws.Cell((x + r) + 2, i + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                ws.Cell((x + r) + 2, i + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell((x + r) + 2, i + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell((x + r) + 2, i + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                                if (i == 3 || i == 4)
                                {
                                    ws.Cell((x + r) + 2, i + 1).Style.NumberFormat.Format = "$ 0.00";
                                    ws.Cell((x + r) + 2, i + 1).DataType = XLDataType.Number;
                                }

                            }
                        }

                        wb.SaveAs(saveFileDialog.FileName);
                    }
            }
        }
    }
}
