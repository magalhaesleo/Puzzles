using projeto_pizzaria.Applications.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Applications.Funcionalidades.ProdutosGenericos.Interfaces
{
    public interface IProdutoGenericoServico : IServico<ProdutoGenerico>
    {
        IEnumerable<T> BuscarTodos<T>() where T : ProdutoGenerico;
    }
}
