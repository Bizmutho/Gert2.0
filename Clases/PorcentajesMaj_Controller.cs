using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class PorcentajesMaj_Controller
    {
        public int[] idOficial = { 30, 152, 87, 32, 145, 29, 112, 161, 110, 165, 163, 151, 150, 148, 108, 164, 174, 173, 175, 176,
        187, 188, 178, 182, 179, 180, 183, 181, 184, 186, 185, 190, 193, 194, 195};
        Conexion con;
        public PorcentajesMaj_Controller()
        {
            con = new Conexion();
        }

        public DataTable PorcentajeOficiales(int oficial)
        {
            DateTime QncAct = DateTime.Now; 
            DataTable datosT = new DataTable();
            datosT.Columns.Add("OFICIAL");
            datosT.Columns.Add("QUINCENA");
            datosT.Columns.Add("NO. CONTRATO");
            datosT.Columns.Add("TOTAL");
            datosT.Columns.Add("PAGADO");
            datosT.Columns.Add("DIFERENCIA");
            datosT.Columns.Add("PORCENTAJE");
            DateTime q1, q2, q3;

            q1 = calcularQuincenaAnterior(QncAct);
            q2 = calcularQuincenaAnterior(q1);
            q3 = calcularQuincenaAnterior(q2);

            DateTime[] quincenas = { q1, q2, q3 };

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

        public DateTime calcularQuincenaAnterior(DateTime qnc)
        {
            DateTime newQnc;
            int y = qnc.Year, m = qnc.Month, d = qnc.Day;

            if (d <= 15)
            {
                if (m == 1)
                {
                    m = 12;
                    y--;
                }
                else
                {
                    m--;
                }
                newQnc = new DateTime(y, m, DateTime.DaysInMonth(y, m));
            }
            else
            {
                newQnc = new DateTime(y, m, 15);
            }

            if (newQnc.DayOfWeek == DayOfWeek.Sunday)
            {
                newQnc = new DateTime(newQnc.Year, newQnc.Month, newQnc.Day - 1);
            }

            return newQnc;
        }

        public DataTable porcentajes(DataTable datosT, DateTime[] quincenas, int oficial)
        {
            DateTime quincena;
            int cli = 0;
            int[] cliPorQnc = new int[3];
            float pago, pagado;
            float[] pagoPorQnc = new float[3];
            float[] pagadoPorQnc = new float[3];
            float totalpago = 0, totalpagado = 0;
            float[] porPorQnc = new float[3];

            for (int i = 0; i < quincenas.Length; i++)
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
                        pagoPorQnc[i] = totalpago;
                        pagadoPorQnc[i] = totalpagado;
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

            for (int i = quincenas.Length - 1; i >= 0; i--)
            {
                datosT.Rows.Add(nombreOficial(oficial), quincenas[i].ToShortDateString(), cliPorQnc[i], pagoPorQnc[i], pagadoPorQnc[i], pagoPorQnc[i] - pagadoPorQnc[i], pagadoPorQnc[i] / pagoPorQnc[i] * 100 + "%");
            }
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
                case 108: return "OF. CORPORATIVO";
                case 163: return "KAREN";
                case 152: return "MAGDA";
                case 148: return "ALDAMA";
                case 151: return "PADILLA";
                case 161: return "HERMELINDA";
                case 30: return "JUAN";
                case 32: return "MARTINA S.";
                case 164: return "ABASOLO";
                case 150: return "PERSONAL";
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
                case 193: return "MONSERRAT";
                case 194: return "MONSERRAT REGULARES";
                case 195: return "MONSERRAT MORA";
                default: return "";
            }
        }

      //  187, 188, 178, 182, 179, 180, 183, 181, 184, 186, 185
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
