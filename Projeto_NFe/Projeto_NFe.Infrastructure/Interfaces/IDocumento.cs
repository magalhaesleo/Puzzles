using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Interfaces
{
    public interface IDocumento
    {
        string NumeroComPontuacao { get; set; }
        void Validar();

        string ObterTipo();

        
    }
}
