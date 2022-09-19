using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class ListaMora_Controller
    {
        public int[] idOficial = { 164, 148, 171, 160, 165, 155, 161, 110, 30, 163, 152, 145, 87, 32, 144, 151, 150, 108, 29, 112,  };
        Conexion conCreditos, conSaldo;
        DateTime qncAct;
        public ListaMora_Controller()
        {
            conCreditos = new Conexion();
            conSaldo = new Conexion();
            qncAct = DateTime.Now;
        }
        public void consulta(int oficial, DataGridView dvm)
        {
            DateTime[] qnc = new DateTime[0];
            float[] pendiente = new float[0];
            float pago, pagado, vencido = 0;
            float Tpendiente = 0;
            int IdCredito, Credito = 0, NPago = 1, CPago = 0;
            string NomSocio = "", NomOficial = "";
            bool isM, First = true;
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

            DataTable dtm = new DataTable();
            dtm.Columns.Add("No. Credito");
            dtm.Columns.Add("Socio");
            dtm.Columns.Add("Oficial");
            dtm.Columns.Add("No. Pago");
            dtm.Columns.Add("Quincena");
            dtm.Columns.Add("Pendiente");

            try
            {
                conCreditos.crearConexion();
                conCreditos.OpenConnection();
                conSaldo.crearConexion();
                conSaldo.OpenConnection();
                string sqlCreditos = "", sqlSaldo = "";
                MySqlCommand cmdCreditos, cmdSaldo;
                MySqlDataReader resulCreditos, resulSaldo;


                sqlCreditos = queryCreditos(idOficial[oficial]);

                cmdCreditos = new MySqlCommand(sqlCreditos, conCreditos.GetConnection());
                cmdCreditos.CommandTimeout = 1000000;
                resulCreditos = cmdCreditos.ExecuteReader();
                if (resulCreditos.HasRows)
                {
                    while (resulCreditos.Read())
                    {
                        IdCredito = resulCreditos.GetInt32(0);
                        sqlSaldo = querySaldo(IdCredito);

                        cmdSaldo = new MySqlCommand(sqlSaldo, conSaldo.GetConnection());
                        cmdSaldo.CommandTimeout = 1000000;
                        resulSaldo = cmdSaldo.ExecuteReader();
                        if (resulSaldo.HasRows)
                        {
                            isM = resulSaldo.Read();
                            while (isM)
                            {
                                if (qnc.Length == 0)
                                {
                                    qnc = new DateTime[resulSaldo.GetInt32(8)];
                                    pendiente = new float[resulSaldo.GetInt32(8)];
                                }

                                Credito = resulSaldo.GetInt32(0);

                                if (NomSocio == "")
                                {
                                    NomSocio = resulSaldo.GetString(1) + " " + resulSaldo.GetString(2) + " " + resulSaldo.GetString(3);
                                    NomSocio.Replace("  ", " ");
                                    NomSocio.Replace("   ", " ");

                                    if (NomOficial == "")
                                    {
                                        NomOficial = resulSaldo.GetString(4) + " " + resulSaldo.GetString(5) + " " + resulSaldo.GetString(6);
                                        NomOficial.Replace("  ", " ");
                                        NomOficial.Replace("   ", " ");
                                    }
                                }

                                qnc[CPago] = resulSaldo.GetDateTime(7);

                                pago = resulSaldo.GetFloat(9);
                                pagado = resulSaldo["Pagado"] != DBNull.Value ? resulSaldo.GetFloat(10) : 0;
                                pendiente[CPago] = pago - pagado;
                                Tpendiente += pendiente[CPago];

                                if (qnc[CPago] < qncAct)
                                {
                                    vencido += pendiente[CPago];
                                }
                                else if (qnc[CPago] >= qncAct && vencido <= 50)
                                {
                                    isM = false;
                                }

                                NPago++;
                                CPago++;
                                isM = resulSaldo.Read();
                            }

                            if (vencido > 0)
                            {
                                for (int i = 0; i < qnc.Length; i++)
                                {
                                    if (First)
                                    {
                                        dtm.Rows.Add(Credito, NomSocio, NomOficial, i + 1, qnc[i].ToShortDateString(), pendiente[i] <= 0 ? 0 : Math.Round(pendiente[i], 2));
                                        First = false;
                                    }
                                    else
                                    {
                                        dtm.Rows.Add("", "", "", i + 1, qnc[i].ToShortDateString(), pendiente[i] <= 0 ? 0 : Math.Round(pendiente[i], 2));
                                    }
                                }
                                dtm.Rows.Add("Total", "", "", "", "", Tpendiente <= 0 ? 0 : Math.Round(Tpendiente, 2));
                            }

                            NomSocio = "";
                            NPago = 1;
                            CPago = 0;
                            Tpendiente = 0;
                            First = true;
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
                string x = e.Message;
                Console.WriteLine("Error: " + e);
            }
            finally { conCreditos.CloseConnection(); conSaldo.CloseConnection(); }

            dvm.DataSource = dtm;
        }

        public string queryCreditos(int oficial)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select Id from prestamosind where OficialId = " + oficial + " " +
                "and not(Activo = 0 and Estatus = 1) " +
                "and not(Activo = 1 and Estatus = 1) " +
                "and Id not in (SELECT Id from prestamosind where(Activo = 0 and Estatus = 0) and FechaDeposito< '" + qncAct.Year + "-" + qncAct.Month.ToString("00") + "-" + qncAct.Day.ToString("00") + "') " +
                "order by Id ASC";

            return ReporteInversion;
        }
        public string querySaldo(int credito)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select deudaindividual.PrestamoId, pi.Nombre, pi.Paterno, pi.Materno, p.Nombre, p.Paterno, p.Materno, deudaindividual.FechaPago, pi.Pagos, TotalPago, sum(ri.Monto) as Pagado from deudaindividual " +
                "left join reciboind ri on deudaindividual.Id = ri.PagoNo and ri.Activo = 1 " +
                "left join prestamosind pi on pi.Id = deudaindividual.PrestamoId " +
                "left join personal p on p.Id = pi.OficialId " +
                "where deudaindividual.PrestamoId = " + credito + " and deudaindividual.Activo = 1 " +
                "group by PagoId";

            return ReporteInversion;
        }

    }
}
