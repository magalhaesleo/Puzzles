﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs
{
    public class ExcecaoNumeroCPFInvalido : Exception
    {
        public ExcecaoNumeroCPFInvalido() : base("CPF Inválido")
        {

        }
    }
}
