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
            Dictionary<int, Modelos.ContpaqDeposito> depDesgloce = new Dictionary<int, Modelos.ContpaqDeposito>();
            
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
                        Modelos.ContpaqDeposito dep = new Modelos.ContpaqDeposito();

                        dep.idDeposito = data.GetInt32(0);
                        dep.idPrestamo = data.GetInt32(1);
                        dep.socio = data.GetString(2);
                        dep.oficial = data.GetString(3);

                        depDesgloce.Add(data.GetInt32(0), dep);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine($"Error obteniendo los depositos: {e}");
            } finally
            {
                con.CloseConnection();
            }

            if (depDesgloce.Count != 0)
            {
                for (int i = 0; i < depDesgloce.Count; i++)
                {
                    
                }
            }
        }

        public String queryCreditos(DateTime ini, DateTime fin)
        {
            String query = "select " +
                "pi.id as pId, di.id as dId, concat(pi.Nombre, ' ', pi.Paterno, ' ', pi.Materno) as socio, concat(p.Nombre, ' ', p.Paterno, ' ', p.Materno) as oficial " +
                "from depositoind di left join prestamosind pi on pi.id = di.prestamoid left join personal p on p.id = pi.OficialId " +
                $"where pi.Activo = 1 and di.Activo = 1 and DiaDeposito between '{ini.Year}-{ini.Month.ToString("00")}-{ini.Day.ToString("00")}' and '{fin.Year}-{fin.Month.ToString("00")}-{fin.Day.ToString("00")}'";
            Console.WriteLine(query);
            return query;
        }
    }
}
