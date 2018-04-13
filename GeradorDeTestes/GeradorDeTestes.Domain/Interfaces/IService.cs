using GeradorDeTestes.Domain.Abstract_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Interfaces
{
     public interface IService<T> where T : Entidade
    {
        int Adicionar(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);
        List<T> GetAll();
    }
}
