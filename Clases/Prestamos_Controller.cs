using DocumentFormat.OpenXml.Office2010.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosedXML.Excel.XLPredefinedFormat;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Modulos.Clases
{
    public class Prestamos_Controller
    {
        Conexion Con;

        public Prestamos_Controller()
        {
            Con = new Conexion();
        }

        public void consultarTabla(DataGridView dg)
        {
            Con.crearConexion();
            Con.OpenConnection();
            string query1 = "SELECT pr.Id AS 'No Contrato', concat(pr.Nombre, ' ', pr.Paterno, ' ', pr.Materno, ' ') AS Nombre, ciudad.Ciudad AS 'Municipio',\r\npr.Monto, pr.Monto/pr.Pagos + ((pr.Monto/pr.Pagos)*(pr.Tasa/100)*(pr.Pagos/2)) + ((pr.Monto/pr.Pagos)*(pr.Tasa/100)*(pr.Pagos/2)*0.16) \r\nAS 'Quincena Fondo' ,pr.Pagos, pr.Tasa, pr.IVA, pr.Aval1 AS 'Aval', concat(personal.Nombre, ' ', personal.Paterno, ' ', personal.Materno) as Oficial,\r\npr.FechaI AS 'Fecha de Inicio'\r\nFROM prestamosind as pr\r\nINNER JOIN socios ON pr.SocioId = socios.Id\r\nINNER JOIN localidad ON socios.LocalidadId = localidad.Id\r\nINNER JOIN ciudad ON localidad.CiudadId = ciudad.Id\r\nINNER JOIN personal ON pr.OficialId = personal.Id\t\r\nWHERE pr.Activo = 1 AND pr.Estatus = 1;";


            MySqlCommand query = new MySqlCommand(query1, Con.GetConnection());
            DataTable dt = new DataTable();
            MySqlDataAdapter da2 = new MySqlDataAdapter();
            da2.SelectCommand = query;
            dt.Clear();
            da2.Fill(dt);
            dg.DataSource = dt;
        }
        public void consultarTabla2(DataGridView dg2)
        {
            Con.crearConexion();
            Con.OpenConnection();
            string query1 = "SELECT pr.Id AS 'No Contrato', concat(pr.Nombre, ' ', pr.Paterno, ' ', pr.Materno, ' ') AS Nombre, ciudad.Ciudad AS 'Municipio',\r\npr.Monto, pr.Monto/pr.Pagos + ((pr.Monto/pr.Pagos)*(pr.Tasa/100)*(pr.Pagos/2)) + ((pr.Monto/pr.Pagos)*(pr.Tasa/100)*(pr.Pagos/2)*0.16) \r\nAS 'Quincena Fondo' ,pr.Pagos, pr.Tasa, pr.IVA, pr.Aval1 AS 'Aval', concat(personal.Nombre, ' ', personal.Paterno, ' ', personal.Materno) as Oficial,\r\npr.FechaI AS 'Fecha de Inicio'\r\nFROM prestamosind as pr\r\nINNER JOIN socios ON pr.SocioId = socios.Id\r\nINNER JOIN localidad ON socios.LocalidadId = localidad.Id\r\nINNER JOIN ciudad ON localidad.CiudadId = ciudad.Id\r\nINNER JOIN personal ON pr.OficialId = personal.Id\t\r\nWHERE pr.Activo = 1 AND pr.Estatus = 0;";


            MySqlCommand query = new MySqlCommand(query1, Con.GetConnection());
            DataTable dt2 = new DataTable();
            MySqlDataAdapter da2 = new MySqlDataAdapter();
            da2.SelectCommand = query;
            dt2.Clear();
            da2.Fill(dt2);
            dg2.DataSource = dt2;
        }
        public void llenarFondeador(ComboBox fon)
        {
            Con.crearConexion();
            Con.OpenConnection();
            string query = "SELECT Id, Fondeador FROM fondeador;";

            DataTable dt3 = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt3);

            fon.ValueMember = "Id";
            fon.DisplayMember = "Fondeador";
            fon.DataSource = dt3;
            fon.Text = "Seleccione un Fondeador";
        }
        public void llenarSucursal(ComboBox suc)
        {
            Con.crearConexion();
            Con.OpenConnection();
            string query = "SELECT Id, Nombre FROM sucursal;";

            DataTable dt4 = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt4);
            suc.ValueMember = "Id";
            suc.DisplayMember = "Nombre";
            suc.DataSource = dt4;
            suc.Text = "Seleccione una Sucursal";


        }
        public void llenarOficial(ComboBox ofi)
        {
            Con.crearConexion();
            Con.OpenConnection();
            string query = "SELECT personal.Id, concat(personal.Nombre, ' ', personal.Paterno, ' ', personal.Materno) AS Nombre FROM personal where PuestoId = 3 and Activo = 1;";

            DataTable dt5 = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt5);
            ofi.ValueMember = "Id";
            ofi.DisplayMember = "Nombre";
            ofi.DataSource = dt5;
            ofi.Text = "Seleccione un Oficial";

        }
        public void llenarSocio(ComboBox socio)
        {
            Con.crearConexion();
            Con.OpenConnection();
            string query = "SELECT Id, Nombre, Paterno, Materno, concat(Nombre, ' ', Paterno, ' ', Materno) AS 'Nombre Completo' FROM socios;";

            DataTable dt6 = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt6);
            socio.ValueMember = "Id";
            socio.DisplayMember = "Nombre Completo";
            socio.DataSource = dt6;
            

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt6.Rows)
            {
                coleccion.Add(Convert.ToString(row["Nombre Completo"]));
            }
            socio.AutoCompleteCustomSource = coleccion;
            socio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            socio.AutoCompleteSource = AutoCompleteSource.CustomSource;
            socio.Text = "Seleccione un Socio";
        }
       

    }
}