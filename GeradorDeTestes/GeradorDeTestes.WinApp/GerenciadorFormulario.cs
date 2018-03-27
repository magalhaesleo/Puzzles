using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();

        public abstract void Editar();

        public abstract void Excluir();

        public abstract UserControl CarregarListControl();

        public abstract void AtualizarListagem();

        public abstract string ObtemTipo();
    }
}
