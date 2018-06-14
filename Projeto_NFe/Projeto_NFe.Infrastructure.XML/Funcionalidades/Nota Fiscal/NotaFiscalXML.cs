using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Emitentes;
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
    public static class NotaFiscalXML
    {
        public static string Serializar(NotaFiscal notaFiscal, string path)
        {
            string xml = "";
            using (XmlTextWriter textWriter = new XmlTextWriter(path, Encoding.UTF8))
            {
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("Nfe");

                textWriter.WriteStartElement("infNFe");

                textWriter.WriteStartAttribute("Id");//Atributos do Nó
                textWriter.WriteString(notaFiscal.ChaveAcesso);// escrevendo no atributo
                textWriter.WriteEndAttribute();// finalizando o atributo

                textWriter.WriteStartAttribute("versao");//Atributos do Nó
                textWriter.WriteString("3.10");// escrevendo no atributo
                textWriter.WriteEndAttribute();// finalizando o atributo

                textWriter.WriteEndElement();//infNFe
                textWriter.WriteEndElement();//Nfe
            }
            return xml;
        }



        //                using (XmlWriter writer = new XmlTextWriter(path, Encoding.UTF8))
        //        {
        //            XmlDeclaration xmldecl =
        //            XmlNode docNode = writer.CreateXmlDeclaration("1.0", "UTF-8", null);
        //            doc.AppendChild(docNode);
        //            writer.a
        //            writer.WriteStartElement("NFe");
        //writer.WriteEndElement();
        //        }
        //public static T Deserialize<T>(this string obj)
        //{
        //    using (XmlReader reader = XmlReader.Create(new StringReader(obj)))
        //    {
        //        XmlSerializer serializer = new XmlSerializer(typeof(T));
        //        return (T)serializer.Deserialize(reader);
        //    }
        //}

        private static NotaFiscalXMLModelo FormaObjetoNotaFiscalXMLModelo(NotaFiscal notaFiscal)
        {
            NotaFiscalXMLModelo notaFiscalXMLModelo = new NotaFiscalXMLModelo();

            notaFiscalXMLModelo.ChaveAcesso = notaFiscal.ChaveAcesso;
            notaFiscalXMLModelo.NaturezaOperacao = notaFiscal.NaturezaOperacao;
            notaFiscalXMLModelo.DataEmissao = notaFiscal.DataEmissao;
            notaFiscalXMLModelo.Emitente = EmitenteXML.FormaObjetoEmitenteXMLModelo(notaFiscal.Emitente);
            notaFiscal.ValorTotalICMS = notaFiscal.ValorTotalICMS;

            return notaFiscalXMLModelo;
        }

       

    }
}
