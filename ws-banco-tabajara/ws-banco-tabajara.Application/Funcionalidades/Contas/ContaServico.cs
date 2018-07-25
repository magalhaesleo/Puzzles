using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Application.Funcionalidades.Contas
{
    public class ContaServico : IContaServico
    {
        private IContaRepositorio _contaRepositorio;
        public ContaServico(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }
        public Conta Adicionar(Conta conta)
        {
            Conta contaAdicionada = _contaRepositorio.Adicionar(conta);

            return contaAdicionada;
        }

        public void AlterarStatusConta(bool status)
        {
            throw new NotImplementedException();
        }

        public Conta Buscar(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Conta> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Editar(Conta entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Conta entidade)
        {
            throw new NotImplementedException();
        }
    }
}
