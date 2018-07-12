using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using projeto_pizzaria.Domain.Interfaces.Sabores;
using projeto_pizzaria.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Sabores
{
    public class SaborRepositorioSQL : ISaborRepositorio
    {
        PizzariaContexto _pizzariaContexto;

        public SaborRepositorioSQL(PizzariaContexto pizzariaContexto)
        {
            _pizzariaContexto = pizzariaContexto;
        }

        public long Adicionar(Sabor sabor)
        {
            throw new NotImplementedException();
        }

        public void Editar(Sabor sabor)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Sabor sabor)
        {
            throw new NotImplementedException();
        }

        public List<Sabor> BuscarTodos()
        {
            return _pizzariaContexto.Sabores.ToList();
        }

        public IEnumerable<Sabor> BuscarTodosSaboresCalzone()
        {
            IEnumerable<Sabor> saboresCalzone = BuscarTodos().Where(b => b.ValorCalzone != 0);

            return saboresCalzone;
        }

        public IEnumerable<Sabor> BuscarTodosSaboresPizza()
        {
            IEnumerable<Sabor> saboresPizza = BuscarTodos().Where(b => b.ValorPequena != 0);

            return saboresPizza;
        }
    }
}
