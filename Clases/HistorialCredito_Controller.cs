using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class HistorialCredito_Controller
    {
        Conexion con;

        public HistorialCredito_Controller()
        {
            con = new Conexion();
        }

        public List<(int, String)> obtenerSocios()
        {
            List<(int, String)> socios = new List<(int, String)>();

            try
            {
                con.crearConexion();
                con.OpenConnection();

                String sql = "SELECT id, concat(Nombre, ' ', Paterno, ' ', Materno) as socio FROM emprendedor.socios where Activo = 1";

                MySqlCommand comm = new MySqlCommand(sql, con.GetConnection());
                comm.CommandTimeout = 100000;
                MySqlDataReader data = comm.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        socios.Add((data.GetInt32(0), data.GetString(1)));
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            } finally
            {
                con.CloseConnection();
            }

            return socios;
        } 

        public List<(int, String, DateTime, DateTime, DateTime, int, int, double, double, double)> consultarHistorial(int socio)
        {
            List<(int, String, DateTime, DateTime, DateTime, int, int, double, double, double)> historial = new List<(int, String, DateTime, DateTime, DateTime, int, int, double, double, double)>();

            try
            {
                con.crearConexion();
                con.OpenConnection();

                String sql = "select " +
                    "pi.id as Credito, " +
                    "concat(p.Nombre, ' ', p.Paterno, ' ', p.Materno) as Oficial, " +
                    "pi.FechaI, " +
                    "FechaF, " +
                    "UltimoP, " +
                    "NoPagos, " +
                    "NoDepositos, " +
                    "pi.Monto, " +
                    "Pagar, " +
                    "Pagado " +
                    "from prestamosind pi " +
                    "left join (select PrestamoId, max(FechaPago) as FechaF, sum(TotalPago) as Pagar, count(id) as NoPagos from deudaindividual " +
                    "where Activo = 1 " +
                    "group by PrestamoId " +
                    ") FF on FF.PrestamoId = pi.Id left join (select PrestamoId, max(DiaDeposito) as UltimoP, sum(monto) as Pagado, count(id) as NoDepositos from depositoind where Activo = 1 group by PrestamoId) UP on UP.PrestamoId = pi.Id left join personal p on p.id = pi.Oficialid where not (pi.Activo = 0 and pi.Estatus = 1) " +
                    "and not (pi.Activo = 1 and pi.Estatus = 1) " +
                    $"and socioid = {socio};";

                MySqlCommand comm = new MySqlCommand(sql, con.GetConnection());
                comm.CommandTimeout = 100000;
                MySqlDataReader data = comm.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        historial.Add((
                            data.GetInt32(0),
                            data.GetString(1),
                            data.GetDateTime(2),
                            data.GetDateTime(3),
                            data.GetDateTime(4),
                            data.GetInt32(5),
                            data.GetInt32(6),
                            data.GetDouble(7),
                            data.GetDouble(8),
                            data.GetDouble(9)
                            ));
                    }
                }

            } catch(Exception e)
            {
                Console.WriteLine(e);
            } finally
            {
                con.CloseConnection();
            }

            return historial;
        }

        public List<(DateTime, String, String, Double)> obtenerDepositos(int credito)
        {
            List<(DateTime, String, String, Double)> depositos = new List<(DateTime, String, String, Double)>();
            try
            {
                con.crearConexion();
                con.OpenConnection();

                String query = "select depositoind.id, DiaDeposito, Folio, Banco, Monto from depositoind " +
                    "where depositoind.Activo = 1 and depositoind.PrestamoId = " + credito;

                MySqlCommand cmd = new MySqlCommand(query, con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();

                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        depositos.Add((
                            resultados.GetDateTime(1),
                            resultados.GetString(2),
                            resultados.GetString(3),
                            resultados.GetDouble(4)
                        ));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                resultados.Close();
            }
            catch (Exception e)
            {
                string x = e.Message;
                Console.WriteLine("4.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            return depositos;
        }

        public List<(DateTime, Double, Double, Double, Double, Double, Double)> quincenas(int credito)
        {
            List<(DateTime, Double, Double, Double, Double, Double, Double)> qncs = new List<(DateTime, Double, Double, Double, Double, Double, Double)>();
            DateTime qn;
            int np = 0, id, npag = 0;
            float cap = 0, norm, pag, pend, vencido = 0, salVen = 0, liquida = 0;
            double mora = 0, inte = 0, iva = 0;

            DateTime qncAct = DateTime.Now;

            if (qncAct.Day < 15)
            {
                if (qncAct.Day < 12)
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, 15);
                }
                else
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, DateTime.DaysInMonth(qncAct.Month, qncAct.Month));
                }
            }
            else
            {
                if (qncAct.Day >= 27)
                {
                    qncAct = new DateTime((qncAct.Month == 12) ? (qncAct.Year + 1) : qncAct.Year, (qncAct.Month == 12) ? 1 : (qncAct.Month + 1), 15); ;
                }
                else
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, DateTime.DaysInMonth(qncAct.Month, qncAct.Month));
                }
            }

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query(credito), con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();
                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {

                        id = resultados.GetInt32(0);
                        qn = resultados.GetDateTime(1);
                        np = resultados.GetInt32(2);
                        cap = resultados.GetFloat(3);

                        mora = resultados.GetFloat(4);

                        norm = resultados.GetFloat(5);
                        pag = resultados["Pagado"] != DBNull.Value ? resultados.GetFloat(6) : 0;
                        pend = norm - pag;

                        inte = resultados.GetFloat(9);
                        iva = resultados.GetFloat(10);

                        qncs.Add((qn, cap, inte, iva, mora, norm, pag));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                resultados.Close();
            }
            catch (Exception e)
            {
                string x = e.Message;
                Console.WriteLine("4.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            return qncs;
        }

        public string query(int credito)
        {
            string quincenas =
                "select deudaindividual.Id, deudaindividual.FechaPago, PagoId, deudaindividual.Monto, deudaindividual.Moratorio, TotalPago, sum(ri.Monto) as Pagado, concat(personal.nombre, ' ', personal.paterno, ' ', personal.materno) as Oficial, prestamosind.Monto as Prestado, deudaindividual.Intereses, deudaindividual.IVA  from deudaindividual " +
                "left join reciboind ri on deudaindividual.Id = ri.PagoNo and ri.Activo = 1 " +
                "left join prestamosind on prestamosind.id = deudaindividual.PrestamoId " +
                "left join personal on personal.id = prestamosind.OficialId " +
                "where deudaindividual.PrestamoId = " + credito + " and deudaindividual.Activo = 1 " +
                "group by PagoId";
            return quincenas;
        }
    }
}
