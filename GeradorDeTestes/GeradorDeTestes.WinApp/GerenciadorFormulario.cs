using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.WinApp
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();

        public abstract void Excluir();

        public abstract void CarregarListagem();
    }
}
