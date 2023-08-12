using ClosedXML.Excel;
using Modulos.Clases;
using System;
using System.Collections;
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
    public partial class Morosidad_Cartera : Form
    {
        List<(int, String)> oficiales;

        public Morosidad_Cartera()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            DataTable dtm = new DataTable();
            dtm.Columns.Add("SOCIO");
            dtm.Columns.Add("CREDITO");
            dtm.Columns.Add("MONTO");
            dtm.Columns.Add("VENCIMIENTO");
            dtm.Columns.Add("QNC VEN");
            dtm.Columns.Add("SALDO VEN");
            dtm.Columns.Add("QNC PEN");
            dtm.Columns.Add("SALDO PEN");

            adgvMorosos.DataSource = dtm;
            adgvMorosos.RowHeadersVisible = false;


            adgvMorosos.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvMorosos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            adgvMorosos.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvMorosos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvMorosos.Columns[1].Width = 75;

            adgvMorosos.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvMorosos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvMorosos.Columns[2].Width = 75;

            adgvMorosos.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvMorosos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            adgvMorosos.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvMorosos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvMorosos.Columns[4].Width = 85;

            adgvMorosos.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvMorosos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            adgvMorosos.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvMorosos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            obtenerOficiales();
            cbOficiales.SelectedIndex = 0;
        }

        private void obtenerOficiales()
        {
            oficiales = new List<(int, string)>();
            MorosidadCartera_Controller mcc = new MorosidadCartera_Controller();
            oficiales = mcc.obtenerOficiales();

            cbOficiales.Items.Clear();

            if (oficiales.Count != 0)
            {
                oficiales.ForEach(oficiales => cbOficiales.Items.Add(oficiales.Item2));

            } else
            {
                cbOficiales.Items.Add("Sin datos.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (oficiales.Count != 0)
            {
                Clases.MorosidadCartera_Controller mcc = new Clases.MorosidadCartera_Controller();
                adgvMorosos.DataSource = mcc.consulta(oficiales[cbOficiales.SelectedIndex].Item1);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (adgvMorosos.Rows.Count > 0)
            {
                DateTime qncAct = DateTime.Now;

                if (qncAct.Day < 15)
                {
                    if (qncAct.Day < 12)
                    {
                        qncAct = new DateTime(qncAct.Year, qncAct.Month, 15);
                    }
                    else
                    {
                        qncAct = new DateTime(qncAct.Year, qncAct.Month, DateTime.DaysInMonth(qncAct.Month, qncAct.Month));
                    }
                }
                else
                {
                    if (qncAct.Day >= 27)
                    {
                        qncAct = new DateTime((qncAct.Month == 12) ? (qncAct.Year + 1) : qncAct.Year, (qncAct.Month == 12) ? 1 : (qncAct.Month + 1), 15); ;
                    }
                    else
                    {
                        qncAct = new DateTime(qncAct.Year, qncAct.Month, DateTime.DaysInMonth(qncAct.Month, qncAct.Month));
                    }
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLSX (*.xlsx)|*.xlsx";
                sfd.FileName = "Morosidad cartera  " + cbOficiales.Items[cbOficiales.SelectedIndex].ToString() + ".xlsx";
                bool fileError = false;
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

                        ws.Cell(1, 1).Value = "CARTERA " + cbOficiales.Items[cbOficiales.SelectedIndex].ToString();
                        ws.Range(ws.Cell(1, 1), ws.Cell(1, 8)).Merge();
                        ws.Cell(1, 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                        ws.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(1, 1).Style.Font.FontName = "Arial";
                        ws.Cell(1, 1).Style.Alignment.WrapText = true;

                        for (int i = 1; i <= adgvMorosos.ColumnCount; i++)
                        {
                            ws.Cell(2, i).Value = adgvMorosos.Columns[i-1].HeaderText.ToString();
                            ws.Cell(2, i).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 210, 210, 208));

                            ws.Cell(2, i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(2, i).Style.Font.FontName = "Arial";

                            ws.Cell(2, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Column(1).Width = 50;
                        ws.Column(2).Width = 10;
                        ws.Column(3).Width = 13;
                        ws.Column(4).Width = 15;
                        ws.Column(5).Width = 10;
                        ws.Column(6).Width = 15;
                        ws.Column(7).Width = 10;
                        ws.Column(8).Width = 15;

                        for (int r = 0; r < adgvMorosos.RowCount; r++)
                        {
                            for (int c = 0; c < adgvMorosos.ColumnCount; c++)
                            {
                                if ((c + 1) == 6 || (c + 1) == 3 || (c + 1) == 8)
                                {
                                    if (float.Parse(adgvMorosos.Rows[r].Cells[c].Value.ToString().Replace("$", "").Replace(" ", "")) != 0)
                                    {
                                        ws.Cell(r + 3, c + 1).Value = adgvMorosos.Rows[r].Cells[c].Value.ToString().Replace("$", "").Replace(" ", "");
                                    }
                                } else if ((c + 1) == 5 || (c + 1) == 7)
                                {
                                    if (float.Parse(adgvMorosos.Rows[r].Cells[c].Value.ToString().Replace("$", "").Replace(" ", "")) != 0)
                                    {
                                        ws.Cell(r + 3, c + 1).Value = adgvMorosos.Rows[r].Cells[c].Value.ToString().Replace("$", "").Replace(" ", "");
                                    }
                                }
                                else
                                {
                                    ws.Cell(r + 3, c + 1).Value = adgvMorosos.Rows[r].Cells[c].Value.ToString();
                                }


                                ws.Cell(r + 3, c + 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 234, 234, 234));
                                ws.Cell(r + 3, c + 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Cell(r + 3, c + 1).Style.Font.FontName = "Arial";
                                ws.Cell(r + 3, c + 1).Style.Alignment.WrapText = true;

                                if ((c + 1) == 6 || (c + 1) == 3 || (c + 1) == 8)
                                {
                                    ws.Cell(r + 3, c + 1).Style.NumberFormat.Format = "$    0.00";
                                    ws.Cell(r + 3, c + 1).DataType = XLDataType.Number;
                                } else
                                {
                                    ws.Cell(r + 3, c + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                }

                                ws.Cell(r + 3, c + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(r + 3, c + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(r + 3, c + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(r + 3, c + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            }
                        }

                        wb.SaveAs(sfd.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay información para exportar", "Info");
            }
        }

        private void cbOficiales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
