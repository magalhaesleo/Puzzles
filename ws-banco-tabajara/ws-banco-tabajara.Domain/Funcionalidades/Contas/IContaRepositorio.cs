﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Interfaces;

namespace ws_banco_tabajara.Domain.Funcionalidades.Contas
{
    public interface IContaRepositorio : IRepositorio<Conta>
    {
        IQueryable<Conta> BuscarListaPorQuantidadeDefinida(int quantidade);

        Conta BuscarPorIdentificacaoDeCliente(long idCliente);
    }
}
