using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Enderecos;
using Projeto_NFe.Common.Tests.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Enderecos
{
    [TestFixture]
    public class EnderecoServicoTeste
    {
        private IEnderecoServico _enderecoServico;
        private Mock<IEnderecoRepositorio> _enderecoRepositorioMock;
        private Mock<Endereco> _enderecoMock;

        [SetUp]
        public void Inicializar()
        {
            _enderecoRepositorioMock = new Mock<IEnderecoRepositorio>();
            _enderecoServico = new EnderecoServico(_enderecoRepositorioMock.Object);
            _enderecoMock = new Mock<Endereco>();
        }

        [Test]
        public void Endereco_Aplicacao_Adicionar_Sucesso()
        {
            _enderecoRepositorioMock.Setup(er => er.Adicionar(_enderecoMock.Object)).Returns(_enderecoMock.Object);

            Endereco enderecoAdicionado = _enderecoServico.Adicionar(_enderecoMock.Object);

            _enderecoRepositorioMock.Verify(er => er.Adicionar(_enderecoMock.Object));

            enderecoAdicionado.Should().NotBeNull();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_Sucesso()
        {
            long idValido = 1;

            _enderecoMock.Setup(em => em.Id).Returns(idValido);

            _enderecoRepositorioMock.Setup(er => er.Atualizar(_enderecoMock.Object)).Returns(_enderecoMock.Object);

            Endereco enderecoAtualizado = _enderecoServico.Atualizar(_enderecoMock.Object);

            _enderecoRepositorioMock.Verify(er => er.Atualizar(_enderecoMock.Object));

            enderecoAtualizado.Should().NotBeNull();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_IdMenorQueUm_Falha()
        {
            Endereco endereco = new Endereco() { Id = 0 };

            Action resultado = () => _enderecoServico.Atualizar(endereco);

            resultado.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Excluir_Sucesso()
        {
            Endereco endereco = new Endereco() { Id = 10 };

            _enderecoRepositorioMock.Setup(er => er.Excluir(endereco));

            _enderecoServico.Excluir(endereco);

            _enderecoRepositorioMock.Verify(er => er.Excluir(endereco));
        }

        [Test]
        public void Endereco_Aplicacao_Excluir_IdMenorQueUm_Falha()
        {
            Endereco endereco = new Endereco() { Id = 0 };

            _enderecoRepositorioMock.Setup(er => er.Excluir(endereco));

            Action resultado = () => _enderecoServico.Excluir(endereco);

            resultado.Should().Throw<ExcecaoIdentificadorIndefinido>();
        }

        [Test]
        public void Endereco_Aplicacao_BuscarTodos_Sucesso()
        {
            Mock<List<Endereco>> listEnderecosMock = new Mock<List<Endereco>>();

            _enderecoRepositorioMock.Setup(er => er.BuscarTodos()).Returns(listEnderecosMock.Object);

            IEnumerable<Endereco> listaEnderecos = _enderecoServico.BuscarTodos();

            listaEnderecos.Should().NotBeNull();

            _enderecoRepositorioMock.Verify(er => er.BuscarTodos());
        }

        [Test]
        public void Endereco_Aplicacao_BuscarPorId_Sucesso()
        {
            long id = 1;

            _enderecoRepositorioMock.Setup(er => er.BuscarPorId(id));

            _enderecoServico.BuscarPorId(id);

            _enderecoRepositorioMock.Verify(er => er.BuscarPorId(id));
        }


        [Test]
        public void Endereco_Aplicacao_BuscarPorId_IdMenorQueUm_Falha()
        {
            long id = -10;

            _enderecoRepositorioMock.Setup(er => er.BuscarPorId(id));

            Action resultado = () =>_enderecoServico.BuscarPorId(id);

            resultado.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

    }
}
