using GeradorDeTestes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Application.IoC
{
    public static class IOCGerarPDF
    {
        #region atributos e parâmetros para PDF
        private static GeraPDF _gerarPDF;

        public static GeraPDF GeraPDF
        {
            get
            {
                if (_gerarPDF == null)
                {
                    return _gerarPDF = new GeraPDF();
                }
                else
                {
                    return _gerarPDF;
                }
            }
        }
        #endregion

    }
}
