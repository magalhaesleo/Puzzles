using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioComInscricaoEstadualAcimaDoLimite : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioComInscricaoEstadualAcimaDoLimite() : base("A inscricão estadual esta acima do limite")
        {
        }
    }
}
