using Modulos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulos
{
    public partial class Captura : Form
    {
        List<string> allItems = new List<string>();
        List<string> Bancos = new List<string>();
        List<int> idsDepositos = new List<int>();
        List<(bool, int, bool, double)> desc = new List<(bool, int, bool, double)>();
        int Credito;
        public static Boolean Activo = false;

        public Captura()
        {
            InitializeComponent();
            Captura_Controller cc = new Captura_Controller();

            allItems = cc.Socios();
            Bancos = cc.Bancos();

            comboBox2.DataSource = allItems;
            comboBox3.DataSource = Bancos;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            StartPosition = FormStartPosition.CenterScreen;

            DataTable dtm = new DataTable();
            dtm.Columns.Add("QUINCENA");
            dtm.Columns.Add("#");
            dtm.Columns.Add("CAPITAL");
            dtm.Columns.Add("NORMAL");
            dtm.Columns.Add("PAGADO");
            dtm.Columns.Add("VENCIDO");

            DataTable dtd = new DataTable();
            dtd.Columns.Add("DIA DEPOSITO");
            dtd.Columns.Add("FOLIO");
            dtd.Columns.Add("BANCO");
            dtd.Columns.Add("MONTO");

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            adgvQuincenas.Columns.Add(checkColumn);

            adgvQuincenas.DataSource = dtm;
            adgvQuincenas.RowHeadersVisible = false;

            adgvDepositos.DataSource = dtd;
            adgvDepositos.RowHeadersVisible = false;

            adgvQuincenas.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvQuincenas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvQuincenas.Columns[0].Width = 20;

            adgvQuincenas.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            adgvQuincenas.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvQuincenas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvQuincenas.Columns[2].Width = 50;

            adgvQuincenas.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvQuincenas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvQuincenas.Columns[3].Width = 70;

            adgvQuincenas.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvQuincenas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvQuincenas.Columns[4].Width = 80;

            adgvQuincenas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            adgvDepositos.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvDepositos.Columns[0].Width = 110;

            adgvDepositos.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvDepositos.Columns[1].Width = 75;

            adgvDepositos.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            adgvDepositos.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            adgvDepositos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adgvDepositos.Columns[3].Width = 80;

            adgvDepositos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            adgvQuincenas.Refresh();
            adgvDepositos.Refresh();
            cbTipoPago.SelectedIndex = 0;
            textBox3.Enabled = false;
            textBox3.BackColor = Color.WhiteSmoke;

            Activo = true;
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            String txt = comboBox2.Text;

            List<string> filteredItems = allItems.FindAll(x => x.ToLower().Contains(txt.ToLower()));

            comboBox2.DataSource = filteredItems;

            comboBox2.DroppedDown = true;

            comboBox2.IntegralHeight = false;

            comboBox2.SelectedIndex = -1;

            comboBox2.Text = txt;

            comboBox2.SelectionStart = txt.Length;

            comboBox2.SelectionLength = 0;

            comboBox2.DropDownHeight = 150;
        }

        private void comboBox3_TextUpdate(object sender, EventArgs e)
        {
            String txt = comboBox3.Text;

            List<string> filteredItems = Bancos.FindAll(x => x.ToLower().Contains(txt.ToLower()));

            comboBox3.DataSource = filteredItems;

            comboBox3.DroppedDown = true;

            comboBox3.IntegralHeight = false;

            comboBox3.SelectedIndex = -1;

            comboBox3.Text = txt;

            comboBox3.SelectionStart = txt.Length;

            comboBox3.SelectionLength = 0;

            comboBox3.DropDownHeight = 150;
        }

       private bool ValidarFecha()
        {
            DateTime hoy = DateTime.Now;
            bool val = true;
            
            if (dateTimePicker1.Value.Date > hoy)
            {
                val = false;
                MessageBox.Show("Fecha Incorrecta, no puedes seleccionar una fecha futura", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
           
            return val;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Captura_Controller cc = new Captura_Controller();
            bool needUpdate = false;
            String mensaje = "", titulo = "";

            if (ValidarFecha())

            {
                


                if (cbTipoPago.SelectedIndex == 2)
                {
                    List<(int, bool)> aux = new List<(int, bool)>();
                    bool newDes = false;

                    for (int i = adgvQuincenas.RowCount - 1; i >= 0; i--)
                    {
                        if (desc[i].Item1 != (bool)(adgvQuincenas.Rows[i].Cells[0].Value))
                        {
                            newDes = true;

                            aux.Add((desc[i].Item2, desc[i].Item1));
                        }
                    }

                    if (newDes)
                    {
                        String[] txt = comboBox2.SelectedItem.ToString().Split(" ");
                        StorageClass.setIdC(Convert.ToInt32(txt[0]));

                        StorageClass.setIdsDeuda(aux);
                        using (dialogCarga dc = new dialogCarga("Modificando deuda...", cc.modificar_descuentos))
                        {
                            dc.ShowDialog(this);
                        }
                        titulo = "Modificación de deuda";
                        mensaje = "Deuda modificada exitosamente";
                        button1.Text = "Guardar";
                        needUpdate = true;
                    }
                    else
                    {
                        MessageBox.Show("Seleccione la quincena que desea modificar.");
                    }
                }
                else if (cbTipoPago.SelectedIndex == 4)
                {
                    List<int> mora = new List<int>();
                    bool modif = false;

                    for (int i = adgvQuincenas.RowCount - 1; i >= 0; i--)
                    {
                        if (desc[i].Item3 != (bool)(adgvQuincenas.Rows[i].Cells[0].Value))
                        {
                            modif = true;
                            mora.Add(desc[i].Item2);
                        }
                    }

                    if (modif)
                    {
                        String[] txt = comboBox2.SelectedItem.ToString().Split(" ");
                        StorageClass.setIdC(Convert.ToInt32(txt[0]));

                        StorageClass.setIds(mora);
                        using (dialogCarga dc = new dialogCarga("Modificando deuda...", cc.quitar_moratorios))
                        {
                            dc.ShowDialog(this);
                        }

                        titulo = "Modificación de deuda";
                        mensaje = "Deuda modificada exitosamente";

                        needUpdate = true;
                    }
                }
                else if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
                {

                    if (cbTipoPago.SelectedIndex == 0 || cbTipoPago.SelectedIndex == 3)
                    {
                        String[] txt = comboBox2.SelectedItem.ToString().Split(" ");
                        StorageClass.setIdC(Convert.ToInt32(txt[0]));
                        StorageClass.setBanco(comboBox3.SelectedItem.ToString());
                        StorageClass.setFDeposito(dateTimePicker1.Value);
                        StorageClass.setFolio(textBox1.Text);
                        StorageClass.setMonto((textBox2.Text != "") ? float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat) : 0f);

                        if (cbTipoPago.SelectedIndex == 3)
                        {
                            if (textBox3.Text.Length != 0)
                            {
                                StorageClass.setMora(true);
                                StorageClass.setMontoMora(float.Parse(textBox3.Text, CultureInfo.InvariantCulture.NumberFormat));

                                using (dialogCarga dc = new dialogCarga("Capturando ficha...", cc.Captura))
                                {
                                    dc.ShowDialog(this);
                                }

                                titulo = "Captura de deposito";
                                mensaje = "Ficha capturada exitosamente";

                                needUpdate = true;
                            }
                            else
                            {
                                textBox3.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            using (dialogCarga dc = new dialogCarga("Capturando ficha...", cc.Captura))
                            {
                                dc.ShowDialog(this);
                            }

                            titulo = "Captura de deposito";
                            mensaje = "Ficha capturada exitosamente";

                            needUpdate = true;
                        }
                    }
                    else if (cbTipoPago.SelectedIndex == 1)
                    {
                        List<int> aux = new List<int>();
                        bool newDes = false;
                        float c = 0;

                        for (int i = adgvQuincenas.RowCount - 1; i >= 0; i--)
                        {
                            if (desc[i].Item1 != (bool)(adgvQuincenas.Rows[i].Cells[0].Value))
                            {
                                c++;
                                newDes = true;

                                aux.Add(desc[i].Item2);
                            }
                        }

                        StorageClass.canPagos = c;

                        if (newDes)
                        {
                            String[] txt = comboBox2.SelectedItem.ToString().Split(" ");
                            StorageClass.setIdC(Convert.ToInt32(txt[0]));
                            StorageClass.setBanco(comboBox3.SelectedItem.ToString());
                            StorageClass.setFDeposito(dateTimePicker1.Value);
                            StorageClass.setFolio(textBox1.Text);
                            StorageClass.setMonto((textBox2.Text != "") ? float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat) : 0f);

                            StorageClass.setIds(aux);
                            using (dialogCarga dc = new dialogCarga("Capturando ficha...", cc.descuentosCaptura))
                            {
                                dc.ShowDialog(this);
                            }

                            titulo = "Captura de deposito";
                            mensaje = "Ficha capturada exitosamente";

                            needUpdate = true;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una quincena a la cual hacer descuento.");
                        }
                    }

                }
                else
                {
                    if (textBox1.Text.Length == 0)
                    {
                        textBox1.BackColor = Color.Red;
                    }
                    else if (textBox2.Text.Length == 0)
                    {
                        textBox2.BackColor = Color.Red;
                    }
                }

                if (!StorageClass.validacion)
                {
                    MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK);
                }

                StorageClass.validacion = false;

                if (needUpdate)
                {
                    adgvQuincenas.DataSource = cc.quincenas(StorageClass.getIdC(), desc);
                    int rowView = 0;
                    for (int i = adgvQuincenas.Rows.Count - 1; i >= 0; i--)
                    {

                        adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                        adgvQuincenas.Rows[i].Cells[0].ReadOnly = desc[i].Item1;
                        adgvQuincenas.Rows[i].Cells[1].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[2].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[3].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[4].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[5].ReadOnly = true;

                        if (!adgvQuincenas.Rows[i].Cells[5].Value.ToString().Equals("$0") && rowView == 0)
                        {
                            rowView = i;

                        }
                        adgvQuincenas.Rows[i].Cells[6].ReadOnly = true;
                    }

                    adgvQuincenas.FirstDisplayedScrollingRowIndex = rowView;

                    adgvDepositos.DataSource = cc.depositos(StorageClass.getIdC(), idsDepositos);
                    adgvDepositos.FirstDisplayedScrollingRowIndex = adgvDepositos.RowCount - 1;

                    adgvQuincenas.Refresh();
                    adgvDepositos.Refresh();
                    Informacion();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox3.Enabled = false;
                    textBox3.BackColor = Color.WhiteSmoke;
                    cbTipoPago.SelectedIndex = 0;
                    dateTimePicker1.Value = DateTime.Now;
                }

            }
            

            comboBox2.Select();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            String[] txt = comboBox2.SelectedItem.ToString().Split(" ");
            int c = Convert.ToInt32(txt[0]);
            int rowView = 0;
            if (Credito != c)
            {
                Captura_Controller cc = new Captura_Controller();

                adgvQuincenas.DataSource = cc.quincenas(Convert.ToInt32(txt[0]), desc);
                Credito = Convert.ToInt32(txt[0]);
                StorageClass.setIdC(Credito);
                foreach (DataGridViewColumn column in adgvQuincenas.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                adgvQuincenas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                for (int i = adgvQuincenas.Rows.Count - 1; i >= 0; i--)
                {
                    adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                    adgvQuincenas.Rows[i].Cells[0].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[1].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[2].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[3].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[4].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[5].ReadOnly = true;

                    if (!adgvQuincenas.Rows[i].Cells[5].Value.ToString().Equals("$0") && rowView == 0)
                    {
                        rowView = i;
                    }

                    adgvQuincenas.Rows[i].Cells[6].ReadOnly = true;
                }

                if (rowView > 0)
                {
                    adgvQuincenas.FirstDisplayedScrollingRowIndex = rowView;
                }

                adgvDepositos.DataSource = cc.depositos(Convert.ToInt32(txt[0]), idsDepositos);

                if (adgvDepositos.RowCount > 1)
                {
                    adgvDepositos.FirstDisplayedScrollingRowIndex = adgvDepositos.RowCount - 1;
                }

                adgvQuincenas.Refresh();
                adgvDepositos.Refresh();
                Informacion();

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && comboBox2.SelectedIndex < 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && comboBox3.SelectedIndex < 0)
            {
                comboBox3.SelectedIndex = 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Captura_Controller cc = new Captura_Controller();

            var confirmResult = MessageBox.Show("¿Cancelar deposito con folio: " + adgvDepositos.Rows[adgvDepositos.CurrentCell.RowIndex].Cells[1].Value.ToString() + "?",
                                     "¿Cancelar deposito?",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                StorageClass.cancelar = idsDepositos[adgvDepositos.CurrentCell.RowIndex];
                using (dialogCarga dc = new dialogCarga("Cancelando deposito...", cc.cancelarDeposito))
                {
                    dc.ShowDialog(this);
                }

                if (StorageClass.validacion)
                {
                    MessageBox.Show("Deposito cancelado exitosamente", "Cancelar deposito", MessageBoxButtons.OK);
                }

                adgvQuincenas.DataSource = cc.quincenas(StorageClass.getIdC(), desc);
                int rowView = 0;
                for (int i = adgvQuincenas.Rows.Count - 1; i >= 0; i--)
                {

                    adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                    adgvQuincenas.Rows[i].Cells[0].ReadOnly = desc[i].Item1;
                    adgvQuincenas.Rows[i].Cells[1].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[2].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[3].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[4].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[5].ReadOnly = true;

                    if (!adgvQuincenas.Rows[i].Cells[5].Value.ToString().Equals("$0") && rowView == 0)
                    {
                        rowView = i;
                    }
                    adgvQuincenas.Rows[i].Cells[6].ReadOnly = true;
                }

                adgvQuincenas.FirstDisplayedScrollingRowIndex = rowView;

                adgvDepositos.DataSource = cc.depositos(StorageClass.getIdC(), idsDepositos);

                if (adgvDepositos.RowCount > 1)
                {
                    adgvDepositos.FirstDisplayedScrollingRowIndex = adgvDepositos.RowCount - 1;
                }

                adgvQuincenas.Refresh();
                adgvDepositos.Refresh();
                Informacion();

            }
        }

        private void cbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPago.SelectedIndex == 0)
            {
                button1.Text = "Guardar";
                textBox3.Text = "";
                textBox3.Enabled = false;
                textBox3.BackColor = Color.WhiteSmoke;

                for (int i = 0; i < adgvQuincenas.RowCount; i++)
                {
                    adgvQuincenas.Rows[i].Cells[0].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                }

            }
            else if (cbTipoPago.SelectedIndex == 1)
            {
                textBox3.Enabled = false;
                textBox3.BackColor = Color.WhiteSmoke;
                textBox3.Text = "";
                button1.Text = "Guardar";

                Captura_Controller cc = new Captura_Controller();

                String[] txt = comboBox2.Text.Split(" ");

                int c = Convert.ToInt32(txt[0]);

                if (Credito != c)
                {
                    adgvQuincenas.DataSource = cc.quincenas(c, desc);

                    Credito = c;
                    StorageClass.setIdC(Credito);
                    foreach (DataGridViewColumn column in adgvQuincenas.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    adgvQuincenas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    adgvQuincenas.Refresh();
                    Informacion();
                }

                for (int i = adgvQuincenas.Rows.Count - 1; i >= 0; i--)
                {
                    adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                    adgvQuincenas.Rows[i].Cells[0].ReadOnly = false;
                    adgvQuincenas.Rows[i].Cells[1].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[2].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[3].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[4].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[5].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[6].ReadOnly = true;
                }
            }
            else if (cbTipoPago.SelectedIndex == 2)
            {
                textBox3.Enabled = false;
                textBox3.BackColor = Color.WhiteSmoke;
                textBox3.Text = "";
                button1.Text = "Modificar descuentos";

                Captura_Controller cc = new Captura_Controller();


                String[] txt = comboBox2.Text.Split(" ");

                int c = Convert.ToInt32(txt[0]);

                if (Credito != c)
                {
                    adgvQuincenas.DataSource = cc.quincenas(c, desc);

                    Credito = Convert.ToInt32(c);
                    StorageClass.setIdC(Credito);
                    foreach (DataGridViewColumn column in adgvQuincenas.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    adgvQuincenas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    adgvQuincenas.Refresh();
                    Informacion();
                }

                for (int i = adgvQuincenas.Rows.Count - 1; i >= 0; i--)
                {
                    adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                    adgvQuincenas.Rows[i].Cells[0].ReadOnly = false;
                    adgvQuincenas.Rows[i].Cells[1].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[2].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[3].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[4].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[5].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[6].ReadOnly = true;
                }
            }
            else if (cbTipoPago.SelectedIndex == 3)
            {
                textBox3.Enabled = true;
                textBox3.BackColor = Color.White;
                textBox3.Text = "";
                button1.Text = "Guardar";

                for (int i = 0; i < adgvQuincenas.RowCount; i++)
                {
                    adgvQuincenas.Rows[i].Cells[0].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                }

            }
            else if (cbTipoPago.SelectedIndex == 4)
            {
                textBox3.Enabled = true;
                textBox3.BackColor = Color.WhiteSmoke;
                textBox3.Text = "";
                button1.Text = "Guardar";

                Captura_Controller cc = new Captura_Controller();

                String[] txt = comboBox2.Text.Split(" ");

                int c = Convert.ToInt32(txt[0]);

                if (Credito != c)
                {
                    adgvQuincenas.DataSource = cc.quincenas(c, desc);
                    Credito = c;
                    StorageClass.setIdC(Credito);
                    foreach (DataGridViewColumn column in adgvQuincenas.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    adgvQuincenas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    adgvQuincenas.Refresh();
                    Informacion();
                }

                for (int i = adgvQuincenas.Rows.Count - 1; i >= 0; i--)
                {
                    adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item3;
                    adgvQuincenas.Rows[i].Cells[0].ReadOnly = false;
                    adgvQuincenas.Rows[i].Cells[1].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[2].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[3].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[4].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[5].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[6].ReadOnly = true;
                }
            }
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex < 0)
            {
                comboBox3.SelectedIndex = 0;
            }
        }

        private void comboBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox2.SelectedIndex < 0)
                {
                    comboBox2.SelectedIndex = 0;
                }
                String[] txt = comboBox2.SelectedItem.ToString().Split(" ");
                int c = Convert.ToInt32(txt[0]);
                int rowView = 0;
                if (Credito != c)
                {
                    Captura_Controller cc = new Captura_Controller();

                    adgvQuincenas.DataSource = cc.quincenas(Convert.ToInt32(txt[0]), desc);
                    Credito = Convert.ToInt32(txt[0]);
                    StorageClass.setIdC(Credito);
                    foreach (DataGridViewColumn column in adgvQuincenas.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    adgvQuincenas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    for (int i = adgvQuincenas.Rows.Count - 1; i >= 0; i--)
                    {
                        adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                        adgvQuincenas.Rows[i].Cells[0].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[1].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[2].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[3].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[4].ReadOnly = true;
                        adgvQuincenas.Rows[i].Cells[5].ReadOnly = true;

                        if (!adgvQuincenas.Rows[i].Cells[5].Value.ToString().Equals("$0") && rowView == 0)
                        {
                            rowView = i;
                        }

                        adgvQuincenas.Rows[i].Cells[6].ReadOnly = true;
                    }

                    if (rowView > 0)
                    {
                        adgvQuincenas.FirstDisplayedScrollingRowIndex = rowView;
                    }

                    adgvDepositos.DataSource = cc.depositos(Convert.ToInt32(txt[0]), idsDepositos);

                    if (adgvDepositos.RowCount > 1)
                    {
                        adgvDepositos.FirstDisplayedScrollingRowIndex = adgvDepositos.RowCount - 1;
                    }

                    adgvQuincenas.Refresh();
                    adgvDepositos.Refresh();
                    Informacion();
                }
            }
        }

        public void Informacion()
        {
            lblOficial.Text = StorageClass.Oficial;
            lblMonto.Text = "$" + StorageClass.Monto;
            lblPagos.Text = StorageClass.nPagosCub + "/" + StorageClass.nPagos;
            lblVencido.Text = "$" + StorageClass.saldoVencido;
            lblLiquida.Text = "$" + StorageClass.liquida;
            lblPagado.Text = "$" + StorageClass.pagado;
        }

        private void adgvQuincenas_FilterStringChanged(object sender, EventArgs e)
        {
            ((DataView)adgvQuincenas.DataSource).RowFilter = adgvQuincenas.FilterString;
        }

        private void adgvQuincenas_SortStringChanged(object sender, EventArgs e)
        {
            ((DataView)adgvQuincenas.DataSource).Sort = adgvQuincenas.SortString;
        }

        private void adgvQuincenas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && (cbTipoPago.SelectedIndex == 1 || cbTipoPago.SelectedIndex == 2 || cbTipoPago.SelectedIndex == 4))
            {
                adgvQuincenas.Rows[e.RowIndex].Cells[0].Value = !((bool)adgvQuincenas.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void adgvDepositos_FilterStringChanged(object sender, EventArgs e)
        {
            ((DataView)adgvDepositos.DataSource).RowFilter = adgvDepositos.FilterString;
        }

        private void adgvDepositos_SortStringChanged(object sender, EventArgs e)
        {
            ((DataView)adgvDepositos.DataSource).Sort = adgvDepositos.SortString;
        }

        public void buscarDeuda(String contrato, String socio)
        {
            comboBox2.SelectedIndex = allItems.IndexOf((contrato + " - " + socio).Replace("  ", " "));

            int c = Convert.ToInt32(contrato);
            int rowView = 0;
            if (Credito != c)
            {
                Captura_Controller cc = new Captura_Controller();

                adgvQuincenas.DataSource = cc.quincenas(c, desc);
                Credito = Convert.ToInt32(c);
                StorageClass.setIdC(Credito);
                foreach (DataGridViewColumn column in adgvQuincenas.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                adgvQuincenas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                for (int i = adgvQuincenas.Rows.Count - 1; i >= 0; i--)
                {
                    adgvQuincenas.Rows[i].Cells[0].Value = desc[i].Item1;
                    adgvQuincenas.Rows[i].Cells[0].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[1].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[2].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[3].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[4].ReadOnly = true;
                    adgvQuincenas.Rows[i].Cells[5].ReadOnly = true;

                    if (!adgvQuincenas.Rows[i].Cells[5].Value.ToString().Equals("$0") && rowView == 0)
                    {
                        rowView = i;
                    }

                    adgvQuincenas.Rows[i].Cells[6].ReadOnly = true;
                }

                if (rowView > 0)
                {
                    adgvQuincenas.FirstDisplayedScrollingRowIndex = rowView;
                }

                adgvDepositos.DataSource = cc.depositos(c, idsDepositos);

                if (adgvDepositos.RowCount > 1)
                {
                    adgvDepositos.FirstDisplayedScrollingRowIndex = adgvDepositos.RowCount - 1;
                }

                adgvQuincenas.Refresh();
                adgvDepositos.Refresh();
                Informacion();
            }
        }

        private void Captura_FormClosing(object sender, FormClosingEventArgs e)
        {
            Activo = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)

        {
          
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


