using Projeto_NFe.Domain.Funcionalidades.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades.Emitentes
{
    public static partial class ObjectMother
    {
        public static Emitente PegarEmitenteValido(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemNome(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia ="",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemRazaoSocial(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemCNPJ(Endereco endereco)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = null,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemInscricaoEstadual(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemInscricaoMunicipal(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemEndereco(CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = null
            };
        }
    }
}
