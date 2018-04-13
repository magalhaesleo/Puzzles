using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Exportação
{
    public class ExportarTesteParaArquivo : ExportarParaArquivo<Teste>
    {
        
        public void TesteParaCSV(Teste teste)
        {
            this.ObjetoParaCSV(teste);
        }

        public void TesteParaXML(Teste teste)
        {
            this.ObjetoParaXML(teste);
        }

    }
}
