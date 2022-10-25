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
    public partial class Prestamos_Agregar : Form
    {
        Conexion Con;
        public Prestamos_Agregar()
        {
            InitializeComponent();
            Con = new Conexion();
        }

        private void Prestamos_Agregar_Load(object sender, EventArgs e)
        {
            Prestamos_Controller pc = new Prestamos_Controller();
            pc.llenarFondeador(comboFondeador);
            pc.llenarSucursal(comboSuc);
            pc.llenarOficial(comboOficial);
            pc.llenarSocio(comboSocio);
        }

        private void comboSocio_SelectedIndexChanged(object sender, EventArgs e)
        {
           

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fAlta = DateTime.Now;
            Con.crearConexion();
            Con.OpenConnection();

            string query = ("INSERT INTO prestamosind(FHAAlta, USRAlta, SucursalId, Activo, Estatus, OficialId, SocioId, Nombre, Paterno, Materno, IFE, CURP, Passaporte, RFC, " +
                "Monto, IVA, FuenteId, Pagos, Tasa, FechaI, Aval1, A1Direccion, A1Colonia, A1Telefono, A1IFE, Aval2, " +
                "A2Direccion, A2Colonia, A2Telefono, A2IFE) VALUES" +
                "('" + fAlta.ToString("yyyy-MM-dd HH:mm:ss:ff") + "'," + StorageClass.getId() + ", '" + comboSuc.SelectedValue + "', 1, 1, '" + comboOficial.SelectedValue + "', '" + comboSocio.SelectedValue + "',(SELECT Nombre FROM socios WHERE Id = '"+ comboSocio.SelectedValue+ "'),(SELECT Paterno FROM socios WHERE Id = '"+ comboSocio.SelectedValue+ "'),(SELECT Materno FROM socios WHERE Id = '"+ comboSocio.SelectedValue+"'), " +
                "'" + textIne.Text + "', '" + textCurp.Text + "','" + textPass.Text + "','" + textRfc.Text + "', " +
                "'" + textMonto.Text + "', '" + textIva.Text + "', '" + comboFondeador.SelectedValue + "', '" + textPlazo.Text + "', " +
                "'" + textTasa.Text + "', '" + fechaInicio.Text + "', '" + textNomAval1.Text + "', '" + textDirAval1.Text + "', " +
                "'" + textColAval1.Text + "', '" + textTelAval1.Text + "', '" + textIneAval1.Text + "', " +
                "'" + textNomAval2.Text + "', '" + textDirAval2.Text + "', '" + textColAval2.Text + "', " +
                "'" + textTelAval2.Text + "', '" + textIneAval2.Text + "');");
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());

            cmd.ExecuteNonQuery();


            MessageBox.Show("REGISTRO EXITOSO");


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

        private void comboSocio_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboSocio_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboSocio_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
