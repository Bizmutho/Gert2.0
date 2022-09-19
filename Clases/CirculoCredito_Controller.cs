using ClosedXML.Excel;
using Modulos.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class CirculoCredito_Controller
    {
        Conexion con;

        public CirculoCredito_Controller()
        {
            con = new Conexion();
        }

        public void reporte()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XLSX (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "Reporte circulo de credito.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool fileError = false;

                if (File.Exists(saveFileDialog.FileName))
                {
                    try
                    {
                        File.Delete(saveFileDialog.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("No se puede escribir en el disco" + ex.Message);
                    }
                }
                if (!fileError)
                {
                    XLWorkbook wb = new XLWorkbook();
                    List<Credito_Circulo> list = new List<Credito_Circulo>();
                    DateTime curDate = DateTime.Now;
                    int c = 0;
                    var ws = wb.AddWorksheet("Hoja 1");
                    ws.Columns().AdjustToContents();
                    ws.Rows().AdjustToContents();

                    String[] header = {
                        "ClaveOtorgante",
                        "NombreOtorgante",
                        "IdentificadorDeMedio",
                        "FechaExtraccion",
                        "NotaOtorgante",
                        "Version",
                        "ApellidoPaterno",
                        "ApellidoMaterno",
                        "ApellidoAdicional",
                        "Nombres",
                        "FechaNacimiento",
                        "RFC",
                        "CURP",
                        "NumeroSeguridadSocial",
                        "Nacionalidad",
                        "Residencia",
                        "NumeroLicenciaConducir",
                        "EstadoCivil",
                        "Sexo",
                        "ClaveElectorIFE",
                        "NumeroDependientes",
                        "FechaDefuncion",
                        "IndicadorDefuncion",
                        "TipoPersona",
                        "Direccion",
                        "ColoniaPoblacion",
                        "DelegacionMunicipio",
                        "Ciudad",
                        "Estado",
                        "CP",
                        "FechaResidencia",
                        "NumeroTelefono",
                        "TipoDomicilio",
                        "TipoAsentamiento",
                        "OrigenDomicilio",
                        "NombreEmpresa",
                        "Direccion",
                        "ColoniaPoblacion",
                        "DelegacionMunicipio",
                        "Ciudad",
                        "Estado",
                        "CP",
                        "NumeroTelefono",
                        "Extension",
                        "Fax",
                        "Puesto",
                        "FechaContratacion",
                        "ClaveMoneda",
                        "SalarioMensual",
                        "FechaUltimoDiaEmpleo",
                        "FechaVerificacionEmpleo",
                        "OrigenRazonSocialDomicilio",
                        "ClaveActualOtorgante",
                        "NombreOtorgante",
                        "CuentaActual",
                        "TipoResponsabilidad",
                        "TipoCuenta",
                        "TipoContrato",
                        "ClaveUnidadMonetaria",
                        "ValorActivoValuacion",
                        "NumeroPagos",
                        "FrecuenciaPagos",
                        "MontoPagar",
                        "FechaAperturaCuenta",
                        "FechaUltimoPago",
                        "FechaUltimaCompra",
                        "FechaCierraCuenta",
                        "FechaCorte",
                        "Garantia",
                        "CreditoMaximo",
                        "SaldoActual",
                        "LimiteCredito",
                        "SaldoVencido",
                        "NumeroPagosVencidos",
                        "PagoActual",
                        "HistoricoPagos",
                        "ClavePrevencion",
                        "TotalPagosReportados",
                        "ClaveAnteriorOtorgante",
                        "NombreAnteriorOtorgante",
                        "NumeroCuentaAnterior",
                        "FechaPrimerIncumplimiento",
                        "SaldoInsoluto",
                        "MontoUltimoPago",
                        "FechaIngresoCarteraVencida",
                        "MontoCorrespondienteIntereses",
                        "FormaPagoActualIntereses",
                        "DiasVencimiento",
                        "PlazoMeses",
                        "CorreoElectronicoConsumidor",
                        "MontoCreditoOriginacion"
                    };

                    for (int i = 0; i < header.Length; i++)
                    {
                        ws.Cell(1, i + 1).Value = header[i];
                        ws.Cell(1, i + 1).Style.Font.FontName = "Arial";
                    }

                    try
                    {

                        con.crearConexion();
                        con.OpenConnection();

                        MySqlCommand command = new MySqlCommand(queryCreditos(), con.GetConnection());
                        command.CommandTimeout = 10000;
                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            Inicio_Controller ic = new Inicio_Controller();
                            Credito_Circulo cc;
                            Console.WriteLine("Creditos...");
                            while (reader.Read())
                            {
                                cc = new Credito_Circulo();
                                cc.paterno = reader.GetString(0);
                                cc.materno = reader.GetString(1);
                                cc.nombre = reader.GetString(2);
                                cc.fechaNac = reader.GetString(3);
                                cc.RFC = ic.CalcularRFC(reader.GetString(2).Trim(), reader.GetString(0).Trim(), reader.GetString(1).Trim(), reader.GetString(3).Substring(2).Trim());
                                cc.estadoCivil = reader.GetInt32(4);
                                cc.sexo = reader.GetInt32(5);
                                cc.direccion = reader.GetString(6);
                                cc.colonia = reader.GetString(7);
                                cc.localidad = reader.GetString(8);
                                cc.ciudad = reader.GetString(9);
                                cc.CP = reader.GetString(10);
                                cc.cuentaActual = reader.GetString(11);
                                cc.pagos = reader.GetInt32(12);
                                cc.monto = reader.GetString(13);
                                c++;
                                list.Add(cc);
                            }
                            Console.WriteLine($"Creditos totales: {c}");
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error obteniendo los datos: {ex.Message}");
                    }
                    finally
                    {
                        con.CloseConnection();
                    }

                    String sS = "", sex = "";
                    DateTime dummyDte = new DateTime(1901,1,1);
                    Console.WriteLine("Estado creditos...");
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine($"Paso 1: {i}/{c} - {list[i].cuentaActual}");
                        estadoCredito(list[i].cuentaActual, list[i]);
                    }


                    Console.WriteLine("Pagos creditos...");
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine($"Paso 2: {i}/{c} - {list[i].cuentaActual}");
                        pagosCredito(list[i].cuentaActual, list[i]);
                    }

                    Console.WriteLine("Listo...");
                    if (list.Count > 0) {
                        for (int i = 0; i < list.Count; i++)
                        {
                            switch (list[i].estadoCivil)
                            {
                                case 1:
                                    sS = "S";
                                    break;
                                case 2:
                                    sS = "C";
                                    break;
                                case 3:
                                    sS = "V";
                                    break;
                                case 4:
                                    sS = "D";
                                    break;
                                case 5:
                                    sS = "L";
                                    break;
                                case 6:
                                    sS = "S";
                                    break;
                                case 7:
                                    sS = "S";
                                    break;
                                default:
                                    sS = "S";
                                    break;
                            }

                            switch (list[i].sexo)
                            {
                                case -1:
                                    sex = "M";
                                    break;
                                case 0:
                                    sex = "F";
                                    break;
                                case 1:
                                    sex = "M";
                                    break;
                            }

                            ws.Cell(i + 2, 1).SetValue<string>("0025770045");
                            ws.Cell(i + 2, 2).Value = "PromotoradeEmpresas";
                            ws.Cell(i + 2, 4).Value = $"{curDate.Year}{curDate.Month.ToString("00")}{curDate.Day.ToString("00")}";
                            ws.Cell(i + 2, 6).Value = "4";
                            ws.Cell(i + 2, 7).Value = list[i].paterno;
                            ws.Cell(i + 2, 8).Value = list[i].materno;
                            ws.Cell(i + 2, 10).Value = list[i].nombre;
                            ws.Cell(i + 2, 11).Value = list[i].fechaNac;
                            ws.Cell(i + 2, 12).Value = list[i].RFC;
                            ws.Cell(i + 2, 15).Value = "MX";
                            ws.Cell(i + 2, 18).Value = sS;
                            ws.Cell(i + 2, 19).Value = sex;
                            ws.Cell(i + 2, 24).Value = "PF";
                            ws.Cell(i + 2, 25).SetValue<string>(list[i].direccion);
                            ws.Cell(i + 2, 26).SetValue<string>(list[i].colonia);
                            ws.Cell(i + 2, 27).Value = list[i].localidad;
                            ws.Cell(i + 2, 28).Value = list[i].ciudad;
                            ws.Cell(i + 2, 29).Value = "TAMP";
                            ws.Cell(i + 2, 30).Value = list[i].CP;
                            ws.Cell(i + 2, 35).Value = "MX";
                            ws.Cell(i + 2, 36).Value = "Trabajador Independiente";
                            ws.Cell(i + 2, 37).SetValue<string>(list[i].direccion);
                            ws.Cell(i + 2, 38).SetValue<string>(list[i].colonia);
                            ws.Cell(i + 2, 39).Value = list[i].localidad;
                            ws.Cell(i + 2, 40).Value = list[i].ciudad;
                            ws.Cell(i + 2, 41).Value = "TAMP";
                            ws.Cell(i + 2, 42).Value = list[i].CP;
                            ws.Cell(i + 2, 53).SetValue<string>("0025770045");
                            ws.Cell(i + 2, 54).Value = "PromotoradeEmpresas";
                            ws.Cell(i + 2, 55).Value = list[i].cuentaActual;
                            ws.Cell(i + 2, 56).Value = "I";
                            ws.Cell(i + 2, 57).Value = "F";
                            ws.Cell(i + 2, 58).Value = "GS";
                            ws.Cell(i + 2, 59).Value = "MX";
                            ws.Cell(i + 2, 61).Value = list[i].pagos;
                            ws.Cell(i + 2, 62).Value = "Q";
                            ws.Cell(i + 2, 63).Value = (list[i].pagoNormal >= list[i].saldoActual) ? list[i].saldoActual : list[i].pagoNormal ;
                            ws.Cell(i + 2, 64).SetValue<string>($"{list[i].apertura.Year}{list[i].apertura.Month.ToString("00")}{list[i].apertura.Day.ToString("00")}");
                            ws.Cell(i + 2, 65).SetValue<string>($"{list[i].fechaUltimoPago.Year}{list[i].fechaUltimoPago.Month.ToString("00")}{list[i].fechaUltimoPago.Day.ToString("00")}");
                            ws.Cell(i + 2, 66).SetValue<string>($"{list[i].apertura.Year}{list[i].apertura.Month.ToString("00")}{list[i].apertura.Day.ToString("00")}");

                            if (list[i].saldoActual <= 0)
                            {
                                if (list[i].fechaUltimoPago <= list[i].cierre )
                                {
                                    ws.Cell(i + 2, 67).SetValue<string>($"{list[i].fechaUltimoPago.Year}{list[i].fechaUltimoPago.Month.ToString("00")}{list[i].fechaUltimoPago.Day.ToString("00")}");
                                } else
                                {
                                    ws.Cell(i + 2, 67).SetValue<string>($"{list[i].cierre.Year}{list[i].cierre.Month.ToString("00")}{list[i].cierre.Day.ToString("00")}");
                                }
                            }

                            ws.Cell(i + 2, 68).SetValue<string>($"{curDate.Year}{curDate.Month.ToString("00")}{curDate.Day.ToString("00")}");
                            ws.Cell(i + 2, 70).Value = list[i].monto;
                            ws.Cell(i + 2, 71).Value = list[i].saldoActual;
                            ws.Cell(i + 2, 72).Value = list[i].monto;
                            ws.Cell(i + 2, 73).Value = list[i].vencido;
                            ws.Cell(i + 2, 75).Value = (list[i].vencido == 0 ) ? " V" : list[i].pagoActual;
                            ws.Cell(i + 2, 82).Value = "19010101";
                            ws.Cell(i + 2, 83).Value = list[i].insoluto;
                            ws.Cell(i + 2, 84).Value = list[i].montoUltimoPago;
                            ws.Cell(i + 2, 89).Value = (list[i].pagos / 2);
                        }
                        wb.SaveAs(saveFileDialog.FileName);
                    }
                }
            }
        }

        public void estadoCredito(String credito, Credito_Circulo cc)
        {
            try
            {
                Console.WriteLine("Inicio estado credito...");
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand mySqlCommand = new MySqlCommand(queryEstadoCredito(credito), con.GetConnection());
                mySqlCommand.CommandTimeout = 100000;
                MySqlDataReader data = mySqlCommand.ExecuteReader();
                DateTime currDte = DateTime.Now;
                DateTime dummyDte = new DateTime(1901,1,1);
                DateTime apertura = dummyDte;
                DateTime cierre = dummyDte;
                float pago = 0, capital = 0, actual = 0, insoluto = 0, vencido = 0;
                int pagVen = 1;

                if (data.HasRows)
                {
                    Console.WriteLine("Datos...");
                    while (data.Read())
                    {
                        if (apertura == dummyDte)
                        {
                            apertura = data.GetDateTime(0);
                        }
                        cierre = data.GetDateTime(0);
                        if (capital == 0)
                        {
                            capital = data.GetFloat(2);
                        }
                        if (pago == 0)
                        {
                            pago = data.GetFloat(3);
                        }
                        if (currDte > cierre)
                        {
                            vencido += data.GetFloat(3) - data.GetFloat(4);

                            if (data.GetFloat(4) < (data.GetFloat(3) * 0.97))
                            {
                                pagVen++;
                            }
                        }
                        actual += ((data.GetFloat(3) - data.GetFloat(4)) > 0) ? data.GetFloat(3) - data.GetFloat(4) : 0;
                        insoluto += ((data.GetFloat(2) - data.GetFloat(4) < 0) ? 0 : data.GetFloat(2) - data.GetFloat(4));
                    }
                    Console.WriteLine("Obtenidos...");
                }
                cc.apertura = apertura;
                cc.cierre = cierre;
                cc.capital = capital;
                cc.pagoNormal = pago;
                cc.saldoActual = (actual < 0) ? 0 : actual;
                cc.vencido = (vencido < 0) ? 0 : vencido;
                cc.insoluto = insoluto;
                cc.pagoActual = pagVen;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Reintentando......");
                estadoCredito(credito,cc);
            } finally
            {
                Console.WriteLine("Fin...\n\n\n");
                con.CloseConnection();
            }
        } 

        public void pagosCredito(String credito, Credito_Circulo cc)
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand mySqlCommand = new MySqlCommand($"select DiaDeposito, Monto from depositoind where PrestamoId = {credito} and activo = 1 order by DiaDeposito ASC;", con.GetConnection());
                mySqlCommand.CommandTimeout = 100000;
                MySqlDataReader data = mySqlCommand.ExecuteReader();
                DateTime apertura = cc.apertura;
                DateTime cierre = cc.cierre;
                DateTime fechaPago = new DateTime(1901,1,1);
                float monto = 0;

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        fechaPago = data.GetDateTime(0);
                        monto = data.GetFloat(1);
                        if (fechaPago < apertura)
                        {
                            fechaPago = apertura;
                        }
                        if(fechaPago > cierre)
                        {
                            cierre = fechaPago;
                        }
                    }
                }

                cc.cierre = cierre;
                cc.montoUltimoPago = monto;
                cc.fechaUltimoPago = fechaPago;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Reintentando......");
                pagosCredito(credito, cc);
            }
            finally
            {
                Console.WriteLine("Fin...\n\n\n");
                con.CloseConnection();
            }
        }

        public string queryEstadoCredito(String credito)
        {
            return "select deudaindividual.FechaPago, PagoId, deudaindividual.Monto, TotalPago, ifnull(sum(ri.Monto), 0) as Pagado, prestamosind.Monto as Prestado from deudaindividual " +
                "left join reciboind ri on deudaindividual.Id = ri.PagoNo and ri.Activo = 1 " +
                "left join prestamosind on prestamosind.id = deudaindividual.PrestamoId " +
                $"where deudaindividual.PrestamoId = {credito} and deudaindividual.Activo = 1 " +
                "group by PagoId";
        }

        public String queryCreditos()
        {
            return "select " +
                "prestamosind.paterno, " +
                "IF(socios.Materno='','X',socios.Materno) ApellidoMaterno, " +
                "prestamosind.nombre, " +
                "DATE_FORMAT(socios.Nacimiento, '%Y%m%d') FechaNacimiento, " +
                "socios.EstadoCivil, " +
                "socios.Sexo, " +
                "CONCAT(socios.Direccion, ' ', socios.NoExterior, IF(socios.NoInterior = 0, '', CONCAT(' Número interior: ', socios.NoInterior)))  Direccion, " +
                "socios.Colonia, " +
                "localidad.Localidad, " +
                "ciudad.ciudad, " +
                "socios.codigopostal, " +
                "prestamosind.id, " +
                "prestamosind.pagos, " +
                "prestamosind.Monto " +
                "from prestamosind " +
                "left join socios on socios.id = prestamosind.Socioid " +
                "left join localidad on localidad.id = socios.localidadid " +
                "left join ciudad on ciudad.id = localidad.ciudadid " +
                "where prestamosind.id in ( " +
                "select PrestamoId from deudaindividual where FechaPago <= '2022-04-30' and activo = 1 group by PrestamoId) " +
                "and not((prestamosind.Activo = 0 and prestamosind.Estatus = 1) or(prestamosind.Activo = 1 and prestamosind.Estatus = 1)) " +
                "order by paterno asc, ApellidoMaterno asc, nombre asc; ";
            /*return "select " +
                "prestamosind.paterno, " +
                "IF(socios.Materno='','X',socios.Materno) ApellidoMaterno, " +
                "prestamosind.nombre, " +
                "DATE_FORMAT(socios.Nacimiento, '%Y%m%d') FechaNacimiento, " +
                "socios.EstadoCivil, " +
                "socios.Sexo, " +
                "CONCAT(socios.Direccion, ' ', socios.NoExterior, IF(socios.NoInterior = 0, '', CONCAT(' Número interior: ', socios.NoInterior)))  Direccion, " +
                "socios.Colonia, " +
                "localidad.Localidad, " +
                "ciudad.ciudad, " +
                "socios.codigopostal, " +
                "prestamosind.id, " +
                "prestamosind.pagos, " +
                "prestamosind.Monto " +
                "from prestamosind " +
                "left join socios on socios.id = prestamosind.Socioid " +
                "left join localidad on localidad.id = socios.localidadid " +
                "left join ciudad on ciudad.id = localidad.ciudadid " +
                "where prestamosind.id in (3608,2287,3435,1961,3462,2768,2718,2961,878,3444,2946,3291,2742,557,2914,3374,2276,3636,3254,2376,2908,867,2957,1862,2731,988) " +
                "order by paterno asc, ApellidoMaterno asc, nombre asc; ";
            return "select " +
                "prestamosind.paterno, " +
                "IF(socios.Materno='','X',socios.Materno) ApellidoMaterno, " +
                "prestamosind.nombre, " +
                "DATE_FORMAT(socios.Nacimiento, '%Y%m%d') FechaNacimiento, " +
                "socios.EstadoCivil, " +
                "socios.Sexo, " +
                "CONCAT(socios.Direccion, ' ', socios.NoExterior, IF(socios.NoInterior = 0, '', CONCAT(' Número interior: ', socios.NoInterior)))  Direccion, " +
                "socios.Colonia, " +
                "localidad.Localidad, " +
                "ciudad.ciudad, " +
                "socios.codigopostal, " +
                "prestamosind.id, " +
                "prestamosind.pagos, " +
                "prestamosind.Monto " +
                "from prestamosind " +
                "left join socios on socios.id = prestamosind.Socioid " +
                "left join localidad on localidad.id = socios.localidadid " +
                "left join ciudad on ciudad.id = localidad.ciudadid " +
                "where prestamosind.id in (3462) " +
                "order by paterno asc, ApellidoMaterno asc, nombre asc; ";*/
        }
    }
}
