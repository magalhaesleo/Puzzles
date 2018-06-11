using Projeto_NFe.Application.Interfaces;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Notas_Fiscais
{
    public interface INotaFiscalServico : IServico<NotaFiscal>
    {
        bool ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso);

        NotaFiscal Emitir(NotaFiscal notaFiscal);

        NotaFiscal BuscarNotaFiscalEmitidaPorChave(string chaveDeAcesso);
    }
}
