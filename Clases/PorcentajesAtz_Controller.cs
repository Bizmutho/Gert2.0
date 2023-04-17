using Modulos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class PorcentajesAtz_Controller
    {
        Conexion con;
        public int[] idOficial = { 112, 145, 110, 29, 87, 165, 144, 172, 108, 169, 152, 155, 170, 163, 166, 148, 171, 151, 160, 161, 30, 32, 164, 168, 173, 174,  175, 176,
        187, 188, 178, 182, 179, 180, 183, 181, 184, 186, 185, 190, 196, 197, 198};

        public PorcentajesAtz_Controller()
        {
            con = new Conexion();
        }

        public DataTable PorcentajeOficiales(int ano, int mes, int oficial)
        {
            DataTable datosT = new DataTable();
            datosT.Columns.Add("OFICIAL");
            DateTime q1, q2;

            q1 = new DateTime(ano, mes, 15);
            if (q1.DayOfWeek == DayOfWeek.Sunday) q1 = new DateTime(ano, mes, 14);
            q2 = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));
            if (q2.DayOfWeek == DayOfWeek.Sunday) q2 = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes) - 1);
            datosT.Columns.Add(q1.Day + " DE " + q1.ToString("MMMM").ToUpper());
            datosT.Columns.Add("PORCENTAJE 1");
            datosT.Columns.Add(q2.Day + " DE " + q2.ToString("MMMM").ToUpper());
            datosT.Columns.Add("PORCENTAJE 2");
            datosT.Columns.Add("PROMEDIO");
            DateTime[] quincenas = { q1, q2 };
            if (oficial != 0)
            {
                datosT = porcentajes(datosT, quincenas, idOficial[oficial - 1]);
            }
            else
            {
                for (int i = 0; i < idOficial.Length; i++)
                {
                    datosT = porcentajes(datosT, quincenas, idOficial[i]);
                }
            }
            return datosT;
        }

        public DataTable porcentajes(DataTable datosT, DateTime[] quincenas, int oficial)
        {
            DateTime quincena;
            int cli = 0;
            int[] cliPorQnc = new int[2];
            float pago, pagado;
            float totalpago = 0, totalpagado = 0;
            float[] porPorQnc = new float[2];
            float promedio;
            for (int i = 0; i < 2; i++)
            {
                quincena = quincenas[i];
                try
                {
                    con.crearConexion();
                    con.OpenConnection();
                    string sql = "";
                    sql = ReporteDeInversion(quincena, oficial);

                    MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                    cmd.CommandTimeout = 1000000;
                    MySqlDataReader resultados = cmd.ExecuteReader();

                    if (resultados.HasRows)
                    {
                        while (resultados.Read())
                        {
                            cli += 1;
                            pago = resultados["totalPago"] != DBNull.Value ? resultados.GetFloat(1) : 0;
                            pagado = resultados["Pagado"] != DBNull.Value ? resultados.GetFloat(2) : 0;
                            totalpago += pago;
                            if (Math.Round(pagado, 2) >= Math.Round(pago, 2))
                            {
                                totalpagado += pago;
                            }
                            else
                            {
                                totalpagado += pagado;
                            }

                        }
                        cliPorQnc[i] = cli;
                        porPorQnc[i] = totalpagado / totalpago * 100;

                        cli = 0;
                        pago = 0;
                        pagado = 0;
                        totalpagado = 0;
                        totalpago = 0;
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
            }
            promedio = (porPorQnc[0] + porPorQnc[1]) / 2;
            datosT.Rows.Add(nombreOficial(oficial), cliPorQnc[0], Math.Round(porPorQnc[0], 2) + "%", cliPorQnc[1], Math.Round(porPorQnc[1], 2) + "%", Math.Round(promedio, 2) + "%");
            return datosT;
        }

        public string nombreOficial(int idOficial)
        {
            switch (idOficial)
            {
                case 110: return "JAVIER";
                case 112: return "VICENTE";
                case 145: return "MAGUE";
                case 29: return "VALENTINA";
                case 87: return "MARTINA R.";
                case 165: return "CINTHIA";
                case 144: return "NORMA PATRICIA";
                case 108: return "OF. CORPORATIVO";
                case 163: return "KAREN";
                case 152: return "MAGDA";
                case 155: return "GLADYS";
                case 148: return "ALDAMA";
                case 151: return "PADILLA";
                case 160: return "BARRETAL";
                case 161: return "HERMELINDA";
                case 30: return "JUAN";
                case 32: return "MARTINA S.";
                case 164: return "ABASOLO";
                case 173: return "BRANDON";
                case 174: return "ALFONSO";
                case 175: return "JESUS";
                case 176: return "NANCY";
                case 187: return "CINTHIA MORA (BRANDON)";
                case 188: return "CINTHIA MORA (JESUS)";
                case 178: return "LLERA GERT";
                case 182: return "LLERA REGULARES";
                case 179: return "LLERA MORA";
                case 180: return "G. FARIAS GERT";
                case 183: return "G. FARIAS REGULARES";
                case 181: return "G. FARIAS MORA";
                case 184: return "VICTORIA GERT";
                case 186: return "VICTORIA REGULARES";
                case 185: return "VICTORIA MORA";
                case 196: return "JUAN CARLOS";
                case 197: return "JUAN CARLOS (REGULARES)";
                case 198: return "JUAN CARLOS (MORA)";
                default: return "";
            }
        }

        public string ReporteDeInversion(DateTime Qnc, int oficial)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select P_Id as Creditos, totalPago, sum(RI.Monto) as Pagado from ( " +
                "SELECT Id as P_Id from prestamosind where Id in " +
                "(SELECT PrestamoId from deudaindividual where FechaPago = '" + Qnc.Year + "-" + Qnc.Month.ToString("00") + "-" + Qnc.Day + "' and Activo = 1 and OficialCreditoId = " + oficial + " ) " +
                "and not(Activo = 0 and Estatus = 1) " +
                "and Id not in (SELECT Id from prestamosind where(Activo = 0 and Estatus = 0) and FechaDeposito< '" + Qnc.Year + "-" + Qnc.Month.ToString("00") + "-" + (Qnc.Day - 3) + "')" +
                ") prestamos " +
                "left join(select Id, PrestamoId, totalPago, FechaPago, Activo from deudaindividual) DI on P_Id = DI.PrestamoId and FechaPago = '" + Qnc.Year + "-" + Qnc.Month.ToString("00") + "-" + Qnc.Day + "' and Activo = 1 " +
                "left join(select PagoNo, Monto from reciboind where Activo = 1) RI on DI.Id = PagoNo " +
                "group by P_Id, PagoNo";

            return ReporteInversion;
        }
    }
}
