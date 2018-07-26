using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_banco_tabajara.Domain.Excecoes
{
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio(CodigosDeErro codigoDeErro, string message) : base(message)
        {
            CodigoDoErro = codigoDeErro;
        }

        public CodigosDeErro CodigoDoErro { get; }
    }
}
