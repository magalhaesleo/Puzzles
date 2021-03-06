﻿using projeto_pizzaria.Applications.Funcionalidades.Clientes;
using projeto_pizzaria.Applications.Funcionalidades.Pedidos;
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
        private readonly PedidoServico _pedidoServico;
        private readonly ClienteServico _clienteServico;
        private  UserControlPedido _userControlPedido;

        public PedidoGerenciadorDeFormulario(PedidoServico pedidoServico, ClienteServico clienteServico)
        {
            _pedidoServico = pedidoServico;
            _clienteServico = clienteServico;

        }
        public override void Adicionar()
        {
            RealizarPedido_Dialog dialogRealizarPedido = new RealizarPedido_Dialog(_clienteServico, _pedidoServico);

            DialogResult resultadoDialogRealizarPedido = dialogRealizarPedido.ShowDialog();

            if (resultadoDialogRealizarPedido == DialogResult.OK)
            {
                try
                {
                    _pedidoServico.Adicionar(dialogRealizarPedido.Pedido);
                    MessageBox.Show("Pedido realizado com sucesso");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }

            AtualizarListagem();
        }

        public override void AtualizarListagem()
        {
            _userControlPedido.AtualizarListaDePedidos(_pedidoServico.BuscarTodos());
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
            return "Você esta no gerenciamento de pedidos";
        }

        public override VisibleBotao ObterPropriedadeVisibleDosBotoes()
        {
            return new VisibleBotao()
            {
                Adicionar = true
            };
        }

        public override UserControl ObterUserControl()
        {
            if(_userControlPedido == null)
            {
                 _userControlPedido = new UserControlPedido();
                AtualizarListagem();
                return _userControlPedido;
            }
            else
            {
                AtualizarListagem();
                return _userControlPedido;
            }
        }

      
    }
}
