using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes
{
    public class ExcecaoTransportadorComInscricaoEstadualNula : ExcecaoDeNegocio
    {
        public ExcecaoTransportadorComInscricaoEstadualNula() : base("O Transportador deve possuir uma inscrição estadual.")
        {
        }
    }
}
