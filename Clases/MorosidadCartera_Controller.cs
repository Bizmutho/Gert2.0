using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class MorosidadCartera_Controller
    {
        Conexion conCreditos, conSaldo, conDemanda;
        DateTime qncAct;

        public MorosidadCartera_Controller()
        {
            conCreditos = new Conexion();
            conSaldo = new Conexion();
            conDemanda = new Conexion();
            qncAct = DateTime.Now;
        }

        public DataView consulta(int oficial)
        {
            DateTime[] qnc = new DateTime[0];
            DateTime final = new DateTime();
            float[] pendiente = new float[0];
            float pago = 0, pagado, vencido = 0, prestado = 0;
            float Tpendiente = 0;
            int IdCredito, Credito = 0, CPago = 0;
            string NomSocio = "";
            bool isM;
            string status = "";
            DateTime qncAct = DateTime.Now, qncVen;
            TimeSpan diasVen;
            int dias;
            float tasa=0, moratorios=0, monVen=0; 


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

            DataTable dtm = new DataTable();
            dtm.Columns.Add("SOCIO");
            dtm.Columns.Add("CREDITO");
            dtm.Columns.Add("MONTO");
            dtm.Columns.Add("VENCIMIENTO");
            dtm.Columns.Add("QNC VEN");
            dtm.Columns.Add("SALDO VEN");
            dtm.Columns.Add("QNC PEN");
            dtm.Columns.Add("SALDO PEN");
            dtm.Columns.Add("MORATORIOS");
            dtm.Columns.Add("TOTAL");
            dtm.Columns.Add("JURIDICO");

            try
            {
                conCreditos.crearConexion();
                conCreditos.OpenConnection();
                conSaldo.crearConexion();
                conSaldo.OpenConnection();
                conDemanda.crearConexion();
                conDemanda.OpenConnection();
                string sqlCreditos = "", sqlSaldo = "", sqlDemanda = "";
                MySqlCommand cmdCreditos, cmdSaldo, cmdDemanda;
                MySqlDataReader resulCreditos, resulSaldo, resulDemanda;

                sqlCreditos = queryCreditos(oficial);

                cmdCreditos = new MySqlCommand(sqlCreditos, conCreditos.GetConnection());
                cmdCreditos.CommandTimeout = 1000000;
                resulCreditos = cmdCreditos.ExecuteReader();
                if (resulCreditos.HasRows)
                {
                    while (resulCreditos.Read())
                    {
                        IdCredito = resulCreditos.GetInt32(0);
                        sqlDemanda = queryDemanda(IdCredito);
                        sqlSaldo = querySaldo(IdCredito);

                        cmdSaldo = new MySqlCommand(sqlSaldo, conSaldo.GetConnection());
                        cmdSaldo.CommandTimeout = 1000000;
                        resulSaldo = cmdSaldo.ExecuteReader();
                        if (resulSaldo.HasRows)
                        {
                            cmdDemanda = new MySqlCommand(sqlDemanda, conDemanda.GetConnection());
                            cmdDemanda.CommandTimeout = 1000000;
                            resulDemanda = cmdDemanda.ExecuteReader();

                            try
                            {
                                if (resulDemanda.HasRows)
                                {
                                    while (resulDemanda.Read())
                                    {
                                        status = resulDemanda.GetString(1);
                                    }
                                }
                                else { status = "-"; }
                            }
                            catch (Exception ex) { Console.WriteLine("error linea 117"+ex.Message); }
                            resulDemanda.Close();

                            isM = resulSaldo.Read();
                            while (isM)
                            {
                                if (qnc.Length == 0)
                                {
                                    qnc = new DateTime[resulSaldo.GetInt32(5)];
                                    pendiente = new float[resulSaldo.GetInt32(5)];
                                    
                                }

                                Credito = resulSaldo.GetInt32(0);
                                qncVen = resulSaldo.GetDateTime(4);
                                diasVen = DateTime.Now.AddDays(15) - qncVen;
                                dias = diasVen.Days;

                                if (NomSocio == "")
                                {
                                    NomSocio = resulSaldo.GetString(1) + " " + resulSaldo.GetString(2) + " " + resulSaldo.GetString(3);
                                    NomSocio.Replace("  ", " ");
                                    NomSocio.Replace("   ", " ");

                                }

                                if (prestado == 0)
                                {
                                    prestado = resulSaldo.GetFloat(8);
                                }

                                qnc[CPago] = resulSaldo.GetDateTime(4);
                                final = resulSaldo.GetDateTime(4);

                                pago = resulSaldo.GetFloat(6);
                                pagado = resulSaldo["Pagado"] != DBNull.Value ? resulSaldo.GetFloat(7) : 0;
                                pendiente[CPago] = pago - pagado;
                                Tpendiente += pendiente[CPago];

                                tasa = ((resulSaldo.GetFloat(9) * 2) / 30) / 100;
                                monVen = pago - pagado;
                                moratorios += (monVen * tasa * dias)*1.16f;

                                if (qnc[CPago] < qncAct)
                                {
                                    vencido += pendiente[CPago];
                                }
                                else if (qnc[CPago] >= qncAct && vencido <= 50)
                                {
                                    isM = false;
                                }

                                CPago++;
                                isM = resulSaldo.Read();
                            } //aqui termina el while de saldos, de nada

                            if (vencido > 0)
                            {
                                int qncVencidas = 0;
                                int qncPendientes = 0;
                                float salVencido = 0;
                                float salPendiente = 0;
                                for (int i = 0; i < qnc.Length; i++)
                                {
                                    if ((qnc[i] < qncAct) & pendiente[i] > 0)
                                    {
                                        if (pendiente[i] > (pago * 0.93))
                                        {
                                            qncVencidas++;
                                        }
                                        salVencido += pendiente[i];
                                    } else if((qnc[i] >= qncAct) & pendiente[i] > 0)
                                    {
                                        qncPendientes++;
                                        salPendiente += pendiente[i];
                                    }
                                }

                                float total = salVencido + moratorios;

                                if (qncVencidas > 1 || qnc[qnc.Length - 1] < qncAct)
                                {
                                    dtm.Rows.Add(NomSocio, Credito, "$ " + prestado, final.ToShortDateString(), qncVencidas, "$ " + salVencido, qncPendientes, "$ " + salPendiente, moratorios.ToString("C"), total.ToString("C"), status);
                                }

                                qncVencidas = 0;
                                qncPendientes = 0;
                                salVencido = 0;
                                salPendiente = 0;
                                dias = 0;
                                moratorios = 0;
                                tasa = 0;
                                monVen = 0;
                                
                            }

                            NomSocio = "";
                            prestado = 0;
                            CPago = 0;
                            Tpendiente = 0;
                            qnc = new DateTime[0];
                            pendiente = new float[0];
                            vencido = 0;
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        resulSaldo.Close();
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                resulCreditos.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally { conCreditos.CloseConnection(); conSaldo.CloseConnection(); conDemanda.CloseConnection(); }

            return new DataView(dtm);
        }

        public string queryCreditos(int oficial)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select Id from prestamosind where OficialId = " + oficial + " " +
                "and not(Activo = 0 and Estatus = 1) " +
                "and not(Activo = 1 and Estatus = 1) " +
                "and Id not in (SELECT Id from prestamosind where(Activo = 0 and Estatus = 0) and FechaDeposito < '" + qncAct.Year + "-" + qncAct.Month.ToString("00") + "-" + qncAct.Day.ToString("00") + "') " +
                "order by Id ASC";

            return ReporteInversion;
        }
        public string querySaldo(int credito)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select deudaindividual.PrestamoId, pi.Nombre, pi.Paterno, pi.Materno, deudaindividual.FechaPago, pi.Pagos, TotalPago, sum(ri.Monto) as Pagado, pi.Monto, pi.Tasa from deudaindividual " +
                "left join reciboind ri on deudaindividual.Id = ri.PagoNo and ri.Activo = 1 " +
                "left join prestamosind pi on pi.Id = deudaindividual.PrestamoId " +
                "where deudaindividual.PrestamoId = " + credito + " and deudaindividual.Activo = 1 " +
                "group by PagoId";

            return ReporteInversion;
        }

        public string queryDemanda(int credito)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select IdPrestamo, Estatus from estatus_juridico where IdPrestamo = " + credito;

            return ReporteInversion;
        }

    }
}
