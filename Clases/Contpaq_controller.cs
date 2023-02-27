using Modulos.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class Contpaq_controller
    {
        Conexion con;
        public Contpaq_controller()
        {
            con = new Conexion();
        }

        public void contpaq()
        {
            DateTime ini = StorageClass.contpaqIni;
            DateTime fin = StorageClass.contpaqFin;
            List<int> depositos = new List<int>();
            Dictionary<int, Modelos.ContpaqDeposito> list = new Dictionary<int, Modelos.ContpaqDeposito>();
            double cargo = 0, abono = 0;

            DataTable dtm = StorageClass.contpaqData;

            dtm.Clear();

            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand(queryCreditos(ini, fin), con.GetConnection());
                Console.WriteLine(queryCreditos(ini, fin));
                command.CommandTimeout = 100000;
                MySqlDataReader data = command.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        depositos.Add(data.GetInt32(0));
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine($"Error obteniendo los depositos: {e}");
            } finally
            {
                con.CloseConnection();
            }

            if (depositos.Count != 0)
            {

                int idDeuda, idDeposito, idPrestamo, idAuxPrestamo, idAuxDeuda, idAuxDeposito;
                double deudaMonto, deudaIntereses, deudaIVA, deudaMora, deudaTotal, montoRecibo, montoDeposito;
                double monto, intereses, iva, mora;
                DateTime diaDeposito = DateTime.Now;
                Boolean enRango, first;
                String socio, oficial, banco, codigoBanco;
                double i = 1;
                depositos.ForEach(credito =>
                {
                    Console.Clear();
                    Console.WriteLine($"Calculando {Math.Round((100 * i / depositos.Count), 2)}% ...");
                    i++;
                    try
                    {
                        con.crearConexion();
                        con.OpenConnection();

                        MySqlCommand cmd = new MySqlCommand(query(credito), con.GetConnection());
                        cmd.CommandTimeout = 100000;
                        MySqlDataReader data = cmd.ExecuteReader();

                        if (data.HasRows)
                        {
                            idDeuda = 0; idDeposito = 0; idPrestamo = 0; idAuxPrestamo = 0; idAuxDeuda = 0; idAuxDeposito = 0;
                            deudaMonto = 0; deudaIntereses = 0; deudaIVA = 0; deudaMora = 0; deudaTotal = 0; montoRecibo = 0; montoDeposito = 0;
                            monto = 0; intereses = 0; iva = 0; mora = 0;
                            diaDeposito = DateTime.Now;
                            enRango = false; first = false;
                            socio = ""; oficial = ""; banco = ""; codigoBanco = "";
                            while (data.Read())
                            {
                                idAuxDeuda = data.GetInt32(0);
                                idAuxDeposito = data.GetInt32(7);
                                idAuxPrestamo = data.GetInt32(10);
                                if ((idDeuda != idAuxDeuda || idDeposito != idAuxDeposito) && enRango)
                                {
                                    if (list.ContainsKey(idDeposito) && (idDeposito == credito))
                                    {
                                        list[idDeposito].abonoCapital = monto + list[idDeposito].abonoCapital + montoRecibo;
                                        list[idDeposito].abonoIntereses = intereses + list[idDeposito].abonoIntereses;
                                        list[idDeposito].abonoIVA = iva + list[idDeposito].abonoIVA;
                                        list[idDeposito].abonoMora = mora + list[idDeposito].abonoMora;

                                        monto = 0;
                                        intereses = 0;
                                        iva = 0;
                                        mora = 0;
                                    }
                                    else if (idDeposito == credito)
                                    {
                                        ContpaqDeposito cd = new ContpaqDeposito();

                                        cd.diaDeposito = diaDeposito;
                                        cd.cargo = montoDeposito;
                                        cd.abonoCapital = monto + montoRecibo;
                                        cd.abonoIntereses = intereses;
                                        cd.abonoIVA = iva;
                                        cd.abonoMora = mora;
                                        cd.referencia = idPrestamo;
                                        cd.codigoBanco = codigoBanco;
                                        cd.banco = banco;
                                        cd.socio = socio;
                                        cd.oficial = oficial;
                                        cd.idPrestamo = idPrestamo;

                                        list.Add(idDeposito, cd);
                                        monto = 0;
                                        intereses = 0;
                                        iva = 0;
                                        mora = 0;
                                    }

                                }

                                diaDeposito = data.GetDateTime(8);
                                montoRecibo = data.GetDouble(6);
                                montoDeposito = data.GetDouble(9);
                                codigoBanco = data.GetString(11);
                                banco = data.GetString(12);
                                socio = data.GetString(13);
                                oficial = data.GetString(14);

                                enRango = ((diaDeposito >= ini) && (diaDeposito <= fin));

                                if (idDeuda != idAuxDeuda)
                                {
                                    idDeuda = idAuxDeuda;
                                    deudaMonto = data.GetDouble(1);
                                    deudaIntereses = data.GetDouble(2);
                                    deudaIVA = data.GetDouble(3);
                                    deudaMora = data.GetDouble(4);
                                    deudaTotal = data.GetDouble(5);

                                }

                                if (idPrestamo != idAuxPrestamo)
                                {
                                    idPrestamo = idAuxPrestamo;
                                    first = true;
                                }

                                if (idDeposito != idAuxDeposito)
                                {
                                    idDeposito = idAuxDeposito;
                                }

                                if (first && enRango && (idDeposito == credito))
                                {
                                    first = false;

                                    if (montoRecibo >= 0)
                                    {
                                        if (montoRecibo > deudaMora)
                                        {
                                            montoRecibo -= deudaMora;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                mora += deudaMora;
                                            }
                                            deudaMora = 0;
                                        }
                                        else
                                        {
                                            deudaMora -= montoRecibo;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                mora += montoRecibo;
                                            }
                                            montoRecibo = 0;
                                        }
                                    }

                                    if (montoRecibo >= 0)
                                    {
                                        if (montoRecibo > deudaIVA)
                                        {
                                            montoRecibo -= deudaIVA;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                iva += deudaIVA;
                                            }
                                            deudaIVA = 0;
                                        }
                                        else
                                        {
                                            deudaIVA -= montoRecibo;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                iva += montoRecibo;
                                            }
                                            montoRecibo = 0;
                                        }
                                    }

                                    if (montoRecibo >= 0)
                                    {
                                        if (montoRecibo > deudaIntereses)
                                        {
                                            montoRecibo -= deudaIntereses;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                intereses += deudaIntereses;
                                            }
                                            deudaIntereses = 0;
                                        }
                                        else
                                        {
                                            deudaIntereses -= montoRecibo;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                intereses += montoRecibo;
                                            }
                                            montoRecibo = 0;
                                        }
                                    }

                                    if (montoRecibo >= 0)
                                    {
                                        if (montoRecibo > deudaMonto)
                                        {
                                            montoRecibo -= deudaMonto;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                monto += deudaMonto;
                                            }
                                            deudaMonto = 0;
                                        }
                                        else
                                        {
                                            deudaMonto -= montoRecibo;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                monto += montoRecibo;
                                            }
                                            montoRecibo = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    if (montoRecibo >= 0)
                                    {
                                        if (montoRecibo > deudaMonto)
                                        {
                                            montoRecibo -= deudaMonto;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                monto += deudaMonto;
                                            }
                                            deudaMonto = 0;
                                        }
                                        else
                                        {
                                            deudaMonto -= montoRecibo;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                monto += montoRecibo;
                                            }
                                            montoRecibo = 0;
                                        }
                                    }

                                    if (montoRecibo >= 0)
                                    {
                                        if (montoRecibo > deudaIntereses)
                                        {
                                            montoRecibo -= deudaIntereses;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                intereses += deudaIntereses;
                                            }
                                            deudaIntereses = 0;
                                        }
                                        else
                                        {
                                            deudaIntereses -= montoRecibo;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                intereses += montoRecibo;
                                            }
                                            montoRecibo = 0;
                                        }
                                    }

                                    if (montoRecibo >= 0)
                                    {
                                        if (montoRecibo > deudaIVA)
                                        {
                                            montoRecibo -= deudaIVA;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                iva += deudaIVA;
                                            }
                                            deudaIVA = 0;
                                        }
                                        else
                                        {
                                            deudaIVA -= montoRecibo;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                iva += montoRecibo;
                                            }
                                            montoRecibo = 0;
                                        }
                                    }

                                    if (montoRecibo >= 0)
                                    {
                                        if (montoRecibo > deudaMora)
                                        {
                                            montoRecibo -= deudaMora;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                mora += deudaMora;
                                            }
                                            deudaMora = 0;
                                        }
                                        else
                                        {
                                            deudaMora -= montoRecibo;
                                            if (enRango && (idDeposito == credito))
                                            {
                                                mora += montoRecibo;
                                            }
                                            montoRecibo = 0;
                                        }
                                    }
                                }
                            }

                            if (enRango && (idDeposito == credito))
                            {
                                if (list.ContainsKey(idDeposito) && (idDeposito == credito))
                                {
                                    list[idDeposito].abonoCapital = monto + list[idDeposito].abonoCapital + montoRecibo;
                                    list[idDeposito].abonoIntereses = intereses + list[idDeposito].abonoIntereses;
                                    list[idDeposito].abonoIVA = iva + list[idDeposito].abonoIVA;
                                    list[idDeposito].abonoMora = mora + list[idDeposito].abonoMora;

                                    monto = 0;
                                    intereses = 0;
                                    iva = 0;
                                    mora = 0;
                                }
                                else if (idDeposito == credito)
                                {
                                    ContpaqDeposito cd = new ContpaqDeposito();

                                    cd.diaDeposito = diaDeposito;
                                    cd.cargo = montoDeposito;
                                    cd.abonoCapital = monto + montoRecibo;
                                    cd.abonoIntereses = intereses;
                                    cd.abonoIVA = iva;
                                    cd.abonoMora = mora;
                                    cd.referencia = idPrestamo;

                                    cd.codigoBanco = codigoBanco;
                                    cd.banco = banco;
                                    cd.socio = socio;
                                    cd.oficial = oficial;
                                    cd.idPrestamo = idPrestamo;
                                    
                                    list.Add(idDeposito, cd);
                                    
                                    monto = 0;
                                    intereses = 0;
                                    iva = 0;
                                    mora = 0;
                                }

                            }

                            if (list.ContainsKey(credito))
                            {
                                cargo += list[credito].cargo;
                                abono += list[credito].abonoIntereses + list[credito].abonoIVA + list[credito].abonoMora;

                                if (list[credito].cargo == (list[credito].abonoCapital + list[credito].abonoIntereses + list[credito].abonoIVA + list[credito].abonoMora))
                                {
                                    abono += list[credito].abonoCapital;
                                }
                                else
                                {
                                    list[credito].abonoCapital = (list[credito].cargo - (list[credito].abonoIntereses + list[credito].abonoIVA + list[credito].abonoMora));
                                    abono += list[credito].abonoCapital;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error obteniendo los datos de contpaq: " + e.Message);
                    }
                    finally { con.CloseConnection(); }
                });

                StorageClass.contpaqAbono = abono;
                StorageClass.contpaqCargo = cargo;
                foreach (KeyValuePair<int, ContpaqDeposito> item in list)
                {
                    if ((item.Value.cargo - (item.Value.abonoCapital + item.Value.abonoIntereses + item.Value.abonoIVA + item.Value.abonoMora)) > 1)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value.diaDeposito.ToShortDateString()} - {item.Value.idPrestamo} - {item.Value.cargo} - {item.Value.abonoCapital} - {item.Value.abonoIntereses} - {Math.Round(item.Value.abonoIVA, 2)} - {item.Value.abonoMora} - {item.Value.codigoBanco} - {item.Value.banco} - {/*item.Value.oficial*/""} - {/*item.Value.socio*/""}");
                    }

                    {
                        dtm.Rows.Add(item.Value.diaDeposito.ToShortDateString(), item.Value.codigoBanco, item.Value.oficial, "$ " + Math.Round(item.Value.cargo, 2), "$ 0", item.Value.idPrestamo, item.Value.socio, "Pago de prestamo", item.Value.banco);
                    }

                    if (item.Value.abonoCapital != 0)
                    {
                        dtm.Rows.Add(item.Value.diaDeposito.ToShortDateString(), "10501100", item.Value.oficial, "$ 0", "$ " + Math.Round(item.Value.abonoCapital, 2), item.Value.idPrestamo, item.Value.socio, "Capital", item.Value.banco);
                    }

                    if (item.Value.abonoIntereses != 0)
                    {
                        dtm.Rows.Add(item.Value.diaDeposito.ToShortDateString(), "40131000", item.Value.oficial, "$ 0", "$ " + Math.Round(item.Value.abonoIntereses, 2), item.Value.idPrestamo, item.Value.socio, "Intereses", item.Value.banco);
                    }

                    if (item.Value.abonoIVA != 0)
                    {
                        dtm.Rows.Add(item.Value.diaDeposito.ToShortDateString(), "40131000", item.Value.oficial, "$ 0", "$ " + Math.Round(item.Value.abonoIVA, 2), item.Value.idPrestamo, item.Value.socio, "IVA", "");
                    }

                    if (item.Value.abonoMora != 0)
                    {
                        dtm.Rows.Add(item.Value.diaDeposito.ToShortDateString(), "40131000", item.Value.oficial, "$ 0", "$ " + Math.Round(item.Value.abonoMora, 2), item.Value.idPrestamo, item.Value.socio, "Mora", item.Value.banco);
                    }
                }
            }

        }

        public String queryCreditos(DateTime ini, DateTime fin)
        {
            return $"select id from depositoind where Activo = 1 and DiaDeposito between '{ini.Year}-{ini.Month.ToString("00")}-{ini.Day.ToString("00")}' and '{fin.Year}-{fin.Month.ToString("00")}-{fin.Day.ToString("00")}'";
        }
        public String query(int Deposito)
        {
            return "select " +
                "    di.Id, " +
                "	 di.Monto MontoD, " +
                "    di.Intereses, " +
                "    di.IVA, " +
                "    di.Moratorio, " +
                "    di.TotalPago, " +
                "    ri.Monto as MontoR, " +
                "    depind.Id idDeposito, " +
                "    depind.DiaDeposito, " +
                "    depind.Monto AS MontoDep, " +
                "    depind.PrestamoId, " +
                "    banco.Codigo as bancoCodigo, " +
                "    banco.banco, " +
                "    concat(pi.nombre, ' ', pi.paterno, ' ', pi.materno) as Socio, " +
                "    concat(personal.nombre, ' ', personal.paterno, ' ', personal.materno) as Oficial " +
                "from deudaindividual di " +
                "left " +
                "join reciboind ri on ri.PagoNo = di.id and ri.Activo = 1 " +
                "left join depositoind depind on depind.id = ri.DepositoId and depind.Activo = 1 " +
                "left join prestamosind pi on pi.id = di.PrestamoId " +
                "left join personal on personal.id = pi.OficialId " +
                "left join banco on banco.id = depind.BancoId " +
                "where di.id in ( " +
                $"   select PagoNo from reciboind where DepositoId in ( {Deposito} ) " +
                "	and Activo = 1 " +
                ") and di.Activo = 1 " +
                "order by di.Id ASC, depind.id ASC;  ";
        }
    }
}
