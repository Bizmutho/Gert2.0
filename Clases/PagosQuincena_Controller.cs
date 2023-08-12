using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class PagosQuincena_Controller
    {
        Conexion con;

        public PagosQuincena_Controller()
        {
            con = new Conexion();
        }

        public DataView buscar(DateTime qnc, int Oficial)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Contrato");
            dt.Columns.Add("Socio");
            dt.Columns.Add("Monto");

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand(query(qnc, Oficial), con.GetConnection());
                command.CommandTimeout = 100000;
                MySqlDataReader data = command.ExecuteReader();

                if (data.HasRows)
                {
                    int contrato, socios = 0;
                    String socio;
                    float monto, pagado, pendiente;
                    while (data.Read())
                    {
                        contrato = data.GetInt32(0);
                        socio = data.GetString(1);
                        monto = data.GetFloat(2);
                        pagado = data.GetFloat(3);
                        pendiente = monto - pagado;

                        if (pendiente > 200)
                        {
                            socios++;
                            dt.Rows.Add(contrato, socio, "$" + Math.Round(pendiente, 2));
                        }

                    }
                    if (socios == 0)
                    {
                        dt.Rows.Add("", "Al corriente", "$0");
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine("Error obteniendo los datos:" + ex.Message);
            } finally
            {
                con.CloseConnection();
            }
            return new DataView(dt);
        }

        public String query(DateTime qnc, int Oficial)
        {
            String query =  " " +
                "select " +
                "   prestamosind.id as Credito, " +
                "   concat(prestamosind.Nombre, ' ', prestamosind.Paterno, ' ', prestamosind.Materno) as Socio, " +
                "   TotalPago," +
                "   ifnull(sum(reciboind.Monto), 0) as Pagado " +
                "from prestamosind " +
                "left join ( " +
                "   select * from deudaindividual where FechaPago = '"+qnc.Year+"-"+qnc.Month.ToString("00")+"-"+qnc.Day.ToString("00")+"' and deudaindividual.Activo = 1) di on di.PrestamoId = prestamosind.id " +
                "left join reciboind on reciboind.PagoNo = di.id and reciboind.Activo = 1 " +
                "where prestamosind.id in ( " +
                "   select PrestamoId from deudaindividual where FechaPago = '" + qnc.Year + "-" + qnc.Month.ToString("00") + "-" + qnc.Day.ToString("00") + "' and deudaindividual.Activo = 1) " +
                "and not(prestamosind.Activo = 0 and prestamosind.Estatus = 0) " +
                "and prestamosind.id not in (select id from prestamosind where FechaDeposito < '" + qnc.Year + "-" + qnc.Month.ToString("00") + "-" + (qnc.Day - 3).ToString("00") + "' and(Activo = 0 and Estatus = 0)) " +
                "and OficialId = "+Oficial+" " +
                "group by prestamosind.Id " +
                "order by prestamosind.Id ASC";
            Console.WriteLine(query);
            return query;
        }
    }
}
