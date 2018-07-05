using projeto_pizzaria.Domain.helpers.EnableBotoes;
using projeto_pizzaria.Domain.helpers.VisibleBotoes;
using projeto_pizzaria.WinApp.Funcionalidades.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_pizzaria.WinApp.Base
{
    public partial class Principal : Form
    {
        private GerenciadorDeFormulario _gerenciadorDeFormulario;
        private PedidoGerenciadorDeFormulario _pedidoGerenciadorDeFormulario;

        public Principal()
        {
            InitializeComponent();
        }

        private void CarregarGerenciadorDeFormulario(GerenciadorDeFormulario gerenciadorDeFormularioAtual)
        {
            _gerenciadorDeFormulario = gerenciadorDeFormularioAtual;

            definirPropriedadeVisibleDosBotoes(_gerenciadorDeFormulario.ObterPropriedadeVisibleDosBotoes());
        }

        private void botaoRealizarPedido_Click(object sender, EventArgs e)
        {
            CarregarGerenciadorDeFormulario(ObterPedidoGerenciadorDeFormulario());
        }
        
        private PedidoGerenciadorDeFormulario ObterPedidoGerenciadorDeFormulario()
        {
            if (_pedidoGerenciadorDeFormulario == null)
            {
                return _pedidoGerenciadorDeFormulario = new PedidoGerenciadorDeFormulario();
            }
            else
                return _pedidoGerenciadorDeFormulario;
        }

        private void definirPropriedadeVisibleDosBotoes(VisibleBotao visibleBotao)
        {
            botaoAdicionar.Visible = visibleBotao.Adicionar;
        }

        private void botaoAdicionar_Click(object sender, EventArgs e)
        {
            _gerenciadorDeFormulario.Adicionar();
        }
    }
}
