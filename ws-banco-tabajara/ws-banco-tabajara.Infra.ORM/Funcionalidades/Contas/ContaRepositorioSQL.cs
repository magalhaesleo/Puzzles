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
            return _contextoBancoTabajara.Contas.Find(id);
        }

        public IQueryable<Conta> BuscarTodos()
        {
           return _contextoBancoTabajara.Contas;
        }

        public void Editar(Conta conta)
        {
            _contextoBancoTabajara.SaveChanges();
        }

        public void Excluir(Conta conta)
        {
            _contextoBancoTabajara.Contas.Remove(conta);

            _contextoBancoTabajara.SaveChanges();
        }
    }
}
