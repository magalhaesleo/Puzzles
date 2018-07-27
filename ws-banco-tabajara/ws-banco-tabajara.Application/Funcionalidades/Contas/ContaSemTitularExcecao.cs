﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Excecoes;

namespace ws_banco_tabajara.Application.Funcionalidades.Contas
{
    public class ContaSemTitularExcecao : ExcecaoDeNegocio
    {
        public ContaSemTitularExcecao() : base(CodigosDeErro.InvalidObject, "A conta deve possuir um titular")
        {
        }
    }
}
