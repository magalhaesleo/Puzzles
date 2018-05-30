using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteServicoTeste
    {
        Mock<IEmitenteRepositorio> _mockRepositorioEmitente;
        IEmitenteServico _emitenteServico;
        Mock<Emitente> _mockEmitente;
        Mock<CNPJ> _mockCnpj;

        [SetUp]
        public void InicializarTestes()
        {
            _mockRepositorioEmitente = new Mock<IEmitenteRepositorio>();
            _mockEmitente = new Mock<Emitente>();
            _emitenteServico = new EmitenteServico(_mockRepositorioEmitente.Object);
            _mockCnpj = new Mock<CNPJ>();

            _mockEmitente.Object.CNPJ = _mockCnpj.Object;
        }

        [Test]
        public void EmitenteServico_Adicionar_Sucesso()
        {

            _mockEmitente.Setup(me => me.Validar());

            _mockRepositorioEmitente.Setup(mre => mre.Adicionar(_mockEmitente.Object)).Returns(_mockEmitente.Object);

            _emitenteServico.Adicionar(_mockEmitente.Object);

            _mockRepositorioEmitente.Verify(mre => mre.Adicionar(_mockEmitente.Object));

            _mockEmitente.Verify(me => me.Validar());
        }

        [Test]
        public void EmitenteServico_Atualizar_Sucesso()
        {
            long idValido = 1;

            _mockEmitente.Setup(me => me.Validar());
            _mockEmitente.Setup(me => me.Id).Returns(idValido);
            _mockRepositorioEmitente.Setup(mre => mre.Atualizar(_mockEmitente.Object)).Returns(_mockEmitente.Object);

            _emitenteServico.Atualizar(_mockEmitente.Object);

            _mockRepositorioEmitente.Verify(mre => mre.Atualizar(_mockEmitente.Object));

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
            _mockCnpj.VerifyNoOtherCalls();
            _mockEmitente.Verify(me => me.Id);

        }

        [Test]
        public void EmitenteServico_Excluir_Sucesso()
        {
            long idValido = 1;

            _mockEmitente.Setup(me => me.Id).Returns(idValido);

            _mockRepositorioEmitente.Setup(mre => mre.Excluir(_mockEmitente.Object));

            _emitenteServico.Excluir(_mockEmitente.Object);

            _mockRepositorioEmitente.Verify(mre => mre.Excluir(_mockEmitente.Object));
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
        }

        [Test]
        public void EmitenteServico_BuscarPorId_Sucesso()
        {
            long id = 1;

            _mockRepositorioEmitente.Setup(er => er.BuscarPorId(id));

            _emitenteServico.BuscarPorId(id);

            _mockRepositorioEmitente.Verify(er => er.BuscarPorId(id));
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
