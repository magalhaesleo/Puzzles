using projeto_pizzaria.Domain.Excecoes;
using System;
using System.Runtime.Serialization;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes
{
    public class PedidoSemClienteExcecao : ExcecaoDeNegocio
    {
    
        public PedidoSemClienteExcecao() : base("O pedido deve conter um cliente")
        {
        }
    }
}