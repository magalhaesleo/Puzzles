using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades.Documentos
{
    public class FakeCPF : CPF
    {

        public override string ObterTipo()
        {
            return base.ObterTipo();
        }
    }
}
