using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes
{
    public class ExcecaoProdutoNotaFiscalSemNotaFiscal : ExcecaoDeNegocio
    {
        public ExcecaoProdutoNotaFiscalSemNotaFiscal() : base("Para criar uma produto nota fiscal é necessário vincular uma nota fiscal")
        {
        }
    }
}
