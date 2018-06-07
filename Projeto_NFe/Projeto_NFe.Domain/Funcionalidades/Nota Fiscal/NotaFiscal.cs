using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscal : Entidade
    {
        public Transportador Transportador { get; set; }
        public Destinatario Destinatario { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime DataEntrada { get; set; }
        public void GerarCodigoDeAcesso()
        {
        }
        public void Validar()
        {
            if (Transportador == null)
                throw new ExcecaoTransportadorInvalido();
        }
    }
}
