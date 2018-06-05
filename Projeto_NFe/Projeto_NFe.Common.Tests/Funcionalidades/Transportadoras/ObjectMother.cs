using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades.Transportadoras
{
    public static partial class ObjectMother
    {
        public static Transportador PegarTransportadorValidoComCNPJ(Endereco endereco, CNPJ cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true         
            };
        }

        public static Transportador PegarTransportadorValidoComCPF(Endereco endereco, CPF cpf)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true
            };
        }

        public static Transportador PegarTransportadorComInscricaoEstadualAcimaDoLimite(Endereco endereco, CNPJ cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.11000",
                ResponsabilidadeFrete = true
            };
        }

        public static Transportador PegarTransportadorComInscricaoEstadualAbaixoDoLimite(Endereco endereco, CNPJ cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.1",
                ResponsabilidadeFrete = true
            };
        }

        public static Transportador PegarTransportadorSemNome(Endereco endereco, CNPJ cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true
            };
        }

        public static Transportador PegarTransportadorSemEndereco(CNPJ cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true
            };
        }

        public static Transportador PegarTransportadorComInscricaoEstadualNula(Endereco endereco, CNPJ cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "",
                ResponsabilidadeFrete = true
            };
        }

        public static Transportador PegarTransportadorSemDocumento(Endereco endereco)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true
            };
        }
    }
}
