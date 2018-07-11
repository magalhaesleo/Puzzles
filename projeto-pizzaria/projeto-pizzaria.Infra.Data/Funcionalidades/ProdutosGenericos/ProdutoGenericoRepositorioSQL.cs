using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Interfaces.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.ProdutosGenericos
{
    public class ProdutoGenericoRepositorioSQL : IProdutoGenericoRepositorio
    {
        public long Adicionar(ProdutoGenerico entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoGenerico> BuscarTodos<T>() where T : ProdutoGenerico
        {
            throw new NotImplementedException();
        }

        public List<ProdutoGenerico> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Editar(ProdutoGenerico entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(ProdutoGenerico entidade)
        {
            throw new NotImplementedException();
        }
    }
}
