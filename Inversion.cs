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
    public partial class Inversion : Form
    {
        public Inversion()
        {
            InitializeComponent();

            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "yyyy-MM";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.CustomFormat = "yyyy-MM";

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpInicio.Text) <= Convert.ToDateTime(dtpFin.Text))
            {
                Inversion_Controller datos = new Inversion_Controller();
                DateTime fechaI = dtpInicio.Value;
                DateTime fechaF = dtpFin.Value;
                DataTable informacion = datos.RetornoInversion(fechaI.Year, fechaI.Month, fechaF.Year, fechaF.Month);
                dgvInversion.DataSource = informacion;

                dgvInversion.RowHeadersVisible = false;
                foreach (DataGridViewColumn column in dgvInversion.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvInversion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvInversion.Refresh();

            }
            else
            {
                MessageBox.Show("La fecha inicial debe ser menor a igual a la fecha final.");

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvInversion.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
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
                        try
                        {
                            int columnCount = dgvInversion.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dgvInversion.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvInversion.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgvInversion.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgvInversion.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Información exportada", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay información para exportar", "Info");
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Inversion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
