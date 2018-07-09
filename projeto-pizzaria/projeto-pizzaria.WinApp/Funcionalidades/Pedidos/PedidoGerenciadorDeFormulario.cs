using projeto_pizzaria.Applications.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.helpers.VisibleBotoes;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Clientes;
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
    public class PedidoGerenciadorDeFormulario : GerenciadorDeFormulario
    {
        public override void Adicionar()
        {
            RealizarPedido_Dialog dialogRealizarPedido = new RealizarPedido_Dialog(new ClienteServico(new ClienteRepositorioSQL(new PizzariaContexto())));

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

        public override VisibleBotao ObterPropriedadeVisibleDosBotoes()
        {
            return new VisibleBotao()
            {
                Adicionar = true
            };
        }
    }
}
