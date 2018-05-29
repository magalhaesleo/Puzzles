using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoRazaoSocialEmitentePequeno : ExcecaoDeNegocio
    {
        public ExcecaoRazaoSocialEmitentePequeno() : base("A Razão Social do emitente deve possuir no minimo 5 caracteres")
        {

        }
    }
}
