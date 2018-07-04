using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.WinApp.Base
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();

        public abstract void Editar();

        public abstract void Excluir();

        public abstract void AtualizarListagem();

        public abstract string ObtemTipo();
       

       
    }
}
