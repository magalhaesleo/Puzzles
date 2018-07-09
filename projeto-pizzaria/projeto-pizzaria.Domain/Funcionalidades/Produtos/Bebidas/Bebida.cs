using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Produtos.Bebidas
{
    public class Bebida : Produto
    {
        public override string Tipo
        {
            get
            {
                return "Bebida";
            }
        }
    }
}
