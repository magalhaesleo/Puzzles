using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioSemEndereco : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioSemEndereco() : base("O destinatário deve possuir um endereço.")
        {
        }
    }
}
