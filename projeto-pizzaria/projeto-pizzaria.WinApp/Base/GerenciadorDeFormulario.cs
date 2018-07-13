using projeto_pizzaria.Domain.helpers.VisibleBotoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_pizzaria.WinApp.Base
{
    public abstract class GerenciadorDeFormulario
    {
        public abstract void Adicionar();

        public abstract void Editar();

        public abstract void Excluir();

        public abstract void AtualizarListagem();

        public abstract string ObtemTipo();

        public abstract VisibleBotao ObterPropriedadeVisibleDosBotoes();

        public abstract UserControl ObterUserControl();


    }
}
