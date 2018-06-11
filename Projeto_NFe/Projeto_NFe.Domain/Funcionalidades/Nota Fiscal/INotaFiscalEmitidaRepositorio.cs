using Projeto_NFe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal
{
    public interface INotaFiscalEmitidaRepositorio : IRepositorio<NotaFiscal>
    {
        int ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso);

        NotaFiscal BuscarNotaFiscalEmitidaPorChave(string chaveDeAcesso);
    }
}
