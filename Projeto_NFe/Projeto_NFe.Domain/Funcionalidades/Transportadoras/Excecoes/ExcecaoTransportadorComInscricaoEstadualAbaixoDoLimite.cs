using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes
{
    public class ExcecaoTransportadorComInscricaoEstadualAbaixoDoLimite : ExcecaoDeNegocio
    {
        public ExcecaoTransportadorComInscricaoEstadualAbaixoDoLimite() : base("A quantidade de caracteres da inscrição estadual esta abaixo do padrão")
        {
        }
    }
}
