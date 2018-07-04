using projeto_pizzaria.WinApp.Base;
using projeto_pizzaria.WinApp.Funcionalidades.Pedidos.RealizarPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_pizzaria.WinApp.Funcionalidades.Pedidos
{
    public class PedidoGerenciadorDeFormulario : GerenciadorFormulario
    {
        public override void Adicionar()
        {
            RealizarPedido_Dialog dialogRealizarPedido = new RealizarPedido_Dialog();

            DialogResult resultadoDialogRealizarPedido = dialogRealizarPedido.ShowDialog();
        }

        public override void AtualizarListagem()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override string ObtemTipo()
        {
            throw new NotImplementedException();
        }
    }
}
