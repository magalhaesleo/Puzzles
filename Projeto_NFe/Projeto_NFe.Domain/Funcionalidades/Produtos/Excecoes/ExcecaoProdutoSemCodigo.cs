using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Produtos.Excecoes
{
    public class ExcecaoProdutoSemCodigo : ExcecaoDeNegocio
    {
        public ExcecaoProdutoSemCodigo() : base("O produto deve conter um código")
        {
        }
    }
}
