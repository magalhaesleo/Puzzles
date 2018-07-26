using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Application.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContaServicoTeste
    {
        private ContaServico _contaServico;
        private Mock<Conta> _contaMoq;
        private Mock<IContaRepositorio> _contaRepositorioMoq;

        [SetUp]
        public void IniciarCenario()
        {
            _contaRepositorioMoq = new Mock<IContaRepositorio>();
            _contaServico = new ContaServico(_contaRepositorioMoq.Object);
            _contaMoq = new Mock<Conta>();
        }

        [Test]
        public void Conta_Aplicacao_Adicionar_Sucesso()
        {
            _contaMoq.Setup(c => c.Id).Returns(1);
            _contaRepositorioMoq.Setup(c => c.Adicionar(_contaMoq.Object)).Returns(_contaMoq.Object);
            Conta contaAdicionada = _contaServico.Adicionar(_contaMoq.Object);

            contaAdicionada.Should().NotBeNull();
            int idContaAdicionada = 1;
            contaAdicionada.Id.Should().BeGreaterOrEqualTo(idContaAdicionada);
        }

        [Test]
        public void Conta_Aplicacao_Editar_Sucesso()
        {
            _contaMoq.Setup(c => c.Id).Returns(1);
            _contaRepositorioMoq.Setup(c => c.Adicionar(_contaMoq.Object)).Returns(_contaMoq.Object);
            Conta contaAdicionada = _contaServico.Adicionar(_contaMoq.Object);

            contaAdicionada.Should().NotBeNull();
            int idContaAdicionada = 1;
            contaAdicionada.Id.Should().BeGreaterOrEqualTo(idContaAdicionada);
        }
    }
}
