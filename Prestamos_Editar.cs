using Microsoft.Office.Interop.Excel;
using Modulos.Clases;
using MySql.Data.MySqlClient;
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
    public partial class Prestamos_Editar : Form
    {
        Conexion Con;
        public Prestamos_Editar()
        {
            InitializeComponent();
            Con = new Conexion();
        }

        private void Prestamos_Editar_Load(object sender, EventArgs e)
        {
            Prestamos_Controller pc = new Prestamos_Controller();
            pc.llenarFondeador(comboFondeador);
            pc.llenarSucursal(comboSuc);
            pc.llenarOficial(comboOficial);
            pc.llenarSocio(comboSocio);
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salir_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.salir, "SALIR");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
            DateTime fCambio = DateTime.Now;
            Con.crearConexion();
            Con.OpenConnection();

            string query = ("UPDATE prestamosind SET FHACambio = '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', " +
                "USRCambio = " + StorageClass.getId() + ", " +
                "OficialId = '" + comboOficial.SelectedValue + "', SocioId = '" + comboSocio.SelectedValue + "', " +
                "Nombre = (SELECT Nombre FROM socios WHERE Id = '" + comboSocio.SelectedValue + "'), " +
                "Paterno = (SELECT Paterno FROM socios WHERE Id = '" + comboSocio.SelectedValue + "'), " +
                "Materno = (SELECT Materno FROM socios WHERE Id = '" + comboSocio.SelectedValue + "'), " +
                "IFE = '" + textIne.Text + "', CURP = '" + textCurp.Text + "'," +
                "Passaporte = '" + textPass.Text + "', RFC = '" + textRfc.Text + "', " +
                "Monto = '" + textMonto.Text + "', IVA = '" + textIva.Text + "', " +
                "Pagos = '" + textPlazo.Text + "', Tasa = '" + textTasa.Text + "', " +
                "FechaI = '" + fechaInicio.Text + "', Aval1 = '" + textNomAval1.Text + "'," +
                "A1Direccion = '" + textDirAval1.Text + "', A1Colonia = '" + textColAval1.Text + "', " +
                "A1Telefono = '" + textTelAval1.Text + "', A1IFE = '" + textIneAval1.Text + "', " +
                "Aval2 = '" + textNomAval2.Text + "', A2Direccion = '" + textDirAval2.Text + "', " +
                "A2Colonia = '" + textColAval2.Text + "', A2Telefono = '" + textTelAval2.Text + "', A2IFE = '" + textIneAval2.Text + "' WHERE Id = '" + textContrato.Text + "';");
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());

            cmd.ExecuteNonQuery();


            MessageBox.Show("ACTUALIZACIÓN EXITOSA");


            textContrato.Text = "";
            comboSuc.Text = "";
            comboOficial.Text = "";
            comboSocio.Text = "";
            textIne.Text = "";
            textCurp.Text = "";
            textPass.Text = "";
            textRfc.Text = "";
            textMonto.Text = "";
            textIne.Text = "";
            textIva.Text = "";
            comboFondeador.Text = "";
            textPlazo.Text = "";
            textTasa.Text = "";
            fechaInicio.Text = "";
            textNomAval1.Text = "";
            textDirAval1.Text = "";
            textColAval1.Text = "";
            textTelAval1.Text = "";
            textIneAval1.Text = "";
            textNomAval2.Text = "";
            textDirAval2.Text = "";
            textColAval2.Text = "";
            textTelAval2.Text = "";
            textIneAval2.Text = "";
        }

        private void comboFondeador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboSuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboOficial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números");
                e.Handled = true;
                return;
            }
        }

        private void textTasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números");
                e.Handled = true;
                return;
            }
        }

        private void textIva_TextChanged(object sender, EventArgs e)
        {

        }

        private void textIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números");
                e.Handled = true;
                return;
            }
        }

        private void textPlazo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números");
                e.Handled = true;
                return;
            }
        }

        private void textTelAval1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números");
                e.Handled = true;
                return;
            }
        }

        private void textTelAval2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números");
                e.Handled = true;
                return;
            }
        }

        private void comboSocio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Con.crearConexion();
            Con.OpenConnection();
            string query = "SELECT IFE, CURP, RFC FROM socios WHERE Id = @id;";
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());
            cmd.Parameters.AddWithValue("@id", comboSocio.SelectedValue);


            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textIne.Text = dr["IFE"].ToString();
                textCurp.Text = dr["CURP"].ToString();
                textRfc.Text = dr["RFC"].ToString();
            }
        }
    }
}
