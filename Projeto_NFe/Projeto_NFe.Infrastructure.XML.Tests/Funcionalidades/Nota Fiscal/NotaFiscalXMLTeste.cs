using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System.IO;

namespace Projeto_NFe.Infrastructure.XML.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalXMLTeste
    {
        Emitente _emitente;
        Destinatario _destinatario;
        Transportador _transportador;
        NotaFiscal _notaFiscal;
        Produto _produto;
        ProdutoNotaFiscal _produtoNotaFiscal;
        Endereco _endereco;
        string _file;

        [SetUp]
        public void IniciarCenario()
        {
            _file = @"C:\Users\ndduser\Desktop\notafiscal.xml";
            _endereco = Common.Tests.Funcionalidades.Enderecos.ObjectMother.PegarEnderecoValido();

            _emitente = Common.Tests.Funcionalidades.Emitentes.ObjectMother.PegarEmitenteValido(_endereco, new CNPJ { NumeroComPontuacao = "99.327.235/0001-50" });
            _destinatario = Common.Tests.Funcionalidades.Destinatarios.ObjectMother.PegarDestinatarioValidoComCNPJ(_endereco, new CNPJ { NumeroComPontuacao = "13.106.137/0001-77" });
            _transportador = Common.Tests.Funcionalidades.Transportadoras.ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, new CNPJ { NumeroComPontuacao = "11.222.333/0001-81" });

            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitente, _destinatario, _transportador);
            _notaFiscal.DataEmissao = DateTime.Now;
            _produto = Common.Tests.Funcionalidades.Produtos.ObjectMother.ObterProdutoValido();
            _produtoNotaFiscal = Common.Tests.Funcionalidades.ProdutoNotasFiscais.ObjectMother.PegarProdutoNotaFiscalValido(_produto, _notaFiscal);

            _notaFiscal.Produtos = new List<ProdutoNotaFiscal>();
            _notaFiscal.Produtos.Add(_produtoNotaFiscal);

            _notaFiscal.ValidarGeracao();
            _notaFiscal.ValidarParaEmitir();
            _notaFiscal.CalcularValoresTotais();
            _notaFiscal.GerarChaveDeAcesso(new Random());
            _notaFiscal.DataEmissao = DateTime.Now;

            File.Delete(_file);
        }

        [Test]
        public void NotaFiscal_InfraXML_Serializar_Sucesso()
        {
            string resultado = NotaFiscalXMLRepositorio.Serializar(_notaFiscal);
        }

        [Test]
        public void NotaFiscal_InfraXML_SerializarParaArquivo_Sucesso()
        {
            
            NotaFiscalXMLRepositorio.Serializar(_notaFiscal, _file);
        }
    }
}
