﻿using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Funcionalidades.Contas;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Extratos;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Application.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContaServicoTeste
    {
        private ContaServico _contaServico;
        private Mock<Conta> _contaMoq;
        private Mock<Conta> _contaBuscadaNoBancoMoq;
        private Mock<IContaRepositorio> _contaRepositorioMoq;
        private Mock<IClienteRepositorio> _clienteRepositorioMoq;
        private Mock<Cliente> _clienteMock;
        private Mock<Extrato> _extratoMock;

        [SetUp]
        public void IniciarCenario()
        {
            _contaRepositorioMoq = new Mock<IContaRepositorio>();
            _clienteRepositorioMoq = new Mock<IClienteRepositorio>();
            _contaServico = new ContaServico(_contaRepositorioMoq.Object, _clienteRepositorioMoq.Object);
            _clienteMock = new Mock<Cliente>();
            _contaMoq = new Mock<Conta>();
            _extratoMock = new Mock<Extrato>();
            _contaMoq.Setup(c => c.Titular).Returns(_clienteMock.Object);
            _contaBuscadaNoBancoMoq = new Mock<Conta>();        }

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
        public void Conta_Aplicacao_AlterarStatusConta_Sucesso()
        {
            //Cenario
            byte idContaBuscadaNoBanco = 1;
            bool statusAtualDaConta = _contaMoq.Object.Ativa;

            _contaRepositorioMoq.Setup(crm => crm.Buscar(idContaBuscadaNoBanco)).Returns(_contaMoq.Object);

            _contaRepositorioMoq.Setup(crm => crm.Editar(_contaMoq.Object));

            //Acao
            _contaServico.AlterarStatusConta(idContaBuscadaNoBanco);

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.Buscar(idContaBuscadaNoBanco));
            _contaRepositorioMoq.Verify(crm => crm.Editar(_contaMoq.Object));
            statusAtualDaConta.Should().Be(!_contaMoq.Object.Ativa);
        }


        [Test]
        public void Conta_Aplicacao_Excluir_Sucesso()
        {
            //Cenario
            long idConta = 1;
            _contaMoq.Setup(c => c.Id).Returns(idConta);
            _contaRepositorioMoq.Setup(crm => crm.Excluir(_contaMoq.Object));
            _contaRepositorioMoq.Setup(crm => crm.Buscar(_contaMoq.Object.Id)).Returns(_contaMoq.Object);

            //Acao
            _contaServico.Excluir(_contaMoq.Object.Id);

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.Excluir(_contaMoq.Object));
            _contaRepositorioMoq.Verify(crm => crm.Buscar(_contaMoq.Object.Id));
        }


        [Test]
        public void Conta_Aplicacao_Buscar_Sucesso()
        {
            //Cenario
            byte idConta = 1;
            _contaRepositorioMoq.Setup(crm => crm.Buscar(idConta)).Returns(_contaMoq.Object);

            //Acao
            Conta contaBuscada = _contaServico.Buscar(idConta);

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.Buscar(idConta));
            contaBuscada.Should().NotBeNull();
        }

        [Test]
        public void Conta_Aplicacao_Editar_Sucesso()
        {
            //Cenario
            byte idContaReferencia = 1;

            _contaMoq.Setup(cbb => cbb.Id).Returns(idContaReferencia);

            _contaRepositorioMoq.Setup(crm => crm.Buscar(_contaMoq.Object.Id)).Returns(_contaBuscadaNoBancoMoq.Object);

            _contaRepositorioMoq.Setup(crm => crm.Editar(_contaBuscadaNoBancoMoq.Object));

            _clienteRepositorioMoq.Setup(cr => cr.Buscar(_contaMoq.Object.Titular.Id)).Returns(_clienteMock.Object);

            //Acao
            _contaServico.Editar(_contaMoq.Object);

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.Buscar(_contaMoq.Object.Id));
            _contaRepositorioMoq.Verify(crm => crm.Editar(_contaBuscadaNoBancoMoq.Object));
            _contaMoq.Verify(cm => cm.Id);
        }

        [Test]
        public void Conta_Aplicacao_EditarComTitularNulo_Falha()
        {
            //Cenario
            Cliente titularNulo = null;
            _contaMoq.Setup(c => c.Titular).Returns(titularNulo);

            //Acao
            Action resultado = () => _contaServico.Editar(_contaMoq.Object);

            //Verificao
            resultado.Should().Throw<ContaSemTitularExcecao>();
            _contaRepositorioMoq.VerifyNoOtherCalls();
            _clienteRepositorioMoq.VerifyNoOtherCalls();
        }
        
        [Test]
        public void Conta_Aplicacao_BuscarTodos_Sucesso()
        {
            //Cenario

            _contaRepositorioMoq.Setup(crm => crm.BuscarTodos()).Returns((new List<Conta>()).AsQueryable());

            //Acao
            IQueryable<Conta> contasBuscadas = _contaServico.BuscarTodos();

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.BuscarTodos());
            contasBuscadas.Should().NotBeNull();
        }

        [Test]
        public void Conta_Aplicacao_Sacar_Sucesso()
        {
            long idParaBuscar = 1;
            double valor = 10;

            _contaRepositorioMoq.Setup(crm => crm.Buscar(idParaBuscar)).Returns(_contaMoq.Object);
            _contaRepositorioMoq.Setup(crm => crm.Editar(_contaMoq.Object));

            _contaMoq.Setup(c => c.Sacar(valor));

            var contaResposta = _contaServico.Sacar(idParaBuscar, valor);

            contaResposta.Should().NotBeNull();
            contaResposta.Should().Be(_contaMoq.Object);
            _contaRepositorioMoq.Verify(crm => crm.Buscar(idParaBuscar));
            _contaRepositorioMoq.Verify(crm => crm.Editar(_contaMoq.Object));
        }

        [Test]
        public void Conta_Aplicacao_Depositar_Sucesso()
        {
            long idParaBuscar = 1;
            double valor = 10;

            _contaRepositorioMoq.Setup(crm => crm.Buscar(idParaBuscar)).Returns(_contaMoq.Object);
            _contaRepositorioMoq.Setup(crm => crm.Editar(_contaMoq.Object));

            _contaMoq.Setup(c => c.Depositar(valor));

            var contaResposta = _contaServico.Depositar(idParaBuscar, valor);

            contaResposta.Should().NotBeNull();
            contaResposta.Should().Be(_contaMoq.Object);
            _contaRepositorioMoq.Verify(crm => crm.Buscar(idParaBuscar));
            _contaRepositorioMoq.Verify(crm => crm.Editar(_contaMoq.Object));
        }

        [Test]
        public void Conta_Aplicacao_Transferir_Sucesso()
        {
            Mock<Conta> contaMovimentadaMock = new Mock<Conta>();

            long idParaBuscarConta = 1;
            long idParaBuscarContaMovimentada = 2;
            double valor = 10;

            _contaRepositorioMoq.Setup(crm => crm.Buscar(idParaBuscarConta)).Returns(_contaMoq.Object);
            _contaRepositorioMoq.Setup(crm => crm.Buscar(idParaBuscarContaMovimentada)).Returns(contaMovimentadaMock.Object);

            _contaRepositorioMoq.Setup(crm => crm.Editar(_contaMoq.Object));
            _contaRepositorioMoq.Setup(crm => crm.Editar(contaMovimentadaMock.Object));

            _contaMoq.Setup(c => c.Transferir(contaMovimentadaMock.Object, valor));

            var contaResposta = _contaServico.Transferir(idParaBuscarConta, idParaBuscarContaMovimentada, valor);

            contaResposta.Should().NotBeNull();
            contaResposta.Should().Be(_contaMoq.Object);
            _contaRepositorioMoq.Verify(crm => crm.Buscar(idParaBuscarConta));
            _contaRepositorioMoq.Verify(crm => crm.Buscar(idParaBuscarContaMovimentada));
            _contaRepositorioMoq.Verify(crm => crm.Editar(_contaMoq.Object));
            _contaRepositorioMoq.Verify(crm => crm.Editar(contaMovimentadaMock.Object));
        }

        [Test]
        public void Conta_Aplicacao_GerarExtrato_Sucesso()
        {
            
            long idDeContaParaBuscarExtrato = 1;

            _contaRepositorioMoq.Setup(crm => crm.Buscar(idDeContaParaBuscarExtrato)).Returns(_contaMoq.Object);

            _contaMoq.Setup(c => c.GerarExtrato()).Returns(_extratoMock.Object);

            Extrato extratoGerado = _contaServico.GerarExtrato(idDeContaParaBuscarExtrato);

            extratoGerado.Should().NotBeNull();
            _contaRepositorioMoq.Verify(crm => crm.Buscar(idDeContaParaBuscarExtrato));
            _contaMoq.Verify(cm => cm.GerarExtrato());
        }

        [Test]
        public void Conta_Aplicacao_BuscarPorIdentificacaoDeCliente_Sucesso()
        {
            //Cenario
            byte idCliente= 1;
            _contaRepositorioMoq.Setup(crm => crm.BuscarPorIdentificacaoDeCliente(idCliente)).Returns(_contaMoq.Object);

            //Acao
            Conta contaBuscada = _contaServico.BuscarPorIdentificacaoDeCliente(idCliente);

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.BuscarPorIdentificacaoDeCliente(idCliente));
            contaBuscada.Should().NotBeNull();
        }
    }
}
