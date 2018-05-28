using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades.Enderecos
{
    public static class ObjectMother
    {
        public static Endereco PegarEnderecoValido()
        {
            return new Endereco()
            {
                Bairro = "Santa Catarina",
                Estado = "Santa Catarina",
                Logradouro = "02",
                Municipio = "Lages",
                Numero = 803,
                Pais = "Brasil"
            };
        }
    }
}
