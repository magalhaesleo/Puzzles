using Projeto_NFe.Domain.Funcionalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Interfaces
{
    public interface IRepositorio<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        void Excluir(T entidade);
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(long Id);

    }
}
