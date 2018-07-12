using projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Interfaces.Sabores
{
    public interface ISaborRepositorio : IRepositorio<Sabor>
    {
        IEnumerable<Sabor> BuscarTodosSaboresCalzone();
        IEnumerable<Sabor> BuscarTodosSaboresPizza();
    }
}
