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
        public abstract void GerarCSV(T objeto, string path);


        public virtual void GerarXML(T objeto, string path)
        {
            XMLExtension.Serialize(objeto, path);
        }
    }
}
