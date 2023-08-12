using MySql.Data.MySqlClient;
using System.Data;

namespace Modulos.Clases
{
    public class Inversion_Controller
    {
        Conexion con;
        public Inversion_Controller()
        {
            con = new Conexion();
        }

        public DataTable RetornoInversion(int ano1, int mes1, int ano2, int mes2)
        {
            DataTable datosT = new DataTable();
            datosT.Columns.Add("QUINCENA");
            datosT.Columns.Add("CLIENTES");
            datosT.Columns.Add("INVERSION");
            datosT.Columns.Add("CAPITAL POR RECUPERAR");
            datosT.Columns.Add("INTERES POR RECUPERAR");
            datosT.Columns.Add("IVA POR RECUPERAR");
            datosT.Columns.Add("CAPITAL RECUPERADO");
            datosT.Columns.Add("INTERES RECUPERADO");
            datosT.Columns.Add("IVA RECUPERADO");
            datosT.Columns.Add("CAPITAL DIFERENCIA");
            datosT.Columns.Add("INTERES DIFERENCIA");
            datosT.Columns.Add("IVA DIFERENCIA");
            datosT.Columns.Add("PORCENTAJE");
            DateTime q1actual, q2actual;
            DateTime fecha2 = new DateTime(ano2, mes2, DateTime.DaysInMonth(ano2, mes2));

            if (fecha2.DayOfWeek == DayOfWeek.Sunday) fecha2 = new DateTime(ano2, mes2, DateTime.DaysInMonth(ano2, mes2) - 1);


            do
            {
                q1actual = new DateTime(ano1, mes1, 15);
                if (q1actual.DayOfWeek == DayOfWeek.Sunday) q1actual = new DateTime(ano1, mes1, 14);
                q2actual = new DateTime(ano1, mes1, DateTime.DaysInMonth(ano1, mes1));
                if (q2actual.DayOfWeek == DayOfWeek.Sunday) q2actual = new DateTime(ano1, mes1, DateTime.DaysInMonth(ano1, mes1) - 1);
                mes1 += 1;
                datosT = inversionQ(datosT, q1actual);
                datosT = inversionQ(datosT, q2actual);
                if (mes1 == 13)
                {
                    mes1 = 1;
                    ano1 += 1;
                }
            } while (q2actual != fecha2);

            return datosT;
        }

        public DataTable inversionQ(DataTable datosT, DateTime fecha1)
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();
                string sql = "";
                sql = ReporteDeInversion(fecha1);

                MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();

                if (resultados.HasRows)
                {
                    float pagado = 0;
                    float cli = 0;
                    float monto = 0, montoAct = 0;
                    float capPr = 0, capPrAct = 0;
                    float ivaPr = 0, ivaPrAct = 0;
                    float intPr = 0, intPrAct = 0;
                    float tPago = 0;
                    float capR = 0, capRAct = 0;
                    float ivaR = 0, ivaRAct = 0;
                    float intR = 0, intRAct = 0;
                    float capD = 0;
                    float ivaD = 0;
                    float intD = 0;
                    float Porc = 0;

                    while (resultados.Read())
                    {
                        cli += 1;
                        montoAct = resultados.GetFloat(1);
                        capPrAct = resultados.GetFloat(2);
                        intPrAct = resultados.GetFloat(3);
                        ivaPrAct = resultados.GetFloat(4);
                        tPago = resultados["Pagado"] != DBNull.Value ? resultados.GetFloat(5) : 0;
                        pagado = capPrAct + intPrAct + ivaPrAct;
                        if (Math.Round(tPago, 2) >= Math.Round(pagado, 2))
                        {
                            capRAct = capPrAct;
                            intRAct = intPrAct;
                            ivaRAct = ivaPrAct;

                            capR += capPrAct;
                            intR += intPrAct;
                            ivaR += ivaPrAct;
                        }
                        else if (tPago <= capPrAct)
                        {
                            capRAct = tPago;

                            capR += tPago;
                        }
                        else
                        {
                            capRAct = capPrAct;
                            intRAct = (tPago - capPrAct) / 1.16F;
                            ivaRAct = intRAct * .16F;
                            capR += capRAct;
                            intR += intRAct;
                            ivaR += ivaRAct;

                        }

                        monto += montoAct;
                        capPr += capPrAct;
                        intPr += intPrAct;
                        ivaPr += ivaPrAct;

                        capPrAct = 0;
                        intPrAct = 0;
                        ivaPrAct = 0;

                    }
                    capD = capPr - capR;
                    intD = intPr - intR;
                    ivaD = ivaPr - ivaR;
                    Porc = capR / capPr * 100;
                    datosT.Rows.Add(fecha1.Year + "-" + fecha1.Month.ToString("00") + "-" + fecha1.Day, cli, monto, capPr, intPr, ivaPr, capR, intR, ivaR, capD, intD, ivaD, Math.Round(Porc, 2) + "%");

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
                Console.WriteLine("Error: " + e);
            }
            finally { con.CloseConnection(); }

            return datosT;
        }

        public string ReporteDeInversion(DateTime Qnc)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select P_Id as Creditos, P_Monto as Inversion, DI.Monto as InversionRecuperar, intereses as InteresesRecuperar, iva as IVAREcuperar, sum(RI.Monto) as Pagado from ( " +
                "SELECT Id as P_Id, monto as P_Monto from prestamosind where Id in " +
                "(SELECT PrestamoId from deudaindividual where FechaPago = '" + Qnc.Year + "-" + Qnc.Month.ToString("00") + "-" + Qnc.Day + "'  and Activo = 1 ) " +
                "and not(Activo = 0 and Estatus = 1) " +
                "and Id not in (SELECT Id from prestamosind where(Activo = 0 and Estatus = 0) and FechaDeposito< '" + Qnc.Year + "-" + Qnc.Month.ToString("00") + "-" + (Qnc.Day - 3) + "') " +
                ") prestamos " +
                "left join(select Id, PrestamoId, monto, intereses, iva, FechaPago, Activo from deudaindividual) DI on P_Id = DI.PrestamoId and FechaPago = '" + Qnc.Year + "-" + Qnc.Month.ToString("00") + "-" + Qnc.Day + "' and Activo = 1 " +
                "left join(select PagoNo, Monto from reciboind where Activo = 1) RI on DI.Id = PagoNo " +
                "group by P_Id, PagoNo";

            return ReporteInversion;
        }

    }
}
