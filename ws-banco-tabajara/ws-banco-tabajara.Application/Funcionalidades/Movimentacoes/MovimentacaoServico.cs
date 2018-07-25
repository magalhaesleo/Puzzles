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
        IMovimentacaoRepositorio _repositorio;

        public MovimentacaoServico(IMovimentacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Movimentacao Adicionar(Movimentacao movimentacao)
        {
            movimentacao = _repositorio.Adicionar(movimentacao);

            return movimentacao;
        }

        public IQueryable<Movimentacao> BuscarPorConta(long id)
        {
            return _repositorio.BuscarPorConta(id);
        }
    }
}
