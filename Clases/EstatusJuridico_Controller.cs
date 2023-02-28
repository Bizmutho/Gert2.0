using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class EstatusJuridico_Controller
    {
        Conexion con, conES;
        public EstatusJuridico_Controller ()
        {
            con = new Conexion();
            conES = new Conexion();
        }


        public List<(int, string)>LawyerList ()
        {
            con.crearConexion();
            con.OpenConnection();
            String sql = "select Id, concat(Nombre, ' ', Paterno, ' ', Materno) Nombre from abogados";
            List<(int, string)> lawyer = new List<(int, string)>();

            try
            {
                MySqlCommand cdm = new MySqlCommand(sql, con.GetConnection());
                cdm.CommandTimeout = 1000000;
                MySqlDataReader resultados = cdm.ExecuteReader();

                while (resultados.Read())
                {
                    lawyer.Add((resultados.GetInt32(0), resultados.GetString(1)));
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error al extraer datos de abogados "+ex);
            }
            finally { con.CloseConnection(); }

            return lawyer;
        }

        public void updateJuridico(String credito, string fInicio, string mora, string status, string obs)
        {
            con.crearConexion();
            con.OpenConnection();
            mora = mora.Remove(0, 1);
            float montoMora = float.Parse(mora);
            String sql = "update estatus_juridico set FechaOficio='"+fInicio+"' , Moratorios="+montoMora+" , Estatus = '"+status+"' , Observacion = '"+obs+"'  where IdPrestamo ="+credito;

            try
            {

                MySqlCommand cdm = new MySqlCommand(sql, con.GetConnection());
                if (cdm.ExecuteNonQuery() != -1)
                {
                    MessageBox.Show("Modificación exitosa");
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                MessageBox.Show(e.ToString());
            }
            finally { con.CloseConnection(); }
        }

        public DataView procesList (int oficial)
        {
            DateTime fechaof;
            int credito;
            string empresa;
            string municipio;
            string socio;
            string of;
            DateTime inicioCred;
            DateTime ultimoPago;
            float deuda;
            float mora;
            float montoAbogado;
            float total;
            string abogado;
            string status;
            float liquidoCon;
            string obs;

            DataTable dtm = new DataTable();
            dtm.Columns.Add("Fecha oficio");
            dtm.Columns.Add("No. Credito");
            dtm.Columns.Add("Empresa");
            dtm.Columns.Add("Municipio");
            dtm.Columns.Add("Socio");
            dtm.Columns.Add("Oficial");
            dtm.Columns.Add("Fecha inicio");
            dtm.Columns.Add("Ultimo pago");
            dtm.Columns.Add("Suerte principal");
            dtm.Columns.Add("Moratorio");
            dtm.Columns.Add("Gastos abogado");
            dtm.Columns.Add("Total demanda");
            dtm.Columns.Add("Abogado");
            dtm.Columns.Add("Estatus");
            dtm.Columns.Add("Liquido con");
            dtm.Columns.Add("Observaciones");

            try
            {
                con.crearConexion();
                con.OpenConnection();
                String sql = "select " +
                    "    pr.Id, " +
                    "    ej.FechaOficio, " +
                    "    cd.Ciudad, " +
                    "    concat(sc.Nombre, ' ', sc.Paterno, ' ', sc.Materno) Socio, " +
                    "    concat(pe.Nombre, ' ', pe.Paterno, ' ', pe.Materno) Oficial, " +
                    "    pr.FechaI, " +
                    "    max(di.DiaDeposito) as UltimoPago," +
                    "    ej.Moratorios, " +
                    "    concat(ab.Nombre, ' ', ab.Paterno, ' ', ab.Materno) Abogado, " +
                    "    ej.Estatus, " +
                    "    ej.liquido_con, " +
                    "    ej.Observacion " +
                    "from estatus_juridico as ej " +
                    "inner join prestamosind as pr on ej.IdPrestamo = pr.Id " +
                    "inner join socios as sc on pr.SocioId = sc.Id " +
                    "inner join localidad as lc on sc.LocalidadId = lc.Id " +
                    "inner join ciudad as cd on lc.CiudadId = cd.Id " +
                    "inner join personal as pe on pr.OficialId = pe.Id " +
                    "inner join abogados as ab on ej.Abogado = ab.Id " +
                    "inner join depositoind as di on di.PrestamoId = ej.IdPrestamo " +
                    "where ej.Activo = 1 and ej.Abogado = " + oficial.ToString();
                MySqlCommand cdm = new MySqlCommand(sql, con.GetConnection());
                cdm.CommandTimeout = 1000000;
                MySqlDataReader resultados = cdm.ExecuteReader();

                while (resultados.Read())
                {
                    credito = resultados.GetInt32(0);
                    fechaof = resultados.GetDateTime(1);
                    municipio = resultados.GetString(2);
                    empresa = "GERT";
                    socio = resultados.GetString(3);
                    of = resultados.GetString(4);
                    inicioCred = resultados.GetDateTime(5);
                    ultimoPago = resultados.GetDateTime(6);
                    mora = resultados.GetFloat(7);
                    abogado = resultados.GetString(8);
                    status = resultados.GetString(9);
                    liquidoCon = resultados.GetFloat(10);
                    obs = resultados.GetString(11);

                    deuda = obtenerDeuda(credito);
                    montoAbogado = (deuda + mora) * .20f;
                    total = deuda + mora + montoAbogado;

                    dtm.Rows.Add(fechaof.ToShortDateString(), credito, empresa, municipio, socio, of, inicioCred.ToShortDateString(), ultimoPago.ToShortDateString(), deuda.ToString("C"), mora.ToString("C"), montoAbogado.ToString("C"), total.ToString("C"), abogado, status, liquidoCon.ToString("C"), obs);
                }
            } catch (System.Exception ex)
            {
                Console.WriteLine("Error: "+ex);
                MessageBox.Show(ex.ToString());
            }
            finally { conES.CloseConnection();}

            return new DataView(dtm);
        }
        
        public float obtenerDeuda(int credito)
        {
            float saldo = 0;
            float pagado, pago;
            con.crearConexion();
            con.OpenConnection();
            String sql = "select TotalPago, sum(ri.Monto) as Pagado from deudaindividual left join reciboind ri on deudaindividual.Id = ri.PagoNo and ri.Activo = 1 where deudaindividual.PrestamoId = 160 and deudaindividual.Activo = 1 group by PagoId";
            
            try
            {
                MySqlCommand cdm = new MySqlCommand(sql, con.GetConnection());
                cdm.CommandTimeout = 1000000;
                MySqlDataReader resultados = cdm.ExecuteReader();

                while (resultados.Read())
                {
                    pago = resultados.GetFloat(0);
                    pagado = resultados.GetFloat(1);
                    saldo += pago - pagado;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al extraer datos de abogados " + ex);
            }
            finally { con.CloseConnection(); }

            return saldo;
        }
    }
}
