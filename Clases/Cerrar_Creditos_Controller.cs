using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class Cerrar_Creditos_Controller
    {
        Conexion con;

        public Cerrar_Creditos_Controller()
        {
            con = new Conexion();
        }

        public void Creditos(double monto, DataTable dtc, List<(int, String, double)> idCreditos)
        {
            dtc.Clear();
            idCreditos.Clear();

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand(queryCreditos(), con.GetConnection());
                command.CommandTimeout = 10000;
                MySqlDataReader data = command.ExecuteReader();

                double pendiente;
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        pendiente = (data.GetDouble(4) - data.GetDouble(5));
                        pendiente = pendiente < 0 ? 0 : pendiente;
                        if (pendiente <= monto)
                        {
                            idCreditos.Add((data.GetInt32(0), data.GetString(2), data.GetDouble(3)));
                            dtc.Rows.Add(data.GetInt32(0), data.GetString(1), "$" + Math.Round(pendiente, 2));
                        }
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine("Error consultando los creditos: " + ex.Message);
            } finally
            {
                con.CloseConnection();
            }
        }
        public void Quincenas(int id, DataTable dtq)
        {
            dtq.Clear();
            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand(queryQuincenas(id), con.GetConnection());
                command.CommandTimeout = 10000;
                MySqlDataReader data = command.ExecuteReader();

                double pago=0, pagado=0;
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        pago += data.GetDouble(1);
                        pagado += data.GetDouble(2);
                        dtq.Rows.Add(data.GetDateTime(0).ToShortDateString(), Math.Round(data.GetDouble(1), 2), Math.Round(data.GetDouble(2), 2));
                    }
                    dtq.Rows.Add("Totales", Math.Round(pago, 2), Math.Round(pagado, 2));
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error cargando la deuda: " + e.Message);
            } finally
            {
                con.CloseConnection();
            }
        }

        public bool cerrarCreditos(List<(int, String, double)> ids)
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();

                String query = "SET SQL_SAFE_UPDATES = 0;\n";

                ids.ForEach(id =>
                {
                    query += "update prestamosind set FHACambio = now(), USRCambio = " + StorageClass.getId() + ", Activo = 0, Estatus = 0 where Id = " + id.Item1 + ";\n" +
                    "update deudaindividual set FHACambio = now(), USRCambio = " + StorageClass.getId() + ", Estatus = 0 where Id = " + id.Item1 + ";\n";
                });

                query += "SET SQL_SAFE_UPDATES = 1;";
                
                MySqlCommand command = new MySqlCommand(query, con.GetConnection());
                command.CommandTimeout = 100000;
                command.ExecuteNonQuery();
                return true;
            } catch (Exception e)
            {
                Console.WriteLine("Error cerrando los creditos: " + e.Message);
                return false;
            } finally
            {
                con.CloseConnection();
            }
        }

        public void Depositos(int id, DataTable dtd)
        {
            dtd.Clear();
            try
            {
                con.crearConexion();
                con.OpenConnection();

                String query = "select DiaDeposito, Folio, Banco, Monto from depositoind where depositoind.Activo = 1 and depositoind.PrestamoId = " + id;

                MySqlCommand command = new MySqlCommand(query, con.GetConnection());
                command.CommandTimeout = 10000;
                MySqlDataReader data = command.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        dtd.Rows.Add(data.GetDateTime(0).ToShortDateString(), data.GetString(1), data.GetString(2), data.GetDouble(3));
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error al obtener los depositos: " + e.Message);
            } finally
            {
                con.CloseConnection();
            }
        }

        public String queryCreditos()
        {
            return "select " +
                "deudaindividual.PrestamoId, " +
                "concat(prestamosind.Nombre, ' ', prestamosind.Paterno, ' ', prestamosind.Materno) as Socio, " +
                "concat(personal.Nombre, ' ', personal.Paterno, ' ', personal.Materno) as Oficial, " +
                "prestamosind.Monto, " +
                "sum(deudaindividual.TotalPago) as Pagar, " +
                "IFNULL(Pagado, 0) " +
                "from deudaindividual " +
                "left join( " +
                "select " +
                "depositoind.PrestamoId, " +
                "sum(depositoind.monto) as Pagado " +
                "from depositoind " +
                "where Activo = 1 and PrestamoId in (select Id from prestamosind where (Activo = 1 and Estatus = 0) and Id != 0) group by PrestamoId) di on di.PrestamoId = deudaindividual.PrestamoId " +
                "left join prestamosind on prestamosind.id = deudaindividual.PrestamoId " +
                "left join personal on personal.id = prestamosind.OficialId " +
                "where deudaindividual.PrestamoId in (select Id from prestamosind where(Activo = 1 and Estatus = 0) and Id != 0) group by deudaindividual.PrestamoId " +
                "order by Oficial ASC, PrestamoId ASC; ";
        }

        public String queryQuincenas(int id)
        {
            return "select deudaindividual.FechaPago, TotalPago, ifnull(sum(ri.Monto), 0) as Pagado from deudaindividual " +
                "left join reciboind ri on deudaindividual.Id = ri.PagoNo and ri.Activo = 1 " +
                "where deudaindividual.PrestamoId = " + id + " and deudaindividual.Activo = 1 " +
                "group by PagoId";
        }
    }
}
