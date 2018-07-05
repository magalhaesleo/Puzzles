using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Endereco PegarEnderecoValido()
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

        public static Endereco PegarEnderecoSemCEP()
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

        public static Endereco PegarEnderecoSemCidade()
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

        public static Endereco PegarEnderecoSemBairro()
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

        public static Endereco PegarEnderecoSemRua()
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

        public static Endereco PegarEnderecoSemNumero()
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

        public static Endereco PegarEnderecoSemComplemento()
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
