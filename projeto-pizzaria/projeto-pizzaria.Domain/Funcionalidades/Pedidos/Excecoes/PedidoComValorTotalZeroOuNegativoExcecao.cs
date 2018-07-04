using projeto_pizzaria.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes
{
    public class PedidoComValorTotalZeroOuNegativoExcecao : ExcecaoDeNegocio
    {
        public PedidoComValorTotalZeroOuNegativoExcecao() : base("O Valor Total de um Pedido não pode ser menor ou igual a zero.")
        {
        }
    }
}
