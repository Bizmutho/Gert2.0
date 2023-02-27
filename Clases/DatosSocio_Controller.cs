using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class DatosSocio_Controller
    {
        Conexion con;
        public DatosSocio_Controller()
        {
            con = new Conexion();
        }

        public List<(String, String)> listaSocios()
        {
            List<(String, String)> socios = new List<(String, String)> ();

            try
            {
                con.crearConexion();
                con.OpenConnection();

                String sqlCreditos = "select Id, CONCAT(Nombre, ' ', Paterno, ' ', Materno) as Socio from prestamosind where (Activo = 1 and Estatus = 0) or (Activo = 1 and Estatus = 1)";

                MySqlCommand mySqlCommand = new MySqlCommand(sqlCreditos, con.GetConnection());
                mySqlCommand.CommandTimeout = 100000;
                MySqlDataReader data = mySqlCommand.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        socios.Add((data.GetString(0),data.GetString(1).Replace("  ", " ").Trim()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error obteniendo la lista de socios: " + ex);
            }

            return socios;
        }

        public String[] datosSocio(String id)
        {
            try
            {
                String query = "select " +
                    "CONCAT(prestamosind.Nombre, ' ', prestamosind.Materno, ' ', prestamosind.Paterno) as Socio, " +
                    "socios.Telefono as TelefonoSocio, " +
                    "socios.Direccion as DireccionSocio, " +
                    "socios.Colonia as ColoniaSocio, " +
                    "socios.CodigoPostal as CPSocio, " +
                    "socios.NoExterior as NoExtSocio, " +
                    "socios.NoInterior as NoIntSocio, " +
                    "Aval1, " +
                    "A1Direccion, " +
                    "A1Colonia, " +
                    "A1Telefono," +
                    "socios.RFC " +
                    "from prestamosind " +
                    "left join socios on socios.id = prestamosind.socioid " +
                    "where prestamosind.id = " + id + ";";

                con.crearConexion();
                con.OpenConnection ();

                MySqlCommand mySqlCommand = new MySqlCommand(query, con.GetConnection());
                mySqlCommand.CommandTimeout = 100000;
                MySqlDataReader data = mySqlCommand.ExecuteReader();

                if (data.HasRows)
                {
                    String[] datosS = new String[7];
                    while (data.Read())
                    {
                        datosS[0] = ((!data.GetString(0).Equals("") || !data.GetString(0).Equals(" ")) ? data.GetString(0) : "N/A");
                        datosS[1] = ((!data.GetString(1).Equals("") || !data.GetString(1).Equals(" ")) ? data.GetString(1) : "N/A");
                        datosS[2] = ((!data.GetString(2).Equals("") || !data.GetString(2).Equals(" ")) ? data.GetString(2) : "N/A") +
                                    ", Colonia: " + ((!data.GetString(3).Equals("") || !data.GetString(3).Equals(" "))? data.GetString(3) : "N/A") +
                                    ", CP: " + ((!data.GetString(4).Equals("") || !data.GetString(4).Equals(" ")) ? data.GetString(4) : "N/A") +
                                    ", NoExt: " + ((!data.GetString(5).Equals("") || !data.GetString(5).Equals(" ")) ? data.GetString(5) : "N/A") +
                                    ", NoInt: " + ((!data.GetString(6).Equals("") || !data.GetString(6).Equals(" ")) ? data.GetString(6) : "N/A");
                        datosS[3] = ((!data.GetString(7).Equals("") || !data.GetString(7).Equals(" ")) ? data.GetString(7) : "N/A");
                        datosS[4] = ((!data.GetString(10).Equals("") || !data.GetString(10).Equals(" ")) ? data.GetString(10) : "N/A");
                        datosS[5] = ((!data.GetString(8).Equals("") || !data.GetString(8).Equals(" ")) ? data.GetString(8) : "N/A") + ", Colonia: " + ((!data.GetString(9).Equals("") || !data.GetString(9).Equals(" ")) ? data.GetString(9) : "N/A");
                        datosS[6] = ((!data.GetString(11).Equals("") || !data.GetString(11).Equals(" ")) ? data.GetString(11) : "N/A");
                    }
                    return datosS;
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error obteniendo la informacion del socio :" + ex);
            }

            return null;
        }

    }
}
