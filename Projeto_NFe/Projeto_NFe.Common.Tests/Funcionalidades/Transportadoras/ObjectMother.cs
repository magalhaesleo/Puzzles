using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades.Transportadoras
{
    public static partial class ObjectMother
    {
        public static Transportador PegarTransportadorValidoComDependencias(Endereco endereco, IDocumento documento)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = documento,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorValidoComCNPJ(Endereco endereco, IDocumento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = cnpj,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorValidoComCPF(Endereco endereco, IDocumento cpf)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = cpf,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorComInscricaoEstadualAcimaDoLimite(Endereco endereco, IDocumento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.11000",
                ResponsabilidadeFrete = true,
                Endereco = endereco, 
                Documento = cnpj
            };
        }


        public static Transportador PegarTransportadorSemNome(Endereco endereco, IDocumento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "",
                Documento = cnpj,
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorSemEndereco(Endereco endereco, IDocumento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = cnpj,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorComInscricaoEstadualNula(Endereco endereco, IDocumento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "",
                ResponsabilidadeFrete = true,
                Endereco = endereco,
                Documento = cnpj
            };
        }

        public static Transportador PegarTransportadorSemDocumento(Endereco endereco, IDocumento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Endereco = endereco,
                Documento = null
            };
        }
    }
}
