using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Clases
{
    public static class StorageClass
    {
        static int idS;
        static int idC;
        static String banco;
        static DateTime fDeposito;
        static String Folio;
        static float monto;
        static float montoMora;
        static List<string> Oficiales = new List<string>();
        static List<int> OficialesId = new List<int>();
        static bool Mora;
        static List<(int, bool)> idsDeuda = new List<(int, bool)>();
        static List<int> ids = new List<int> ();
        public static DateTime contpaqIni { get; set; }
        public static DateTime contpaqFin { get; set; }
        public static DataTable contpaqData { get; set; }
        public static DataTable contpaqTotal { get; set; }

        public static int cancelar { get; set; }
        public static float capitalMonto { get; set; }
        public static float canPagos { get; set; }
        public static bool validacion { get; set; } = false;

        public static String Oficial { get; set; } = "";
        public static double Monto { get; set; } = 0;
        public static int nPagos { get; set; }
        public static int nPagosCub { get; set; }

        public static float saldoVencido { get; set; } = 0;

        public static float liquida { get; set; } = 0;

        public static float pagado { get; set; } = 0;


        public static void setIdsDeuda(List<(int, bool)> l)
        {
            idsDeuda = l;
        }

        public static List<(int, bool)> getIdsDeuda()
        {
            return idsDeuda;
        }
        public static void setIds(List<int> l)
        {
            ids = l;
        }

        public static List<int> getIds()
        {
            return ids;
        }

        public static void setId(int id)
        {
            idS = id;
        }

        public static int getId()
        {
            return idS;
        }

        public static void setIdC(int id)
        {
            idC = id;
        }

        public static int getIdC()
        {
            return idC;
        }

        public static void setBanco(String b)
        {
            banco = b;
        }

        public static String getBanco()
        {
            return banco;
        }
        public static void setFDeposito(DateTime dt)
        {
            fDeposito = dt;
        }

        public static DateTime getFDeposito()
        {
            return fDeposito;
        }

        public static void setFolio(String f)
        {
            Folio = f;
        }

        public static String getFolio()
        {
            return Folio;
        }

        public static void setMonto(float m)
        {
            monto = m;
        }

        public static float getMonto()
        {
            return monto;
        }

        public static void setMontoMora(float m)
        {
            montoMora = m;
        }

        public static float getMontoMora()
        {
            return montoMora;
        }

        public static void setMora(bool m)
        {
            Mora = m;
        }

        public static bool getMora()
        {
            return Mora;
        }

        public static double contpaqAbono { get; set; }
        public static double contpaqCargo { get; set; }
    }
}
