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
            if(_pedidoServico == null)
            {
                return new PedidoServico(ObterInstaciaDePedidoRepositorio(), ObterInstanciaDeSaborRepositorio(), ObterInstanciaDeAdicionalRepositorio(), ObterInstanciaDeProdutoGenericoRepositorioSQL());
            }
            else
            {
                return _pedidoServico;
            }
        }


        private ClienteServico ObterInstanciaDeClienteServico()
        {
            if (_pedidoServico == null)
            {
                return new ClienteServico(ObterInstaciaDeClienteRepositorio());
            }
            else
            {
                return _clienteServico;
            }
        }

        private ClienteRepositorioSQL ObterInstaciaDeClienteRepositorio()
        {
            if (_pedidoRepositorioSQL == null)
            {
                return new ClienteRepositorioSQL(ObterInstaciaDoContextoSQL());
            }
            else
            {
                return _clienteRepositorioSQL;
            }
        }
        private PedidoRepositorioSQL ObterInstaciaDePedidoRepositorio()
        {
            if(_pedidoRepositorioSQL == null)
            {
                return new PedidoRepositorioSQL(ObterInstaciaDoContextoSQL());
            }else
            {
                return _pedidoRepositorioSQL;
            }
        }

        private SaborRepositorioSQL ObterInstanciaDeSaborRepositorio()
        {
            if (_saborRepositorioSQL == null)
            {
                return new SaborRepositorioSQL(ObterInstaciaDoContextoSQL());
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
                return new ProdutoGenericoRepositorioSQL(ObterInstaciaDoContextoSQL());
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
                return new AdicionalRepositorioSQL(ObterInstaciaDoContextoSQL());
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
                return new PizzariaContexto();
            }
            else
            {
                return _pizzariaContexto;
            }
        }

    }
}
