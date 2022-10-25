using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class Login_Controller
    {
        Conexion con;

       


        public Login_Controller()
        {
            con = new Conexion();
        }

        public int iniciarSesion(String usuario, String contra)
        {

            try
            {
                con.crearConexion();
                con.OpenConnection();

                String query = "select id from usuarios where Usuario = '" + usuario + "' and Contrasena = '" + Ofuscar.Encriptar(contra) + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.GetConnection());
                cmd.CommandTimeout = 1000000;
                MySqlDataReader resultados = cmd.ExecuteReader();

                if (resultados.HasRows)
                {
                    while (resultados.Read())
                    {
                        StorageClass.setId(resultados.GetInt32(0));
                    }
                    return 1;
                }
            } catch(Exception ex)
            {
                Console.WriteLine("La base de datos se la cargo el payaso");
                return 3;
            }
            return 2;
        }
    }
}
