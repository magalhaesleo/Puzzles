using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Application.Funcionalidades.Movimentacoes
{
    public class MovimentacaoServico : IMovimentacaoServico
    {
        public Movimentacao Adicionar(Movimentacao entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Movimentacao> BuscarPorConta(long id)
        {
            throw new NotImplementedException();
        }
    }
}
