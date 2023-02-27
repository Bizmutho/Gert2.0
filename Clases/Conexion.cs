using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos
{
    public class Conexion
    {
        private MySqlConnection connection;
        //private string server = "127.0.0.1";
        private string server = "SERVERI";
        private string database = "emprendedor";
        private string uid = "SICartera";
        private string password = "cartera1";

        public Conexion()
        {
            crearConexion();
        }

        public void crearConexion()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public string OpenConnection()
        {
            try
            {
                connection.Open();
                return "conectado";
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        return "No se encuentra el servidor, revise con su administrador";

                    case 1045:
                        return "Sus credenciales son incorrectas";
                }
                return "Sus credenciales son incorrectas";
            }
        }

        public string CloseConnection()
        {
            try
            {
                connection.Close();
                return "Cerrada";
            }
            catch (MySqlException ex)
            {
                return "Error al cerrar la conexión : " + ex.Message;
            }

        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
