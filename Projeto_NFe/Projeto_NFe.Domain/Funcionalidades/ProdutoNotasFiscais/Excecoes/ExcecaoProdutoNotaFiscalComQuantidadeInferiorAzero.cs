using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes
{
    public class ExcecaoProdutoNotaFiscalComQuantidadeInferiorAum : ExcecaoDeNegocio
    {
        public ExcecaoProdutoNotaFiscalComQuantidadeInferiorAum() : base("A quantidade de produtos no produto nota fiscal deve ser maior que 0")
        {
        }
    }
}
