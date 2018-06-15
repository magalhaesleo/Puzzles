using NUnit.Framework;
using Projeto_NFe.Infrastructure.PDF.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using System.IO;
using NUnit.Framework;
using FluentAssertions;

namespace Projeto_NFe.Infrastructure.PDF.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalParaPDFTeste
    {

        NotaFiscal _notaFiscal;
        string _caminhoParaANovaNotaFiscal = @"..\..\..\NotaFiscal.pdf";


        [SetUp]
        public void IniciarCenario()
        {
            Endereco enderecoEmitente = Common.Tests.Funcionalidades.Enderecos.ObjectMother.PegarEnderecoValido();
            Endereco enderecoDestinatario = Common.Tests.Funcionalidades.Enderecos.ObjectMother.PegarEnderecoValido();
            Endereco enderecoTransportador = Common.Tests.Funcionalidades.Enderecos.ObjectMother.PegarEnderecoValido();

            Emitente emitente = Common.Tests.Funcionalidades.Emitentes.ObjectMother.PegarEmitenteValido(enderecoEmitente, new CNPJ { NumeroComPontuacao = "99.327.235/0001-50" });
            Destinatario destinatario = Common.Tests.Funcionalidades.Destinatarios.ObjectMother.PegarDestinatarioValidoComCNPJ(enderecoDestinatario, new CNPJ { NumeroComPontuacao = "13.106.137/0001-77" });
            Transportador transportador = Common.Tests.Funcionalidades.Transportadoras.ObjectMother.PegarTransportadorValidoComCNPJ(enderecoTransportador, new CNPJ { NumeroComPontuacao = "11.222.333/0001-81" });

            _notaFiscal = Common.Tests.Funcionalidades.Nota_Fiscal.ObjectMother.PegarNotaFiscalValida(emitente, destinatario, transportador);

            Produto produto = Common.Tests.Funcionalidades.Produtos.ObjectMother.ObterProdutoValido();
            ProdutoNotaFiscal produtoNotaFiscal = Common.Tests.Funcionalidades.ProdutoNotasFiscais.ObjectMother.PegarProdutoNotaFiscalValido(produto, _notaFiscal);

            _notaFiscal.Produtos = new List<ProdutoNotaFiscal>();
            _notaFiscal.Produtos.Add(produtoNotaFiscal);

            _notaFiscal.ValidarGeracao();
            _notaFiscal.ValidarParaEmitir();
            _notaFiscal.CalcularValoresTotais();
            _notaFiscal.GerarChaveDeAcesso(new Random());
            _notaFiscal.DataEmissao = DateTime.Now;

            
        }

        [Test]
        public void NotaFiscal_InfraPDF_Exportar_Sucesso()
        {
            NotaFiscalRepositorioPDF gerador = new NotaFiscalRepositorioPDF();
            gerador.Exportar(_caminhoParaANovaNotaFiscal, _notaFiscal);

            Action acaoParaVerificarSeArquivoExiste = () => File.Exists(_caminhoParaANovaNotaFiscal);

            acaoParaVerificarSeArquivoExiste.Should().Equals(true);

            File.Delete(_caminhoParaANovaNotaFiscal);

        }

        [Test]
        public void NotaFiscal_InfraPDF_Exportar_Com5Produtos_Sucesso()
        {
            Produto produto = Common.Tests.Funcionalidades.Produtos.ObjectMother.ObterProdutoValido();
            ProdutoNotaFiscal produtoNotaFiscal = Common.Tests.Funcionalidades.ProdutoNotasFiscais.ObjectMother.PegarProdutoNotaFiscalValido(produto, _notaFiscal);

            _notaFiscal.Produtos = new List<ProdutoNotaFiscal>();
            _notaFiscal.Produtos.Add(produtoNotaFiscal);
            _notaFiscal.Produtos.Add(produtoNotaFiscal);
            _notaFiscal.Produtos.Add(produtoNotaFiscal);
            _notaFiscal.Produtos.Add(produtoNotaFiscal);
            _notaFiscal.Produtos.Add(produtoNotaFiscal);

            _notaFiscal.ValidarGeracao();
            _notaFiscal.ValidarParaEmitir();
            _notaFiscal.CalcularValoresTotais();
            _notaFiscal.GerarChaveDeAcesso(new Random());
            _notaFiscal.DataEmissao = DateTime.Now;

            NotaFiscalRepositorioPDF gerador = new NotaFiscalRepositorioPDF();
            gerador.Exportar(_caminhoParaANovaNotaFiscal, _notaFiscal);

            Action acaoParaVerificarSeArquivoExiste = () => File.Exists(_caminhoParaANovaNotaFiscal);

            acaoParaVerificarSeArquivoExiste.Should().Equals(true);

            File.Delete(_caminhoParaANovaNotaFiscal);

        }

    }
}
