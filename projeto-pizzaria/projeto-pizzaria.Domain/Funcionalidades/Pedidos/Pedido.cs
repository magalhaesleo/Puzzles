using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosPedido;
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

        public Cliente Cliente { get; set; }

        public List<ProdutoPedido> Produtos { get; set; }

        public StatusPedido Status { get; set; }

        public double ValorTotal { get; set; }

        public FormaPagamentoPedido FormaPagamento { get; set; }

        public string Responsavel { get; set; }

        public string Departamento { get; set; }

    }
}
