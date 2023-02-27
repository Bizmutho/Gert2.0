using DocumentFormat.OpenXml.Drawing.Diagrams;
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

        public void updateJuridico(string f, string d, string s, string p, string o)
        {
            con.crearConexion();
            con.OpenConnection();
            float a = float.Parse(p);
            Console.WriteLine("valor de a: "+a);
            String sql = "update estatus_juridico set FechaOficio='"+f+"' , TotalDemanda="+a+" , Estatus = '"+s+"' , Observacion = '"+o+"'  where IdPrestamo ="+p;

            try
            {

                MySqlCommand cdm = new MySqlCommand(sql, con.GetConnection());
                if (cdm.ExecuteNonQuery() != -1)
                {
                    MessageBox.Show("Modificación exitosa");
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                MessageBox.Show(e.ToString());
            }
            finally { con.CloseConnection(); }
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
            string obs;
            string direccion;

            DataTable dtm = new DataTable();
            dtm.Columns.Add("CREDITO");
            dtm.Columns.Add("FECHA OFICIO");
            dtm.Columns.Add("EMPRESA");
            dtm.Columns.Add("SOCIO");
            dtm.Columns.Add("MUNICIPIO");
            dtm.Columns.Add("DIRECCION");
            dtm.Columns.Add("OFICIAL");
            dtm.Columns.Add("INICIO CREDITO");
            dtm.Columns.Add("TOTAL DEMANDA");
            dtm.Columns.Add("ABOGADO");
            dtm.Columns.Add("ESTATUS");
            dtm.Columns.Add("OBSERVACIONES");

            try
            {
                con.crearConexion();
                con.OpenConnection();
                String sql = "select pr.Id, ej.FechaOficio, 'GERT' Empresa," +  
                    "concat(sc.Nombre, ' ', sc.Paterno, ' ', sc.Materno) Socio, cd.Ciudad,"+ 
                    "concat(pe.Nombre, ' ', pe.Paterno, ' ', pe.Materno) Oficial, "+
                    "pr.FechaI, ej.TotalDemanda, concat(ab.Nombre, ' ', ab.Paterno, ' ', ab.Materno) Abogado, ej.Estatus, ej.Observacion, " +
                    "concat(sc.Direccion, ', ', sc.Colonia, ', c.p. ', sc.CodigoPostal, ', nInt. ', sc.NoInterior, ', nExt. ', sc.NoExterior) as Direccion "+
                    "from estatus_juridico as ej " +
                    "inner join prestamosind as pr on ej.IdPrestamo = pr.Id " +
                    "inner join socios as sc on pr.SocioId = sc.Id "+
                    "inner join localidad as lc on sc.LocalidadId = lc.Id "+
                    "inner join ciudad as cd on lc.CiudadId = cd.Id "+
                    "inner join personal as pe on pr.OficialId = pe.Id "+
                    "inner join abogados as ab on ej.Abogado = ab.Id where ej.Activo = 1 and ej.Abogado = " + oficial.ToString();
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
                    obs = resultados.GetString(10);
                    direccion = resultados.GetString(11);
                    dtm.Rows.Add(credito.ToString(), fechaof.ToShortDateString(), empresa, socio, municipio, direccion, of, inicioCred.ToShortDateString(), totalDemanda.ToString("C"), abogado, status, obs);
                }
            } catch (System.Exception ex)
            {
                Console.WriteLine("Error: "+ex);
                MessageBox.Show(ex.ToString());
            }
            finally { conES.CloseConnection();}
            return new DataView(dtm);

        }
    }
}
