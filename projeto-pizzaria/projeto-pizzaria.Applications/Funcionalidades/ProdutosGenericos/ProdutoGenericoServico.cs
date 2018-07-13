using projeto_pizzaria.Applications.Funcionalidades.ProdutosGenericos.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Interfaces.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Applications.Funcionalidades.ProdutosGenericos
{
    public class ProdutoGenericoServico : IProdutoGenericoServico
    {
        private IProdutoGenericoRepositorio _produtoGenericoRepositorio;

        public ProdutoGenericoServico(IProdutoGenericoRepositorio produtoGenericoRepositorio)
        {
            _produtoGenericoRepositorio = produtoGenericoRepositorio;
        }

        public long Adicionar(ProdutoGenerico entidade)
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

        public IEnumerable<ProdutoGenerico> BuscarTodos()
        {
            return _produtoGenericoRepositorio.BuscarTodos();
        }

        public IEnumerable<ProdutoGenerico> BuscarTodos<T>() where T : ProdutoGenerico
        {
            return _produtoGenericoRepositorio.BuscarTodos<T>();
        }
    }
}
