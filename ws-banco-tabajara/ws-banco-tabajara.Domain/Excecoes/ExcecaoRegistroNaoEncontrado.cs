using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Base;

namespace ws_banco_tabajara.Domain.Excecoes
{
    public class ExcecaoRegistroNaoEncontrado : ExcecaoDeNegocio
    {
        public ExcecaoRegistroNaoEncontrado() : base(CodigosDeErro.NotFound, "Registro não encontrado")
        {
        }
    }
}
