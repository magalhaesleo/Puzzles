using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.XML.Funcionalidades.Produtos
{
    public class ProdutoXMLModelo
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual double ValorUnitario { get; set; }
        public virtual double ValorTotal { get; set; }
        public virtual double AliquotaICMS { get; set; }
        public virtual double ValorICMS { get; set; }
}
