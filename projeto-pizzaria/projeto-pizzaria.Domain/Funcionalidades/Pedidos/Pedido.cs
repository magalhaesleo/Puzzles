using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos
{
    public class Pedido : Entidade
    {
        public DateTime Data { get; set; }

        public virtual Cliente Cliente { get; set; }

        public List<Produto> Produtos { get; set; }

        public StatusPedido Status { get; set; }

        public double ValorTotal
        {
            get
            {
                return CalcularValorTotal();
            }
        }

        public FormaPagamentoPedido? FormaPagamento { get; set; }

        public string Responsavel { get; set; }

        public string Departamento { get; set; }

        public Pedido()
        {
            //Status = StatusPedido.AGUARDANDO_ENTREGA;
            Data = DateTime.Now;
            Produtos = new List<Produto>();
        }

        private double CalcularValorTotal()
        {
            double valorTotal = 0;

            foreach (Produto produto in Produtos)
            {
                valorTotal += produto.Valor;
            }

            return valorTotal;
        }

        public void AtualizarStatus()
        {
            Status++; //fazer extension method?
        }

        public void Validar()
        {
            if (Cliente == null)
                throw new PedidoSemClienteExcecao();

            if (Produtos.Count == 0)
                throw new PedidoSemProdutosExcecao();

            if (FormaPagamento == null)
                throw new PedidoSemFormaDePagamentoExcecao();

            if (ValorTotal <= 0)
                throw new PedidoComValorTotalZeroOuNegativoExcecao();

        }
    }
}
