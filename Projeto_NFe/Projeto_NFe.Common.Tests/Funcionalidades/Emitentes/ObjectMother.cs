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
        public static Emitente PegarEmitenteValido(Endereco endereco)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = "05638499000180",
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

    }
}
