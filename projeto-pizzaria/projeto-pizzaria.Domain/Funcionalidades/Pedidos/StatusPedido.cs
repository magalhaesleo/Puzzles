﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos
{
    public enum StatusPedido
    {
        AGUARDANDO_MONTAGEM = 2,
        EM_MONTAGEM = 1,
        AGUARDANDO_ENTREGA,
        EM_ENTREGA,
        ENTREGUE
    }
}