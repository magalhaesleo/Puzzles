using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoListaDeProdutoVazia : ExcecaoDeNegocio
    {
        public ExcecaoListaDeProdutoVazia() : base("A nota fiscal não pode ser emitida sem nenhum produto.")
        {
        }
    }
}
