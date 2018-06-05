using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteServicoTeste
    {
        Mock<IEmitenteRepositorio> _mockRepositorioEmitente;
        Mock<IEnderecoRepositorio> _enderecoRepositorioMock;
        IEmitenteServico _emitenteServico;
        Endereco _endereco;
        Mock<Emitente> _mockEmitente;
        Mock<CNPJ> _mockCnpj;

        [SetUp]
        public void InicializarTestes()
        {
            _mockRepositorioEmitente = new Mock<IEmitenteRepositorio>();
            _enderecoRepositorioMock = new Mock<IEnderecoRepositorio>();
            _endereco = new Endereco();
            _mockEmitente = new Mock<Emitente>();
            _emitenteServico = new EmitenteServico(_mockRepositorioEmitente.Object, _enderecoRepositorioMock.Object);
            _mockCnpj = new Mock<CNPJ>();

            _mockEmitente.Object.CNPJ = _mockCnpj.Object;
        }

        [Test]
        public void EmitenteServico_Adicionar_Sucesso()
        {
            //Cenário
            _endereco.Id = 1;
            _mockRepositorioEmitente.Setup(mre => mre.Adicionar(_mockEmitente.Object)).Returns(_mockEmitente.Object);
            _enderecoRepositorioMock.Setup(er => er.Adicionar(_endereco)).Returns(_endereco);
            _mockEmitente.Setup(em => em.Endereco).Returns(_endereco);
            _mockEmitente.Setup(me => me.Validar());

            //Ação
            Emitente emitente = _emitenteServico.Adicionar(_mockEmitente.Object);

            //Verificar 
            emitente.Should().NotBeNull();
            emitente.Endereco.Should().NotBeNull();
            _mockRepositorioEmitente.Verify(mre => mre.Adicionar(_mockEmitente.Object));
            _mockEmitente.Verify(me => me.Validar());
            _enderecoRepositorioMock.Verify(er => er.Adicionar(_endereco));
        }

        [Test]
        public void EmitenteServico_Atualizar_Sucesso()
        {
            //Cenário
            long idValido = 1;

            _mockRepositorioEmitente.Setup(mre => mre.Adicionar(_mockEmitente.Object)).Returns(_mockEmitente.Object);
            _enderecoRepositorioMock.Setup(er => er.Adicionar(_endereco)).Returns(_endereco);
            _mockEmitente.Setup(em => em.Endereco).Returns(_endereco);
            _mockEmitente.Setup(me => me.Validar());

            Emitente emitente = _emitenteServico.Adicionar(_mockEmitente.Object);

            _mockEmitente.Setup(me => me.Id).Returns(idValido);
            _enderecoRepositorioMock.Setup(en => en.Atualizar(_endereco)).Returns(_endereco);
            _mockRepositorioEmitente.Setup(mre => mre.Atualizar(_mockEmitente.Object)).Returns(_mockEmitente.Object);

            //Ação
            _emitenteServico.Atualizar(_mockEmitente.Object);

            //Verificar
            _mockRepositorioEmitente.Verify(mre => mre.Atualizar(_mockEmitente.Object));
            _enderecoRepositorioMock.Verify(en => en.Atualizar(_mockEmitente.Object.Endereco));

            _mockEmitente.Verify(me => me.Validar());
        }

        [Test]
        public void EmitenteServico_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockEmitente.Setup(me => me.Id).Returns(idInvalido);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _emitenteServico.Atualizar(_mockEmitente.Object);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _enderecoRepositorioMock.VerifyNoOtherCalls();
            _mockCnpj.VerifyNoOtherCalls();
            _mockEmitente.Verify(me => me.Id);
        }

        [Test]
        public void EmitenteServico_Excluir_Sucesso()
        {
            long idValido = 1;

            _endereco.Id = 1;
            _mockEmitente.Setup(me => me.Id).Returns(idValido);

            _enderecoRepositorioMock.Setup(en => en.Excluir(_mockEmitente.Object.Endereco));
            _mockRepositorioEmitente.Setup(mre => mre.Excluir(_mockEmitente.Object));

            _emitenteServico.Excluir(_mockEmitente.Object);

            _mockRepositorioEmitente.Verify(mre => mre.Excluir(_mockEmitente.Object));
            _enderecoRepositorioMock.Verify(en => en.Excluir(_mockEmitente.Object.Endereco));
        }

        [Test]
        public void EmitenteServico_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockEmitente.Setup(me => me.Id).Returns(idInvalido);

            _mockRepositorioEmitente.Setup(mre => mre.Excluir(_mockEmitente.Object));

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _emitenteServico.Excluir(_mockEmitente.Object);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void EmitenteServico_BuscarPorId_Sucesso()
        {
            _mockEmitente.Setup(er => er.Id).Returns(1);

            _mockRepositorioEmitente.Setup(er => er.BuscarPorId(_mockEmitente.Object.Id)).Returns(_mockEmitente.Object);

            _emitenteServico.BuscarPorId(_mockEmitente.Object.Id);

            _mockRepositorioEmitente.Verify(er => er.BuscarPorId(_mockEmitente.Object.Id));
        }

        [Test]
        public void EmitenteServico_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockRepositorioEmitente.Setup(er => er.BuscarPorId(idInvalido));

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _emitenteServico.BuscarPorId(idInvalido);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockRepositorioEmitente.VerifyNoOtherCalls();
        }

        [Test]
        public void EmitenteServico_BuscarTodos_Sucesso()
        {
            _mockRepositorioEmitente.Setup(mre => mre.BuscarTodos());

            _emitenteServico.BuscarTodos();

            _mockRepositorioEmitente.Verify(mre => mre.BuscarTodos());

        }
    }
}
