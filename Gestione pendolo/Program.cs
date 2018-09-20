using System;
using System.Windows.Forms;

namespace EmiSan1998.CronoSystem.Gestione_pendolo
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principale());
        }
    }
}
