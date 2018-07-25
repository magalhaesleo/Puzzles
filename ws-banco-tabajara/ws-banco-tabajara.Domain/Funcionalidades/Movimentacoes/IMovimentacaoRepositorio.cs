using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Interfaces;

namespace ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes
{
    public interface IMovimentacaoRepositorio
    {
        Movimentacao Adicionar(Movimentacao movimentacao);
        IQueryable<Movimentacao> BuscarPorConta(long id);
    }
}
