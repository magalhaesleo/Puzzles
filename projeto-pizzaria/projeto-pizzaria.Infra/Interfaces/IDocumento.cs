using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Interfaces
{
    public interface IDocumento
    {
        string NumeroComPontuacao { get; set; }
        void Validar();
        string ObterTipo();
    }
}
