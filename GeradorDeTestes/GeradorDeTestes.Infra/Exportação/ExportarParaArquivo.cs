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

        protected virtual void ObjetoParaCSV(T objeto)
        {
            CSVExtension.Serialize(objeto);
        }

        protected virtual void ObjetoParaXML(T objeto)
        {
            XMLExtension.Serialize(objeto);
        }
    }
}
