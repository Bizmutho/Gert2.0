using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class Depositos_Controller
    {
        Conexion con;
        public Depositos_Controller()
        {
            con = new Conexion();
        }

        public DataView depositos(DateTime start, DateTime end, String search)
        {
            DataTable datosT = new DataTable();
            datosT.Columns.Add("Contrato");
            datosT.Columns.Add("Socio");
            datosT.Columns.Add("Oficial");
            datosT.Columns.Add("Banco");
            datosT.Columns.Add("Fecha");
            datosT.Columns.Add("Folio");
            datosT.Columns.Add("Monto");

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query(start, end, search), con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();

                if (resultados.HasRows)
                {
                    int credito;
                    String socio, oficial, banco, folio;
                    DateTime fDeposito;
                    float monto;

                    while (resultados.Read())
                    {
                        credito = resultados.GetInt32(0);
                        socio = resultados.GetString(1);
                        oficial = resultados.GetString(2);
                        banco = resultados.GetString(3);
                        fDeposito = resultados.GetDateTime(4);
                        folio = resultados.GetString(5);
                        monto = resultados.GetFloat(6);

                        datosT.Rows.Add(credito, socio, oficial, banco, fDeposito.ToShortDateString(), folio, "$" + Math.Round(monto, 2));
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
                Console.WriteLine("Error consultando depositos: " + e);
            }
            finally { con.CloseConnection(); }

            return new DataView(datosT);
        }

        public String query(DateTime start, DateTime end, String search)
        {
            return "" +
                "select " +
                "   prestamoid, " +
                "   concat(prestamosind.Nombre, ' ', prestamosind.Paterno, ' ', prestamosind.Materno) as Socio, " +
                "   concat(personal.Nombre, ' ', personal.Paterno, ' ', personal.Materno) as Oficial, " +
                "   Banco, " +
                "   DiaDeposito, " +
                "   Folio, " +
                "   depositoind.Monto " +
                "from depositoind " +
                "left join personal on personal.id = depositoind.OficialCreditoId " +
                "left join prestamosind on prestamosind.id = depositoind.prestamoid " +
                "where depositoind.Activo = 1 " +
                "and DiaDeposito between '"+start.Year+"-"+start.Month.ToString("00")+"-"+start.Day.ToString("00")+"' and '"+end.Year+"-"+end.Month.ToString("00")+ "-"+end.Day.ToString("00")+"' " +
                "and( " +
                "   lower(prestamoid) like '%"+search+"%' or " +
                "   lower(concat(prestamosind.Nombre, ' ', prestamosind.Paterno, ' ', prestamosind.Materno)) like '%" + search + "%' or " +
                "   lower(concat(personal.Nombre, ' ', personal.Paterno, ' ', personal.Materno)) like '%" + search + "%' or " +
                "   lower(Banco) like '%" + search + "%' or " +
                "   lower(DiaDeposito) like '%" + search + "%' or " +
                "   lower(Folio) like '%" + search + "%' or " +
                "   lower(depositoind.Monto) like '%" + search + "%' " +
                ") " +
                "order by DiaDeposito ASC; ";
        }
    }
}
