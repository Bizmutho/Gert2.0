using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Modulos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulos
{
    public partial class historialCredito : Form
    {
        HistorialCredito_Controller hcc = new HistorialCredito_Controller();
        List<(int, String)> socios;
        List<(int, String)> sociosFiltrados;
        List<(int, String, DateTime, DateTime, DateTime, int, int, double, double, double)> historial;

        public historialCredito()
        {
            InitializeComponent();

            cargarSocios();
        }

        private void cargarSocios()
        {
            socios = hcc.obtenerSocios();
            sociosFiltrados = socios;

            if (socios.Count != 0)
            {
                socios.ForEach(socio =>
                {
                    cbSocios.Items.Add($"{socio.Item2}");
                });
            } else
            {
                cbSocios.Items.Add("Sin datos");
            }
            cbSocios.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cbSocios.SelectedIndex >= 0)
            {
                historial = hcc.consultarHistorial(sociosFiltrados[cbSocios.SelectedIndex].Item1);
                lblOficial.Text = $"{historial.Count}";
            }
        }

        private void cbSocios_TextUpdate(object sender, EventArgs e)
        {
            String filtro = cbSocios.Text;

            sociosFiltrados = socios.FindAll(x => x.Item2.ToLower().Contains(filtro.ToLower()));

            cbSocios.Items.Clear();

            sociosFiltrados.ForEach(socio =>
            {
                cbSocios.Items.Add($"{socio.Item2}");
            });

            cbSocios.DroppedDown = true;

            cbSocios.IntegralHeight = false;

            cbSocios.SelectedIndex = -1;

            cbSocios.Text = filtro;

            cbSocios.SelectionStart = filtro.Length;

            cbSocios.SelectionLength = 0;

            cbSocios.DropDownHeight = 150;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (historial.Count > 0)
            {
                (int, String, DateTime, DateTime, DateTime, int, int, double, double, double) actual = historial.ElementAt(historial.Count - 1);
                historial.RemoveAt(historial.Count - 1);
                String socio = sociosFiltrados[cbSocios.SelectedIndex].Item2;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLSX (*.xlsx)|*.xlsx";
                sfd.FileName = $"Historial - {socio}.xlsx";
                bool fileError = false;
                XLColor odd = XLColor.FromArgb(221, 235, 247, 255);
                XLColor even = XLColor.FromArgb(128, 164, 172, 255);
                XLColor act;

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


                        ws.Column(1).Width = 3.43;
                        ws.Column(2).Width = 13.71;
                        ws.Column(3).Width = 10.29;
                        ws.Column(4).Width = 12;
                        ws.Column(5).Width = 10.71;
                        ws.Column(6).Width = 10.29;
                        ws.Column(7).Width = 3.43;
                        ws.Column(8).Width = 10.86;
                        ws.Column(9).Width = 11;
                        ws.Column(10).Width = 11.14;
                        ws.Column(11).Width = 9.71;
                        ws.Column(12).Width = 12.14;
                        ws.Column(13).Width = 11.57;
                        ws.Column(14).Width = 10.71;
                        //Header
                        ws.Range(ws.Cell(1,1), ws.Cell(1, 14)).Merge();
                        ws.Value = "Historial Crediticio";
                        ws.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(1, 1).Style.Font.FontName = "Calibri";

                        for (int i = 1; i <= 14; i++)
                        {
                            ws.Cell(1, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(1, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }
                        // No. Contrato title
                        ws.Range(ws.Cell(2, 1), ws.Cell(2, 2)).Merge();
                        ws.Cell(2, 1).Value = "No. Contrato";
                        ws.Cell(2, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(2, 1).Style.Font.FontName = "Calibri";
                        ws.Cell(2, 1).Style.Font.Bold = true;
                        ws.Cell(2, 1).Style.Font.FontColor = XLColor.White;
                        ws.Cell(2, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 1; i <= 2; i++)
                        {
                            ws.Cell(2, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }
                        // No. Contrato
                        ws.Cell(2, 3).Value = actual.Item1;
                        ws.Cell(2, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(2, 3).Style.Font.FontName = "Calibri";
                        ws.Cell(2, 3).Style.Fill.SetBackgroundColor(XLColor.FromArgb(221, 235, 247, 255));

                        ws.Cell(2, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(2, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(2, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(2, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        // Socio title
                        ws.Cell(2, 4).Value = "Socio:";
                        ws.Cell(2, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(2, 4).Style.Font.FontName = "Calibri";
                        ws.Cell(2, 4).Style.Font.Bold = true;
                        ws.Cell(2, 4).Style.Font.FontColor = XLColor.White;
                        ws.Cell(2, 4).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(2, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(2, 4).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(2, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(2, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        // Socio
                        ws.Range(ws.Cell(2, 5), ws.Cell(2, 14)).Merge();
                        ws.Cell(2, 5).Value = $"{socio}";
                        ws.Cell(2, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(2, 5).Style.Font.FontName = "Calibri";
                        ws.Cell(2, 5).Style.Fill.SetBackgroundColor(XLColor.FromArgb(221, 235, 247, 255));

                        for (int i = 5; i <= 14; i++)
                        {
                            ws.Cell(2, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(2, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        // Oficial title
                        ws.Range(ws.Cell(3, 1), ws.Cell(3, 2)).Merge();
                        ws.Cell(3, 1).Value = "Oficial";
                        ws.Cell(3, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(3, 1).Style.Font.FontName = "Calibri";
                        ws.Cell(3, 1).Style.Font.Bold = true;
                        ws.Cell(3,   1).Style.Font.FontColor = XLColor.White;
                        ws.Cell(3, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 1; i <= 2; i++)
                        {
                            ws.Cell(3, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(3, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(3, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(3, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }
                        // Oficial
                        ws.Range(ws.Cell(3, 3), ws.Cell(3, 14)).Merge();
                        ws.Cell(3, 3).Value = $"{actual.Item2}";
                        ws.Cell(3, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(3, 3).Style.Font.FontName = "Calibri";
                        ws.Cell(3, 3).Style.Fill.SetBackgroundColor(XLColor.FromArgb(221, 235, 247, 255));

                        for (int i = 3; i <= 14; i++)
                        {
                            ws.Cell(3, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(3, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(3, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(3, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        // Creditos anteriores header
                        ws.Range(ws.Cell(5, 1), ws.Cell(5, 14)).Merge();
                        ws.Cell(5, 1).Value = "Creditos Anteriores";
                        ws.Cell(5, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(5, 1).Style.Font.FontName = "Calibri";

                        for (int i = 1; i <= 14; i++)
                        {
                            ws.Cell(5, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(5, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(5, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(5, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        // Header tabla creditos anteriores
                        ws.Range(ws.Cell(6, 1), ws.Cell(6, 3)).Merge();
                        ws.Cell(6, 1).Value = "Credito";
                        ws.Cell(6, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 1).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 1).Style.Font.Bold = true;
                        ws.Cell(6, 1).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 1; i <= 3; i++)
                        {
                            ws.Cell(6, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Cell(6, 4).Value = "Fecha Inicio";
                        ws.Cell(6, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 4).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 4).Style.Font.Bold = true;
                        ws.Cell(6, 4).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 4).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(6, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 4).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(6, 5).Value = "Fecha Fin";
                        ws.Cell(6, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 5).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 5).Style.Font.Bold = true;
                        ws.Cell(6, 5).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 5).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(6, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 5).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Range(ws.Cell(6, 6), ws.Cell(6, 7)).Merge();
                        ws.Cell(6, 6).Value = "Ultimo Pago";
                        ws.Cell(6, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 6).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 6).Style.Font.Bold = true;
                        ws.Cell(6, 6).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 6).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 6; i <= 7; i++)
                        {
                            ws.Cell(6, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Range(ws.Cell(6, 8), ws.Cell(6, 9)).Merge();
                        ws.Cell(6, 8).Value = "Plazo quincenal";
                        ws.Cell(6, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 8).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 8).Style.Font.Bold = true;
                        ws.Cell(6, 8).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 8).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 8; i <= 9; i++)
                        {
                            ws.Cell(6, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Range(ws.Cell(6, 10), ws.Cell(6, 11)).Merge();
                        ws.Cell(6, 10).Value = "Pagos realizados";
                        ws.Cell(6, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 10).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 10).Style.Font.Bold = true;
                        ws.Cell(6, 10).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 10).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 10; i <= 11; i++)
                        {
                            ws.Cell(6, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(6, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Cell(6, 12).Value = "Prestado";
                        ws.Cell(6, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 12).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 12).Style.Font.Bold = true;
                        ws.Cell(6, 12).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 12).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(6, 12).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 12).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 12).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 12).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(6, 13).Value = "A pagar";
                        ws.Cell(6, 13).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 13).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 13).Style.Font.Bold = true;
                        ws.Cell(6, 13).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 13).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(6, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 13).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 13).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 13).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(6, 14).Value = "Pagado";
                        ws.Cell(6, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(6, 14).Style.Font.FontName = "Calibri";
                        ws.Cell(6, 14).Style.Font.Bold = true;
                        ws.Cell(6, 14).Style.Font.FontColor = XLColor.White;
                        ws.Cell(6, 14).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(6, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 14).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 14).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(6, 14).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        //Prestamos anteriores
                        int countA = 1;
                        int row = 7;
                        historial.ForEach(credito =>
                        {
                            act = countA++ % 2 == 0 ? odd : even;
                            ws.Range(ws.Cell(row, 1), ws.Cell(row, 3)).Merge();
                            ws.Cell(row, 1).Value = credito.Item1;
                            ws.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 1).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 1).Style.Fill.SetBackgroundColor(act);

                            for (int i = 1; i <= 3; i++)
                            {
                                ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            }

                            ws.Cell(row, 4).Value = credito.Item3.ToShortDateString();
                            ws.Cell(row, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 4).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 4).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 4).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Cell(row, 5).Value = credito.Item4.ToShortDateString();
                            ws.Cell(row, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 5).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 5).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 5).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Range(ws.Cell(row, 6), ws.Cell(row, 7)).Merge();
                            ws.Cell(row, 6).Value = credito.Item4.ToShortDateString();
                            ws.Cell(row, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 6).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 6).Style.Fill.SetBackgroundColor(act);

                            for (int i = 6; i <= 7; i++)
                            {
                                ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            }

                            ws.Range(ws.Cell(row, 8), ws.Cell(row, 9)).Merge();
                            ws.Cell(row, 8).Value = credito.Item6;
                            ws.Cell(row, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 8).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 8).Style.Fill.SetBackgroundColor(act);

                            for (int i = 8; i <= 9; i++)
                            {
                                ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            }

                            ws.Range(ws.Cell(row, 10), ws.Cell(row, 11)).Merge();
                            ws.Cell(row, 10).Value = credito.Item7;
                            ws.Cell(row, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 10).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 10).Style.Fill.SetBackgroundColor(act);

                            for (int i = 10; i <= 11; i++)
                            {
                                ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            }

                            ws.Cell(row, 12).Value = credito.Item8.ToString("C");
                            ws.Cell(row, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 12).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 12).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(row, 12).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 12).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 12).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 12).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Cell(row, 13).Value = credito.Item9.ToString("C");
                            ws.Cell(row, 13).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 13).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 13).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(row, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 13).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 13).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 13).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Cell(row, 14).Value = credito.Item10.ToString("C");
                            ws.Cell(row, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(row, 14).Style.Font.FontName = "Calibri";
                            ws.Cell(row, 14).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(row, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 14).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 14).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, 14).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            row++;
                        });
                        row++;

                        // Credito actual header
                        ws.Range(ws.Cell(row, 1), ws.Cell(row, 14)).Merge();
                        ws.Cell(row, 1).Value = "Credito Actual";
                        ws.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 1).Style.Font.FontName = "Calibri";

                        for (int i = 1; i <= 14; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        // Header tabla credito actuale
                        act = odd;
                        row++;
                        ws.Range(ws.Cell(row, 1), ws.Cell(row, 3)).Merge();
                        ws.Cell(row, 1).Value = "Credito";
                        ws.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 1).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 1).Style.Font.Bold = true;
                        ws.Cell(row, 1).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 1; i <= 3; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Cell(row, 4).Value = "Fecha Inicio";
                        ws.Cell(row, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 4).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 4).Style.Font.Bold = true;
                        ws.Cell(row, 4).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 4).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 4).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(row, 5).Value = "Fecha Fin";
                        ws.Cell(row, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 5).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 5).Style.Font.Bold = true;
                        ws.Cell(row, 5).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 5).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 5).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Range(ws.Cell(row, 6), ws.Cell(row, 7)).Merge();
                        ws.Cell(row, 6).Value = "Ultimo Pago";
                        ws.Cell(row, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 6).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 6).Style.Font.Bold = true;
                        ws.Cell(row, 6).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 6).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 6; i <= 7; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Range(ws.Cell(row, 8), ws.Cell(row, 9)).Merge();
                        ws.Cell(row, 8).Value = "Plazo quincenal";
                        ws.Cell(row, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 8).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 8).Style.Font.Bold = true;
                        ws.Cell(row, 8).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 8).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 8; i <= 9; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Range(ws.Cell(row, 10), ws.Cell(row, 11)).Merge();
                        ws.Cell(row, 10).Value = "Pagos realizados";
                        ws.Cell(row, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 10).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 10).Style.Font.Bold = true;
                        ws.Cell(row, 10).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 10).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 10; i <= 11; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Cell(row, 12).Value = "Prestado";
                        ws.Cell(row, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 12).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 12).Style.Font.Bold = true;
                        ws.Cell(row, 12).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 12).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(row, 12).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 12).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 12).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 12).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(row, 13).Value = "A pagar";
                        ws.Cell(row, 13).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 13).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 13).Style.Font.Bold = true;
                        ws.Cell(row, 13).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 13).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(row, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 13).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 13).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 13).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(row, 14).Value = "Pagado";
                        ws.Cell(row, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 14).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 14).Style.Font.Bold = true;
                        ws.Cell(row, 14).Style.Font.FontColor = XLColor.White;
                        ws.Cell(row, 14).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(row, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 14).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 14).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 14).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        //Prestamo actual
                        row++;
                        ws.Range(ws.Cell(row, 1), ws.Cell(row, 3)).Merge();
                        ws.Cell(row, 1).Value = actual.Item1;
                        ws.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 1).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 1).Style.Fill.SetBackgroundColor(act);

                        for (int i = 1; i <= 3; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Cell(row, 4).Value = actual.Item3.ToShortDateString();
                        ws.Cell(row, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 4).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 4).Style.Fill.SetBackgroundColor(act);

                        ws.Cell(row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 4).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(row, 5).Value = actual.Item4.ToShortDateString();
                        ws.Cell(row, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 5).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 5).Style.Fill.SetBackgroundColor(act);

                        ws.Cell(row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 5).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Range(ws.Cell(row, 6), ws.Cell(row, 7)).Merge();
                        ws.Cell(row, 6).Value = actual.Item4.ToShortDateString();
                        ws.Cell(row, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 6).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 6).Style.Fill.SetBackgroundColor(act);

                        for (int i = 6; i <= 7; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Range(ws.Cell(row, 8), ws.Cell(row, 9)).Merge();
                        ws.Cell(row, 8).Value = actual.Item6;
                        ws.Cell(row, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 8).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 8).Style.Fill.SetBackgroundColor(act);

                        for (int i = 8; i <= 9; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Range(ws.Cell(row, 10), ws.Cell(row, 11)).Merge();
                        ws.Cell(row, 10).Value = actual.Item7;
                        ws.Cell(row, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 10).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 10).Style.Fill.SetBackgroundColor(act);

                        for (int i = 10; i <= 11; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Cell(row, 12).Value = actual.Item8.ToString("C");
                        ws.Cell(row, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 12).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 12).Style.Fill.SetBackgroundColor(act);

                        ws.Cell(row, 12).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 12).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 12).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 12).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(row, 13).Value = actual.Item9.ToString("C");
                        ws.Cell(row, 13).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 13).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 13).Style.Fill.SetBackgroundColor(act);

                        ws.Cell(row, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 13).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 13).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 13).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(row, 14).Value = actual.Item10.ToString("C");
                        ws.Cell(row, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 14).Style.Font.FontName = "Calibri";
                        ws.Cell(row, 14).Style.Fill.SetBackgroundColor(act);

                        ws.Cell(row, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 14).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 14).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(row, 14).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        
                        // Headers estado actual
                        row+= 2;
                        ws.Range(ws.Cell(row, 1), ws.Cell(row, 5)).Merge();
                        ws.Cell(row, 1).Value = "Depositos";
                        ws.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 1).Style.Font.FontName = "Calibri";

                        for (int i = 1; i <= 5; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Range(ws.Cell(row, 7), ws.Cell(row, 14)).Merge();
                        ws.Cell(row, 7).Value = "Estado del credito";
                        ws.Cell(row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(row, 7).Style.Font.FontName = "Calibri";

                        for (int i = 7; i <= 14; i++)
                        {
                            ws.Cell(row, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(row, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        // Header tabla depositos
                        int rowC = row + 1;
                        int rowD = row + 1;
                        ws.Cell(rowC, 1).Value = "#";
                        ws.Cell(rowC, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowC, 1).Style.Font.FontName = "Calibri";
                        ws.Cell(rowC, 1).Style.Font.Bold = true;
                        ws.Cell(rowC, 1).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowC, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowC, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowC, 2).Value = "Dia deposito";
                        ws.Cell(rowC, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowC, 2).Style.Font.FontName = "Calibri";
                        ws.Cell(rowC, 2).Style.Font.Bold = true;
                        ws.Cell(rowC, 2).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowC, 2).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowC, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 2).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 2).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowC, 3).Value = "Folio";
                        ws.Cell(rowC, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowC, 3).Style.Font.FontName = "Calibri";
                        ws.Cell(rowC, 3).Style.Font.Bold = true;
                        ws.Cell(rowC, 3).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowC, 3).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowC, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowC, 4).Value = "Banco";
                        ws.Cell(rowC, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowC, 4).Style.Font.FontName = "Calibri";
                        ws.Cell(rowC, 4).Style.Font.Bold = true;
                        ws.Cell(rowC, 4).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowC, 4).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowC, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 4).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowC, 5).Value = "Monto";
                        ws.Cell(rowC, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowC, 5).Style.Font.FontName = "Calibri";
                        ws.Cell(rowC, 5).Style.Font.Bold = true;
                        ws.Cell(rowC, 5).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowC, 5).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowC, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 5).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        // Tabla depositos
                        rowC++;
                        List<(DateTime, String, String, Double)> depositos = hcc.obtenerDepositos(actual.Item1);
                        double totalDep = 0;
                        int count = 1;
                        if (depositos.Count != 0)
                        {
                            depositos.ForEach(dep =>
                            {
                                act = count % 2 == 0 ? odd : even;
                                ws.Cell(rowC, 1).Value = count++;
                                ws.Cell(rowC, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowC, 1).Style.Font.FontName = "Calibri";
                                ws.Cell(rowC, 1).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowC, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowC, 2).Value = dep.Item1.ToShortDateString();
                                ws.Cell(rowC, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowC, 2).Style.Font.FontName = "Calibri";
                                ws.Cell(rowC, 2).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowC, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 2).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 2).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowC, 3).Value = dep.Item2;
                                ws.Cell(rowC, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowC, 3).Style.Font.FontName = "Calibri";
                                ws.Cell(rowC, 3).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowC, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowC, 4).Value = dep.Item3;
                                ws.Cell(rowC, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                                ws.Cell(rowC, 4).Style.Font.FontName = "Calibri";
                                ws.Cell(rowC, 4).Style.Alignment.WrapText = true;
                                ws.Cell(rowC, 4).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowC, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 4).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                totalDep += dep.Item4;
                                ws.Cell(rowC, 5).Value = dep.Item4.ToString("C");
                                ws.Cell(rowC, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowC, 5).Style.Font.FontName = "Calibri";
                                ws.Cell(rowC, 5).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowC, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowC, 5).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                rowC++;
                            });
                        }

                        // Total depositos
                        act = count % 2 == 0 ? odd : even;
                        ws.Range(ws.Cell(rowC, 1), ws.Cell(rowC, 4)).Merge();
                        ws.Cell(rowC, 1).Value = "Total:";
                        ws.Cell(rowC, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowC, 1).Style.Font.FontName = "Calibri";
                        ws.Cell(rowC, 1).Style.Font.Bold = true;
                        ws.Cell(rowC, 1).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowC, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        for (int i = 1; i <= 4; i++)
                        {
                            ws.Cell(rowC, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowC, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowC, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowC, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        }

                        ws.Cell(rowC, 5).Value = totalDep.ToString("C");
                        ws.Cell(rowC, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowC, 5).Style.Font.FontName = "Calibri";
                        ws.Cell(rowC, 5).Style.Fill.SetBackgroundColor(act);

                        ws.Cell(rowC, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowC, 5).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        // Header tabla deuda
                        ws.Cell(rowD, 7).Value = "#";
                        ws.Cell(rowD, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowD, 7).Style.Font.FontName = "Calibri";
                        ws.Cell(rowD, 7).Style.Font.Bold = true;
                        ws.Cell(rowD, 7).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowD, 7).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowD, 7).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 7).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 7).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowD, 8).Value = "Quincena";
                        ws.Cell(rowD, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowD, 8).Style.Font.FontName = "Calibri";
                        ws.Cell(rowD, 8).Style.Font.Bold = true;
                        ws.Cell(rowD, 8).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowD, 8).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowD, 8).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 8).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 8).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 8).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowD, 9).Value = "Capital";
                        ws.Cell(rowD, 9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowD, 9).Style.Font.FontName = "Calibri";
                        ws.Cell(rowD, 9).Style.Font.Bold = true;
                        ws.Cell(rowD, 9).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowD, 9).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowD, 9).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 9).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 9).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowD, 10).Value = "Intereses";
                        ws.Cell(rowD, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowD, 10).Style.Font.FontName = "Calibri";
                        ws.Cell(rowD, 10).Style.Font.Bold = true;
                        ws.Cell(rowD, 10).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowD, 10).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowD, 10).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 10).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 10).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowD, 11).Value = "IVA";
                        ws.Cell(rowD, 11).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowD, 11).Style.Font.FontName = "Calibri";
                        ws.Cell(rowD, 11).Style.Font.Bold = true;
                        ws.Cell(rowD, 11).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowD, 11).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowD, 11).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 11).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 11).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 11).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowD, 12).Value = "Moratorios";
                        ws.Cell(rowD, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowD, 12).Style.Font.FontName = "Calibri";
                        ws.Cell(rowD, 12).Style.Font.Bold = true;
                        ws.Cell(rowD, 12).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowD, 12).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowD, 12).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 12).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 12).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 12).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowD, 13).Value = "Total Pago";
                        ws.Cell(rowD, 13).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowD, 13).Style.Font.FontName = "Calibri";
                        ws.Cell(rowD, 13).Style.Font.Bold = true;
                        ws.Cell(rowD, 13).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowD, 13).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowD, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 13).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 13).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 13).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        ws.Cell(rowD, 14).Value = "Pagado";
                        ws.Cell(rowD, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(rowD, 14).Style.Font.FontName = "Calibri";
                        ws.Cell(rowD, 14).Style.Font.Bold = true;
                        ws.Cell(rowD, 14).Style.Font.FontColor = XLColor.White;
                        ws.Cell(rowD, 14).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                        ws.Cell(rowD, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 14).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 14).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(rowD, 14).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                        // Tabla deuda
                        rowD++;
                        List<(DateTime, Double, Double, Double, Double, Double, Double)> deuda = hcc.quincenas(actual.Item1);
                        Double totCap = 0, totInt = 0, totIVA=0, totMora = 0, totPago = 0, totPaga = 0;
                        if (deuda.Count != 0)
                        {
                            count = 1;
                            deuda.ForEach(deu =>
                            {
                                act = count % 2 == 0 ? odd : even;
                                ws.Cell(rowD, 7).Value = count++;
                                ws.Cell(rowD, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowD, 7).Style.Font.FontName = "Calibri";
                                ws.Cell(rowD, 7).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowD, 7).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 7).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 7).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowD, 8).Value = deu.Item1.ToShortDateString();
                                ws.Cell(rowD, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowD, 8).Style.Font.FontName = "Calibri";
                                ws.Cell(rowD, 8).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowD, 8).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 8).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 8).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 8).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowD, 9).Value = deu.Item2.ToString("C");
                                totCap += deu.Item2;
                                ws.Cell(rowD, 9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowD, 9).Style.Font.FontName = "Calibri";
                                ws.Cell(rowD, 9).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowD, 9).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 9).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 9).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowD, 10).Value = deu.Item3.ToString("C");
                                totInt += deu.Item3;
                                ws.Cell(rowD, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowD, 10).Style.Font.FontName = "Calibri";
                                ws.Cell(rowD, 10).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowD, 10).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 10).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 10).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowD, 11).Value = deu.Item4.ToString("C");
                                totIVA += deu.Item4;
                                ws.Cell(rowD, 11).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowD, 11).Style.Font.FontName = "Calibri";
                                ws.Cell(rowD, 11).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowD, 11).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 11).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 11).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 11).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowD, 12).Value = deu.Item5.ToString("C");
                                totMora += deu.Item5;
                                ws.Cell(rowD, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowD, 12).Style.Font.FontName = "Calibri";
                                ws.Cell(rowD, 12).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowD, 12).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 12).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 12).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 12).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowD, 13).Value = deu.Item6.ToString("C");
                                totPago += deu.Item6;
                                ws.Cell(rowD, 13).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowD, 13).Style.Font.FontName = "Calibri";
                                ws.Cell(rowD, 13).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowD, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 13).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 13).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 13).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                                ws.Cell(rowD, 14).Value = deu.Item7.ToString("C");
                                totPaga += deu.Item7;
                                ws.Cell(rowD, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(rowD, 14).Style.Font.FontName = "Calibri";
                                ws.Cell(rowD, 14).Style.Fill.SetBackgroundColor(act);

                                ws.Cell(rowD, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 14).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 14).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, 14).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                rowD++;
                            });

                            // Totales deuda
                            act = count % 2 == 0 ? odd : even;
                            ws.Range(ws.Cell(rowD, 7), ws.Cell(rowD, 8)).Merge();
                            ws.Cell(rowD, 7).Value = "Totales:";
                            ws.Cell(rowD, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(rowD, 7).Style.Font.FontName = "Calibri";
                            ws.Cell(rowD, 7).Style.Font.Bold = true;
                            ws.Cell(rowD, 7).Style.Font.FontColor = XLColor.White;
                            ws.Cell(rowD, 7).Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 73, 125, 255));

                            for (int i = 7; i <= 8; i++)
                            {
                                ws.Cell(rowD, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(rowD, i).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            }

                            ws.Cell(rowD, 9).Value = totCap.ToString("C");
                            ws.Cell(rowD, 9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(rowD, 9).Style.Font.FontName = "Calibri";
                            ws.Cell(rowD, 9).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(rowD, 9).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 9).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 9).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Cell(rowD, 10).Value = totInt.ToString("C");
                            ws.Cell(rowD, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(rowD, 10).Style.Font.FontName = "Calibri";
                            ws.Cell(rowD, 10).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(rowD, 10).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 10).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 10).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Cell(rowD, 11).Value = totIVA.ToString("C");
                            ws.Cell(rowD, 11).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(rowD, 11).Style.Font.FontName = "Calibri";
                            ws.Cell(rowD, 11).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(rowD, 11).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 11).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 11).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 11).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Cell(rowD, 12).Value = totMora.ToString("C");
                            ws.Cell(rowD, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(rowD, 12).Style.Font.FontName = "Calibri";
                            ws.Cell(rowD, 12).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(rowD, 12).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 12).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 12).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 12).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Cell(rowD, 13).Value = totPago.ToString("C");
                            ws.Cell(rowD, 13).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(rowD, 13).Style.Font.FontName = "Calibri";
                            ws.Cell(rowD, 13).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(rowD, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 13).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 13).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 13).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            ws.Cell(rowD, 14).Value = totPaga.ToString("C");
                            ws.Cell(rowD, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Cell(rowD, 14).Style.Font.FontName = "Calibri";
                            ws.Cell(rowD, 14).Style.Fill.SetBackgroundColor(act);

                            ws.Cell(rowD, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 14).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 14).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(rowD, 14).Style.Border.TopBorder = XLBorderStyleValues.Thin;

                            wb.SaveAs(sfd.FileName);
                        }
                    }
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}