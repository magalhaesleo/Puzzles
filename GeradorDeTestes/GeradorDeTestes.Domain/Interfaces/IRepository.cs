using GeradorDeTestes.Domain.Abstract_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Interfaces
{
    public interface IRepository<T> where T : Entidade
    {
        int Add(T entidade);
        void Excluir(T entidade);
        void Editar(T entidade);
        List<T> GetAll();

    }
}
