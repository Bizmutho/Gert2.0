using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Moratorios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosedXML.Excel.XLPredefinedFormat;
using DataTable = System.Data.DataTable;

namespace Modulos.Clases
{
    public class SociosCarteras_controller
    {
        Conexion Con;
        public int[] idOficial = {29, 30, 32, 87, 108, 110, 112, 144, 145, 146, 147, 148, 150, 151, 152, 155, 157, 160, 161, 163, 164, 165, 166,
           167, 168, 169, 170, 171, 172, 173,174,175,176,177,178,179,180,181,182,183,184,185,186,187, 188, 190, 191, 193, 194, 195, 196, 197, 198};



        public SociosCarteras_controller()
        {
            Con = new Conexion();
        }


        public void ConsultaTabla(DataGridView tb, int cb)
        {



            Con.crearConexion();
            Con.OpenConnection();
            string query1 = "";

            query1 = queryConsulta(idOficial[cb]);
            MySqlCommand query = new MySqlCommand(query1, Con.GetConnection());
            DataTable dt2 = new DataTable();
            MySqlDataAdapter da2 = new MySqlDataAdapter();
            da2.SelectCommand = query;
            dt2.Clear();
            da2.Fill(dt2);
            tb.DataSource = dt2;
        }

        public string queryConsulta(int idOficial)
        {
            string oficial = "";
            oficial = "select pr.Id, date(inicio) as FechaInicio, date(fin) as FechaFin, round(TotalPago, 2) TotalPago, " +
                    "concat(socios.Nombre, ' ', socios.Paterno, ' ', socios.Materno) Nombre, pr.Monto, pr.Pagos, pr.Tasa, ciudad.Ciudad, " +
                    "socios.Direccion, socios.Colonia, socios.NoExterior, socios.CodigoPostal, " +
                    "socios.Telefono, pr.Aval1, concat(pr.A1Direccion, ' Colonia ', pr.A1Colonia) DireccionAval, pr.A1Telefono " +
                    "from prestamosind as pr inner join socios on pr.SocioId = socios.Id " +
                    "inner join localidad on socios.LocalidadId = localidad.Id " +
                    "inner join ciudad on localidad.CiudadId = ciudad.Id " +
                    "inner join personal on pr.OficialId = personal.Id " +
                    "left join(select PrestamoId, min(FechaPago) as inicio from deudaindividual where Activo = 1 group by PrestamoId) minPago on minPago.PrestamoId = pr.id " +
                    "left join(select PrestamoId, max(FechaPago) as fin from deudaindividual where Activo = 1 group by PrestamoId) maxPago on maxPago.PrestamoId = pr.id " +
                    "left join(select PrestamoId, TotalPago, min(FechaPago) from deudaindividual where Activo = 1 group by PrestamoId) monPago on monPago.PrestamoId = pr.id " +
                    "where pr.OficialId =" + idOficial + " and pr.Activo = 1;";

            return oficial;
        }

        public void exportarTabla(DataGridView et)
        {
            Microsoft.Office.Interop.Excel.Application exp = new Microsoft.Office.Interop.Excel.Application();

            exp.Application.Workbooks.Add(true);
            int ic = 0;

            foreach (DataGridViewColumn columna in et.Columns)
            {
                ic++;

                exp.Cells[1, ic] = columna.Name;
            }

            int infi = 0;

            foreach (DataGridViewRow fila in et.Rows)
            {
                infi++;
                ic = 0;

                foreach (DataGridViewColumn columna in et.Columns)
                {
                    ic++;
                    exp.Cells[infi + 1, ic] = fila.Cells[columna.Name].Value;
                }
            }
            exp.Visible = true;
        }

        public void comboAbogado(ComboBox cbAbogados)
        {

            Con.crearConexion();
            Con.OpenConnection();
            string query = "SELECT Id, Concat(Nombre, ' ', Paterno, ' ', Materno) as Nombre FROM abogados;";

            DataTable dtAbogado = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dtAbogado);

            cbAbogados.ValueMember = "Id";
            cbAbogados.DisplayMember = "Nombre";
            cbAbogados.DataSource = dtAbogado;
            cbAbogados.Text = "Seleccione un Abogado";



            //cbAbogados.SelectedIndex = 0;


        }


    }
}
