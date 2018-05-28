using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes
{
    public class ExcecaoEnderecoSemLogradouro : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoSemLogradouro() : base("Um endereço deve conter um logradouro")
        {
        }
    }
}
