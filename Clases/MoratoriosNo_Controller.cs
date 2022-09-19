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
    public class MoratoriosNo_Controller
    {
        Conexion con;
        public MoratoriosNo_Controller()
        {
            con = new Conexion();
        }
        public void consulta(int credito, DataGridView dvm, DataGridView dvr, float porcentaje)
        {
            DateTime qnc, qncVen = new DateTime(1, 1, 1);
            float pago, pagado, pendiente, vencido = 0;
            float Tpago = 0, Tpagado = 0, Tpendiente = 0, Tvencido = 0, Tmoratorio = 0, Total;
            int np = 1, qncPen = 0;

            DataTable dtm = new DataTable();
            dtm.Columns.Add("Fecha");
            dtm.Columns.Add("Pago");
            dtm.Columns.Add("Monto");
            dtm.Columns.Add("Pagado");
            dtm.Columns.Add("Pendiente");
            dtm.Columns.Add("Vencido");

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
                if (qncAct.Day >= 27)
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, DateTime.DaysInMonth(qncAct.Year, qncAct.Month));
                }
                else
                {
                    qncAct = new DateTime(qncAct.Year, qncAct.Month, 15);
                }
            }

            try
            {
                con.crearConexion();
                con.OpenConnection();
                string sql = "";
                sql = query(credito);

                MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();
                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        qnc = resultados.GetDateTime(0);
                        pago = resultados.GetFloat(1);
                        pagado = resultados["Pagado"] != DBNull.Value ? resultados.GetFloat(2) : 0;
                        pendiente = pago - pagado;
                        if (pendiente != 0 && qnc <= qncAct)
                        {
                            vencido = pendiente;
                            Tvencido += pendiente;
                            if (pendiente >= pago * .10 && qncVen == new DateTime(1, 1, 1))
                            {
                                qncVen = qnc;
                            }
                        }
                        else if (qnc > qncAct)
                        {
                            vencido = 0;
                        }
                        dtm.Rows.Add(qnc.ToShortDateString(), np, Math.Round(pago, 2), Math.Round(pagado, 2), Math.Round(pendiente, 2), Math.Round(vencido, 2));
                        Tpago += pago;
                        Tpagado += pagado;
                        Tpendiente += pendiente;
                        np += 1;
                    }
                    dtm.Rows.Add("", "Total", Math.Round(Tpago, 2), Math.Round(Tpagado, 2), Math.Round(Tpendiente, 2) > 0 ? Math.Round(Tpendiente, 2) : 0, Math.Round(Tvencido, 2) > 0 ? Math.Round(Tvencido, 2) : 0);
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

            DataTable dtr = new DataTable();
            dtr.Columns.Add(" ");
            dtr.Columns.Add("Monto");

            int a = qncVen.Year;
            int m = qncVen.Month;
            DateTime qnc1, qnc2;

            if (qncVen != new DateTime(1, 1, 1))
            {
                int mPend = (qncAct.Year - qncVen.Year) * 12 + qncAct.Month - qncVen.Month;
                for (int y = 0; y <= mPend; y++)
                {
                    qnc1 = new DateTime(a, m, 15);
                    if (qnc1.DayOfWeek == DayOfWeek.Sunday) qnc1 = new DateTime(a, m, 14);

                    if (qnc1 >= qncVen && qnc1 <= qncAct && qnc1 != qncAct)
                    {
                        qncPen += 1;
                    }

                    qnc2 = new DateTime(a, m, DateTime.DaysInMonth(a, m));
                    if (qnc2.DayOfWeek == DayOfWeek.Sunday) qnc2 = new DateTime(a, m, DateTime.DaysInMonth(a, m) - 1);

                    if (qnc2 >= qncVen && qnc2 <= qncAct && qnc2 != qncAct)
                    {
                        qncPen += 1;
                    }

                    m++;
                    if (m == 13)
                    {
                        m = 1;
                        a++;
                    }
                }
            }

            if (qncPen > 6)
            {
                for (int i = 0; i < qncPen - 6; i++)
                {
                    porcentaje += 5;
                }
            }

            dtr.Rows.Add("Saldo pendiente", Math.Round(Tvencido, 2) > 0 ? Math.Round(Tvencido, 2) : 0);

            if (qncPen > 0)
            {
                Tmoratorio = Tvencido * (porcentaje / 100);
                dtr.Rows.Add("Moratorios (" + porcentaje + "%)", Math.Round(Tmoratorio, 2) > 0 ? Math.Round(Tmoratorio, 2) : 0);

            }

            Total = Tvencido + Tmoratorio;
            dtr.Rows.Add("Total", Math.Round(Total, 2) > 0 ? Math.Round(Total, 2) : 0);

            dvm.DataSource = dtm;
            dvr.DataSource = dtr;
        }

        public void nombres(Label SNombres, Label SApellidos, Label ONombres, Label OApellidos, int Credito)
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();
                string sql = "select prestamosind.Nombre as SNombre, prestamosind.Paterno as SPaterno, prestamosind.Materno as SMaterno, p.Nombre as ONombre, p.Paterno as OPaterno, p.Materno as OMaterno from prestamosind " +
                    "left join personal p on p.Id = prestamosind.OficialId " +
                    "where prestamosind.Id = " + Credito;
                string SNom, SApe, ONom, OApe;

                MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();
                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        SNom = resultados["SNombre"].ToString();
                        SApe = resultados["SPaterno"].ToString() + " " + resultados["SMaterno"].ToString();
                        ONom = resultados["ONombre"].ToString();
                        OApe = resultados["OPaterno"].ToString() + " " + resultados["OMaterno"].ToString();

                        SNom.Replace("  ", " ");
                        SApe.Replace("  ", " ");
                        ONom.Replace("  ", " ");
                        OApe.Replace("  ", " ");

                        SNombres.Text = SNom;
                        SApellidos.Text = SApe;
                        ONombres.Text = ONom;
                        OApellidos.Text = OApe;
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
                Console.WriteLine("Error: " + e);
            }
            finally { con.CloseConnection(); }
        }

        public string query(int credito)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select deudaindividual.FechaPago, TotalPago, sum(ri.Monto) as Pagado from deudaindividual " +
                "left join reciboind ri on deudaindividual.Id = ri.PagoNo and ri.Activo = 1 " +
                "where deudaindividual.PrestamoId = " + credito + " " +
                "group by PagoId";

            return ReporteInversion;
        }

    }
}
