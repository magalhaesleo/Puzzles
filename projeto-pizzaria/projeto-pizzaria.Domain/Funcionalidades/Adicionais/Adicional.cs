using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Adicionais
{
    public class Adicional : Produto
    {
        public override string ObterTipo()
        {
            return "Adicional";
        }
    }
}
