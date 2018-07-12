using projeto_pizzaria.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos
{
    public abstract class ProdutoGenerico : Entidade
    {
        public virtual string Descricao { get; set; }

        public virtual double Valor { get; set; }

    }
}
