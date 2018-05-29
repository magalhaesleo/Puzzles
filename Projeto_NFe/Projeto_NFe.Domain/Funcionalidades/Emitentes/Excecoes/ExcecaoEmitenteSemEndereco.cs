using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoEmitenteSemEndereco : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteSemEndereco(): base("O Emitente deve possuir um Endereço.")
        {
        }
    }
}
