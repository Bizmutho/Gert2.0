using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class Carteras_Controller
    {
        Conexion con;
        public Carteras_Controller()
        {
            con = new Conexion();
        }

        public List<(String, String)> carteras()
        {
            List < (String, String) > carteras = new List<(String, String) >();

            try
            {
                con.crearConexion();
                con.OpenConnection();
                String query = "select id, concat(Nombre, ' ', Paterno, ' ', Materno) as Cartera from personal where Activo = 1";

                MySqlCommand mySqlCommand = new MySqlCommand(query, con.GetConnection());
                mySqlCommand.CommandTimeout = 100000;
                MySqlDataReader data = mySqlCommand.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        carteras.Add((data.GetString(0), data.GetString(1)));
                    }

                    return carteras;
                }

            } catch (Exception ex)
            {
                Console.WriteLine("Error obteniendo la lista de carteras: " + ex.Message);
            } finally
            {
                con.CloseConnection();
            }

            return null;
        }

        public List<(int, String, double, double)> socios(int oficial)
        {
            DateTime qncAct = DateTime.Now;
            
            if (qncAct.Day < 15)
            {
                if (qncAct.Day < 12)
                {
                    qncAct = new DateTime((qncAct.Month == 1) ? qncAct.Year - 1 : qncAct.Year, (qncAct.Month == 1) ? 12 : (qncAct.Month - 1), DateTime.DaysInMonth((qncAct.Month == 1) ? qncAct.Year - 1 : qncAct.Year, (qncAct.Month == 1) ? 12 : (qncAct.Month - 1)));
                }
                else
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, 15);
                }
            }
            else
            {
                if (qncAct.Day >= (DateTime.DaysInMonth(qncAct.Year, qncAct.Month) - 3))
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, DateTime.DaysInMonth(qncAct.Year, qncAct.Month));
                }
                else
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, 15);
                }
            }

            qncAct = new DateTime(2022,2,15);

            try
            {
                con.crearConexion();
                con.OpenConnection();

                List<(int, String, double, double)> socios = new List<(int, String, double, double)>();

                MySqlCommand mySqlCommand = new MySqlCommand(query(qncAct, oficial), con.GetConnection());
                mySqlCommand.CommandTimeout = 10000;
                MySqlDataReader data = mySqlCommand.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        socios.Add((data.GetInt32(0), data.GetString(1), data.GetDouble(2), data.GetDouble(3)));
                    }

                    return socios;
                }

            } catch (Exception ex)
            {
                Console.WriteLine("Error obteniendo la lista de socios: " + ex.Message);
            } finally
            {
                con.CloseConnection();
            }

            return null;
        }

        public String query(DateTime qnc, int Oficial)
        {
            return "select P_Id as Creditos, Socio, TotalPago, ifnull(sum(RI.Monto), 0) as Pagado from ( " +
                "SELECT Id as P_Id, concat(prestamosind.Nombre, ' ', prestamosind.Paterno, ' ', prestamosind.Materno) as Socio from prestamosind where Id in " +
                "(SELECT PrestamoId from deudaindividual where FechaPago = '" + qnc.Year + "-" + qnc.Month.ToString("00") + "-" + qnc.Day + "' and Activo = 1 and OficialCreditoId = " + Oficial+ ") " +
                "and not(Activo = 0 and Estatus = 1) " +
                "and Id not in (SELECT Id from prestamosind where(Activo = 0 and Estatus = 0) and FechaDeposito< '" + qnc.Year + "-" + qnc.Month.ToString("00") + "-" + (qnc.Day-1) + "' and OficialId = " + Oficial + ") " +
                ") prestamos " +
                "left join(select Id, PrestamoId, TotalPago, FechaPago, Activo from deudaindividual where OficialCreditoId = " + Oficial + ") DI on P_Id = DI.PrestamoId and FechaPago = '" + qnc.Year + "-" + qnc.Month.ToString("00") + "-" + qnc.Day + "' and Activo = 1 " +
                "left join(select PagoNo, Monto from reciboind where Activo = 1) RI on DI.Id = PagoNo " +
                "group by P_Id, PagoNo ";
        }
    }
}
