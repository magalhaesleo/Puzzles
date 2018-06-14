using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.XML.Funcionalidades.Emitentes
{
    public static class EmitenteXML
    {

        public static EmitenteXMLModelo FormaObjetoEmitenteXMLModelo(Emitente emitente)
        {
            EmitenteXMLModelo emitenteXMLModelo = new EmitenteXMLModelo();

            emitenteXMLModelo.CNPJ = emitente.CNPJ;
            emitenteXMLModelo.RazaoSocial = emitente.RazaoSocial;
            emitenteXMLModelo.NomeFantasia = emitente.NomeFantasia;
            emitenteXMLModelo.InscricaoEstadual = emitente.InscricaoEstadual;
            emitenteXMLModelo.InscricaoMunicipal = emitente.InscricaoMunicipal;

            return emitenteXMLModelo;
        }

    }
}
