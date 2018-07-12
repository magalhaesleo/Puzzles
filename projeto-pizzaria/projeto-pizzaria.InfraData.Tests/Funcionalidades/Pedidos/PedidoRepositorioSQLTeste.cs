using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
using projeto_pizzaria.Common.Tests.Base;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Pedidos;
using projeto_pizzaria.Infra.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.InfraData.Tests.Funcionalidades.Pedidos
{
    [TestFixture]
    public class PedidoRepositorioSQLTeste
    {
        private PizzariaContexto _pizzariaContexto;
        private PedidoRepositorioSQL _pedidoRepositorio;
        private Pedido _pedido;
        private Endereco _endereco;
        private CPF _cpf;
        private Cliente _cliente;
        private List<Produto> _produtos;

        [SetUp]
        public void IniciarCenario()
        {
            _pizzariaContexto = new PizzariaContexto();

            Database.SetInitializer(new BaseSQLTeste());

            _pizzariaContexto.Database.Initialize(true);

            _pedidoRepositorio = new PedidoRepositorioSQL(_pizzariaContexto);

            _endereco = ObjectMother.ObterEnderecoValido();
            _cpf = ObjectMother.ObterCPFValido();
            _cliente = ObjectMother.ObterClienteValido(_endereco, _cpf);
            _produtos = new List<Produto>();
            Sabor calabresa = ObjectMother.ObterSaborValido_Calabresa();
            long idSaborInseridoPorBaseSQL = 1;
            calabresa.Id = idSaborInseridoPorBaseSQL;
            Pizza pizza = ObjectMother.ObterPizzaComUmSabor(calabresa);
            pizza.Tamanho = TamanhoPizza.GRANDE;
            _produtos.Add(pizza);

            _pedido = new Pedido();
            
        }
        [Test]
        public void Pedido_InfraDados_Adicionar_Sucesso()
        {
            _pedido = ObjectMother.ObterPedidoValido(_cliente, _produtos);
            long idPedido =  _pedidoRepositorio.Adicionar(_pedido);

            idPedido.Should().BeGreaterThan(0);
        }
    }
}
