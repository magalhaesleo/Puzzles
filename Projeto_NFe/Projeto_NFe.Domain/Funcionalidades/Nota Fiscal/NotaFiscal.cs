using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscal : Entidade
    {
        public Transportador Transportador { get; set; }
        public Destinatario Destinatario { get; set; }
        public Emitente Emitente { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataEmissao { get; set; }
        public List<ProdutoNotaFiscal> Produtos { get; set; }
        public string ChaveAcesso { get; set; }
        public double ValorTotalICMS { get; set; }
        public double ValorTotalIPI { get; set; }
        public double ValorTotalProdutos { get; set; }
        public double ValorTotalFrete { get; set; }
        public double ValorTotalImpostos { get; set; }
        public double ValorTotalNota { get; set; }
        public bool FoiEmitida {
            get
            {
                if (string.IsNullOrEmpty(ChaveAcesso))
                    return false;

                return true;
            }
        }

        public void GerarChaveDeAcesso(Random sorteador)
        {
            ChaveAcesso = "";
            for (int i = 0; i < 44; i++)
            {
                ChaveAcesso += sorteador.Next(0, 10);
            }
        }
        public virtual void ValidarGeracao()
        {                           
            if (Destinatario == null)
                throw new ExcecaoDestinatarioInvalido();

            if (Emitente == null)
                throw new ExcecaoEmitenteInvalido();

            if (string.IsNullOrEmpty(NaturezaOperacao))
                throw new ExcecaoSemNaturezaOperacao();

            if (DataEntrada > DateTime.Now)
                throw new ExcecaoDataEntradaInvalida();

            if (Destinatario.Documento.NumeroComPontuacao == Emitente.CNPJ.NumeroComPontuacao)
                throw new ExcecaoDestinatarioIgualAEmitente();

        }

        public virtual void ValidarParaEmitir()
        {            
            if (ValorTotalICMS <= 0)
                throw new ExcecaoValorTotalICMSInvalido();

            if (ValorTotalIPI <= 0)
                throw new ExcecaoValorTotalIPIInvalido();

            if (ValorTotalProdutos <= 0)
                throw new ExcecaoValorTotalProdutoInvalido();

            if (ValorTotalImpostos <= 0)
                throw new ExcecaoValorTotalImpostosInvalido();

            if (ValorTotalNota <= 0)
                throw new ExcecaoValorTotalNotaInvalido();

            if (Produtos == null || Produtos.Count == 0)
                throw new ExcecaoListaDeProdutoVazia();

            foreach (ProdutoNotaFiscal produtoNotaFiscal in Produtos)
            {
                if (produtoNotaFiscal.ValorTotal <= 0)
                    throw new ExcecaoProdutoSemValor();
            }

            if (Transportador == null)           
                TransportadorReceberValoresDeDestinatario();           

            Destinatario.Validar();
            Emitente.Validar();
            Transportador.Validar();

        }

        public void CalcularValoresTotais()
        {
            ValorTotalICMS = 0;
            ValorTotalIPI = 0;
            ValorTotalProdutos = 0;

            foreach (ProdutoNotaFiscal produtoNotaFiscal in Produtos)
            {
                ValorTotalICMS += produtoNotaFiscal.ValorICMS;
                ValorTotalIPI += produtoNotaFiscal.ValorIPI;
                ValorTotalProdutos += produtoNotaFiscal.ValorTotal;
            }

            ValorTotalImpostos = ValorTotalICMS + ValorTotalIPI;
            ValorTotalNota = ValorTotalFrete + ValorTotalImpostos + ValorTotalProdutos;
        }

        private void TransportadorReceberValoresDeDestinatario()
        {
            Transportador = new Transportador();

            Transportador.NomeRazaoSocial = Destinatario.NomeRazaoSocial;
            Transportador.InscricaoEstadual = Destinatario.InscricaoEstadual;
            Transportador.Documento = Destinatario.Documento;
            Transportador.Endereco = Destinatario.Endereco;
            Transportador.ResponsabilidadeFrete = true;
        }
    }
}
