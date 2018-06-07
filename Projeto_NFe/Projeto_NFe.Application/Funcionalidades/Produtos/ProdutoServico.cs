using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produto;
using Projeto_NFe.Domain.Funcionalidades.Produtos;

namespace Projeto_NFe.Application.Funcionalidades.Produtos
{
    public class ProdutoServico : IProdutoServico
    {
        private IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            this._produtoRepositorio = produtoRepositorio;
        }

        public Produto Adicionar(Produto produto)
        {
            produto.Validar();

            return _produtoRepositorio.Adicionar(produto);
        }

        public Produto Atualizar(Produto produto)
        {
            if (produto.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            produto.Validar();

           return _produtoRepositorio.Atualizar(produto);
        }

        public Produto BuscarPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            return _produtoRepositorio.BuscarPorId(id);
        }

        public IEnumerable<Produto> BuscarTodos()
        {
           return _produtoRepositorio.BuscarTodos();
        }

        public void Excluir(Produto produto)
        {
            if (produto.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            _produtoRepositorio.Excluir(produto);
        }
    }
}
