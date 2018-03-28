using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp
{
    public static class ControleDeReferencia
    {
      public static Principal ReferenciaFormularioPrincipal { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Principal formularioPrincipal = new Principal();
            Application.EnableVisualStyles();
            ControleDeReferencia.ReferenciaFormularioPrincipal = formularioPrincipal;
            Application.Run(formularioPrincipal);

            
            
        }
    }
}
