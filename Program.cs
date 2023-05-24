using Modulos.Clases;
using Moratorios;

namespace Modulos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
           var ini = new Login();

            //var ini = new ActualizarOficial();

            //var ini = new Captura();


            ini.Show();

            Application.Run();
        }
    }
}