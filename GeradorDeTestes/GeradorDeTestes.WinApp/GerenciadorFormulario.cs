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
        public abstract void Adicionar(Object objeto);

        public abstract void Excluir(Object objecto);

        public abstract UserControl CarregarListControl();

        public abstract UserControl CarregarButtonsControl();
    }
}
