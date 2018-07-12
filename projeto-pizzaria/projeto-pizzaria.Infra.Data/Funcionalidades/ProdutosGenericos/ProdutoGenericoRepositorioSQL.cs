using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Interfaces.ProdutosGenericos;
using projeto_pizzaria.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.ProdutosGenericos
{
    public class ProdutoGenericoRepositorioSQL : IProdutoGenericoRepositorio
    {
        private PizzariaContexto _pizzariaContexto;
        public ProdutoGenericoRepositorioSQL(PizzariaContexto pizzariaContexto)
        {
            _pizzariaContexto = pizzariaContexto;
        }
        public long Adicionar(ProdutoGenerico entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoGenerico> BuscarTodos<T>() where T : ProdutoGenerico
        {
            IEnumerable<ProdutoGenerico> produtosGenericos = _pizzariaContexto.ProdutosGenericos.OfType<T>();

            return produtosGenericos;
        }

        public List<ProdutoGenerico> BuscarTodos()
        {
            List<ProdutoGenerico> produtosGenericos = _pizzariaContexto.ProdutosGenericos.ToList();

            return produtosGenericos;
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
