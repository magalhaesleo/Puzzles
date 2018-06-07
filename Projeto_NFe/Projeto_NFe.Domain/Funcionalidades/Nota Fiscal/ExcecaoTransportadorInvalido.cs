using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal
{
    public class ExcecaoTransportadorInvalido : ExcecaoDeNegocio
    {
        public ExcecaoTransportadorInvalido() : base("Não é possivel adicionar uma nota fiscal sem transportador")
        {

        }
    }
}
