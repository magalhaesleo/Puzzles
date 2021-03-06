﻿using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Applications.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Interfaces.Adicionais;
using projeto_pizzaria.Domain.Interfaces.Pedidos;
using projeto_pizzaria.Domain.Interfaces.ProdutosGenericos;
using projeto_pizzaria.Domain.Interfaces.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Applications.Tests.Funcionalidades.Pedidos
{
    [TestFixture]
    public class PedidoServicoTeste
    {
        Mock<IPedidoRepositorio> _pedidoRepositorioMoq;
        Mock<ISaborRepositorio> _saborRepositorioMoq;
        Mock<IAdicionalRepositorio> _adicionalRepositorioMoq;
        Mock<IProdutoGenericoRepositorio> _produtoGenericoRepositorioMoq;
       
        Mock<Pedido> _pedido;
        PedidoServico _pedidoServico;

        [SetUp]
        public void IniciarCenario()
        {
            _pedidoRepositorioMoq = new Mock<IPedidoRepositorio>();
            _saborRepositorioMoq = new Mock<ISaborRepositorio>();
            _adicionalRepositorioMoq = new Mock<IAdicionalRepositorio>();
            _produtoGenericoRepositorioMoq = new Mock<IProdutoGenericoRepositorio>();
            _pedidoServico = new PedidoServico(_pedidoRepositorioMoq.Object, _saborRepositorioMoq.Object, _adicionalRepositorioMoq.Object, _produtoGenericoRepositorioMoq.Object);
            _pedido = new Mock<Pedido>();
        }
        [Test]
        public void Pedido_Aplicacao_Adicionar_Sucesso()
        {
            _pedidoRepositorioMoq.Setup(pr => pr.Adicionar(_pedido.Object)).Returns(2);

            long idInserido = _pedidoServico.Adicionar(_pedido.Object);

            idInserido.Should().BeGreaterOrEqualTo(1);
            _pedidoRepositorioMoq.Verify(pr => pr.Adicionar(_pedido.Object));
            _pedidoRepositorioMoq.VerifyNoOtherCalls();
        }
    }
}
