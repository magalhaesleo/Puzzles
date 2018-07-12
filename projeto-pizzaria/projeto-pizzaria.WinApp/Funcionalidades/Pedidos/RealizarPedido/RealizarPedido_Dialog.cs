using projeto_pizzaria.Applications.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos.Bebidas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
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
        bool _itemPedidoEmAndamento = false;
        Pedido Pedido { get; set; }

        public RealizarPedido_Dialog(ClienteServico clienteServico)
        {
            InitializeComponent();

            PopularAtributosDaClasse(clienteServico);
            PopularComboBoxTipoProduto();
            

            Pedido = new Pedido();
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
            comboBoxTipoProduto.Items.Add(typeof(Pizza).Name);
            comboBoxTipoProduto.Items.Add(typeof(Calzone).Name);
            comboBoxTipoProduto.Items.Add(typeof(ProdutoGenerico).Name);
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
            
            if (_itemPedidoEmAndamento)
            {
                DialogResult resultado = MessageBox.Show("Tem certeze que deseja mudar o contexto de produto? você perderá todo o progresso até aqui", "Atenção!", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    LimparComboBoxSabores();
                    ReiniciarValoresDeItemPedido();
                    LimparValoresDeItemPedido();

                    numericUpDownQuantidade.Enabled = true;

                    if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(ProdutoGenerico).Name)
                    {
                        PopularComboBoxTipoBebida();
                        comboBoxItem.Enabled = true;
                        _itemPedidoEmAndamento = true;
                    }

                    if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Calzone).Name)
                    {
                  
                        PopularComboBoxSabores();
                        comboBoxSabores.Enabled = true;
                        listBoxSabores.Enabled = true;

                        _itemPedidoEmAndamento = true;
                    }

                    if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Pizza).Name)
                    {
                        PopularComboBoxSabores();
                        PopularComboBoxAdicionais();
                        comboBoxSabores.Enabled = true;
                        listBoxSabores.Enabled = true;
                        HabilitarRadioButtonsTamanhos();

                        _itemPedidoEmAndamento = true;
                    }
                }
            }
            else
            {
               
                LimparComboBoxSabores();
                ReiniciarValoresDeItemPedido();
                LimparValoresDeItemPedido();

                numericUpDownQuantidade.Enabled = true;


                if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(ProdutoGenerico).Name)
                {
                    PopularComboBoxTipoBebida();
                    comboBoxItem.Enabled = true;
                    _itemPedidoEmAndamento = true;
                }

                if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Calzone).Name)
                {
                    PopularComboBoxSabores();
                    comboBoxSabores.Enabled = true;
                    listBoxSabores.Enabled = true;
                    _itemPedidoEmAndamento = true;
                }

                if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Pizza).Name)
                {
                    PopularComboBoxSabores();
                    PopularComboBoxAdicionais();
                    comboBoxSabores.Enabled = true;
                    listBoxSabores.Enabled = true;
                    _itemPedidoEmAndamento = true;
                    HabilitarRadioButtonsTamanhos();
                }
            }
        }

        private void ReiniciarValoresDeItemPedido()
        {
            comboBoxItem.Enabled = false;
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
            DesabilitarRadioButtonsTamanhos();
            numericUpDownQuantidade.Enabled = false;
            _itemPedidoEmAndamento = false;
        }

        private void LimparValoresDeItemPedido()
        {
            comboBoxItem.Items.Clear();
            comboBoxAdicionais.Items.Clear();
            LimparComboBoxSabores();
            listBoxAdicionais.Items.Clear();
            listBoxSabores.Items.Clear();
            DesabilitarRadioButtonsTamanhos();
            numericUpDownQuantidade.Value = 0;
        }

        private void botaoAdicionarSabor_Click(object sender, EventArgs e)
        {
            //Adicionando sabor no listBox de Sabores
            listBoxSabores.Items.Add(comboBoxSabores.SelectedItem);

            // Habilitando comboBox e adição de adicionais
            if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Pizza).Name)
            {
                HabilitarAdicaoDeAdicionais();
            }

            //Removendo item adicionado no listBox de sabores do comboBox de sabores
            comboBoxSabores.Items.RemoveAt(comboBoxSabores.SelectedIndex);

            // Deixando disable caso o tipo de item seja pizza e ja hajam dois sabores selecionados ou calzone e já tenha um sabor
            ValidarEnabledDeAdicionarSabor();

            VerificarGrupoDeAdicaoDeAdicional();

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
            if (comboBoxTipoProduto.SelectedItem.ToString() == "Pizza" && listBoxSabores.Items.Count < 2)
            {
                botaoAdicionarSabor.Enabled = true;
            }

            // Deixando o botão de adicionar sabor Enable caso a quantidade de sabores adicionados no listBox de sabor é menor que 1 e o tipo de item é Calzone 
            if (comboBoxTipoProduto.SelectedItem.ToString() == "Calzone" && listBoxSabores.Items.Count < 1)
            {
                botaoAdicionarSabor.Enabled = true;
            } 

            //Desabilitando grupo de adicionais caso não hajam mais sabores no listBox de sabores e o tipo de item não seja pizza
            if(comboBoxTipoProduto.SelectedItem.ToString() == "Pizza" && listBoxSabores.Items.Count < 1)
            {
                DesabilitarGrupoDeAdicionais();
            }

            botaoRemoverSabor.Enabled = false;
            botaoAdicionarSabor.Enabled = false;
        }

        public void HabilitarAdicaoDeAdicionais()
        {
                comboBoxAdicionais.Enabled = true;
                listBoxAdicionais.Enabled = true;
        }

        public void DesabilitarAdicaoDeAdicionais()
        {
            comboBoxAdicionais.Enabled = false;
            botaoAdicionarBorda.Enabled = false;
        }
        
        public void DesabilitarGrupoDeAdicionais()
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
            DesabilitarBotaoAdicionarAdicional();

            //Validar se ja é possível adicionar um novo itemPedido
            ValidarDisponibilidadeDoBotaoAdicionarItemPedido();
        }

        private void DesabilitarBotaoAdicionarAdicional()
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

            VerificarGrupoDeAdicaoDeAdicional();
        }

        private void comboBoxSabores_SelectedIndexChanged(object sender, EventArgs e)
        {
            botaoAdicionarSabor.Enabled = true;

            ValidarEnabledDeAdicionarSabor();
        }

        private void comboBoxAdicionais_SelectedIndexChanged(object sender, EventArgs e)
        {
            botaoAdicionarBorda.Enabled = true;
            DesabilitarBotaoAdicionarAdicional();
        }

        private void ValidarEnabledDeAdicionarSabor()
        {
            if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Pizza).Name && listBoxSabores.Items.Count == 2)
            {
                botaoAdicionarSabor.Enabled = false;
            }

            if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Calzone).Name && listBoxSabores.Items.Count == 1)
            {
                botaoAdicionarSabor.Enabled = false;
            }
        }

        private void botaoAdicionarItemPedido_Click(object sender, EventArgs e)
        {       
            if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Pizza).Name)
            {
                Pizza novaPizza = new Pizza();

                novaPizza.Quantidade = Convert.ToInt32(numericUpDownQuantidade.Value);

                //Adicionando adicional na pizza, caso exista
                if (listBoxAdicionais.Items.Count != 0) {
                  novaPizza.Adicional = listBoxAdicionais.Items[0] as Adicional;
                }

                //Adicionando sabor obrigatório na pizza
                novaPizza.Sabor1 = listBoxSabores.Items[0] as Sabor;

                //A qual pedido a pizza pertence
                novaPizza.Pedido = this.Pedido;

                //Adicionando segundo sabor a pizza, caso exista
                if (listBoxSabores.Items.Count == 2)
                {
                    novaPizza.Sabor2 = listBoxSabores.Items[1] as Sabor;
                }

                //Setando tamanhã de pizza de acordo com o radio button marcado
                if (radioButtonPizzaPequena.Checked)
                {
                    novaPizza.Tamanho = TamanhoPizza.PEQUENA;
                }
                else if (radioButtonPizzaMedia.Checked)
                {
                    novaPizza.Tamanho = TamanhoPizza.MEDIA;
                }
                else if(radioButtonPizzaGrande.Checked)
                {
                    novaPizza.Tamanho = TamanhoPizza.GRANDE;
                }

                //Adicionando Pizza no Item Produto
                listBoxItensPedido.Items.Add(novaPizza);

            }

            if(comboBoxTipoProduto.SelectedItem.ToString() == typeof(Calzone).Name)
            {
                Calzone calzone = new Calzone()
                {
                    Pedido = this.Pedido,
                    Quantidade = Convert.ToInt32(numericUpDownQuantidade.Value),
                    Sabor1 = listBoxSabores.Items[0] as Sabor
                };

                listBoxItensPedido.Items.Add(calzone);
            }

            if(comboBoxTipoProduto.SelectedItem.GetType() == typeof(ProdutoGenerico))
            {
                ProdutoGenerico itemSelecionadoNoListBoxItensPedido = comboBoxItem.SelectedItem as ProdutoGenerico;

                ProdutoGenerico bebida = new Bebida();

                bebida.Id = itemSelecionadoNoListBoxItensPedido.Id;
                bebida.Descricao = itemSelecionadoNoListBoxItensPedido.Descricao;
                bebida.Valor = itemSelecionadoNoListBoxItensPedido.Valor;
                

                listBoxItensPedido.Items.Add(bebida);
            }

            LimparValoresDeItemPedido();
            ReiniciarValoresDeItemPedido();

            

        }

        private void ValidarDisponibilidadeDoBotaoAdicionarItemPedido()
        {
            if(comboBoxTipoProduto.SelectedItem.ToString() == typeof(Calzone).Name && listBoxSabores.Items.Count > 0 && numericUpDownQuantidade.Value > 0)
            {
                botaoAdicionarItemPedido.Enabled = true;
            }

            else if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Pizza).Name && listBoxSabores.Items.Count > 0 && numericUpDownQuantidade.Value > 0)
            {
                if (radioButtonPizzaGrande.Checked || radioButtonPizzaMedia.Checked || radioButtonPizzaPequena.Checked) { 
                    botaoAdicionarItemPedido.Enabled = true;
                }
            }

            else if(comboBoxTipoProduto.SelectedItem.ToString() == typeof(ProdutoGenerico).Name && comboBoxItem.SelectedIndex >= 0 && numericUpDownQuantidade.Value > 0)
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

        private void listBoxItensPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItensPedido.SelectedIndex >= 0)
                botaoRemoverItemPedido.Enabled = true;
        }

        private void HabilitarRadioButtonsTamanhos()
        {
            radioButtonPizzaPequena.Enabled = true;
            radioButtonPizzaMedia.Enabled = true;
            radioButtonPizzaGrande.Enabled = true;
        }

        private void DesabilitarRadioButtonsTamanhos()
        {
            radioButtonPizzaPequena.Enabled = false;
            radioButtonPizzaPequena.Checked = false;
            radioButtonPizzaMedia.Enabled = false;
            radioButtonPizzaMedia.Checked = false;
            radioButtonPizzaGrande.Enabled = false;
            radioButtonPizzaGrande.Checked = false;
        }

        private void radioButtonPizzaMedia_CheckedChanged(object sender, EventArgs e)
        {
            ValidarDisponibilidadeDoBotaoAdicionarItemPedido();
        }

        public void LimparComboBoxSabores()
        {
            comboBoxSabores.Items.Clear();
            comboBoxSabores.SelectedItem = null;
        }

        private void botaoCancelarPedido_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButtonPizzaGrande_CheckedChanged(object sender, EventArgs e)
        {
            ValidarDisponibilidadeDoBotaoAdicionarItemPedido();
        }

        private void radioButtonPizzaPequena_CheckedChanged(object sender, EventArgs e)
        {
            ValidarDisponibilidadeDoBotaoAdicionarItemPedido();
        }

        private void VerificarGrupoDeAdicaoDeAdicional()
        {
            if (comboBoxTipoProduto.SelectedItem.ToString() == typeof(Pizza).Name)
            {
                if (listBoxAdicionais.Items.Count > 0)
                {
                    DesabilitarAdicaoDeAdicionais();
                }
                else
                {
                    HabilitarAdicaoDeAdicionais();
                }

            }
        }

        private void botaoRemoverItemPedido_Click(object sender, EventArgs e)
        {
            listBoxItensPedido.Items.RemoveAt(listBoxItensPedido.SelectedIndex);

            LimparValoresDeItemPedido();
            ReiniciarValoresDeItemPedido();
        }
    }
}
