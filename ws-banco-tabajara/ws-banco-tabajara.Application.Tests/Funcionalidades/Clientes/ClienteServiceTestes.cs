using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ws_banco_tabajara.Application.Funcionalidades.Clientes;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Application.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClienteServiceTestes
    {

        private Mock<IClienteRepositorio> _moqClienteRepositorio;
        
        private ClienteServico _clienteServico;

        [SetUp]
        public void Inicializar()
        {
            _moqClienteRepositorio = new Mock<IClienteRepositorio>();
            _clienteServico = new ClienteServico(_moqClienteRepositorio.Object);
        }

        [Test]
        public void Cliente_Application_Adicionar_Sucesso()
        {
            //Cenario
            Cliente clienteParaSerAdicionado = ObjectMother.ObterClienteValido();

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
            Cliente clienteParaRemover = ObjectMother.ObterClienteValido();

            clienteParaRemover.Id = 1;

            _moqClienteRepositorio.Setup(mcr => mcr.Buscar(clienteParaRemover.Id)).Returns(clienteParaRemover);

            _moqClienteRepositorio.Setup(mcr => mcr.Excluir(clienteParaRemover));

            //Acao
            _clienteServico.Excluir(clienteParaRemover.Id);

            //Verificacao
            _moqClienteRepositorio.Verify(mcr => mcr.Excluir(clienteParaRemover));
            _moqClienteRepositorio.Verify(mcr => mcr.Buscar(clienteParaRemover.Id));
        }


        [Test]
        public void Cliente_Application_BuscarTodos_Sucesso()
        {
            //Cenario

            _moqClienteRepositorio.Setup(mcr => mcr.BuscarTodos()).Returns((new List<Cliente>()).AsQueryable());

            //Acao
            IQueryable<Cliente> clienteBuscado = _clienteServico.BuscarTodos();

            //Verificacao
            _moqClienteRepositorio.Verify(mcr => mcr.BuscarTodos());
            clienteBuscado.Should().NotBeNull();
        }

        [Test]
        public void Cliente_Application_Editar_Sucesso()
        {
            //Cenario
            
            
            Cliente clienteBuscadoNoBanco = ObjectMother.ObterClienteValido();
            Cliente clienteEditado = ObjectMother.ObterClienteValido();
            clienteEditado.Nome = "Edicao";

            _moqClienteRepositorio.Setup(mcr => mcr.Buscar(clienteBuscadoNoBanco.Id)).Returns(clienteBuscadoNoBanco);
            
            //Acao
            _clienteServico.Editar(clienteEditado);

            //Verificacao
            
            _moqClienteRepositorio.Verify(mcr => mcr.Editar(clienteBuscadoNoBanco));
            
        }

        [Test]
        public void Cliente_Application_BuscarListaPorQuantidadeDefinida_Sucesso()
        {
            //Cenario
            int quantidadeDefinida = 1;
            _moqClienteRepositorio.Setup(mcr => mcr.BuscarListaPorQuantidadeDefinida(quantidadeDefinida)).Returns((new List<Cliente>()).AsQueryable());

            //Acao
            IQueryable<Cliente> clientesBuscados = _clienteServico.BuscarTodos();

            //Verificacao

            _moqClienteRepositorio.Verify(mcr => mcr.BuscarListaPorQuantidadeDefinida(quantidadeDefinida));
            clientesBuscados.Should().NotBeNull();

        }

    }
}
