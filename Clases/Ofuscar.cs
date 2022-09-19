using System;

namespace Modulos.Clases
{
    public class Ofuscar
    {
        private static string patron_busqueda = "RikEdgvm5ZcjGhñ4fYVPsqKWUne6pO3oSzyÑruaNI9X01bJBC72DATxFHQw8MtLl";
        private static string Patron_encripta = "PyneÑ67zXVoSGIsUJCrWOv3Q9qhaDKZb8TH1muftAcdpigLFRNljM5E2k4B0ñYwx";
        public Ofuscar()
        {
        }

        public static string Encriptar(string cadena)
        {
            try
            {
                string str1 = "";
                int num = checked(cadena.Length - 1);
                int startIndex = 0;
                while (startIndex <= num)
                {
                    string str2 = str1;
                    string str3 = cadena.Substring(startIndex, 1);
                    ref string local1 = ref str3;
                    int length = cadena.Length;
                    ref int local2 = ref length;
                    ref int local3 = ref startIndex;
                    string str4 = Ofuscar.EncriptarCaracter(ref local1, ref local2, ref local3);
                    str1 = str2 + str4;
                    checked { ++startIndex; }
                }
                return str1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ofuscar.Ofusca: " + ex.Message);
                throw ex;
            }
        }

        private static string EncriptarCaracter(
          ref string caracter,
          ref int variable,
          ref int a_indice)
        {
            try
            {
                if (Ofuscar.patron_busqueda.IndexOf(caracter) == -1)
                    return caracter;
                int startIndex = checked(Ofuscar.patron_busqueda.IndexOf(caracter) + variable + a_indice) % Ofuscar.patron_busqueda.Length;
                return Ofuscar.Patron_encripta.Substring(startIndex, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ofuscar.OfuscarChar: " + ex.Message);
                throw ex;
            }
        }

        public static string DesEncriptar(string cadena)
        {
            try
            {
                string str1 = "";
                int num = checked(cadena.Length - 1);
                int startIndex = 0;
                while (startIndex <= num)
                {
                    string str2 = str1;
                    string str3 = cadena.Substring(startIndex, 1);
                    ref string local1 = ref str3;
                    int length = cadena.Length;
                    ref int local2 = ref length;
                    ref int local3 = ref startIndex;
                    string str4 = Ofuscar.DesEncriptarCaracter(ref local1, ref local2, ref local3);
                    str1 = str2 + str4;
                    checked { ++startIndex; }
                }
                return str1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ofuscar.DOfuscar: " + ex.Message);
                throw ex;
            }
        }

        private static string DesEncriptarCaracter(
          ref string caracter,
          ref int variable,
          ref int a_indice)
        {
            try
            {
                if (Ofuscar.Patron_encripta.IndexOf(caracter) == -1)
                    return caracter;
                int startIndex = (checked(Ofuscar.Patron_encripta.IndexOf(caracter) - variable - a_indice) <= 0 ? checked(Ofuscar.patron_busqueda.Length + unchecked(checked(Ofuscar.Patron_encripta.IndexOf(caracter) - variable - a_indice) % Ofuscar.Patron_encripta.Length)) : checked(Ofuscar.Patron_encripta.IndexOf(caracter) - variable - a_indice) % Ofuscar.Patron_encripta.Length) % Ofuscar.Patron_encripta.Length;
                return Ofuscar.patron_busqueda.Substring(startIndex, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ofuscar.DOfuscarChar: " + ex.Message);
                throw ex;
            }
        }
    }
}
