using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Base;

namespace ws_banco_tabajara.Application.Interfaces
{
    public interface IServico<T>  where T:Entidade
    {
        T Adicionar(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);
        IQueryable<T> BuscarTodos();
        T Buscar(long id);
    }
}
