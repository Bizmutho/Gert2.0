using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class Moratorios_Controller
    {
        Conexion con;

        public Moratorios_Controller()
        {
            con = new Conexion();
        }

        public DataTable moratorios(DateTime ini, DateTime fin)
        {
            DataTable datosT = new DataTable();
            datosT.Columns.Add("F. DEPOSITO");
            datosT.Columns.Add("OFICIAL");
            datosT.Columns.Add("CONTRATO");
            datosT.Columns.Add("MONTO");
            datosT.Columns.Add("SOCIO");
            datosT.Columns.Add("F. VENCI.");

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand mySqlCommand = new MySqlCommand(query(ini, fin), con.GetConnection());
                mySqlCommand.CommandTimeout = 100000;
                MySqlDataReader data = mySqlCommand.ExecuteReader();

                if (data.HasRows)
                {
                    DateTime fDeposito, fVenci;
                    String oficial, socio;
                    int contrato;
                    double monto;

                    while (data.Read())
                    {
                        fDeposito = data.GetDateTime(0);
                        oficial = data.GetString(1);
                        contrato = data.GetInt32(2);
                        monto = data.GetDouble(3);
                        socio = data.GetString(4);
                        fVenci = data.GetDateTime(5);

                        datosT.Rows.Add($"{fDeposito.Year}-{fDeposito.Month.ToString("00")}-{fDeposito.Day.ToString("00")}", oficial, contrato, monto, socio, $"{fVenci.Year}-{fVenci.Month.ToString("00")}-{fVenci.Day.ToString("00")}");
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            } finally
            {
                con.CloseConnection();
            }

            return datosT;
        }

        public String query(DateTime ini, DateTime fin)
        {
            return "" +
                "select " +
                "    depositoFecha, " +
                "	 concat(per.Nombre, ' ', per.Paterno, ' ', per.Materno) as Oficial, " +
                "    reciboind.PrestamoId, " +
                "    di.Moratorio, " +
                "    concat(pi.Nombre, ' ', pi.Paterno, ' ', pi.Materno) as Socio, " +
                "    FechaVencimiento " +
                "from reciboind " +
                "right join( " +
                "select id, max(FechaEntrega) as depositoFecha from reciboind where PagoNo in ( " +
                "    select id from deudaindividual where Moratorio != 0 and Activo = 1 " +
                ") and Activo = 1 " +
                "group by PagoNo " +
                ") rf on rf.id = reciboind.id " +
                "left join deudaindividual di on di.id = PagoNo and di.Activo = 1 " +
                "left join prestamosind pi on pi.id = reciboind.PrestamoId " +
                "left join personal per on per.id = di.OficialCreditoId " +
                "left join( " +
                "select PrestamoId, max(FechaPago) as FechaVencimiento from deudaindividual " +
                "group by PrestamoId " +
                ") fechasDeuda on fechasDeuda.PrestamoId = reciboind.PrestamoId " +
                "where reciboind.Activo = 1 " +
                $"and depositoFecha between '{ini.Year}-{ini.Month.ToString("00")}-{ini.Day.ToString("00")}' and '2022-06-30' " +
                "order by depositoFecha ASC;";
        }

    }
}
