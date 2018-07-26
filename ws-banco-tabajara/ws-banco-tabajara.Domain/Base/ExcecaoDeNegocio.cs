using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_banco_tabajara.Domain.Base
{
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio(CodigosDeErro codigoDeErro, string mensagem) : base(mensagem)
        {
            CodigoDeErro = codigoDeErro;
        }

        public CodigosDeErro CodigoDeErro { get; }
    }
}
