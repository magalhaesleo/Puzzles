using projeto_pizzaria.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class EnderecoSemComplementoExcecao : ExcecaoDeNegocio
    {
        public EnderecoSemComplementoExcecao() : base("Endereço deve possuir um Complemento.")
        {
        }
    }
}
