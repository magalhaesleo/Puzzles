using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Infra.ORM.Contextos;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas
{
    public class ContaRepositorioSQL : IContaRepositorio
    {
        private ContextoBancoTabajara _contextoBancoTabajara;
        public ContaRepositorioSQL(ContextoBancoTabajara contextoBancoTabajara)
        {
            _contextoBancoTabajara = contextoBancoTabajara;
        }
        public Conta Adicionar(Conta conta)
        {
            Conta contaAdicionada = _contextoBancoTabajara.Contas.Add(conta);
            _contextoBancoTabajara.SaveChanges();

            return contaAdicionada;
        }

        public Conta Buscar(long id)
        {
            Conta contaBuscada = _contextoBancoTabajara.Contas
                  .Include("Titular")
                  .Include("Movimentacoes")
                  .SingleOrDefault(x => x.Id == id);

            return contaBuscada;
        }

        public IQueryable<Conta> BuscarListaPorQuantidadeDefinida(int quantidade)
        {
            return _contextoBancoTabajara.Contas.Include("Titular").Include("Movimentacoes").Take(quantidade);
        }

        public Conta BuscarPorIdentificacaoDeCliente(long idCliente)
        {
            var contaBuscada = from TBCONTA in _contextoBancoTabajara.Contas where TBCONTA.Titular.Id == idCliente select TBCONTA;

            return contaBuscada;
        }

        public IQueryable<Conta> BuscarTodos()
        {
            IQueryable<Conta> contas = _contextoBancoTabajara.Contas.Include("Titular").Include("Movimentacoes");

            return contas;
        }

        public bool Editar(Conta conta)
        {
            return _contextoBancoTabajara.SaveChanges() != 0;
        }

        public bool Excluir(Conta conta)
        {
            _contextoBancoTabajara.Contas.Remove(conta);

            return _contextoBancoTabajara.SaveChanges() != 0;
        }
    }
}
