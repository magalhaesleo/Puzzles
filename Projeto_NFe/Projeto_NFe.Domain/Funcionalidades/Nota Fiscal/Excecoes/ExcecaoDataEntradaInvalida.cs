using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoDataEntradaInvalida : ExcecaoDeNegocio
    {
        public ExcecaoDataEntradaInvalida() : base("A data de entrada não pode ser maior que a data atual.")
        {
        }
    }
}
