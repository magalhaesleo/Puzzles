using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos.Bebidas
{
    public class Bebida : ProdutoGenerico
    {
        public override string Tipo
        {
            get => "Bebida";
            set => Tipo = value;
        }
    }
}
