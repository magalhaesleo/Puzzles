using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.ProdutosGenericos
{
    public class ProdutoGenericoConfiguracao : EntityTypeConfiguration<ProdutoGenerico>
    {
        public ProdutoGenericoConfiguracao()
        {
            ToTable("TBProdutoGenerico");

            Property(p => p.Descricao);

            Property(p => p.Valor);
        }
    }
}
