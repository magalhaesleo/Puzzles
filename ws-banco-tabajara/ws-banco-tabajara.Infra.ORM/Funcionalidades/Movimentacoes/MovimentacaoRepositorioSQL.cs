using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Contextos;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Movimentacoes
{
    public class MovimentacaoRepositorioSQL : IMovimentacaoRepositorio
    {
        private ContextoBancoTabajara _contextoBancoTabajara;

        public MovimentacaoRepositorioSQL(ContextoBancoTabajara contextoBancoTabajara)
        {
            _contextoBancoTabajara = contextoBancoTabajara;
        }

        public Movimentacao Adicionar(Movimentacao movimentacao)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Movimentacao> BuscarPorConta(long id)
        {
            throw new NotImplementedException();
        }
    }
}
