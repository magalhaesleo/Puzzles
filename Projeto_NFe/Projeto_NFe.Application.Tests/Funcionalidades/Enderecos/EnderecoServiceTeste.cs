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
    public class EnderecoServiceTeste
    {
        private IEnderecoService _enderecoService;
        private Mock<IEnderecoRepositorio> _enderecoRepositorioMock;
        private Mock<Endereco> _enderecoMock;

        [SetUp]
        public void Inicializa()
        {
            _enderecoRepositorioMock = new Mock<IEnderecoRepositorio>();
            _enderecoService = new EnderecoService(_enderecoRepositorioMock.Object);
            _enderecoMock = new Mock<Endereco>();
        }

        [Test]
        public void EnderecoService_Adicionar_Sucesso()
        {
            _enderecoRepositorioMock.Setup(er => er.Adicionar(_enderecoMock.Object)).Returns(_enderecoMock.Object);

            Endereco enderecoAdicionado = _enderecoService.Adicionar(_enderecoMock.Object);

            _enderecoRepositorioMock.Verify(er => er.Adicionar(_enderecoMock.Object));

            enderecoAdicionado.Should().NotBeNull();
        }

        [Test]
        public void EnderecoService_Atualizar_Sucesso()
        {
            _enderecoRepositorioMock.Setup(er => er.Atualizar(_enderecoMock.Object)).Returns(_enderecoMock.Object);

            Endereco enderecoAtualizado = _enderecoService.Atualizar(_enderecoMock.Object);

            _enderecoRepositorioMock.Verify(er => er.Atualizar(_enderecoMock.Object));

            enderecoAtualizado.Should().NotBeNull();
        }

        [Test]
        public void EnderecoService_Atualizar_IdMenorQueUm_Falha()
        {
            Endereco endereco = new Endereco() { Id = 0 };

            Action resultado = () => _enderecoService.Atualizar(endereco);

            resultado.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void EnderecoService_Deletar_Sucesso()
        {
            Endereco endereco = new Endereco() { Id = 10 };

            _enderecoService.Excluir(endereco);

            _enderecoRepositorioMock.Verify();

            _enderecoRepositorioMock.VerifyNoOtherCalls();
        }

    }
}
