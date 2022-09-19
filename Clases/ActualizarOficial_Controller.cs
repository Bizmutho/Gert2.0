using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class ActualizarOficial_Controller
    {
        Conexion con;
        public ActualizarOficial_Controller()
        {
            con = new Conexion();
        }

        public void actualizar(String cont, String IdOficial)
        {
            String[] Contratos = cont.Split("\n");
            List<(int, string)> Ids = new List<(int, string)>();

            for (int i = 0; i < Contratos.Length; i++)
            {
                try
                {
                    con.crearConexion();
                    con.OpenConnection();
                    String sql = "select id from deudaindividual where PrestamoId = "+ Contratos[i] + " and Activo = 1";

                    MySqlCommand cdm = new MySqlCommand(sql, con.GetConnection());
                    cdm.CommandTimeout = 1000000;
                    MySqlDataReader resultados = cdm.ExecuteReader();

                    while (resultados.Read())
                    {
                        Ids.Add((resultados.GetInt32(0), Contratos[i]));
                    }

                } catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                } finally
                {
                    con.CloseConnection();
                }
            }

            String query = "";

            String IdCredito = "";

            Ids.ForEach(item =>
            {
                if(!IdCredito.Equals(item.Item2))
                {
                    IdCredito = item.Item2;
                    query += "update prestamosind set OficialId = " + IdOficial + " where Id = " + IdCredito + ";\n";
                }

                query += "update deudaindividual set OficialCreditoId = " + IdOficial + " where Id = " + item.Item1 + " and PrestamoId = " + IdCredito + ";\n";
                IdCredito = item.Item2;
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
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.CloseConnection();
            }

           Console.WriteLine(query);
        }

    }
}
