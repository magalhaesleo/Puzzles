using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests
{
    public static partial class ObjectMother
    {
        public static Endereco ObterEnderecoValido()
        {
            return new Endereco()
            {
                CEP = "88503-590",
                Cidade = "Lages",
                Bairro = "Centro",
                Rua = "Rua",
                Numero = 1,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoSemCEP()
        {
            return new Endereco()
            {
                CEP = "",
                Cidade = "Lages",
                Bairro = "Centro",
                Rua = "Rua",
                Numero = 1,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoSemCidade()
        {
            return new Endereco()
            {
                CEP = "88503-590",
                Cidade = "",
                Bairro = "Centro",
                Rua = "Rua",
                Numero = 1,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoSemBairro()
        {
            return new Endereco()
            {
                CEP = "88503-590",
                Cidade = "Lages",
                Bairro = "",
                Rua = "Rua",
                Numero = 1,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoSemRua()
        {
            return new Endereco()
            {
                CEP = "88503-590",
                Cidade = "Lages",
                Bairro = "Centro",
                Rua = "",
                Numero = 1,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoSemNumero()
        {
            return new Endereco()
            {
                CEP = "88503-590",
                Cidade = "Lages",
                Bairro = "Centro",
                Rua = "Rua",
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoSemComplemento()
        {
            return new Endereco()
            {
                CEP = "88503-590",
                Cidade = "Lages",
                Bairro = "Centro",
                Rua = "Rua",
                Numero = 1,
                Complemento = ""
            };
        }
    }
}
