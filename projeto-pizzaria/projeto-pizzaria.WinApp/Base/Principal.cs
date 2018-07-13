using projeto_pizzaria.Applications.Funcionalidades.Clientes;
using projeto_pizzaria.Applications.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.helpers.EnableBotoes;
using projeto_pizzaria.Domain.helpers.VisibleBotoes;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Adicionais;
using projeto_pizzaria.Infra.Data.Funcionalidades.Clientes;
using projeto_pizzaria.Infra.Data.Funcionalidades.Pedidos;
using projeto_pizzaria.Infra.Data.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Sabores;
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
        //Instancias de servicos
        ClienteServico _clienteServico;
        PedidoServico _pedidoServico;
        //

        //Instancias de repositórios
        ClienteRepositorioSQL _clienteRepositorioSQL;
        PedidoRepositorioSQL _pedidoRepositorioSQL;
        SaborRepositorioSQL _saborRepositorioSQL;
        AdicionalRepositorioSQL _adicionalRepositorioSQL;
        ProdutoGenericoRepositorioSQL _produtoGenericoRepositorioSQL;
        //

        //Instancias de repositórios
        PizzariaContexto _pizzariaContexto;
        //

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

            //Obtendo o UserControl do Gerenciador de formulário
            painelFormularioPrincipal.Controls.Add(_gerenciadorDeFormulario.ObterUserControl());
        }

        private void botaoRealizarPedido_Click(object sender, EventArgs e)
        {
            CarregarGerenciadorDeFormulario(ObterPedidoGerenciadorDeFormulario());
        }
        
        private PedidoGerenciadorDeFormulario ObterPedidoGerenciadorDeFormulario()
        {
            if (_pedidoGerenciadorDeFormulario == null)
            {
                return _pedidoGerenciadorDeFormulario = new PedidoGerenciadorDeFormulario(ObterInstanciaDePedidoServico(), ObterInstanciaDeClienteServico());
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


        private PedidoServico ObterInstanciaDePedidoServico()
        {
            if (_pedidoServico == null)
            {
                _pedidoServico = new PedidoServico(ObterInstaciaDePedidoRepositorio(), ObterInstanciaDeSaborRepositorio(), ObterInstanciaDeAdicionalRepositorio(), ObterInstanciaDeProdutoGenericoRepositorioSQL());
                return _pedidoServico;
            }
            else
            {
                return _pedidoServico;
            }
        }


        private ClienteServico ObterInstanciaDeClienteServico()
        {
            if (_clienteServico == null)
            {
                _clienteServico = new ClienteServico(ObterInstaciaDeClienteRepositorio());
                return _clienteServico;
            }
            else
            {
                return _clienteServico;
            }
        }

        private ClienteRepositorioSQL ObterInstaciaDeClienteRepositorio()
        {
            if (_clienteRepositorioSQL == null)
            {
                _clienteRepositorioSQL = new ClienteRepositorioSQL(ObterInstaciaDoContextoSQL());
                return _clienteRepositorioSQL;
            }
            else
            {
                return _clienteRepositorioSQL;
            }
        }
        private PedidoRepositorioSQL ObterInstaciaDePedidoRepositorio()
        {
            if (_pedidoRepositorioSQL == null)
            {
                _pedidoRepositorioSQL = new PedidoRepositorioSQL(ObterInstaciaDoContextoSQL());
                return _pedidoRepositorioSQL;
            }
            else
            {
                return _pedidoRepositorioSQL;
            }
        }

        private SaborRepositorioSQL ObterInstanciaDeSaborRepositorio()
        {
            if (_saborRepositorioSQL == null)
            {
                _saborRepositorioSQL = new SaborRepositorioSQL(ObterInstaciaDoContextoSQL());
                return _saborRepositorioSQL;
            }
            else
            {
                return _saborRepositorioSQL;
            }
        }

        private ProdutoGenericoRepositorioSQL ObterInstanciaDeProdutoGenericoRepositorioSQL()
        {
            if (_produtoGenericoRepositorioSQL == null)
            {
                _produtoGenericoRepositorioSQL = new ProdutoGenericoRepositorioSQL(ObterInstaciaDoContextoSQL());
                return _produtoGenericoRepositorioSQL;
            }
            else
            {
                return _produtoGenericoRepositorioSQL;
            }
        }
        private AdicionalRepositorioSQL ObterInstanciaDeAdicionalRepositorio()
        {
            if (_adicionalRepositorioSQL == null)
            {
                _adicionalRepositorioSQL = new AdicionalRepositorioSQL(ObterInstaciaDoContextoSQL());
                return _adicionalRepositorioSQL;
            }
            else
            {
                return _adicionalRepositorioSQL;
            }
        }
        private PizzariaContexto ObterInstaciaDoContextoSQL()
        {
            if (_pizzariaContexto == null)
            {
                _pizzariaContexto = new PizzariaContexto();
                return _pizzariaContexto;
            }
            else
            {
                return _pizzariaContexto;
            }
        }

    }
}
