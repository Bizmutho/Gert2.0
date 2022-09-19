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
    public partial class Cerrar_creditos : Form
    {
        DataTable creditos, quincenas, depositos;
        List<(int, String, double)> idCreditos = new List<(int, String, double)>();
        int id = 0;
        SaveFileDialog saveFileDialog;

        public Cerrar_creditos()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            creditos = new DataTable();
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "";
            checkColumn.Width = 30;
            checkColumn.ReadOnly = false;
            dgvCreditos.Columns.Add(checkColumn);

            creditos.Columns.Add("Contrato");
            creditos.Columns.Add("Socio");
            creditos.Columns.Add("Pendiente");

            dgvCreditos.DataSource = creditos;
            dgvCreditos.RowHeadersVisible = false;

            dgvCreditos.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCreditos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCreditos.Columns[0].Width = 30;

            dgvCreditos.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCreditos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCreditos.Columns[1].Width = 60;

            dgvCreditos.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvCreditos.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCreditos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCreditos.Columns[3].Width = 65;

            quincenas = new DataTable();
            quincenas.Columns.Add("Quincena");
            quincenas.Columns.Add("Pago");
            quincenas.Columns.Add("Pagado");

            dgvQuincenas.DataSource = quincenas;
            dgvQuincenas.RowHeadersVisible = false;

            depositos = new DataTable();
            depositos.Columns.Add("Fecha");
            depositos.Columns.Add("Folio");
            depositos.Columns.Add("Banco");
            depositos.Columns.Add("Monto");

            dgvDepositos.DataSource = depositos;
            dgvDepositos.RowHeadersVisible = false;

            dgvCreditos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuincenas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDepositos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dgvCreditos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (id != idCreditos[dgvCreditos.CurrentCell.RowIndex].Item1)
            {
                id = idCreditos[dgvCreditos.CurrentCell.RowIndex].Item1;
                Clases.Cerrar_Creditos_Controller ccc = new Clases.Cerrar_Creditos_Controller();
                ccc.Quincenas(id, quincenas);
                ccc.Depositos(id, depositos);

                if (dgvQuincenas.Rows.Count > 5)
                {
                    dgvQuincenas.FirstDisplayedScrollingRowIndex = dgvQuincenas.Rows.Count - 1;
                }

                if (dgvDepositos.Rows.Count > 5)
                {
                    dgvDepositos.FirstDisplayedScrollingRowIndex = dgvDepositos.Rows.Count - 1;
                }
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            List<(int, String, double)> ids = new List<(int, String, double)>();
            for(int i = 0; i < dgvCreditos.RowCount; i++)
            {
                if ((bool)(dgvCreditos.Rows[i].Cells[0].Value))
                {
                    ids.Add(idCreditos[i]);
                }
            }
            if (ids.Count != 0)
            {
                Clases.Cerrar_Creditos_Controller ccc = new Clases.Cerrar_Creditos_Controller();
                if (ccc.cerrarCreditos(ids))
                {
                    exportar(ids);
                    buscar();
                }
            }
        }

        public void buscar()
        {
            double menor = 500;
            if (txbLimite.Text != "")
            {
                menor = Convert.ToDouble(txbLimite.Text);
            }

            Clases.Cerrar_Creditos_Controller ccc = new Clases.Cerrar_Creditos_Controller();
            ccc.Creditos(menor, creditos, idCreditos);

            quincenas.Clear();
            depositos.Clear();

            for (int i = 0; i < dgvCreditos.Rows.Count; i++)
            {
                dgvCreditos.Rows[i].Cells[0].ReadOnly = false;
                dgvCreditos.Rows[i].Cells[0].Value = false;
            }
            dgvCreditos.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        public void exportar(List<(int, String, double)> datos)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XLSX (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "Creditos terminados " + DateTime.Now.Day  +"-"+ DateTime.Now.Month + "-" + DateTime.Now.Year +".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (datos.Count > 0)
            {
                bool fileError = false;
                String oficial = "";
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

                        ws.Cell(1, 1).Value = "Oficial";
                        ws.Cell(1, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 210, 210, 208));

                        ws.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(1, 1).Style.Font.FontName = "Arial";

                        ws.Cell(1, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;


                        ws.Column(1).Width = 20;

                        ws.Cell(1, 2).Value = "No. Contrato";
                        ws.Cell(1, 2).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 210, 210, 208));

                        ws.Cell(1, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(1, 2).Style.Font.FontName = "Arial";

                        ws.Cell(1, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 2).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 2).Style.Border.TopBorder = XLBorderStyleValues.Thin;


                        ws.Column(2).Width = 12;

                        ws.Cell(1, 3).Value = "Monto";
                        ws.Cell(1, 3).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 210, 210, 208));

                        ws.Cell(1, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(1, 3).Style.Font.FontName = "Arial";

                        ws.Cell(1, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin;


                        ws.Column(3).Width = 12;

                        for (int i = 0; i < datos.Count; i++)
                        {
                            if (oficial == "")
                            {
                                oficial = datos[i].Item2;
                            } else if (oficial != datos[i].Item2)
                            {
                                ws.Range(ws.Cell(rangeMarge, 1), ws.Cell(i + 1, 1)).Merge();
                                ws.Cell(rangeMarge, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 234, 234, 234));
                                ws.Cell(rangeMarge, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rangeMarge, 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Cell(rangeMarge, 1).Style.Font.FontName = "Arial";
                                ws.Cell(rangeMarge, 1).Style.Alignment.WrapText = true;
                                ws.Cell(i + 1, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                ws.Cell(i + 1, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(i + 1, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(i + 1, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                rangeMarge = i + 2;
                                oficial = datos[i].Item2;
                            }

                            ws.Cell(i + 2, 1).Value = datos[i].Item2;

                            ws.Cell(i + 2, 2).Value = datos[i].Item1;
                            ws.Cell(i + 2, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(i + 2, 2).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            ws.Cell(i + 2, 2).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 234, 234, 234));
                            ws.Cell(i + 2, 2).Style.Font.FontName = "Arial";
                            ws.Cell(i + 2, 2).Style.Alignment.WrapText = true;
                            ws.Cell(i + 2, 2).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 2, 2).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 2, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 2, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                            ws.Cell(i + 2, 3).Value = datos[i].Item3;
                            ws.Cell(i + 2, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                            ws.Cell(i + 2, 3).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 234, 234, 234));
                            ws.Cell(i + 2, 3).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            ws.Cell(i + 2, 3).Style.Font.FontName = "Arial";
                            ws.Cell(i + 2, 3).Style.Alignment.WrapText = true;
                            ws.Cell(i + 2, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 2, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 2, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 2, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 2, 3).Style.NumberFormat.Format = "$#,##0.00;-$#,##0.00";
                            ws.Cell(i + 2, 3).DataType = XLDataType.Number;
                        }

                        ws.Range(ws.Cell(rangeMarge, 1), ws.Cell(datos.Count + 1, 1)).Merge();
                        ws.Cell(rangeMarge, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(0, 234, 234, 234));
                        ws.Cell(rangeMarge, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rangeMarge, 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                        ws.Cell(rangeMarge, 1).Style.Font.FontName = "Arial";
                        ws.Cell(rangeMarge, 1).Style.Alignment.WrapText = true;
                        ws.Cell(datos.Count + 1, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        ws.Cell(datos.Count + 1, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(datos.Count + 1, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(datos.Count + 1, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                        wb.SaveAs(saveFileDialog.FileName);
                }
            }
        }
        }
    }
}
