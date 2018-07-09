using projeto_pizzaria.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes
{
    public class PedidoComClienteSemDocumentoExcecao : ExcecaoDeNegocio
    {
        public PedidoComClienteSemDocumentoExcecao() : base("O Cliente do Pedido deve ter um documento para que a nota fiscal seja emitida.")
        {
        }
    }
}
