using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Funcionalidades.Clientes;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes.Interface;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Application.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClienteServiceTestes
    {

        private Mock<IClienteRepositorio> _moqClienteRepositorio;
        private Mock<IContaRepositorio> _moqContaRepositorio;
        private Mock<Conta> _moqConta;
        private ClienteServico _clienteServico;

        [SetUp]
        public void Inicializar()
        {

            _moqClienteRepositorio = new Mock<IClienteRepositorio>();
            _moqContaRepositorio = new Mock<IContaRepositorio>();

            _moqConta = new Mock<Conta>();
            
            _clienteServico = new ClienteServico(_moqClienteRepositorio.Object, _moqContaRepositorio.Object);
        }

        [Test]
        public void Cliente_Application_Adicionar_Sucesso()
        {
            //Cenario
            byte idDaConta = 1;
            _moqConta.Setup(mc => mc.Id).Returns(idDaConta);

            Cliente clienteParaSerAdicionado = ObjectMother.obterClienteValidoComReferenciaDeConta(_moqConta.Object);

            _moqClienteRepositorio.Setup(mcr => mcr.Adicionar(clienteParaSerAdicionado)).Returns(clienteParaSerAdicionado);

            //Acao
            _clienteServico.Adicionar(clienteParaSerAdicionado);

            //Verificacao
            _moqClienteRepositorio.Verify(mcr => mcr.Adicionar(clienteParaSerAdicionado));
        }

        [Test]
        public void Cliente_Application_Buscar_Sucesso()
        {
            //Cenario
            
            byte idCliente = 1;

            _moqClienteRepositorio.Setup(mcr => mcr.Buscar(idCliente)).Returns(Activator.CreateInstance<Cliente>());

            //Acao
            Cliente clienteBuscado = _clienteServico.Buscar(idCliente);

            //Verificacao
            _moqClienteRepositorio.Verify(mcr => mcr.Buscar(idCliente));
            clienteBuscado.Should().NotBeNull();
        }


        [Test]
        public void Cliente_Application_Excluir_Sucesso()
        {
            //Cenario

            byte idDaConta = 1;
            Cliente clienteParaRemover = ObjectMother.obterClienteValidoSemReferenciaDeConta(idDaConta);

            _moqClienteRepositorio.Setup(mcr => mcr.Excluir(clienteParaRemover));

            //Acao
            _clienteServico.Excluir(clienteParaRemover);

            //Verificacao
            _moqClienteRepositorio.Verify(mcr => mcr.Excluir(clienteParaRemover));
            
        }


        [Test]
        public void Cliente_Application_BuscarTodos_Sucesso()
        {
            //Cenario

            byte idCliente = 1;

            _moqClienteRepositorio.Setup(mcr => mcr.BuscarTodos()).Returns((new List<Cliente>()).AsQueryable());

            //Acao
            IQueryable<Cliente> clienteBuscado = _clienteServico.BuscarTodos();

            //Verificacao
            _moqClienteRepositorio.Verify(mcr => mcr.BuscarTodos());
            clienteBuscado.Should().NotBeNull();
        }

        [Test]
        public void Cliente_Application_EditarComContaVinculada_Sucesso()
        {
            //Cenario
            byte idMoqConta = 1;
            
            _moqConta.Setup(mc => mc.Id).Returns(idMoqConta);
            
            _moqContaRepositorio.Setup(mcr => mcr.Buscar(_moqConta.Object.Id)).Returns(_moqConta.Object);

            Cliente cliente = ObjectMother.obterClienteValidoComReferenciaDeConta(_moqConta.Object);

            _moqClienteRepositorio.Setup(mcr => mcr.Buscar(cliente.Id)).Returns(cliente);
            
            //Acao
            _clienteServico.Editar(cliente);

            //Verificacao
            _moqClienteRepositorio.Verify(mcr => mcr.Buscar(cliente.Id));
            _moqClienteRepositorio.Verify(mcr => mcr.Editar(cliente));
            _moqContaRepositorio.Verify(mcr => mcr.Buscar(cliente.Conta.Id));
            _moqConta.Verify(mc => mc.Id);
            
        }

        [Test]
        public void Cliente_Application_EditarSemContaVinculadaApenasComContaId_Sucesso()
        {
            //Cenario
            byte idDeContaAntigo = 1;
            byte novoIdConta = 2;

            Cliente clienteReferencia = ObjectMother.obterClienteValidoSemReferenciaDeConta(novoIdConta);

            Cliente clienteBuscadoNoBanco = ObjectMother.obterClienteValidoSemReferenciaDeContaComContaIdDiferenteDaAnterior(idDeContaAntigo);

            _moqClienteRepositorio.Setup(mcr => mcr.Buscar(clienteReferencia.Id)).Returns(clienteBuscadoNoBanco);

            _moqContaRepositorio.Setup(mcr => mcr.Buscar(clienteBuscadoNoBanco.ContaId)).Returns(_moqConta.Object);
            
            //Acao
            _clienteServico.Editar(clienteReferencia);

            //Verificacao
            _moqClienteRepositorio.Verify(mcr => mcr.Buscar(clienteReferencia.Id));
            _moqClienteRepositorio.Verify(mcr => mcr.Editar(clienteBuscadoNoBanco));
            _moqContaRepositorio.Verify(mcr => mcr.Buscar(idDeContaAntigo));
            

        }
    }
}
