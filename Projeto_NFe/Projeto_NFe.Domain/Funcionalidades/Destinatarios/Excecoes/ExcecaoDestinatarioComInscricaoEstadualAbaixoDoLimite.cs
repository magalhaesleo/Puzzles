using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioComInscricaoEstadualAbaixoDoLimite : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioComInscricaoEstadualAbaixoDoLimite() : base("A quantidade de caracteres da inscrição estadual esta abaixo do padrão")
        {
        }
    }
}
