using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Common.Tests.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using FluentAssertions;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Transportadoras
{
    [TestFixture]
    public class TransportadorServicoTeste
    {
        private ITransportadorServico _transportadorServico;
        private Mock<ITransportadorRepositorio> _transportadorRepositorioMock;
        private Mock<IEnderecoRepositorio> _enderecoRepositorioMock;
        private Mock<Endereco> _enderecoMock;
        private Mock<Transportador> _transportadorMock;

        [SetUp]
        public void IniciarCenario()
        {
            _transportadorRepositorioMock = new Mock<ITransportadorRepositorio>();
            _enderecoRepositorioMock = new Mock<IEnderecoRepositorio>();
            _transportadorServico = new TransportadorServico(_transportadorRepositorioMock.Object, _enderecoRepositorioMock.Object);
            _enderecoMock = new Mock<Endereco>();
            _transportadorMock = new Mock<Transportador>();
        }

        [Test]
        public void TransportadorServico_Adicionar_Sucesso()
        {
            _transportadorRepositorioMock.Setup(tr => tr.Adicionar(_transportadorMock.Object)).Returns(_transportadorMock.Object);
            _transportadorMock.Setup(tr => tr.Validar());
            _transportadorMock.Object.Endereco = _enderecoMock.Object;
            _enderecoRepositorioMock.Setup(er => er.Adicionar(_transportadorMock.Object.Endereco)).Returns(_transportadorMock.Object.Endereco);

            Transportador transportadorAdicionado = _transportadorServico.Adicionar(_transportadorMock.Object);

            transportadorAdicionado.Should().NotBeNull();
            _transportadorRepositorioMock.Verify(trv => trv.Adicionar(_transportadorMock.Object));
            _transportadorRepositorioMock.VerifyNoOtherCalls();
            _enderecoRepositorioMock.Verify(erv => erv.Adicionar(_transportadorMock.Object.Endereco));
            _enderecoRepositorioMock.VerifyNoOtherCalls();
            _transportadorMock.Verify(trv => trv.Validar());
        }

        [Test]
        public void TransportadorServico_Atualizar_Sucesso()
        {
            _transportadorMock.Setup(tr => tr.Id).Returns(1);
            _enderecoMock.Setup(en => en.Id).Returns(1);
            _transportadorRepositorioMock.Setup(tr => tr.Atualizar(_transportadorMock.Object)).Returns(_transportadorMock.Object);
            _transportadorMock.Setup(tr => tr.Validar());
            _transportadorMock.Object.Endereco = _enderecoMock.Object;
            _enderecoRepositorioMock.Setup(er => er.Atualizar(_transportadorMock.Object.Endereco)).Returns(_transportadorMock.Object.Endereco);

            Transportador transportadorAtualizado = _transportadorServico.Atualizar(_transportadorMock.Object);

            transportadorAtualizado.Should().NotBeNull();
            _transportadorRepositorioMock.Verify(trv => trv.Atualizar(_transportadorMock.Object));
            _transportadorRepositorioMock.VerifyNoOtherCalls();
            _enderecoRepositorioMock.Verify(erv => erv.Atualizar(_transportadorMock.Object.Endereco));
            _enderecoRepositorioMock.VerifyNoOtherCalls();
            _transportadorMock.Verify(trv => trv.Validar());

        }

        [Test]
        public void TransportadorServico_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        {
            _transportadorMock.Setup(tr => tr.Id).Returns(0);
            _enderecoMock.Setup(en => en.Id).Returns(0);

            Action acaoResultado = () => _transportadorServico.Atualizar(_transportadorMock.Object);

            acaoResultado.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _transportadorRepositorioMock.VerifyNoOtherCalls();
            _enderecoRepositorioMock.VerifyNoOtherCalls();

        }

        [Test]
        public void TransportadorServico_Excluir_Sucesso()
        {
            _transportadorMock.Setup(tr => tr.Id).Returns(1);
            _enderecoMock.Setup(en => en.Id).Returns(1);
            _transportadorRepositorioMock.Setup(tr => tr.Excluir(_transportadorMock.Object));
            _transportadorMock.Object.Endereco = _enderecoMock.Object;
            _enderecoRepositorioMock.Setup(er => er.Excluir(_transportadorMock.Object.Endereco));

            _transportadorServico.Excluir(_transportadorMock.Object);

            _transportadorRepositorioMock.Verify(trv => trv.Excluir(_transportadorMock.Object));
            _transportadorRepositorioMock.VerifyNoOtherCalls();
            _enderecoRepositorioMock.Verify(erv => erv.Excluir(_transportadorMock.Object.Endereco));
            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void TransportadorServico_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        {
            _transportadorMock.Setup(tr => tr.Id).Returns(0);
            _enderecoMock.Setup(en => en.Id).Returns(0);

            Action acaoComExcecao = () => _transportadorServico.Excluir(_transportadorMock.Object);

            acaoComExcecao.Should().Throw<ExcecaoIdentificadorIndefinido>();
            _transportadorRepositorioMock.VerifyNoOtherCalls();
            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void TransportadorServico_BuscarPorId_Sucesso()
        {
            _transportadorRepositorioMock.Setup(tr => tr.BuscarPorId(9)).Returns(_transportadorMock.Object);

            Transportador transportador = _transportadorServico.BuscarPorId(9);

            transportador.Should().NotBeNull();
            _transportadorRepositorioMock.Verify(trv => trv.BuscarPorId(9));
            _transportadorRepositorioMock.VerifyNoOtherCalls();
            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void TransportadorServico_BuscarPorId_Falha()
        {

            Action resultado = () => _transportadorServico.BuscarPorId(-10);

            resultado.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _transportadorRepositorioMock.VerifyNoOtherCalls();
            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void TransportadorServico_BuscarTodos_Sucesso()
        {
            List<Transportador> transportadoresLista = new List<Transportador>();

            _transportadorRepositorioMock.Setup(tr => tr.BuscarTodos()).Returns(transportadoresLista);

            IEnumerable<Transportador> transportadores = _transportadorServico.BuscarTodos();

            transportadores.Should().NotBeNull();

            _transportadorRepositorioMock.Verify(trv => trv.BuscarTodos());
            _transportadorRepositorioMock.VerifyNoOtherCalls();
            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }
    }
}
