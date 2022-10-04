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
           ini.Show();

           //var ini = new ActualizarOficial();
           //ini.Show();

            Application.Run();
        }
    }
}