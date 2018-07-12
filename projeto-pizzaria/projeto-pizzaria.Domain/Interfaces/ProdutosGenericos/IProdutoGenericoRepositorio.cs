using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Interfaces.ProdutosGenericos
{
    public interface IProdutoGenericoRepositorio : IRepositorio<ProdutoGenerico>
    {
        IEnumerable<ProdutoGenerico> BuscarTodos<T>() where T : ProdutoGenerico;
    }
}
