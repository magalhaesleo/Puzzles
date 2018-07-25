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
        public Conta Adicionar(Conta entidade)
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
