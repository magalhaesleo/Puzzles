namespace projeto_pizzaria.WinApp.Funcionalidades.Pedidos.RealizarPedido
{
    partial class RealizarPedido_Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelCliente = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.comboBoxTipoProduto = new System.Windows.Forms.ComboBox();
            this.grupoAdicionarItemPedido = new System.Windows.Forms.GroupBox();
            this.labelQuantidade = new System.Windows.Forms.Label();
            this.numericUpDownQuantidade = new System.Windows.Forms.NumericUpDown();
            this.botaoRemoverItemPedido = new System.Windows.Forms.Button();
            this.botaoAdicionarItemPedido = new System.Windows.Forms.Button();
            this.radioButtonPizzaGrande = new System.Windows.Forms.RadioButton();
            this.radioButtonPizzaMedia = new System.Windows.Forms.RadioButton();
            this.radioButtonPizzaPequena = new System.Windows.Forms.RadioButton();
            this.labelTamanho = new System.Windows.Forms.Label();
            this.grupoAdicionarSabores = new System.Windows.Forms.GroupBox();
            this.botaoRemoverSabor = new System.Windows.Forms.Button();
            this.listBoxSabores = new System.Windows.Forms.ListBox();
            this.botaoAdicionarSabor = new System.Windows.Forms.Button();
            this.comboBoxSabores = new System.Windows.Forms.ComboBox();
            this.labelItem = new System.Windows.Forms.Label();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.listBoxItensPedido = new System.Windows.Forms.ListBox();
            this.textBoxDocumentoNotaFiscal = new System.Windows.Forms.Label();
            this.textBoxCnpjEmpresa = new System.Windows.Forms.TextBox();
            this.comboBoxFormaDePagamento = new System.Windows.Forms.ComboBox();
            this.checkBoxNotaFiscal = new System.Windows.Forms.CheckBox();
            this.grupoPedidoParaEmpresa = new System.Windows.Forms.GroupBox();
            this.checkBoxPedidoParaEmpresa = new System.Windows.Forms.CheckBox();
            this.textBoxReponsavel = new System.Windows.Forms.TextBox();
            this.labelResponsavel = new System.Windows.Forms.Label();
            this.textBoxDepartamento = new System.Windows.Forms.TextBox();
            this.labelDepartamento = new System.Windows.Forms.Label();
            this.grupoFormaDePagamento = new System.Windows.Forms.GroupBox();
            this.labelValorTotal = new System.Windows.Forms.Label();
            this.botaoCancelarPedido = new System.Windows.Forms.Button();
            this.labelValorTotalExibido = new System.Windows.Forms.Label();
            this.botaoAdicionarPedido = new System.Windows.Forms.Button();
            this.groupBoxAdicionais = new System.Windows.Forms.GroupBox();
            this.botaoRemoverBorda = new System.Windows.Forms.Button();
            this.listBoxAdicionais = new System.Windows.Forms.ListBox();
            this.botaoAdicionarBorda = new System.Windows.Forms.Button();
            this.comboBoxAdicionais = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxBuscarPorTelefone = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grupoAdicionarItemPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).BeginInit();
            this.grupoAdicionarSabores.SuspendLayout();
            this.grupoPedidoParaEmpresa.SuspendLayout();
            this.grupoFormaDePagamento.SuspendLayout();
            this.groupBoxAdicionais.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(17, 17);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(42, 13);
            this.labelCliente.TabIndex = 0;
            this.labelCliente.Text = "Cliente:";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(62, 10);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(193, 21);
            this.comboBoxCliente.TabIndex = 1;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(16, 50);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(31, 13);
            this.labelTipo.TabIndex = 6;
            this.labelTipo.Text = "Tipo:";
            // 
            // comboBoxTipoProduto
            // 
            this.comboBoxTipoProduto.FormattingEnabled = true;
            this.comboBoxTipoProduto.Location = new System.Drawing.Point(62, 42);
            this.comboBoxTipoProduto.Name = "comboBoxTipoProduto";
            this.comboBoxTipoProduto.Size = new System.Drawing.Size(188, 21);
            this.comboBoxTipoProduto.TabIndex = 7;
            this.comboBoxTipoProduto.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoProduto_SelectedIndexChanged);
            // 
            // grupoAdicionarItemPedido
            // 
            this.grupoAdicionarItemPedido.Controls.Add(this.labelQuantidade);
            this.grupoAdicionarItemPedido.Controls.Add(this.numericUpDownQuantidade);
            this.grupoAdicionarItemPedido.Controls.Add(this.botaoRemoverItemPedido);
            this.grupoAdicionarItemPedido.Controls.Add(this.botaoAdicionarItemPedido);
            this.grupoAdicionarItemPedido.Controls.Add(this.radioButtonPizzaGrande);
            this.grupoAdicionarItemPedido.Controls.Add(this.radioButtonPizzaMedia);
            this.grupoAdicionarItemPedido.Controls.Add(this.radioButtonPizzaPequena);
            this.grupoAdicionarItemPedido.Controls.Add(this.labelTamanho);
            this.grupoAdicionarItemPedido.Controls.Add(this.grupoAdicionarSabores);
            this.grupoAdicionarItemPedido.Controls.Add(this.labelItem);
            this.grupoAdicionarItemPedido.Controls.Add(this.comboBoxItem);
            this.grupoAdicionarItemPedido.Location = new System.Drawing.Point(569, 13);
            this.grupoAdicionarItemPedido.Name = "grupoAdicionarItemPedido";
            this.grupoAdicionarItemPedido.Size = new System.Drawing.Size(453, 312);
            this.grupoAdicionarItemPedido.TabIndex = 12;
            this.grupoAdicionarItemPedido.TabStop = false;
            this.grupoAdicionarItemPedido.Text = "Item do pedido";
            // 
            // labelQuantidade
            // 
            this.labelQuantidade.AutoSize = true;
            this.labelQuantidade.Location = new System.Drawing.Point(301, 27);
            this.labelQuantidade.Name = "labelQuantidade";
            this.labelQuantidade.Size = new System.Drawing.Size(65, 13);
            this.labelQuantidade.TabIndex = 31;
            this.labelQuantidade.Text = "Quantidade:";
            // 
            // numericUpDownQuantidade
            // 
            this.numericUpDownQuantidade.Location = new System.Drawing.Point(372, 20);
            this.numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            this.numericUpDownQuantidade.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownQuantidade.TabIndex = 30;
            this.numericUpDownQuantidade.ValueChanged += new System.EventHandler(this.numericUpDownQuantidade_ValueChanged);
            // 
            // botaoRemoverItemPedido
            // 
            this.botaoRemoverItemPedido.Enabled = false;
            this.botaoRemoverItemPedido.Location = new System.Drawing.Point(283, 285);
            this.botaoRemoverItemPedido.Name = "botaoRemoverItemPedido";
            this.botaoRemoverItemPedido.Size = new System.Drawing.Size(148, 23);
            this.botaoRemoverItemPedido.TabIndex = 29;
            this.botaoRemoverItemPedido.Text = "Remover Item do pedido";
            this.botaoRemoverItemPedido.UseVisualStyleBackColor = true;
            // 
            // botaoAdicionarItemPedido
            // 
            this.botaoAdicionarItemPedido.Enabled = false;
            this.botaoAdicionarItemPedido.Location = new System.Drawing.Point(137, 285);
            this.botaoAdicionarItemPedido.Name = "botaoAdicionarItemPedido";
            this.botaoAdicionarItemPedido.Size = new System.Drawing.Size(143, 23);
            this.botaoAdicionarItemPedido.TabIndex = 28;
            this.botaoAdicionarItemPedido.Text = "Adicionar Item no pedido";
            this.botaoAdicionarItemPedido.UseVisualStyleBackColor = true;
            this.botaoAdicionarItemPedido.Click += new System.EventHandler(this.botaoAdicionarItemPedido_Click);
            // 
            // radioButtonPizzaGrande
            // 
            this.radioButtonPizzaGrande.AutoSize = true;
            this.radioButtonPizzaGrande.Enabled = false;
            this.radioButtonPizzaGrande.Location = new System.Drawing.Point(199, 53);
            this.radioButtonPizzaGrande.Name = "radioButtonPizzaGrande";
            this.radioButtonPizzaGrande.Size = new System.Drawing.Size(60, 17);
            this.radioButtonPizzaGrande.TabIndex = 10;
            this.radioButtonPizzaGrande.TabStop = true;
            this.radioButtonPizzaGrande.Text = "Grande";
            this.radioButtonPizzaGrande.UseVisualStyleBackColor = true;
            // 
            // radioButtonPizzaMedia
            // 
            this.radioButtonPizzaMedia.AutoSize = true;
            this.radioButtonPizzaMedia.Enabled = false;
            this.radioButtonPizzaMedia.Location = new System.Drawing.Point(138, 53);
            this.radioButtonPizzaMedia.Name = "radioButtonPizzaMedia";
            this.radioButtonPizzaMedia.Size = new System.Drawing.Size(54, 17);
            this.radioButtonPizzaMedia.TabIndex = 9;
            this.radioButtonPizzaMedia.TabStop = true;
            this.radioButtonPizzaMedia.Text = "Média";
            this.radioButtonPizzaMedia.UseVisualStyleBackColor = true;
            // 
            // radioButtonPizzaPequena
            // 
            this.radioButtonPizzaPequena.AutoSize = true;
            this.radioButtonPizzaPequena.Enabled = false;
            this.radioButtonPizzaPequena.Location = new System.Drawing.Point(65, 53);
            this.radioButtonPizzaPequena.Name = "radioButtonPizzaPequena";
            this.radioButtonPizzaPequena.Size = new System.Drawing.Size(68, 17);
            this.radioButtonPizzaPequena.TabIndex = 8;
            this.radioButtonPizzaPequena.TabStop = true;
            this.radioButtonPizzaPequena.Text = "Pequena";
            this.radioButtonPizzaPequena.UseVisualStyleBackColor = true;
            // 
            // labelTamanho
            // 
            this.labelTamanho.AutoSize = true;
            this.labelTamanho.Location = new System.Drawing.Point(4, 56);
            this.labelTamanho.Name = "labelTamanho";
            this.labelTamanho.Size = new System.Drawing.Size(55, 13);
            this.labelTamanho.TabIndex = 7;
            this.labelTamanho.Text = "Tamanho:";
            // 
            // grupoAdicionarSabores
            // 
            this.grupoAdicionarSabores.Controls.Add(this.botaoRemoverSabor);
            this.grupoAdicionarSabores.Controls.Add(this.listBoxSabores);
            this.grupoAdicionarSabores.Controls.Add(this.botaoAdicionarSabor);
            this.grupoAdicionarSabores.Controls.Add(this.comboBoxSabores);
            this.grupoAdicionarSabores.Location = new System.Drawing.Point(4, 74);
            this.grupoAdicionarSabores.Name = "grupoAdicionarSabores";
            this.grupoAdicionarSabores.Size = new System.Drawing.Size(427, 95);
            this.grupoAdicionarSabores.TabIndex = 2;
            this.grupoAdicionarSabores.TabStop = false;
            this.grupoAdicionarSabores.Text = "Sabores";
            // 
            // botaoRemoverSabor
            // 
            this.botaoRemoverSabor.Enabled = false;
            this.botaoRemoverSabor.Location = new System.Drawing.Point(321, 18);
            this.botaoRemoverSabor.Name = "botaoRemoverSabor";
            this.botaoRemoverSabor.Size = new System.Drawing.Size(100, 23);
            this.botaoRemoverSabor.TabIndex = 27;
            this.botaoRemoverSabor.Text = "Remover Sabor";
            this.botaoRemoverSabor.UseVisualStyleBackColor = true;
            this.botaoRemoverSabor.Click += new System.EventHandler(this.botaoRemoverSabor_Click);
            // 
            // listBoxSabores
            // 
            this.listBoxSabores.Enabled = false;
            this.listBoxSabores.FormattingEnabled = true;
            this.listBoxSabores.Location = new System.Drawing.Point(5, 47);
            this.listBoxSabores.Name = "listBoxSabores";
            this.listBoxSabores.Size = new System.Drawing.Size(416, 43);
            this.listBoxSabores.TabIndex = 26;
            this.listBoxSabores.SelectedIndexChanged += new System.EventHandler(this.listBoxSabores_SelectedIndexChanged);
            // 
            // botaoAdicionarSabor
            // 
            this.botaoAdicionarSabor.Enabled = false;
            this.botaoAdicionarSabor.Location = new System.Drawing.Point(217, 18);
            this.botaoAdicionarSabor.Name = "botaoAdicionarSabor";
            this.botaoAdicionarSabor.Size = new System.Drawing.Size(100, 23);
            this.botaoAdicionarSabor.TabIndex = 25;
            this.botaoAdicionarSabor.Text = "Adicionar Sabor";
            this.botaoAdicionarSabor.UseVisualStyleBackColor = true;
            this.botaoAdicionarSabor.Click += new System.EventHandler(this.botaoAdicionarSabor_Click);
            // 
            // comboBoxSabores
            // 
            this.comboBoxSabores.Enabled = false;
            this.comboBoxSabores.FormattingEnabled = true;
            this.comboBoxSabores.Location = new System.Drawing.Point(5, 19);
            this.comboBoxSabores.Name = "comboBoxSabores";
            this.comboBoxSabores.Size = new System.Drawing.Size(204, 21);
            this.comboBoxSabores.TabIndex = 3;
            this.comboBoxSabores.SelectedIndexChanged += new System.EventHandler(this.comboBoxSabores_SelectedIndexChanged);
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Location = new System.Drawing.Point(4, 27);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(30, 13);
            this.labelItem.TabIndex = 1;
            this.labelItem.Text = "Item:";
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.Enabled = false;
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(38, 19);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(121, 21);
            this.comboBoxItem.TabIndex = 0;
            // 
            // listBoxItensPedido
            // 
            this.listBoxItensPedido.FormattingEnabled = true;
            this.listBoxItensPedido.Location = new System.Drawing.Point(569, 340);
            this.listBoxItensPedido.Name = "listBoxItensPedido";
            this.listBoxItensPedido.Size = new System.Drawing.Size(453, 95);
            this.listBoxItensPedido.TabIndex = 13;
            this.listBoxItensPedido.SelectedIndexChanged += new System.EventHandler(this.listBoxItensPedido_SelectedIndexChanged);
            // 
            // textBoxDocumentoNotaFiscal
            // 
            this.textBoxDocumentoNotaFiscal.AutoSize = true;
            this.textBoxDocumentoNotaFiscal.Location = new System.Drawing.Point(135, 245);
            this.textBoxDocumentoNotaFiscal.Name = "textBoxDocumentoNotaFiscal";
            this.textBoxDocumentoNotaFiscal.Size = new System.Drawing.Size(68, 13);
            this.textBoxDocumentoNotaFiscal.TabIndex = 18;
            this.textBoxDocumentoNotaFiscal.Text = "Documento: ";
            // 
            // textBoxCnpjEmpresa
            // 
            this.textBoxCnpjEmpresa.Location = new System.Drawing.Point(203, 240);
            this.textBoxCnpjEmpresa.Name = "textBoxCnpjEmpresa";
            this.textBoxCnpjEmpresa.Size = new System.Drawing.Size(158, 20);
            this.textBoxCnpjEmpresa.TabIndex = 19;
            // 
            // comboBoxFormaDePagamento
            // 
            this.comboBoxFormaDePagamento.FormattingEnabled = true;
            this.comboBoxFormaDePagamento.Location = new System.Drawing.Point(7, 19);
            this.comboBoxFormaDePagamento.Name = "comboBoxFormaDePagamento";
            this.comboBoxFormaDePagamento.Size = new System.Drawing.Size(186, 21);
            this.comboBoxFormaDePagamento.TabIndex = 16;
            // 
            // checkBoxNotaFiscal
            // 
            this.checkBoxNotaFiscal.AutoSize = true;
            this.checkBoxNotaFiscal.Location = new System.Drawing.Point(21, 243);
            this.checkBoxNotaFiscal.Name = "checkBoxNotaFiscal";
            this.checkBoxNotaFiscal.Size = new System.Drawing.Size(113, 17);
            this.checkBoxNotaFiscal.TabIndex = 17;
            this.checkBoxNotaFiscal.Text = "Emitir Nota Fiscal?";
            this.checkBoxNotaFiscal.UseVisualStyleBackColor = true;
            // 
            // grupoPedidoParaEmpresa
            // 
            this.grupoPedidoParaEmpresa.Controls.Add(this.checkBoxPedidoParaEmpresa);
            this.grupoPedidoParaEmpresa.Controls.Add(this.textBoxReponsavel);
            this.grupoPedidoParaEmpresa.Controls.Add(this.labelResponsavel);
            this.grupoPedidoParaEmpresa.Controls.Add(this.textBoxDepartamento);
            this.grupoPedidoParaEmpresa.Controls.Add(this.labelDepartamento);
            this.grupoPedidoParaEmpresa.Location = new System.Drawing.Point(20, 85);
            this.grupoPedidoParaEmpresa.Name = "grupoPedidoParaEmpresa";
            this.grupoPedidoParaEmpresa.Size = new System.Drawing.Size(453, 92);
            this.grupoPedidoParaEmpresa.TabIndex = 18;
            this.grupoPedidoParaEmpresa.TabStop = false;
            this.grupoPedidoParaEmpresa.Text = "Pedido para empresa";
            // 
            // checkBoxPedidoParaEmpresa
            // 
            this.checkBoxPedidoParaEmpresa.AutoSize = true;
            this.checkBoxPedidoParaEmpresa.Location = new System.Drawing.Point(7, 30);
            this.checkBoxPedidoParaEmpresa.Name = "checkBoxPedidoParaEmpresa";
            this.checkBoxPedidoParaEmpresa.Size = new System.Drawing.Size(107, 17);
            this.checkBoxPedidoParaEmpresa.TabIndex = 19;
            this.checkBoxPedidoParaEmpresa.Text = "É para Empresa?";
            this.checkBoxPedidoParaEmpresa.UseVisualStyleBackColor = true;
            // 
            // textBoxReponsavel
            // 
            this.textBoxReponsavel.Enabled = false;
            this.textBoxReponsavel.Location = new System.Drawing.Point(318, 54);
            this.textBoxReponsavel.Name = "textBoxReponsavel";
            this.textBoxReponsavel.Size = new System.Drawing.Size(129, 20);
            this.textBoxReponsavel.TabIndex = 18;
            // 
            // labelResponsavel
            // 
            this.labelResponsavel.AutoSize = true;
            this.labelResponsavel.Location = new System.Drawing.Point(246, 61);
            this.labelResponsavel.Name = "labelResponsavel";
            this.labelResponsavel.Size = new System.Drawing.Size(72, 13);
            this.labelResponsavel.TabIndex = 17;
            this.labelResponsavel.Text = "Responsável:";
            // 
            // textBoxDepartamento
            // 
            this.textBoxDepartamento.Enabled = false;
            this.textBoxDepartamento.Location = new System.Drawing.Point(83, 55);
            this.textBoxDepartamento.Name = "textBoxDepartamento";
            this.textBoxDepartamento.Size = new System.Drawing.Size(154, 20);
            this.textBoxDepartamento.TabIndex = 16;
            // 
            // labelDepartamento
            // 
            this.labelDepartamento.AutoSize = true;
            this.labelDepartamento.Location = new System.Drawing.Point(4, 61);
            this.labelDepartamento.Name = "labelDepartamento";
            this.labelDepartamento.Size = new System.Drawing.Size(77, 13);
            this.labelDepartamento.TabIndex = 15;
            this.labelDepartamento.Text = "Departamento:";
            // 
            // grupoFormaDePagamento
            // 
            this.grupoFormaDePagamento.Controls.Add(this.comboBoxFormaDePagamento);
            this.grupoFormaDePagamento.Location = new System.Drawing.Point(21, 183);
            this.grupoFormaDePagamento.Name = "grupoFormaDePagamento";
            this.grupoFormaDePagamento.Size = new System.Drawing.Size(199, 47);
            this.grupoFormaDePagamento.TabIndex = 19;
            this.grupoFormaDePagamento.TabStop = false;
            this.grupoFormaDePagamento.Text = "Forma de pagamento";
            // 
            // labelValorTotal
            // 
            this.labelValorTotal.AutoSize = true;
            this.labelValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValorTotal.Location = new System.Drawing.Point(571, 449);
            this.labelValorTotal.Name = "labelValorTotal";
            this.labelValorTotal.Size = new System.Drawing.Size(68, 15);
            this.labelValorTotal.TabIndex = 20;
            this.labelValorTotal.Text = "Valor Total:";
            // 
            // botaoCancelarPedido
            // 
            this.botaoCancelarPedido.Location = new System.Drawing.Point(947, 460);
            this.botaoCancelarPedido.Name = "botaoCancelarPedido";
            this.botaoCancelarPedido.Size = new System.Drawing.Size(75, 23);
            this.botaoCancelarPedido.TabIndex = 22;
            this.botaoCancelarPedido.Text = "Cancelar";
            this.botaoCancelarPedido.UseVisualStyleBackColor = true;
            // 
            // labelValorTotalExibido
            // 
            this.labelValorTotalExibido.AutoSize = true;
            this.labelValorTotalExibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValorTotalExibido.Location = new System.Drawing.Point(638, 444);
            this.labelValorTotalExibido.Name = "labelValorTotalExibido";
            this.labelValorTotalExibido.Size = new System.Drawing.Size(55, 24);
            this.labelValorTotalExibido.TabIndex = 23;
            this.labelValorTotalExibido.Text = "22.50";
            // 
            // botaoAdicionarPedido
            // 
            this.botaoAdicionarPedido.Location = new System.Drawing.Point(866, 460);
            this.botaoAdicionarPedido.Name = "botaoAdicionarPedido";
            this.botaoAdicionarPedido.Size = new System.Drawing.Size(75, 23);
            this.botaoAdicionarPedido.TabIndex = 24;
            this.botaoAdicionarPedido.Text = "Adicionar";
            this.botaoAdicionarPedido.UseVisualStyleBackColor = true;
            // 
            // groupBoxAdicionais
            // 
            this.groupBoxAdicionais.Controls.Add(this.botaoRemoverBorda);
            this.groupBoxAdicionais.Controls.Add(this.listBoxAdicionais);
            this.groupBoxAdicionais.Controls.Add(this.botaoAdicionarBorda);
            this.groupBoxAdicionais.Controls.Add(this.comboBoxAdicionais);
            this.groupBoxAdicionais.Location = new System.Drawing.Point(573, 197);
            this.groupBoxAdicionais.Name = "groupBoxAdicionais";
            this.groupBoxAdicionais.Size = new System.Drawing.Size(427, 95);
            this.groupBoxAdicionais.TabIndex = 28;
            this.groupBoxAdicionais.TabStop = false;
            this.groupBoxAdicionais.Text = "Adicionais";
            // 
            // botaoRemoverBorda
            // 
            this.botaoRemoverBorda.Enabled = false;
            this.botaoRemoverBorda.Location = new System.Drawing.Point(321, 18);
            this.botaoRemoverBorda.Name = "botaoRemoverBorda";
            this.botaoRemoverBorda.Size = new System.Drawing.Size(100, 23);
            this.botaoRemoverBorda.TabIndex = 27;
            this.botaoRemoverBorda.Text = "Remover Borda";
            this.botaoRemoverBorda.UseVisualStyleBackColor = true;
            this.botaoRemoverBorda.Click += new System.EventHandler(this.botaoRemoverBorda_Click);
            // 
            // listBoxAdicionais
            // 
            this.listBoxAdicionais.Enabled = false;
            this.listBoxAdicionais.FormattingEnabled = true;
            this.listBoxAdicionais.Location = new System.Drawing.Point(5, 47);
            this.listBoxAdicionais.Name = "listBoxAdicionais";
            this.listBoxAdicionais.Size = new System.Drawing.Size(416, 43);
            this.listBoxAdicionais.TabIndex = 26;
            this.listBoxAdicionais.SelectedIndexChanged += new System.EventHandler(this.listBoxAdicionais_SelectedIndexChanged);
            // 
            // botaoAdicionarBorda
            // 
            this.botaoAdicionarBorda.Enabled = false;
            this.botaoAdicionarBorda.Location = new System.Drawing.Point(217, 18);
            this.botaoAdicionarBorda.Name = "botaoAdicionarBorda";
            this.botaoAdicionarBorda.Size = new System.Drawing.Size(100, 23);
            this.botaoAdicionarBorda.TabIndex = 25;
            this.botaoAdicionarBorda.Text = "Adicionar Borda";
            this.botaoAdicionarBorda.UseVisualStyleBackColor = true;
            this.botaoAdicionarBorda.Click += new System.EventHandler(this.botaoAdicionarBorda_Click);
            // 
            // comboBoxAdicionais
            // 
            this.comboBoxAdicionais.Enabled = false;
            this.comboBoxAdicionais.FormattingEnabled = true;
            this.comboBoxAdicionais.Location = new System.Drawing.Point(5, 19);
            this.comboBoxAdicionais.Name = "comboBoxAdicionais";
            this.comboBoxAdicionais.Size = new System.Drawing.Size(204, 21);
            this.comboBoxAdicionais.TabIndex = 3;
            this.comboBoxAdicionais.SelectedIndexChanged += new System.EventHandler(this.comboBoxAdicionais_SelectedIndexChanged);
            // 
            // maskedTextBoxBuscarPorTelefone
            // 
            this.maskedTextBoxBuscarPorTelefone.Location = new System.Drawing.Point(261, 10);
            this.maskedTextBoxBuscarPorTelefone.Mask = "(99) 0000-0000";
            this.maskedTextBoxBuscarPorTelefone.Name = "maskedTextBoxBuscarPorTelefone";
            this.maskedTextBoxBuscarPorTelefone.Size = new System.Drawing.Size(92, 20);
            this.maskedTextBoxBuscarPorTelefone.TabIndex = 30;
            this.maskedTextBoxBuscarPorTelefone.TextChanged += new System.EventHandler(this.maskedTextBoxBuscarPorTelefone_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // RealizarPedido_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 488);
            this.Controls.Add(this.maskedTextBoxBuscarPorTelefone);
            this.Controls.Add(this.groupBoxAdicionais);
            this.Controls.Add(this.botaoAdicionarPedido);
            this.Controls.Add(this.labelValorTotalExibido);
            this.Controls.Add(this.botaoCancelarPedido);
            this.Controls.Add(this.labelValorTotal);
            this.Controls.Add(this.textBoxDocumentoNotaFiscal);
            this.Controls.Add(this.grupoFormaDePagamento);
            this.Controls.Add(this.textBoxCnpjEmpresa);
            this.Controls.Add(this.grupoPedidoParaEmpresa);
            this.Controls.Add(this.checkBoxNotaFiscal);
            this.Controls.Add(this.listBoxItensPedido);
            this.Controls.Add(this.grupoAdicionarItemPedido);
            this.Controls.Add(this.comboBoxTipoProduto);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.labelCliente);
            this.Name = "RealizarPedido_Dialog";
            this.Text = "Realizar Pedido";
            this.grupoAdicionarItemPedido.ResumeLayout(false);
            this.grupoAdicionarItemPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).EndInit();
            this.grupoAdicionarSabores.ResumeLayout(false);
            this.grupoPedidoParaEmpresa.ResumeLayout(false);
            this.grupoPedidoParaEmpresa.PerformLayout();
            this.grupoFormaDePagamento.ResumeLayout(false);
            this.groupBoxAdicionais.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.ComboBox comboBoxTipoProduto;
        private System.Windows.Forms.GroupBox grupoAdicionarItemPedido;
        private System.Windows.Forms.ListBox listBoxItensPedido;
        private System.Windows.Forms.GroupBox grupoAdicionarSabores;
        private System.Windows.Forms.Button botaoRemoverSabor;
        private System.Windows.Forms.ListBox listBoxSabores;
        private System.Windows.Forms.Button botaoAdicionarSabor;
        private System.Windows.Forms.ComboBox comboBoxSabores;
        private System.Windows.Forms.Label labelItem;
        private System.Windows.Forms.ComboBox comboBoxItem;
        private System.Windows.Forms.Label textBoxDocumentoNotaFiscal;
        private System.Windows.Forms.TextBox textBoxCnpjEmpresa;
        private System.Windows.Forms.ComboBox comboBoxFormaDePagamento;
        private System.Windows.Forms.CheckBox checkBoxNotaFiscal;
        private System.Windows.Forms.GroupBox grupoPedidoParaEmpresa;
        private System.Windows.Forms.CheckBox checkBoxPedidoParaEmpresa;
        private System.Windows.Forms.TextBox textBoxReponsavel;
        private System.Windows.Forms.Label labelResponsavel;
        private System.Windows.Forms.TextBox textBoxDepartamento;
        private System.Windows.Forms.Label labelDepartamento;
        private System.Windows.Forms.GroupBox grupoFormaDePagamento;
        private System.Windows.Forms.Label labelValorTotal;
        private System.Windows.Forms.Button botaoCancelarPedido;
        private System.Windows.Forms.Label labelValorTotalExibido;
        private System.Windows.Forms.Button botaoAdicionarPedido;
        private System.Windows.Forms.Button botaoRemoverItemPedido;
        private System.Windows.Forms.Button botaoAdicionarItemPedido;
        private System.Windows.Forms.RadioButton radioButtonPizzaGrande;
        private System.Windows.Forms.RadioButton radioButtonPizzaMedia;
        private System.Windows.Forms.RadioButton radioButtonPizzaPequena;
        private System.Windows.Forms.Label labelTamanho;
        private System.Windows.Forms.GroupBox groupBoxAdicionais;
        private System.Windows.Forms.Button botaoRemoverBorda;
        private System.Windows.Forms.ListBox listBoxAdicionais;
        private System.Windows.Forms.Button botaoAdicionarBorda;
        private System.Windows.Forms.ComboBox comboBoxAdicionais;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBuscarPorTelefone;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantidade;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label labelQuantidade;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
    }
}