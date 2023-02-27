using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class Captura_Controller
    {
        Conexion con;

        public Captura_Controller()
        {
            con = new Conexion();
        }

        public List<string> Socios()
        {
            List<string> list = new List<string>();

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand cmdCreditos;
                MySqlDataReader resulCreditos;

                String nombre;
                String sqlCreditos = "select Id, Nombre, Paterno, Materno from prestamosind where (Activo = 1 and Estatus = 0) or (Activo = 1 and Estatus = 1)";

                cmdCreditos = new MySqlCommand(sqlCreditos, con.GetConnection());
                cmdCreditos.CommandTimeout = 1000000;
                resulCreditos = cmdCreditos.ExecuteReader();

                if (resulCreditos.HasRows)
                {
                    while (resulCreditos.Read())
                    {
                        nombre = resulCreditos.GetInt32(0) + " - " + resulCreditos.GetString(1) + " " + resulCreditos.GetString(2) + " " + resulCreditos.GetString(3);
                        list.Add(nombre.Replace("  ", " "));
                    }
                }
                else
                {
                    Console.WriteLine("Prestamo sin cerrar.");
                }
                resulCreditos.Close();
            }
            catch (Exception e)
            {
                string x = e.Message;
                Console.WriteLine("1.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            return list;
        }

        public List<string> Bancos()
        {
            List<string> list = new List<string>();

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand cmdCreditos;
                MySqlDataReader resulCreditos;

                String nombre;
                String sqlCreditos = "select Banco from banco";

                cmdCreditos = new MySqlCommand(sqlCreditos, con.GetConnection());
                cmdCreditos.CommandTimeout = 1000000;
                resulCreditos = cmdCreditos.ExecuteReader();

                if (resulCreditos.HasRows)
                {
                    while (resulCreditos.Read())
                    {
                        nombre = resulCreditos.GetString(0);
                        list.Add(nombre.Replace("  ", " "));
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
                Console.WriteLine("3.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            return list;
        }

        public DataView quincenas(int credito, List<(bool, int, bool, double)> desc)
        {
            desc.Clear();

            StorageClass.Oficial = "";
            StorageClass.Monto = 0;
            StorageClass.saldoVencido = 0;
            StorageClass.liquida = 0;
            StorageClass.nPagosCub = 0;
            StorageClass.nPagos = 0;

            DataTable datosT = new DataTable();
            datosT.Columns.Add("QUINCENA");
            datosT.Columns.Add("#");
            datosT.Columns.Add("CAPITAL");
            datosT.Columns.Add("NORMAL");
            datosT.Columns.Add("PAGADO");
            datosT.Columns.Add("VENCIDO");

            DateTime qn;
            int np = 0, id, npag = 0;
            float cap = 0, norm, pag, pend, vencido = 0, salVen = 0, liquida = 0;


            DateTime qncAct = DateTime.Now;

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

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query(credito), con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();
                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        
                        id = resultados.GetInt32(0);
                        qn = resultados.GetDateTime(1);
                        np = resultados.GetInt32(2);
                        cap = resultados.GetFloat(3);

                        norm = resultados.GetFloat(5);
                        pag = resultados["Pagado"] != DBNull.Value ? resultados.GetFloat(6) : 0;
                        pend = norm - pag;
                        StorageClass.Oficial = resultados.GetString(7);
                        StorageClass.Monto = resultados.GetDouble(8);


                        desc.Add((cap == norm, id, (resultados.GetFloat(4) != 0), resultados.GetFloat(4)));

                        if (qn <= qncAct)
                        {
                            liquida += pend;

                            if (pend > 0)
                            {
                                vencido = pend;
                                salVen += vencido;
                            }
                        }
                        else if (qn > qncAct)
                        {
                            if (pag <= cap)
                            {
                                liquida += (cap - pag);
                            } else
                            {
                                liquida += (norm - pag);
                            }
                            vencido = 0;
                        }

                        if (pag > (norm * 0.97))
                        {
                            npag++;
                        }

                        datosT.Rows.Add(qn.ToShortDateString(), np, "$" + Math.Round(cap, 2), "$" + Math.Round(norm, 2), "$" + Math.Round(pag, 2), "$" + Math.Round(vencido, 2));
                        vencido = 0;
                    }


                    if (salVen > 0)
                    {
                        StorageClass.saldoVencido = salVen;
                    }
                    if (liquida > 0)
                    {
                        StorageClass.liquida = liquida;
                    }

                    if (np != 0)
                    {
                        StorageClass.nPagos = np;
                        StorageClass.nPagosCub = npag;
                    }
                    if (cap != 0)
                    {
                        StorageClass.capitalMonto = cap;
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
                Console.WriteLine("4.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            return new DataView(datosT);
        }

        public DataView depositos(int credito, List<int> ids)
        {
            ids.Clear();
            
            StorageClass.pagado = 0;

            DataTable dtd = new DataTable();
            dtd.Columns.Add("DIA DEPOSITO");
            dtd.Columns.Add("FOLIO");
            dtd.Columns.Add("BANCO");
            dtd.Columns.Add("MONTO");

            try
            {
                con.crearConexion();
                con.OpenConnection();

                String query = "select depositoind.id, DiaDeposito, Folio, Banco, Monto from depositoind " +
                    "where depositoind.Activo = 1 and depositoind.PrestamoId = " + credito;

                MySqlCommand cmd = new MySqlCommand(query, con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();

                DateTime qnc;
                String folio, banco;
                float monto, pagado = 0;
                
                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        ids.Add(resultados.GetInt32(0));
                        qnc = resultados.GetDateTime(1);
                        folio = resultados.GetString(2);
                        banco = resultados.GetString(3);
                        monto = resultados.GetFloat(4);

                        pagado += monto;

                        dtd.Rows.Add(qnc.ToShortDateString(), folio, banco, "$"+ monto);
                    }
                    StorageClass.pagado = pagado;
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
                Console.WriteLine("4.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            return new DataView(dtd);
        }

        public void modificar_descuentos()
        {
            List<(int, bool)> deudas = StorageClass.getIdsDeuda();
            String queryDeudas = "";

            try
            {
                bool activo = false;
                int pagos = 0;
                double monto = 0, iva = 0, tasa = 0;
                double pMonto = 0, pIntereses = 0, pIVA = 0;

                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand("select if(Activo = 1 and Estatus = 0, true, false) as Abierto , Pagos, Monto, IVA, Tasa from prestamosind where id = " + StorageClass.getIdC() + ";", con.GetConnection());
                MySqlDataReader data = command.ExecuteReader();

                if (data.HasRows)
                {
                    data.Read();

                    activo = data.GetBoolean(0);
                    pagos = data.GetInt32(1);
                    monto = data.GetDouble(2);
                    iva = data.GetDouble(3);
                    tasa = data.GetDouble(4);
                }

                if (activo)
                {
                    pMonto = monto / pagos;
                    pIntereses = pMonto * (tasa / 100) * (pagos / 2);
                    pIVA = pIntereses * (iva / 100);

                    deudas.ForEach(deuda => {
                        if (deuda.Item2)
                        {
                            queryDeudas += "update deudaindividual set USRCambio = " + StorageClass.getId() + ", FHACambio = now(), Monto = " + pMonto + ", Intereses = " + pIntereses + ", IVA = " + pIVA + ", TotalPago =  " + (pMonto + pIntereses + pIVA) + " where Id = " + deuda.Item1 + ";\n ";
                        }
                        else
                        {
                            queryDeudas += "update deudaindividual set USRCambio = " + StorageClass.getId() + ", FHACambio = now(), Monto = " + pMonto + ", Intereses = 0, IVA = 0, TotalPago =  " + pMonto  + " where Id = " + deuda.Item1 + ";\n ";
                        }
                    });

                    StorageClass.validacion = true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al obtener los datos del credito: " + e.Message);
            }
            finally
            {
                con.CloseConnection();

                if (queryDeudas != "")
                {
                    try
                    {
                        con.crearConexion();
                        con.OpenConnection();

                        MySqlCommand command = new MySqlCommand(queryDeudas, con.GetConnection());
                        command.ExecuteNonQuery();
                        StorageClass.validacion = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error modificando la deuda: " + e.Message);
                    }
                    finally
                    {
                        con.CloseConnection();
                    }
                } else
                {
                    StorageClass.validacion = false;
                }
            }
        }

        public void descuentosCaptura()
        {
            List<int> deudas = StorageClass.getIds();
            DateTime fAlta = DateTime.Now, fCambio = DateTime.Now;

            String query = "";

            deudas.ForEach(deuda =>
            {
                query += "update deudaindividual set FHACambio = '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', USRCambio = " + StorageClass.getId() + ", Intereses = 0, IVA = 0, Moratorio = 0, TotalPago = " + StorageClass.capitalMonto + " where id = " + deuda +" ; \n";
            });

            try
            {
                con.crearConexion();
                con.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, con.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("5.- Error: " + e.ToString());
            }
            finally
            {
                con.CloseConnection();

                con.crearConexion();
                con.OpenConnection();

                query = "INSERT INTO depositoind " +
                    "(FHAAlta, FHACambio, USRAlta, USRCambio, SucursalId, Referencia, BancoId, " +
                    "Banco, DiaDeposito, DiaCaptura, OficialCreditoId, PrestamoId, Folio, Monto, " +
                    "FormatoPago, Activo) " +
                    "VALUES " +
                    "( '" + fAlta.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', " + StorageClass.getId() + ", " + StorageClass.getId() + ", 0, " + StorageClass.getIdC() + ", " + bancoId(StorageClass.getBanco()) + ", '" + StorageClass.getBanco() + "', '" + StorageClass.getFDeposito().ToString("yyyy-MM-dd") + " 00:00:00', '" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00', " +
                    getOficialId(StorageClass.getIdC()) + "," + StorageClass.getIdC() + ", '" + StorageClass.getFolio() + "', " + StorageClass.getMonto() + ", 0, 1); ";

                try
                {
                    con.crearConexion();
                    con.OpenConnection();
                    MySqlCommand command = new MySqlCommand(query, con.GetConnection());

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("6.- Error: " + e.ToString());
                }
                finally
                {
                    con.CloseConnection();
                    String recibos = "";

                    float monto = StorageClass.getMonto() / StorageClass.canPagos;

                    List<(int, string)> aux = new List<(int, string)>();

                    query = "";
                    deudas.ForEach(deuda =>
                    {

                        try
                        {
                            con.crearConexion();
                            con.OpenConnection();

                            query = "select Id, FechaPago from deudaindividual where Id = " + deuda + ";\n";


                            MySqlCommand cmd = new MySqlCommand(query, con.GetConnection());
                            cmd.CommandTimeout = 1000000;
                            MySqlDataReader resultados = cmd.ExecuteReader();

                            if (resultados.HasRows)
                            {
                                while (resultados.Read())
                                {
                                    aux.Add((resultados.GetInt32(0), resultados.GetDateTime(1).ToString()));
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
                            Console.WriteLine("7.- Error: " + e);
                        }
                        finally { con.CloseConnection(); }



                    });


                    int depositoID = 0;

                    try
                    {
                        con.crearConexion();
                        con.OpenConnection();
                        String sql = "select MAX(Id) from depositoind where PrestamoId = " + StorageClass.getIdC();
                        MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                        MySqlDataReader resultados = cmd.ExecuteReader();
                        if (resultados.HasRows)
                        {
                            while (resultados.Read())
                            {
                                depositoID = resultados.GetInt32(0);
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
                        Console.WriteLine("8.- Error: " + e);
                    }
                    finally { con.CloseConnection(); }

                    DateTime qnc;

                    aux.ForEach(deuda =>
                    {
                        qnc = Convert.ToDateTime(deuda.Item2);
                        recibos += "insert into reciboind (FHAAlta, FHACambio, USRAlta, USRCAmbio, SucursalId, PrestamoId, PagoNo, NumPago, FechaPago, Monto, FolioRecibo, FechaEntrega, TipoPago, DepositoId, Activo) " +
                                "values " +
                                "('" + fAlta.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', " + StorageClass.getId() + ", " + StorageClass.getId() + ", 0, " + StorageClass.getIdC() + ", " + deuda.Item1 + ", 0, '"+ qnc.ToString("yyyy-MM-dd") + " 00:00:00', " + monto + ", '" + StorageClass.getFolio() + "', '" + StorageClass.getFDeposito().ToString("yyyy-MM-dd") + " 00:00:00', 0, " + depositoID + ", 1); \n";
                    });

                    try
                    {
                        con.crearConexion();
                        con.OpenConnection();
                        MySqlCommand command = new MySqlCommand(recibos, con.GetConnection());

                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("9.- Error: " + e.ToString());
                    }
                    finally
                    {
                        con.CloseConnection();
                    }

                    query = "update prestamosind set FHACambio = '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', USRCambio = " + StorageClass.getId() + ", FechaDeposito = '" + StorageClass.getFDeposito().ToString("yyyy-MM-dd") + " 00:00:00' where Id = " + StorageClass.getIdC();

                    try
                    {
                        con.crearConexion();
                        con.OpenConnection();
                        MySqlCommand command = new MySqlCommand(query, con.GetConnection());

                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("10.- Error: " + e.ToString());
                    }
                    finally
                    {
                        con.CloseConnection();
                    }

                }
            }
        }

        public void Captura()
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();
                String sql = "select if(Activo = 1 and Estatus = 1, true, false) as Activo, Monto, IVA, Pagos, Tasa, FechaI from prestamosind where Id = " + StorageClass.getIdC();
                MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                MySqlDataReader resultados = cmd.ExecuteReader();
                if (resultados.HasRows)
                {
                    resultados.Read();
                    if (resultados.GetBoolean(0))
                    {
                        generarDeuda(StorageClass.getIdC(), resultados.GetInt32(1), resultados.GetInt32(2), resultados.GetInt32(3), resultados.GetFloat(4), resultados.GetDateTime(5));
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
                Console.WriteLine("11.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            
            DateTime fAlta = DateTime.Now, fCambio = DateTime.Now;

            String query = "update prestamosind set FHACambio = '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', USRCambio = " + StorageClass.getId() + ", FechaDeposito = '" + StorageClass.getFDeposito().ToString("yyyy-MM-dd") + " 00:00:00' where Id = " + StorageClass.getIdC();

            try
            {
                con.crearConexion();
                con.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, con.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("12.- Error: " + e.ToString());
            }
            finally
            {
                con.CloseConnection();
            }

            query = "INSERT INTO depositoind " +
                "(FHAAlta, FHACambio, USRAlta, USRCambio, SucursalId, Referencia, BancoId, " +
                "Banco, DiaDeposito, DiaCaptura, OficialCreditoId, PrestamoId, Folio, Monto, " +
                "FormatoPago, Activo) " +
                "VALUES " +
                "( '" + fAlta.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', " + StorageClass.getId() + ", " + StorageClass.getId() + ", 0, " + StorageClass.getIdC() + ", " + bancoId(StorageClass.getBanco()) + ", '" + StorageClass.getBanco() + "', '" + StorageClass.getFDeposito().ToString("yyyy-MM-dd") + " 00:00:00', '" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00', " +
                getOficialId(StorageClass.getIdC()) + "," + StorageClass.getIdC() + ", '" + StorageClass.getFolio() + "', " + StorageClass.getMonto() + ", 0, 1); ";

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand(query, con.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("13.- Error: " + e.ToString());
            }
            finally
            {
                con.CloseConnection();
            }

            int depositoID = 0;

            try
            {
                con.crearConexion();
                con.OpenConnection();
                String sql = "select MAX(Id) from depositoind where PrestamoId = " + StorageClass.getIdC();
                MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                MySqlDataReader resultados = cmd.ExecuteReader();
                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        depositoID = resultados.GetInt32(0);
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
                Console.WriteLine("14.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            int valor = 0;
            String recibos = "";
            double MontoInicial = StorageClass.getMonto();
            bool Moratorios = StorageClass.getMora();
            try
            {
                con.crearConexion();
                con.OpenConnection();
                String sql = "";
                sql += "select deuda.Id, deuda.FechaPago, deuda.TotalPago, IFNULL(recibo.monto,0) as Pagado, round((deuda.TotalPago - IFNULL(recibo.monto,0)), 20) as Pendiente, IFNULL(recibo.orden,0) diferencia, deuda.Monto, deuda.Intereses, deuda.IVA, deuda.Moratorio from deudaindividual deuda left JOIN ";
                sql += "(select PrestamoId, PagoNo, SUM(Monto) monto, MAX(NumPago) orden from reciboind where PrestamoId = " + StorageClass.getIdC() + " and Activo = 1 group by PrestamoId, PagoNo) recibo on recibo.PagoNo = deuda.Id and deuda.PrestamoId = recibo.PrestamoId ";
                sql += "where deuda.Activo = 1 and deuda.PrestamoId = " + StorageClass.getIdC() + " and((deuda.TotalPago - recibo.monto) > 0 or recibo.monto is NULL) ";
                MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                MySqlDataReader resultados = cmd.ExecuteReader();
                int nPago = 0;
                int idDeuda;
                DateTime fechaDeuda;
                double diferencia;
                double MDeposito = 0;
                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        if (MontoInicial > 0)
                        {
                            idDeuda = resultados.GetInt32(0);
                            fechaDeuda = resultados.GetDateTime(1);
                            diferencia = resultados.GetDouble(4);
                            MDeposito = 0;
                            
                            if (Moratorios)
                            {
                                recibos += "update deudaindividual set FHACambio = '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', USRCambio = " + StorageClass.getId() + ", Moratorio = " + StorageClass.getMontoMora() + ", TotalPago = " + (resultados.GetFloat(6) + resultados.GetFloat(7) + resultados.GetFloat(8) + resultados.GetFloat(9) + StorageClass.getMontoMora()) + " where Id = " + idDeuda + "; \n";
                                diferencia += StorageClass.getMontoMora();

                                Moratorios = false;
                                StorageClass.setMora(false);
                                StorageClass.setMontoMora(0);
                            }

                            if (nPago == 0)
                            {
                                nPago = resultados.GetInt32(5);
                            } else
                            {
                                nPago++;
                            }

                            if (diferencia > MontoInicial)
                            {
                                MDeposito = MontoInicial;
                                MontoInicial = 0;
                            }
                            else
                            {
                                MDeposito = diferencia;
                                MontoInicial -= diferencia;
                            }
                            int NumPago = resultados.GetInt32(5);
                            recibos += "insert into reciboind (FHAAlta, FHACambio, USRAlta, USRCAmbio, SucursalId, PrestamoId, PagoNo, NumPago, FechaPago, Monto, FolioRecibo, FechaEntrega, TipoPago, DepositoId, Activo) " +
                                "values " +
                                "('" + fAlta.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', " + StorageClass.getId() + ", " + StorageClass.getId() + ", 0, " + StorageClass.getIdC() + ", " + idDeuda + ", " + nPago + ", '" + fechaDeuda.ToString("yyyy-MM-dd") + " 00:00:00', " + MDeposito + ", '" + StorageClass.getFolio() + "', '" + StorageClass.getFDeposito().ToString("yyyy-MM-dd") + " 00:00:00', 0, " + depositoID + ", 1); \n";

                        }
                    }
                    if (MontoInicial > 0)
                    {
                        recibos += "update reciboind set Monto = " + (MDeposito + MontoInicial) + " where id = LAST_INSERT_ID();";
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
                Console.WriteLine("15.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            try
            {
                String conectar = con.OpenConnection();
                if (conectar == "conectado")
                {
                    MySqlCommand cmd = new MySqlCommand(recibos, con.GetConnection());
                    valor = Convert.ToInt32(cmd.ExecuteScalar());
                    recibos = "";
                }
                else
                {
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("16.- Error: " + e);
            }
            finally
            {
                con.CloseConnection();
            }

        }

        public int bancoId(String banco)
        {

            try
            {
                con.crearConexion();
                con.OpenConnection();
                string sql = "select id from banco where banco = '" + banco + "'";

                int id = 0;

                MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();

                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        id = resultados.GetInt32(0);
                    }
                    return id;
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
                Console.WriteLine("17.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            return 0;
        }

        public int getOficialId(int credito)
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();
                string sql = "select OficialId from prestamosind where Id = " + credito;

                int id = 0;

                MySqlCommand cmd = new MySqlCommand(sql, con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();

                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        id = resultados.GetInt32(0);
                    }
                    return id;
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
                Console.WriteLine("18.- Error: " + e);
            }
            finally { con.CloseConnection(); }

            return 0;
        }

        public string query(int credito)
        {
            string ReporteInversion = "";

            ReporteInversion =
                "select deudaindividual.Id, deudaindividual.FechaPago, PagoId, deudaindividual.Monto, deudaindividual.Moratorio, TotalPago, sum(ri.Monto) as Pagado, concat(personal.nombre, ' ', personal.paterno, ' ', personal.materno) as Oficial, prestamosind.Monto as Prestado from deudaindividual " +
                "left join reciboind ri on deudaindividual.Id = ri.PagoNo and ri.Activo = 1 " +
                "left join prestamosind on prestamosind.id = deudaindividual.PrestamoId " +
                "left join personal on personal.id = prestamosind.OficialId " +
                "where deudaindividual.PrestamoId = " + credito + " and deudaindividual.Activo = 1 " +
                "group by PagoId";

            return ReporteInversion;
        }

        public void generarDeuda(int Credito, int M, int I, int P, float T, DateTime qncIni)
        {
            String query = "update prestamosind set USRCambio = "+ StorageClass.getId() +", FHACambio = now(), Activo = 1, Estatus = 0 where Id = " + Credito;
            
            try
            {
                con.crearConexion();
                con.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, con.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("19.- Error: " + e.ToString());
            }
            finally
            {
                con.CloseConnection();
            }


            DateTime fAlta = DateTime.Now, fCambio = DateTime.Now;

            int day, month, year;

            float monto = (float)(Math.Round((double)M/P, 2));
            float intereses = (float)(Math.Round((double)(monto * (P / 2) * (0.01f * T)), 2));
            float iva = (float)(Math.Round((double)(intereses * (I * 0.01f)), 2));
            float totalPago = monto + intereses + iva;

            query = "";

            for(int i = 1; i <= P; i++)
            {
                query += "insert into deudaindividual(" +
                "FHAALta, FHACambio, USRAlta, USRCambio, SucursalId, PrestamoId, PagoId, OficialCreditoId, " +
                "FechaPago, Monto, Intereses, IVA, Moratorio, TotalPago, Activo, Estatus) " +
                "Values(" +
                "'" + fAlta.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', '" + fCambio.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', " + StorageClass.getId() + ", " + StorageClass.getId() + ", 0, " + Credito + ", " + i + ", " + getOficialId(StorageClass.getIdC()) + ", '" +
                qncIni.ToString("yyyy-MM-dd HH:mm:ss:ff") + "', " + monto + ", " + intereses + ", " + iva + ", 0, " + totalPago + ", 1, 1);\n";

                day = qncIni.Day;
                month = qncIni.Month;
                year = qncIni.Year;

                if (day <= 15)
                {
                    qncIni = new DateTime(qncIni.Year,qncIni.Month,DateTime.DaysInMonth(qncIni.Year, qncIni.Month));
                    if (DayOfWeek.Sunday == qncIni.DayOfWeek)
                    {
                        qncIni = new DateTime(qncIni.Year, qncIni.Month, DateTime.DaysInMonth(qncIni.Year, qncIni.Month)-1);
                    }
                } else
                {
                    if (qncIni.Month != 12)
                    {
                        qncIni = new DateTime(qncIni.Year, qncIni.Month + 1, 15);
                    } else
                    {
                        qncIni = new DateTime(qncIni.Year + 1, 1, 15);
                    }
                    if (DayOfWeek.Sunday == qncIni.DayOfWeek)
                    {
                        qncIni = new DateTime(qncIni.Year, qncIni.Month, 14);
                    }
                }
            }
            
            try
            {
                con.crearConexion();
                con.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, con.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("20.- Error: " + e.ToString());
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public void cancelarDeposito()
        {
            int id = StorageClass.cancelar;
            String query = "update depositoind set FHACambio = now(), USRCambio = " + StorageClass.getId() + ", Activo = 0 where Id = " + id + ";\n" +
                "update reciboind set FHACambio = now(), USRCambio = " + StorageClass.getId() + ", Activo = 0 where DepositoId = " + id + ";"; ;

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand(query, con.GetConnection());
                command.CommandTimeout = 100000;

                command.ExecuteNonQuery();
                StorageClass.validacion = true;

            } catch (Exception e)
            {
                Console.WriteLine("Error cancelando el deposito: " + e.Message);
            } finally
            {
                con.CloseConnection();
            }

        }

        public void quitar_moratorios()
        {
            List<int> deudas = StorageClass.getIds();
            String queryDeudas = "";

            try
            {
                bool activo = false;
                int pagos = 0;
                double monto = 0, iva = 0, tasa = 0;
                double pMonto = 0, pIntereses = 0, pIVA = 0;

                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand("select if(Activo = 1 and Estatus = 0, true, false) as Abierto , Pagos, Monto, IVA, Tasa from prestamosind where id = " + StorageClass.getIdC() + ";", con.GetConnection());
                MySqlDataReader data = command.ExecuteReader();

                if (data.HasRows)
                {
                    data.Read();

                    activo = data.GetBoolean(0);
                    pagos = data.GetInt32(1);
                    monto = data.GetDouble(2);
                    iva = data.GetDouble(3);
                    tasa = data.GetDouble(4);
                }

                if (activo)
                {
                    pMonto = monto / pagos;
                    pIntereses = pMonto * (tasa / 100) * (pagos / 2);
                    pIVA = pIntereses * (iva / 100);

                    deudas.ForEach(deuda => {
                        queryDeudas += "update deudaindividual set USRCambio = " + StorageClass.getId() + ", FHACambio = now(), Monto = " + pMonto + ", Intereses = " + pIntereses + ", IVA = " + pIVA + ", Moratorio = 0, TotalPago = " + (pMonto + pIntereses + pIVA) + " where Id = " + deuda + ";\n";
                    });

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al obtener los datos del credito: " + e.Message);
            }
            finally
            {
                con.CloseConnection();

                if (queryDeudas != "")
                {
                    try
                    {
                        con.crearConexion();
                        con.OpenConnection();

                        MySqlCommand command = new MySqlCommand(queryDeudas, con.GetConnection());
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error modificando la deuda: " + e.Message);
                    }
                    finally
                    {
                        con.CloseConnection();
                    }
                }
            }
        }
    }
}
