using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
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
        public static Destinatario PegarDestinatarioValidoComCNPJ()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = new CNPJ()
                {
                    NumeroComPontuacao = "32.993.282/0001-61"
                },
                InscricaoEstadual = "636.330.646.110"

            };

        }

 
        public static Destinatario PegarDestinatarioSemNome()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "",
                Documento = new CNPJ()
                {
                    NumeroComPontuacao = "32.993.282/0001-61"
                },
                 InscricaoEstadual = "636.330.646.110"
            };

        }

        public static Destinatario PegarDestinatarioSemDocumento()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = null

            };

        }

        public static Destinatario PegarDestinatarioComCNPJ()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = new CNPJ()
                {
                    NumeroComPontuacao = "32.993.282/0001-61"
                },
                InscricaoEstadual = "636.330.646.110"
            };

        }

        public static Destinatario PegarDestinatarioComCNPJSemInscricaoEstadual()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = new CNPJ()
                {
                    NumeroComPontuacao = "32.993.282/0001-61"
                },
                InscricaoEstadual = ""
            };

        }

        public static Destinatario PegarDestinatarioComInscricaoEstadualAbaixoDoPadrao()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = new CNPJ()
                {
                    NumeroComPontuacao = "32.993.282/0001-61"
                },
                InscricaoEstadual = "636.330.646.0"
            };

        }

        public static Destinatario PegarDestinatarioComInscricaoEstadualAcimaDoPadrao()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = new CNPJ()
                {
                    NumeroComPontuacao = "32.993.282/0001-61"
                },
                InscricaoEstadual = "636.330.646.000000000"
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
                }
          };

        }
    }
}
