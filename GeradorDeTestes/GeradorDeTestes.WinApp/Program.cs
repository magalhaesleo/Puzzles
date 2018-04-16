using GeradorDeTestes.Domain.Interfaces.Alternativas;
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

            Type tipoRepositorio = typeof(IAlternativaRepository);
            Console.WriteLine(tipoRepositorio.Name);
            switch (tipoRepositorio.Name)
            {
                case "IAlternativaRepository":
                    Console.WriteLine("DEU BOA");
                    break;
            }


            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
           Principal formularioPrincipal = new Principal();
           System.Windows.Forms.Application.EnableVisualStyles();
           ControleDeReferencia.ReferenciaFormularioPrincipal = formularioPrincipal;
           System.Windows.Forms.Application.Run(formularioPrincipal);

            
            
        }
    }
}
