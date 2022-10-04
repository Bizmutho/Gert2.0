using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public class EstatusJuridico_Controller
    {
        Conexion con, conES;
        public EstatusJuridico_Controller ()
        {
            con = new Conexion();
            conES = new Conexion();
        }


        public List<(int, string)>LawyerList ()
        {
            con.crearConexion();
            con.OpenConnection();
            String sql = "select Id, concat(Nombre, ' ', Paterno, ' ', Materno) Nombre from abogados";
            List<(int, string)> lawyer = new List<(int, string)>();

            try
            {
                MySqlCommand cdm = new MySqlCommand(sql, con.GetConnection());
                cdm.CommandTimeout = 1000000;
                MySqlDataReader resultados = cdm.ExecuteReader();

                while (resultados.Read())
                {
                    lawyer.Add((resultados.GetInt32(0), resultados.GetString(1)));
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error al extraer datos de abogados "+ex);
            }
            finally { con.CloseConnection(); }

            return lawyer;
            
        }

        public DataView procesList (int oficial)
        {
            int credito;
            DateTime fechaof;
            string empresa;
            string socio;
            string municipio;
            string of;
            DateTime inicioCred;
            float totalDemanda;
            string abogado;
            string status;

            DataTable dtm = new DataTable();
            dtm.Columns.Add("CREDITO");
            dtm.Columns.Add("FECHA OFICIO");
            dtm.Columns.Add("EMPRESA");
            dtm.Columns.Add("SOCIO");
            dtm.Columns.Add("MUNICIPIO");
            dtm.Columns.Add("OFICIAL");
            dtm.Columns.Add("INICIO CREDITO");
            dtm.Columns.Add("TOTAL DEMANDA");
            dtm.Columns.Add("ABOGADO");
            dtm.Columns.Add("ESTATUS");

            try
            {
                con.crearConexion();
                con.OpenConnection();
                String sql = "select pr.Id, ej.FechaOficio, 'GERT' Empresa," +  
                    "concat(sc.Nombre, ' ', sc.Paterno, ' ', sc.Materno) Socio, cd.Ciudad,"+ 
                    "concat(pe.Nombre, ' ', pe.Paterno, ' ', pe.Materno) Oficial, "+
                    "pr.FechaI, ej.TotalDemanda, concat(ab.Nombre, ' ', ab.Paterno, ' ', ab.Materno) Abogado, ej.Estatus " +
                    "from estatus_juridico as ej " +
                    "inner join prestamosind as pr on ej.IdPrestamo = pr.Id " +
                    "inner join socios as sc on pr.SocioId = sc.Id "+
                    "inner join localidad as lc on sc.LocalidadId = lc.Id "+
                    "inner join ciudad as cd on lc.CiudadId = cd.Id "+
                    "inner join personal as pe on pr.OficialId = pe.Id "+
                    "inner join abogados as ab on estatus_juridico.Abogado = abogados.Id where ej.Abogado = " + oficial.ToString();
                MySqlCommand cdm = new MySqlCommand(sql, con.GetConnection());
                cdm.CommandTimeout = 1000000;
                MySqlDataReader resultados = cdm.ExecuteReader();

                while (resultados.Read())
                {
                    credito = resultados.GetInt32(0);
                    fechaof = resultados.GetDateTime(1);
                    empresa = resultados.GetString(2);
                    socio = resultados.GetString(3);
                    municipio = resultados.GetString(4);
                    of = resultados.GetString(5);
                    inicioCred = resultados.GetDateTime(6);
                    totalDemanda = resultados.GetFloat(7);
                    abogado = resultados.GetString(8);
                    status = resultados.GetString(9);

                    dtm.Rows.Add(credito.ToString(), fechaof.ToShortDateString(), empresa, socio, municipio, of, inicioCred.ToShortDateString(), totalDemanda.ToString(), abogado, status);
                }
            } catch (System.Exception ex)
            {

            }
            finally { conES.CloseConnection();}
            return new DataView(dtm);

        }
    }
}
