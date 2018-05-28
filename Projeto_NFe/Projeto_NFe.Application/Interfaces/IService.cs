using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Interfaces
{
    public interface IService<T>
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        T Excluir(T entidade);
        T BuscarTodos();
        T BuscarPorId(long id);
    }
}
