using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscalXMLModelo
    {
        private string _chaveAcesso;
        public string ChaveAcesso
        {
            get
            {
                return "Nfe" + _chaveAcesso;
            }
            set
            {
                _chaveAcesso = value;
            }
        }
        public string NaturezaOperacao { get; set; }
        public DateTime? DataEmissao { get; set; }
        public EmitenteXMLModelo Emitente { get; set; }
        public DestinatarioXMLModelo Destinatario { get; set; }
        public List<ProdutoXMLModelo> Produtos { get; set; }
        public double ValorTotalICMS { get; set; }
        public double ValorTotalFrete { get; set; }
        public double ValorTotalIPI { get; set; }
        public double ValorTotalProdutos { get; set; }
        public double ValorTotalNota { get; set; }
    }
}
