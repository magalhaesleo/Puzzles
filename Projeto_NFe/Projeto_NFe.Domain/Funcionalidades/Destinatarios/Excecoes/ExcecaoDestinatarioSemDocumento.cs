using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioSemDocumento : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioSemDocumento() : base("Não foi preenchido o CNPJ/CPF do destinatário")
        {
        }
    }
}
