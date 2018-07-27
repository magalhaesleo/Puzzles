using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

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

        [SetUp]
        public void IniciarCenario()
        {
            _contaRepositorioMoq = new Mock<IContaRepositorio>();
            _clienteRepositorioMoq = new Mock<IClienteRepositorio>();
            _contaServico = new ContaServico(_contaRepositorioMoq.Object, _clienteRepositorioMoq.Object);
            _contaMoq = new Mock<Conta>();
            _contaBuscadaNoBancoMoq = new Mock<Conta>();
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
            _contaRepositorioMoq.Setup(crm => crm.Excluir(_contaMoq.Object));


            //Acao
            _contaServico.Excluir(_contaMoq.Object);

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.Excluir(_contaMoq.Object));
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

            //Acao
            _contaServico.Editar(_contaMoq.Object);

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.Buscar(_contaMoq.Object.Id));
            _contaRepositorioMoq.Verify(crm => crm.Editar(_contaBuscadaNoBancoMoq.Object));
            _contaMoq.Verify(cm => cm.Id);
        }

        [Test]
        public void Conta_Aplicacao_EditarComTitularNulo_Sucesso()
        {
            //Cenario
            byte idContaReferencia = 1;

            _contaMoq.Setup(cbb => cbb.Id).Returns(idContaReferencia);

            _contaRepositorioMoq.Setup(crm => crm.Buscar(_contaMoq.Object.Id)).Returns(_contaBuscadaNoBancoMoq.Object);

            _contaMoq.Object.Titular = null;

            _contaRepositorioMoq.Setup(crm => crm.Editar(_contaBuscadaNoBancoMoq.Object));

            //Acao
            _contaServico.Editar(_contaMoq.Object);

            //Verificao
            _contaRepositorioMoq.Verify(crm => crm.Buscar(_contaMoq.Object.Id));
            _contaRepositorioMoq.Verify(crm => crm.Editar(_contaBuscadaNoBancoMoq.Object));
            _contaMoq.Verify(cm => cm.Id);


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
    }
}
