using Modulos.Clases;
using Modulos.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Credito.clases
{
    public class Captura_Contrato_Controller
    {
        Conexion con;
        public Captura_Contrato_Controller()
        {
            con = new Conexion();
        }

        public List<(int, string)> listas(string lista, string filtro)
        {
            List<(int, string)> list = new List<(int, string)>();
            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand slqC = new MySqlCommand("call " + lista + "(" + filtro + ");", con.GetConnection());
                slqC.CommandTimeout = 100000;
                MySqlDataReader dataR = slqC.ExecuteReader();

                if (dataR.HasRows)
                {
                    while (dataR.Read())
                    {
                        list.Add((dataR.GetInt32(0), dataR.GetString(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la lista (" + lista + "): " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }

            return list;
        }

        public void informacionSocio(int id)
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand sqlC = new MySqlCommand("call informacionSocio(" + id + ");", con.GetConnection());
                sqlC.CommandTimeout = 100000;
                MySqlDataReader dataR = sqlC.ExecuteReader();

                if (dataR.HasRows)
                {
                    while (dataR.Read())
                    {
                        CreditoInfo.Nombres = dataR.GetString(1);
                        CreditoInfo.Paterno = dataR.GetString(2);
                        CreditoInfo.Materno = dataR.GetString(3);
                        CreditoInfo.FcaNac = dataR.GetDateTime(4);
                        CreditoInfo.Sexo = dataR.GetInt32(5);
                        CreditoInfo.Curp = dataR.GetString(6);
                        CreditoInfo.RFC = dataR.GetString(7);
                        CreditoInfo.INE = dataR.GetString(8);
                        CreditoInfo.Telefono = dataR.GetString(9);
                        CreditoInfo.Celular = dataR.GetString(10);
                        CreditoInfo.PaisNac = dataR.GetInt32(11);
                        CreditoInfo.EstadoNac = dataR.GetInt32(12);
                        CreditoInfo.MunicipioNac = dataR.GetInt32(13);
                        CreditoInfo.LocalidadNac = dataR.GetInt32(14);
                        CreditoInfo.EstadoCivil = dataR.GetInt32(15);
                        CreditoInfo.Correo = dataR.GetString(16);
                        CreditoInfo.Pais = dataR.GetInt32(17);
                        CreditoInfo.Estado = dataR.GetInt32(18);
                        CreditoInfo.Municipio = dataR.GetInt32(19);
                        CreditoInfo.Localidad = dataR.GetInt32(20);
                        CreditoInfo.Colonia = dataR.GetString(21);
                        CreditoInfo.Direccion = dataR.GetString(22);
                        CreditoInfo.NoInterior = dataR.GetString(23);
                        CreditoInfo.NoExterior = dataR.GetString(24);
                        CreditoInfo.CodigoPostal = dataR.GetString(25);
                        CreditoInfo.Estudios = dataR.GetInt32(26);
                        CreditoInfo.Actividades = dataR.GetInt32(27);
                        CreditoInfo.DescripcionActividad = dataR.GetString(28);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener informacion de socio: " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public bool insertarPrestamo_Persona()
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand(queryCreditoPersona(), con.GetConnection());

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener informacion de socio: " + ex.Message);
                return false;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public bool insertarPrestamo()
        {
            try
            {
                con.crearConexion();
                con.OpenConnection();

                MySqlCommand command = new MySqlCommand(queryCredito(), con.GetConnection());

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener informacion de socio: " + ex.Message);
                return false;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public string queryCreditoPersona()
        {
            string query = "";
            query = "" +
                "call insertarPrestamo_Persona( " +
                     StorageClass.getId() + ", '" +
                     CreditoInfo.Nombres + "', '" +
                     CreditoInfo.Paterno + "', '" +
                     CreditoInfo.Materno + "', '" +
                     CreditoInfo.FcaNac.Year + "-" + CreditoInfo.FcaNac.Month.ToString("00") + "-" + CreditoInfo.FcaNac.Day.ToString("00") + "', " +
                     CreditoInfo.Sexo + ", '" +
                     CreditoInfo.Curp + "', '" +
                     CreditoInfo.RFC + "', " +
                     CreditoInfo.LocalidadNac + ", '" +
                     CreditoInfo.Telefono + "', '" +
                     CreditoInfo.Celular + "', '" +
                     CreditoInfo.INE + "', '" +
                     CreditoInfo.Direccion + "', '" +
                     CreditoInfo.Colonia + "', '" +
                     CreditoInfo.CodigoPostal + "', '" +
                     CreditoInfo.NoExterior + "', '" +
                     CreditoInfo.NoInterior + "', '" +
                     CreditoInfo.Correo + "', " +
                     CreditoInfo.Localidad + ", " +
                     CreditoInfo.Estudios + ", " +
                     CreditoInfo.Actividades + ", '" +
                     CreditoInfo.DescripcionActividad + "', " +
                     CreditoInfo.EstadoCivil + ", " +
                     CreditoInfo.Oficial + ", " +
                     CreditoInfo.Monto + ", " +
                     CreditoInfo.Pagos + ", " +
                     CreditoInfo.IVA + ", " +
                     CreditoInfo.Tasa + ", '" +
                     CreditoInfo.FcaInicio.Year + "-" + CreditoInfo.FcaInicio.Month.ToString("00") + "-" + CreditoInfo.FcaInicio.Day.ToString("00") + "', " +
                     CreditoInfo.Fondeador + ", '" +
                     CreditoInfo.Aval1Nombre + "', '" +
                     CreditoInfo.Aval1Direccion + "', '" +
                     CreditoInfo.Aval1Telefono + "', '" +
                     CreditoInfo.Aval1INE + "', ";

            if (!CreditoInfo.Aval2Nombre.Equals("NULL"))
            {
                query += "'" +
                     CreditoInfo.Aval2Nombre + "', '" +
                     CreditoInfo.Aval2Direccion + "', '" +
                     CreditoInfo.Aval2Telefono + "', '" +
                     CreditoInfo.Aval2INE + "');";
            }
            else
            {
                query += " NULL, NULL, NULL, NULL);";
            }

            return query;
        }


        public string queryCredito()
        {
            string query = "";
            query = "" +
                "call insertarPrestamo( " +
                1 + ", " +
                CreditoInfo.idSocio + ", " +
                CreditoInfo.Oficial + ", " +
                CreditoInfo.Monto + ", " +
                CreditoInfo.Pagos + ", " +
                CreditoInfo.IVA + ", " +
                CreditoInfo.Tasa + ", '" +
                CreditoInfo.FcaInicio.Year + "-" + CreditoInfo.FcaInicio.Month.ToString("00") + "-" + CreditoInfo.FcaInicio.Day.ToString("00") + "', " +
                CreditoInfo.Fondeador + ", '" +
                CreditoInfo.Aval1Nombre + "', '" +
                CreditoInfo.Aval1Direccion + "', '" +
                CreditoInfo.Aval1Telefono + "', '" +
                CreditoInfo.Aval1INE + "', ";

            if (!CreditoInfo.Aval2Nombre.Equals("NULL"))
            {
                query += "'" +
                     CreditoInfo.Aval2Nombre + "', '" +
                     CreditoInfo.Aval2Direccion + "', '" +
                     CreditoInfo.Aval2Telefono + "', '" +
                     CreditoInfo.Aval2INE + "');";
            }
            else
            {
                query += " NULL, NULL, NULL, NULL);";
            }

            return query;
        }
    }
}
