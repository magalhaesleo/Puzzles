using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais
{
    public class ProdutoNotaFiscal : Entidade
    {
        public Produto Produto { get; set; }

        public NotaFiscal NotaFiscal { get; set; }

        public int Quantidade { get; set; }

        public double ValorTotal { get { return Produto.Valor * Quantidade; } }

        public double ValorICMS { get { return Produto.AliquotaICMS * ValorTotal; } }

        public double ValorIPI { get { return Produto.AliquotaIPI * ValorTotal; } }

        public ProdutoNotaFiscal(NotaFiscal notaFiscal, Produto produto, int quantidadeProduto)
        {
            NotaFiscal = notaFiscal;
            Produto = produto;
            Quantidade = quantidadeProduto;
        }

        public ProdutoNotaFiscal()
        {

        }

        public void Validar()
        {
            if (Produto == null)
                throw new ExcecaoProdutoNotaFiscalSemProduto();


            if (NotaFiscal == null)
                throw new ExcecaoProdutoNotaFiscalSemNotaFiscal();


            if (Quantidade < 1)
                throw new ExcecaoProdutoNotaFiscalComQuantidadeInferiorAum();

                
        }
    }
}
