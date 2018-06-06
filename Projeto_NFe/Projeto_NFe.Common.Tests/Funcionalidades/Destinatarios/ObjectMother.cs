using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades.Destinatarios
{
    public static partial class ObjectMother
    {
        public static Destinatario PegarDestinatarioValidoComDependencias(Endereco endereco, IDocumento documento)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = documento,
                InscricaoEstadual = "636.330.646.110",
                Endereco = endereco
            };

        }
        public static Destinatario PegarDestinatarioValidoComCNPJ(Endereco endereco, IDocumento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = cnpj,
                InscricaoEstadual = "636.330.646.110",
                Endereco = endereco

            };

        }
        public static Destinatario PegarDestinatarioValidoComCNPJSemDependencias()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                InscricaoEstadual = "636.330.646.110",
                Documento = new CNPJ()
                {
                    NumeroComPontuacao = "99.327.235/0001-50"
                },
                Endereco = new Endereco()
                {
                    Logradouro = "Logradouro",
                    Numero = 1,
                    Bairro = "Bairro",
                    Municipio = "Município",
                    Estado = "Estado",
                    Pais = "País"
                },

            };

        }

        public static Destinatario PegarDestinatarioSemNome(Endereco endereco, IDocumento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "",
                Documento = cnpj,
                InscricaoEstadual = "636.330.646.110",
                Endereco = endereco
            };

        }

        public static Destinatario PegarDestinatarioSemDocumento(Endereco endereco, IDocumento cpf)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = null,
                Endereco = endereco

            };

        }

        public static Destinatario PegarDestinatarioComCNPJSemInscricaoEstadual(Endereco endereco, IDocumento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = cnpj,
                InscricaoEstadual = "",
                Endereco = endereco
            };

        }

        public static Destinatario PegarDestinatarioComInscricaoEstadualAcimaDoPadrao(Endereco endereco, IDocumento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = cnpj,
                InscricaoEstadual = "636.330.646.000000000",
                Endereco = endereco
            };

        }
        public static Destinatario PegarDestinatarioValidoComCPF()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = new CPF()
                {
                    NumeroComPontuacao = "603.486.029-60"
                },
                Endereco = new Endereco()
                {
                    Logradouro = "Logradouro",
                    Numero = 1,
                    Bairro = "Bairro",
                    Municipio = "Município",
                    Estado = "Estado",
                    Pais = "País"
                },
                
            };
        }

        public static Destinatario PegarDestinatarioSemEndereco(Endereco endereco, IDocumento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = cnpj,
                Endereco = endereco,
                InscricaoEstadual = "636.330.646.0"
            };
        }
    }
}
