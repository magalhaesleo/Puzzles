using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class ExcecaoEnderecoSemPais : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoSemPais() : base("Um endereço deve ter um país definido")
        {
        }
    }
}
