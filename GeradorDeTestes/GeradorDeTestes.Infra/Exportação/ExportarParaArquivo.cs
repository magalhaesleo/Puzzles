using GeradorDeTestes.Infra.CSV;
using GeradorDeTestes.Infra.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Exportação
{
    public abstract class ExportarParaArquivo<T>
    {
        public abstract void ObjetoParaCSV(T objeto, string path);

       // public abstract void ObjetoParaPDF(T objeto, string path);

        protected virtual void ObjetoParaXML(T objeto, string path)
        {
            XMLExtension.Serialize(objeto, path);
        }
    }
}
