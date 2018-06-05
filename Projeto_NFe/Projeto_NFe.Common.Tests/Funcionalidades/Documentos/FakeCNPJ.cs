using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades.Documentos
{
    public class FakeCNPJ : CNPJ
    {
        //public string Numero { get; set; }
        //public string NumeroComPontuacao { get; set; }

        public override string ObterTipo()
        {
            return base.ObterTipo();
        }

    }
}
