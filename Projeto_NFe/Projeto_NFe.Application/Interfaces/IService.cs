using Projeto_NFe.Domain.Funcionalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Interfaces
{
    public interface IService<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        void Excluir(T entidade);
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(long id);
    }
}
