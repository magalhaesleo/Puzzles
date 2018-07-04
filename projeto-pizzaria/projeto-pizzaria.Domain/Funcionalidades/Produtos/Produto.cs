using projeto_pizzaria.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Produtos
{
    public abstract class Produto : Entidade
    {
        public virtual double Valor { get; set; }

        public abstract string ObterTipo();
    }
}
