using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Application.Tests.Funcionalidades.Movimentacoes
{
    [TestFixture]
    public class MovimentacaoServicoTeste
    {
        Mock<IMovimentacaoRepositorio> _movimentacaoRepositorioMock;
        MovimentacaoServico _movimentacaoServico;

        Mock<Movimentacao> _mockMovimentacao;

        [SetUp]
        public void IniciarCenario()
        {
            _movimentacaoRepositorioMock = new Mock<IMovimentacaoRepositorio>();
            _movimentacaoServico = new MovimentacaoServico(_movimentacaoRepositorioMock.Object);

            _mockMovimentacao = new Mock<Movimentacao>();
        }

        [Test]
        public void Movimentacao_Aplicacao_Adicionar_Sucesso()
        {
            _movimentacaoRepositorioMock.Setup(m => m.Adicionar(_mockMovimentacao.Object)).Returns(_mockMovimentacao.Object);
            
            _movimentacaoServico.Adicionar(_mockMovimentacao.Object);

            _movimentacaoRepositorioMock.Verify(mrm => mrm.Adicionar(_mockMovimentacao.Object));
        }

        [Test]
        public void Movimentacao_Aplicacao_BuscarPorConta_Sucesso()
        {
            _movimentacaoRepositorioMock.Setup(m => m.BuscarPorConta(_mockMovimentacao.Object.Conta.Id)).Returns(It.IsAny<IQueryable<Movimentacao>>);

            _movimentacaoServico.BuscarPorConta(_mockMovimentacao.Object.Conta.Id);

            _movimentacaoRepositorioMock.Verify(mrm => mrm.BuscarPorConta(_mockMovimentacao.Object.Conta.Id));
        }
    }
}
