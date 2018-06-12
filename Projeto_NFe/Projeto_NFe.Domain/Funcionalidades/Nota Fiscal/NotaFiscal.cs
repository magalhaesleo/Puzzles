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
        public List<ProdutoNotaFiscal> Produtos { get; set; }
        public virtual string ChaveAcesso { get; set; }
        public double ValorTotalICMS { get; set; }
        public double ValorTotalIPI { get; set; }
        public double ValorTotalProduto { get; set; }
        public double ValorTotalFrete { get; set; }
        public double ValorTotalNota { get; set; }
        public virtual void GerarChaveDeAcesso(Random sorteador)
        {
            for (int i = 0; i < 44; i++)
            {
                ChaveAcesso += sorteador.Next(0, 10);
            }
        }
        public virtual void ValidarGeracao()
        {
            if (Transportador == null)
                throw new ExcecaoTransportadorInvalido();

            if (Destinatario == null)
                throw new ExcecaoDestinatarioInvalido();
            if (Emitente == null)
                throw new ExcecaoEmitenteInvalido();

            if (string.IsNullOrEmpty(NaturezaOperacao))
                throw new ExcecaoSemNaturezaOperacao();

            if (DataEntrada > DateTime.Now)
                throw new ExcecaoDataEntradaInvalida();

        }

        public virtual void ValidarParaEmitir()
        {
            if (ValorTotalICMS < 1)
                throw new ExcecaoValorTotalICMSInvalido();

            if (ValorTotalIPI < 1)
                throw new ExcecaoValorTotalIPIInvalido();

            if (ValorTotalProduto < 1)
                throw new ExcecaoValorTotalProdutoInvalido();

        }
    }
}
