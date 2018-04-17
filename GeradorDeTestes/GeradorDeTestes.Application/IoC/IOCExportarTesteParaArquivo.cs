using GeradorDeTestes.Infra.Exportação;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Application.IoC
{
    public static class IOCExportarTesteParaArquivo
    {

        private static ExportarTesteParaArquivo _exportarTeste;

        public static ExportarTesteParaArquivo ExportarTeste
        {
            get
            {
                if (_exportarTeste == null)
                {
                    _exportarTeste = new ExportarTesteParaArquivo();
                }
                return _exportarTeste;
            }
        }
    }
}
