using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Application.Funcionalidades.Movimentacoes
{
    public interface IMovimentacaoServico
    {
        Movimentacao Adicionar(Movimentacao entidade);
        IQueryable<Movimentacao> BuscarPorConta(long id);

    }
}
