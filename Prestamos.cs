using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Vml.Presentation;
using DocumentFormat.OpenXml.Vml;
using Microsoft.Office.Interop.Excel;
using Modulos.Clases;
using MySql.Data.MySqlClient;
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
    public partial class Prestamos : Form
    {
        Conexion Con;
        public Prestamos()
        {
            InitializeComponent();
            Con = new Conexion();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Prestamos_Load(object sender, EventArgs e)
        {
            Prestamos_Controller pc = new Prestamos_Controller();
            pc.consultarTabla(dataSocios);
            pc.consultarTabla2(dataActivos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prestamos_Agregar pa = new Prestamos_Agregar();
            pa.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Prestamos_Controller pc2 = new Prestamos_Controller();
            pc2.consultarTabla(dataSocios);
            pc2.consultarTabla2(dataActivos);
        }

        private void pictureRefresh_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureRefresh, "ACTUALIZAR");
        }

        private void pictureSalir_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pictureSalir, "SALIR");
        }

        private void dataSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //this.dataSocios.CurrentRow.Cells["Id"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prestamos_Editar pe = new Prestamos_Editar();
            pe.Show();
            Con.crearConexion();
            Con.OpenConnection();
            string query = "SELECT pr.Id, sucursal.Nombre, pr.Activo, pr.Estatus, concat(personal.Nombre, ' ', personal.Paterno, ' ', personal.Materno) AS 'Nombre Oficial'," +
                "concat(socios.Nombre, ' ', socios.Paterno, ' ', socios.Materno) AS 'Nombre Socio', pr.Nombre, pr.Paterno, pr.Materno, pr.IFE, pr.CURP, pr.Passaporte, " +
                "pr.RFC, pr.Monto, pr.IVA, fondeador.Fondeador , pr.Pagos, pr.Tasa, pr.FechaI, pr.Aval1, pr.A1Direccion, pr.A1Colonia, pr.A1Telefono, " +
                "pr.A1IFE, pr.Aval2, pr.A2Direccion, pr.A2Colonia, pr.A2Telefono, pr.A2IFE FROM prestamosind AS pr INNER JOIN sucursal ON pr.SucursalId = sucursal.Id" +
                " INNER JOIN personal ON pr.OficialId = personal.Id INNER JOIN socios ON pr.SocioId = socios.Id INNER JOIN fondeador ON pr.FuenteId = fondeador.Id" +
                " WHERE pr.Id = @NoContrato;";
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());
            cmd.Parameters.AddWithValue("@NoContrato", this.dataSocios.CurrentRow.Cells["No Contrato"].Value.ToString());


            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pe.textContrato.Text = dr["Id"].ToString();
                pe.textMonto.Text = dr["Monto"].ToString();
                pe.textIva.Text = dr["IVA"].ToString();
                pe.textPlazo.Text = dr["Pagos"].ToString();
                pe.comboSuc.Text = dr["Nombre"].ToString();
                pe.comboOficial.Text = dr["Nombre Oficial"].ToString();
                pe.comboSocio.Text = dr["Nombre Socio"].ToString();
                pe.textIne.Text = dr["IFE"].ToString();
                pe.textCurp.Text = dr["CURP"].ToString();
                pe.textTasa.Text = dr["Tasa"].ToString(); 
                pe.textPass.Text = dr["Passaporte"].ToString();
                pe.textRfc.Text = dr["RFC"].ToString();
                pe.comboFondeador.Text = dr["Fondeador"].ToString();
                pe.fechaInicio.Text = dr["FechaI"].ToString();
                pe.textNomAval1.Text = dr["Aval1"].ToString();
                pe.textDirAval1.Text = dr["A1Direccion"].ToString();
                pe.textColAval1.Text = dr["A1Colonia"].ToString();
                pe.textTelAval1.Text = dr["A1Telefono"].ToString();
                pe.textIneAval1.Text = dr["A1IFE"].ToString();
                pe.textNomAval2.Text = dr["Aval2"].ToString();
                pe.textDirAval2.Text = dr["A2Direccion"].ToString();
                pe.textColAval2.Text = dr["A2Colonia"].ToString();
                pe.textTelAval2.Text = dr["A2Telefono"].ToString();
                pe.textIneAval2.Text = dr["A2IFE"].ToString();
            }
            
            
        }

        private void sinAbrir_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿DESEA CANCELAR ESTE PRÉSTAMO?", "CONFIRMAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                Con.crearConexion();
                Con.OpenConnection();

                string query = ("DELETE FROM prestamosind WHERE Id = '" + this.dataSocios.CurrentRow.Cells["No Contrato"].Value.ToString() + "'");
                MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());

                cmd.ExecuteNonQuery();


                MessageBox.Show("PRÉSTAMO CANCELADO");

                Prestamos_Controller pc3 = new Prestamos_Controller();
                pc3.consultarTabla(dataSocios);
            }
        }
    }
}
