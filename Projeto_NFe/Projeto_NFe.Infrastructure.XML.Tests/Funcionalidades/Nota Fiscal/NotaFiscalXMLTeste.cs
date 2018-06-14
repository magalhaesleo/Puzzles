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
        List<ProdutoNotaFiscal> _produtosNotaFiscal;

        [SetUp]
        public void IniciarCenario()
        {
            _produto = new Produto();
            _emitente = new Emitente();
            _destinatario = new Destinatario();
            _transportador = new Transportador();
            _produtosNotaFiscal = new List<ProdutoNotaFiscal>();
            _produtoNotaFiscal = new ProdutoNotaFiscal(_notaFiscal, _produto, 1);
        }

        [Test]
        public void NotaFiscal_InfraXML_Serializar_Sucesso()
        {
            _produtosNotaFiscal.Add(_produtoNotaFiscal);
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitente, _destinatario, _transportador, _produtosNotaFiscal);
            //NotaFiscalDTO dto = NotaFiscalMapper.Criar(_notaFiscal);
            string path = @"C:\Users\ndduser\Desktop\NotaFiscal.xml";
            string resultado = NotaFiscalXMLRepositorio.Serializar(_notaFiscal, path);
        }
    }
}
