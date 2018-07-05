using projeto_pizzaria.Applications.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_pizzaria.WinApp.Funcionalidades.Pedidos.RealizarPedido
{
    public partial class RealizarPedido_Dialog : Form
    {
        ClienteServico _clienteServico;

        public RealizarPedido_Dialog(ClienteServico clienteServico)
        {
            InitializeComponent();

            PopularAtributosDaClasse(clienteServico);
        }
        public void PopularAtributosDaClasse(ClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        private IEnumerable<Cliente> BuscarClientePorTelefone(string digitosInformadosNaPesquisa)
        {
            return _clienteServico.BuscarClientePorTelefone(digitosInformadosNaPesquisa);
        }

        private void PopularComboboxDeClientes(IEnumerable<Cliente> listaDeClientesBuscados)
        {
            //limpando a lista de clientes anterior
            comboBoxCliente.Items.Clear();

            //Populando o combobox de cliente
            foreach (var cliente in listaDeClientesBuscados)
            {
                comboBoxCliente.Items.Add(cliente);
            }
        }
        private void maskedTextBoxBuscarPorTelefone_TextChanged(object sender, EventArgs e)
        {
            // Pegando os valores do campo de busca por telefone e atribuindo em uma váriavel que será passada por parâmetro no método 'BuscarClientePorTelefone'
            string digitosInformadosNaPesquisa = maskedTextBoxBuscarPorTelefone.Text;

            //Preenchendo a lista de clientes encontrados
            IEnumerable<Cliente> listaDeClientesBuscados = BuscarClientePorTelefone(digitosInformadosNaPesquisa);

            //Populando comboBoxDeClientes
            PopularComboboxDeClientes(listaDeClientesBuscados);
        }
    }
}
