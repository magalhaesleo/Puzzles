using NFe.Infra.XML.Features.NotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal.Mapeadores;
using Projeto_NFe.Infrastructure.XML.Serializador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal
{
    public static class NotaFiscalXMLRepositorio
    {
       public static string Serializar(NotaFiscal notaFiscal)
        {
            NotaFiscalModeloXml notaFiscalXML = NotaFiscalXMLMapper.MontarNotaFiscalXMLModelo(notaFiscal);
            return XMLHelper.Serializar(notaFiscalXML);
        }

        public static void Serializar(NotaFiscal notaFiscal, string path)
        {
            NotaFiscalModeloXml notaFiscalXML = NotaFiscalXMLMapper.MontarNotaFiscalXMLModelo(notaFiscal);
            XMLHelper.SerializarParaAquivo(notaFiscalXML, path);
        }
    }
}
