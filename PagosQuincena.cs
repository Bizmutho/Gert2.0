using ClosedXML.Excel;
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
    public partial class PagosQuincena : Form
    {
        int[] oficiales = { 164, 168, 148, 171, 173, 165, 169, 155, 170, 161, 110, 174, 30, 163, 166, 152, 87, 32, 172, 151, 29, 112, 175, 176,
         187, 188, 178, 182, 179, 180, 183, 181, 184, 186, 185, 190};
        public PagosQuincena()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

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
                if (qncAct.Day >= 27)
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, DateTime.DaysInMonth(qncAct.Year, qncAct.Month));
                }
                else
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, 15);
                }
            }

            dtpQuincena.Format = DateTimePickerFormat.Custom;
            dtpQuincena.CustomFormat = "dd/MM/yyyy";
            dtpQuincena.Value = qncAct;

            cbOficiales.SelectedIndex = 0;

            DataTable dtPagos = new DataTable();
            dtPagos.Columns.Add("Contrato");
            dtPagos.Columns.Add("Socio");
            dtPagos.Columns.Add("Monto");

            adgvPagos.DataSource = dtPagos;
            adgvPagos.RowHeadersVisible = false;

            adgvPagos.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvPagos.Columns[0].Width = 80;

            adgvPagos.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvPagos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            adgvPagos.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvPagos.Columns[2].Width = 70;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Clases.PagosQuincena_Controller pqc = new Clases.PagosQuincena_Controller();
            adgvPagos.DataSource = pqc.buscar(dtpQuincena.Value, (cbOficiales.SelectedIndex < 0) ? 0 : oficiales[cbOficiales.SelectedIndex]);
            lblQuincena.Text = "Pagos a la quincena: " + dtpQuincena.Value.Day.ToString("00") + "/" + dtpQuincena.Value.Month.ToString("00") + "/" + dtpQuincena.Value.Year;
        }

        private void adgvPagos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (adgvPagos.CurrentCell.RowIndex >= 0)
            {
                Captura captura = new Captura();
                captura.Show();
                captura.buscarDeuda(adgvPagos.Rows[adgvPagos.CurrentCell.RowIndex].Cells[0].Value.ToString(), adgvPagos.Rows[adgvPagos.CurrentCell.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (adgvPagos.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLSX (*.xlsx)|*.xlsx";
                sfd.FileName = "Pendientes " + cbOficiales.Items[cbOficiales.SelectedIndex].ToString() + ".xlsx";
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

                        ws.Cell(1, 1).Value = "CARTERA " + cbOficiales.Items[cbOficiales.SelectedIndex].ToString() + " AL " + dtpQuincena.Value.Day.ToString("00") + "/" + dtpQuincena.Value.Month.ToString("00") + "/" + dtpQuincena.Value.Year;
                        ws.Range(ws.Cell(1, 1), ws.Cell(1, 3)).Merge();
                        ws.Cell(1, 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                        ws.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(1, 1).Style.Font.FontName = "Arial";
                        ws.Cell(1, 1).Style.Alignment.WrapText = true;

                        for (int i = 1; i <= adgvPagos.ColumnCount; i++)
                        {
                            ws.Cell(2, i).Value = adgvPagos.Columns[i - 1].HeaderText.ToString();
                            ws.Cell(2, i).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 210, 210, 208));

                            ws.Cell(2, i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(2, i).Style.Font.FontName = "Arial";

                            ws.Cell(2, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }
                        
                        ws.Column(1).Width = 10;
                        ws.Column(2).Width = 50;
                        ws.Column(3).Width = 16;

                        for (int r = 0; r < adgvPagos.RowCount; r++)
                        {
                            for (int c = 0; c < adgvPagos.ColumnCount; c++)
                            {
                                if ((c + 1) == 3)
                                {
                                    ws.Cell(r + 3, c + 1).Value = adgvPagos.Rows[r].Cells[c].Value.ToString().Replace("$", "").Replace(" ", "");
                                }
                                else
                                {
                                    ws.Cell(r + 3, c + 1).Value = adgvPagos.Rows[r].Cells[c].Value.ToString();
                                }

                                ws.Cell(r + 3, c + 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 234, 234, 234));
                                ws.Cell(r + 3, c + 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Cell(r + 3, c + 1).Style.Font.FontName = "Arial";
                                ws.Cell(r + 3, c + 1).Style.Alignment.WrapText = true;

                                if ((c + 1) == 3)
                                {
                                    ws.Cell(r + 3, c + 1).Style.NumberFormat.Format = "$    0.00";
                                    ws.Cell(r + 3, c + 1).DataType = XLDataType.Number;
                                }
                                else
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

        private void btnQncAtras_Click(object sender, EventArgs e)
        {
            DateTime qnc = dtpQuincena.Value;

            if(qnc.Day <= 15)
            {
                qnc = new DateTime((qnc.Month == 1 ) ? qnc.Year - 1 : qnc.Year, (qnc.Month == 1) ? 12 : qnc.Month-1, DateTime.DaysInMonth((qnc.Month == 1) ? qnc.Year - 1 : qnc.Year, (qnc.Month == 1) ? 12 : qnc.Month - 1));
                if (qnc.DayOfWeek == DayOfWeek.Sunday)
                {
                    dtpQuincena.Value = new DateTime(qnc.Year, qnc.Month, qnc.Day - 1);
                } else
                {
                    dtpQuincena.Value = qnc;
                }

            } else if (qnc.Day >= 16)
            {
                qnc = new DateTime(qnc.Year, qnc.Month, 15);
                if (qnc.DayOfWeek == DayOfWeek.Sunday)
                {
                    dtpQuincena.Value = new DateTime(qnc.Year, qnc.Month, qnc.Day - 1);
                } else
                {
                    dtpQuincena.Value = qnc;
                }
            }
        }

        private void btnQncAdelante_Click(object sender, EventArgs e)
        {
            DateTime qnc = dtpQuincena.Value;

            if (qnc.Day <= 15)
            {
                qnc = new DateTime(qnc.Year, qnc.Month, DateTime.DaysInMonth(qnc.Year, qnc.Month));
                if (qnc.DayOfWeek == DayOfWeek.Sunday)
                {
                    dtpQuincena.Value = new DateTime(qnc.Year, qnc.Month, qnc.Day - 1);
                }
                else
                {
                    dtpQuincena.Value = qnc;
                }

            }
            else if (qnc.Day >= 16)
            {
                qnc = new DateTime((qnc.Month == 12) ? qnc.Year + 1 : qnc.Year, (qnc.Month == 12) ? 1 : qnc.Month + 1, 15);
                if (qnc.DayOfWeek == DayOfWeek.Sunday)
                {
                    dtpQuincena.Value = new DateTime(qnc.Year, qnc.Month, qnc.Day - 1);
                }
                else
                {
                    dtpQuincena.Value = qnc;
                }
            }
        }
    }
}
