using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
   public class ExcecaoEmitenteSemNome : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteSemNome() : base ("O Emitente deve possuir um nome fantasia")
        {

        }
    }
}
