using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos
{
    public enum StatusPedido
    {
        AGUARDANDO_MONTAGEM = 1,
        EM_MONTAGEM = 2,
        AGUARDANDO_ENTREGA = 3,
        EM_ENTREGA = 4,
        ENTREGUE = 5
    }
}
