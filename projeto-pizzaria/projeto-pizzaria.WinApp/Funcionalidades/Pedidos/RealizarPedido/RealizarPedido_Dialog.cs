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
        bool _pedidoEmAndamento = false;

        public RealizarPedido_Dialog(ClienteServico clienteServico)
        {
            InitializeComponent();

            PopularAtributosDaClasse(clienteServico);
            PopularComboBoxTipoProduto();
            PopularComboBoxSabores();
            PopularComboBoxAdicionais();
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
            maskedTextBoxBuscarPorTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            // Pegando os valores do campo de busca por telefone e atribuindo em uma váriavel que será passada por parâmetro no método 'BuscarClientePorTelefone'
            string digitosInformadosNaPesquisa = maskedTextBoxBuscarPorTelefone.Text;

            //Preenchendo a lista de clientes encontrados
            IEnumerable<Cliente> listaDeClientesBuscados = BuscarClientePorTelefone(digitosInformadosNaPesquisa);

            //Populando comboBoxDeClientes
            PopularComboboxDeClientes(listaDeClientesBuscados);
        }

        private void PopularComboBoxTipoProduto()
        {
            comboBoxTipoProduto.Items.Add("Pizza");
            comboBoxTipoProduto.Items.Add("Calzone");
            comboBoxTipoProduto.Items.Add("Bebidas");
        }

        private void PopularComboBoxSabores()
        {
            comboBoxSabores.Items.Add("Margarida com requeijão ao molho de ló");
            comboBoxSabores.Items.Add("IUASUIEHASE");
            comboBoxSabores.Items.Add("AAAAAAAAAAAAAAA");
        }

        private void PopularComboBoxTipoBebida()
        {
            comboBoxItem.Items.Add("Coca cola");
            comboBoxItem.Items.Add("Sprite");
        }

        private void PopularComboBoxAdicionais()
        {
            comboBoxAdicionais.Items.Add("Cheddar");
            comboBoxAdicionais.Items.Add("Catupiry");
        }
        private void comboBoxTipoProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReiniciarValoresDeItemPedido();


            if (_pedidoEmAndamento)
            {

                DialogResult resultado = MessageBox.Show("Tem certeze que deseja mudar o contexto de produto? você perderá todo o progresso até aqui", "Atenção!", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    if (comboBoxTipoProduto.SelectedItem == "Bebidas")
                    {
                        LimparValoresDeItemPedido();
                        PopularComboBoxTipoBebida();
                        comboBoxItem.Enabled = true;
                        _pedidoEmAndamento = true;
                    }

                    if (comboBoxTipoProduto.SelectedItem == "Calzone")
                    {
                        LimparValoresDeItemPedido();
                        PopularComboBoxSabores();
                        comboBoxSabores.Enabled = true;
                        listBoxSabores.Enabled = true;
                        botaoAdicionarSabor.Enabled = true;
                        _pedidoEmAndamento = true;
                    }

                    if (comboBoxTipoProduto.SelectedItem == "Pizza")
                    {
                        LimparValoresDeItemPedido();
                        PopularComboBoxSabores();
                        PopularComboBoxAdicionais();
                        comboBoxSabores.Enabled = true;
                        listBoxSabores.Enabled = true;
                        botaoAdicionarSabor.Enabled = true;
                        _pedidoEmAndamento = true;
                    }
                }
            }
            else
            {
                if (comboBoxTipoProduto.SelectedItem == "Bebidas")
                {
                    LimparValoresDeItemPedido();
                    PopularComboBoxTipoBebida();
                    comboBoxItem.Enabled = true;
                    _pedidoEmAndamento = true;
                }

                if (comboBoxTipoProduto.SelectedItem == "Calzone")
                {
                    LimparValoresDeItemPedido();
                    PopularComboBoxSabores();
                    comboBoxSabores.Enabled = true;
                    listBoxSabores.Enabled = true;
                    botaoAdicionarSabor.Enabled = true;
                    _pedidoEmAndamento = true;
                }

                if (comboBoxTipoProduto.SelectedItem == "Pizza")
                {
                    LimparValoresDeItemPedido();
                    PopularComboBoxSabores();
                    PopularComboBoxAdicionais();
                    comboBoxSabores.Enabled = true;
                    listBoxSabores.Enabled = true;
                    botaoAdicionarSabor.Enabled = true;
                    _pedidoEmAndamento = true;
                }
            }
               
        }

        private void ReiniciarValoresDeItemPedido()
        {
            comboBoxItem.Enabled = false;
            radioButtonPizzaGrande.Enabled = false;
            radioButtonPizzaMedia.Enabled = false;
            radioButtonPizzaPequena.Enabled = false;
            comboBoxSabores.Enabled = false;
            comboBoxSabores.Enabled = false;
            botaoAdicionarSabor.Enabled = false;
            botaoAdicionarBorda.Enabled = false;
            botaoRemoverBorda.Enabled = false;
            botaoRemoverSabor.Enabled = false;
            comboBoxAdicionais.Enabled = false;
            comboBoxAdicionais.Enabled = false;
            botaoAdicionarItemPedido.Enabled = false;
            botaoRemoverItemPedido.Enabled = false;
        }

        private void LimparValoresDeItemPedido()
        {
            comboBoxItem.Items.Clear();
            comboBoxSabores.Items.Clear();
            comboBoxSabores.Items.Clear();
            comboBoxAdicionais.Items.Clear();
            comboBoxAdicionais.Items.Clear();
            listBoxAdicionais.Items.Clear();
            listBoxSabores.Items.Clear();
            listBoxItensPedido.Items.Clear();
        }

        private void botaoAdicionarSabor_Click(object sender, EventArgs e)
        {
            //Adicionando sabor no listBox de Sabores
            listBoxSabores.Items.Add(comboBoxSabores.SelectedItem);

            // Habilitando comboBox e adição de adicionais
            if (comboBoxTipoProduto.SelectedItem == "Pizza")
            {
                habilitarAdicaoDeAdicionais();
            }

            //Removendo item adicionado no listBox de sabores do comboBox de sabores
            comboBoxSabores.Items.RemoveAt(comboBoxSabores.SelectedIndex);

            // Deixando disable caso o tipo de item seja pizza e ja hajam dois sabores selecionados ou calzone e já tenha um sabor
            validarEnabledDeAdicionarSabor();

            ValidarDisponibilidadeDoBotaoAdicionarItemPedido();

            botaoAdicionarSabor.Enabled = false;
        }

        private void botaoRemoverSabor_Click(object sender, EventArgs e)
        {
            //Adicionando o item que será removido no comboBox de Sabores novamente
            comboBoxSabores.Items.Add(listBoxSabores.SelectedItem);

            //Removendo sabor selecionado no listBox de sabores selecionado
            listBoxSabores.Items.RemoveAt(listBoxSabores.SelectedIndex);

            // Deixando o botão de adicionar sabor Enable caso a quantidade de sabores adicionados no listBox de sabor é menor que 2 e o tipo de item é pizza 
            if (comboBoxTipoProduto.SelectedItem == "Pizza" && listBoxSabores.Items.Count < 2)
            {
                botaoAdicionarSabor.Enabled = true;
            }

            // Deixando o botão de adicionar sabor Enable caso a quantidade de sabores adicionados no listBox de sabor é menor que 1 e o tipo de item é Calzone 
            if (comboBoxTipoProduto.SelectedItem == "Calzone" && listBoxSabores.Items.Count < 1)
            {
                botaoAdicionarSabor.Enabled = true;
            } 

            //Desabilitando grupo de adicionais caso não hajam mais sabores no listBox de sabores e o tipo de item não seja pizza
            if(comboBoxTipoProduto.SelectedItem == "Pizza" && listBoxSabores.Items.Count < 1)
            {
                desabilitarGrupoDeAdicionais();
            }

            botaoRemoverSabor.Enabled = false;
            botaoAdicionarSabor.Enabled = false;
        }

        public void habilitarAdicaoDeAdicionais()
        {
                comboBoxAdicionais.Enabled = true;
                botaoAdicionarBorda.Enabled = true;
                listBoxAdicionais.Enabled = true;
        }
        
        public void desabilitarGrupoDeAdicionais()
        {
            // Limpando valores do listBox
            listBoxAdicionais.Items.Clear();
            comboBoxAdicionais.Items.Clear();

            PopularComboBoxAdicionais();

            comboBoxAdicionais.Enabled = false;
            botaoAdicionarBorda.Enabled = false;

        }

        private void botaoAdicionarBorda_Click(object sender, EventArgs e)
        {
            //adicionando o item selecionado na comboBox na listBoxAdicionais
            listBoxAdicionais.Items.Add(comboBoxAdicionais.SelectedItem);

            //excluindo do comboBox o item que foi selecionado para adicionar na listBoxAdicionais
            comboBoxAdicionais.Items.RemoveAt(comboBoxAdicionais.SelectedIndex);

            //Não permite adicionar mais de um adicional
            desabilitarBotaoAdicionarAdicional();
        }

        private void desabilitarBotaoAdicionarAdicional()
        {
            if (listBoxAdicionais.Items.Count == 1)
            {
                botaoAdicionarBorda.Enabled = false;
            }
        }

        private void listBoxSabores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxSabores.SelectedIndex >= 0)
                botaoRemoverSabor.Enabled = true;

        }

        private void listBoxAdicionais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxAdicionais.SelectedIndex >= 0)
            botaoRemoverBorda.Enabled = true;

            botaoAdicionarBorda.Enabled = false;
        }

        private void botaoRemoverBorda_Click(object sender, EventArgs e)
        {
            comboBoxAdicionais.Items.Add(listBoxAdicionais.SelectedItem);

            listBoxAdicionais.Items.RemoveAt(listBoxAdicionais.SelectedIndex);

            botaoRemoverBorda.Enabled = false;
        }

        private void comboBoxSabores_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            botaoAdicionarSabor.Enabled = true;
            validarEnabledDeAdicionarSabor();
        }

        private void comboBoxAdicionais_SelectedIndexChanged(object sender, EventArgs e)
        {
            botaoAdicionarBorda.Enabled = true;
            desabilitarBotaoAdicionarAdicional();
        }

        private void validarEnabledDeAdicionarSabor()
        {
            if (comboBoxTipoProduto.SelectedItem == "Pizza" && listBoxSabores.Items.Count == 2)
            {
                botaoAdicionarSabor.Enabled = false;
            }

            if (comboBoxTipoProduto.SelectedItem == "Calzone" && listBoxSabores.Items.Count == 1)
            {
                botaoAdicionarSabor.Enabled = false;
            }
        }

        private void botaoAdicionarItemPedido_Click(object sender, EventArgs e)
        {
            
        }

        private void ValidarDisponibilidadeDoBotaoAdicionarItemPedido()
        {
            if(comboBoxTipoProduto.SelectedItem == "Calzone" || comboBoxTipoProduto.SelectedItem == "Pizza" && listBoxSabores.Items.Count > 0 && numericUpDownQuantidade.Value > 0)
            {
                botaoAdicionarItemPedido.Enabled = true;
            }
            else if(comboBoxTipoProduto.SelectedItem == "Bebidas" && comboBoxItem.SelectedIndex >= 0 && numericUpDownQuantidade.Value > 0)
            {
                botaoAdicionarItemPedido.Enabled = true;
            }
            else
            {
                botaoAdicionarItemPedido.Enabled = false;
            }
        }

        private void numericUpDownQuantidade_ValueChanged(object sender, EventArgs e)
        {
            ValidarDisponibilidadeDoBotaoAdicionarItemPedido();
        }
    }
}
