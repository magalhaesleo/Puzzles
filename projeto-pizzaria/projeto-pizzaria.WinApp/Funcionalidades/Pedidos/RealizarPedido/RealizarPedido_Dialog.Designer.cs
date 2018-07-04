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
            this.lblCliente = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTipoProduto = new System.Windows.Forms.ComboBox();
            this.grupoAdicionarItemPedido = new System.Windows.Forms.GroupBox();
            this.listBoxItensPedido = new System.Windows.Forms.ListBox();
            this.textBoxDocumentoNotaFiscal = new System.Windows.Forms.Label();
            this.textBoxCnpjEmpresa = new System.Windows.Forms.TextBox();
            this.comboBoxFormaDePagamento = new System.Windows.Forms.ComboBox();
            this.checkBoxNotaFiscal = new System.Windows.Forms.CheckBox();
            this.grupoPedidoParaEmpresa = new System.Windows.Forms.GroupBox();
            this.checkBoxPedidoParaEmpresa = new System.Windows.Forms.CheckBox();
            this.textBoxReponsavel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDepartamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grupoFormaDePagamento = new System.Windows.Forms.GroupBox();
            this.labelValorTotal = new System.Windows.Forms.Label();
            this.botaoCancelar = new System.Windows.Forms.Button();
            this.labelValorTotalExibido = new System.Windows.Forms.Label();
            this.botaoAdicionarPedido = new System.Windows.Forms.Button();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.labelItem = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxSabores = new System.Windows.Forms.ComboBox();
            this.botaoAdicionarSabor = new System.Windows.Forms.Button();
            this.listBoxSabores = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTamanho = new System.Windows.Forms.Label();
            this.radioButtonPizzaPequena = new System.Windows.Forms.RadioButton();
            this.radioButtonPizzaMedia = new System.Windows.Forms.RadioButton();
            this.radioButtonPizzaGrande = new System.Windows.Forms.RadioButton();
            this.grupoAdicionarItemPedido.SuspendLayout();
            this.grupoPedidoParaEmpresa.SuspendLayout();
            this.grupoFormaDePagamento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(13, 13);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(62, 10);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(188, 21);
            this.comboBoxCliente.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo:";
            // 
            // comboBoxTipoProduto
            // 
            this.comboBoxTipoProduto.FormattingEnabled = true;
            this.comboBoxTipoProduto.Location = new System.Drawing.Point(62, 42);
            this.comboBoxTipoProduto.Name = "comboBoxTipoProduto";
            this.comboBoxTipoProduto.Size = new System.Drawing.Size(188, 21);
            this.comboBoxTipoProduto.TabIndex = 7;
            // 
            // grupoAdicionarItemPedido
            // 
            this.grupoAdicionarItemPedido.Controls.Add(this.radioButtonPizzaGrande);
            this.grupoAdicionarItemPedido.Controls.Add(this.radioButtonPizzaMedia);
            this.grupoAdicionarItemPedido.Controls.Add(this.radioButtonPizzaPequena);
            this.grupoAdicionarItemPedido.Controls.Add(this.labelTamanho);
            this.grupoAdicionarItemPedido.Controls.Add(this.groupBox1);
            this.grupoAdicionarItemPedido.Controls.Add(this.labelItem);
            this.grupoAdicionarItemPedido.Controls.Add(this.comboBoxItem);
            this.grupoAdicionarItemPedido.Location = new System.Drawing.Point(12, 80);
            this.grupoAdicionarItemPedido.Name = "grupoAdicionarItemPedido";
            this.grupoAdicionarItemPedido.Size = new System.Drawing.Size(453, 219);
            this.grupoAdicionarItemPedido.TabIndex = 12;
            this.grupoAdicionarItemPedido.TabStop = false;
            this.grupoAdicionarItemPedido.Text = "Item do pedido";
            // 
            // listBoxItensPedido
            // 
            this.listBoxItensPedido.FormattingEnabled = true;
            this.listBoxItensPedido.Location = new System.Drawing.Point(12, 306);
            this.listBoxItensPedido.Name = "listBoxItensPedido";
            this.listBoxItensPedido.Size = new System.Drawing.Size(453, 95);
            this.listBoxItensPedido.TabIndex = 13;
            // 
            // textBoxDocumentoNotaFiscal
            // 
            this.textBoxDocumentoNotaFiscal.AutoSize = true;
            this.textBoxDocumentoNotaFiscal.Location = new System.Drawing.Point(135, 571);
            this.textBoxDocumentoNotaFiscal.Name = "textBoxDocumentoNotaFiscal";
            this.textBoxDocumentoNotaFiscal.Size = new System.Drawing.Size(71, 13);
            this.textBoxDocumentoNotaFiscal.TabIndex = 18;
            this.textBoxDocumentoNotaFiscal.Text = "Documento : ";
            // 
            // textBoxCnpjEmpresa
            // 
            this.textBoxCnpjEmpresa.Location = new System.Drawing.Point(207, 566);
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
            this.checkBoxNotaFiscal.Location = new System.Drawing.Point(20, 570);
            this.checkBoxNotaFiscal.Name = "checkBoxNotaFiscal";
            this.checkBoxNotaFiscal.Size = new System.Drawing.Size(108, 17);
            this.checkBoxNotaFiscal.TabIndex = 17;
            this.checkBoxNotaFiscal.Text = "Emitir nota fiscal?";
            this.checkBoxNotaFiscal.UseVisualStyleBackColor = true;
            // 
            // grupoPedidoParaEmpresa
            // 
            this.grupoPedidoParaEmpresa.Controls.Add(this.checkBoxPedidoParaEmpresa);
            this.grupoPedidoParaEmpresa.Controls.Add(this.textBoxReponsavel);
            this.grupoPedidoParaEmpresa.Controls.Add(this.label2);
            this.grupoPedidoParaEmpresa.Controls.Add(this.textBoxDepartamento);
            this.grupoPedidoParaEmpresa.Controls.Add(this.label1);
            this.grupoPedidoParaEmpresa.Location = new System.Drawing.Point(12, 407);
            this.grupoPedidoParaEmpresa.Name = "grupoPedidoParaEmpresa";
            this.grupoPedidoParaEmpresa.Size = new System.Drawing.Size(453, 91);
            this.grupoPedidoParaEmpresa.TabIndex = 18;
            this.grupoPedidoParaEmpresa.TabStop = false;
            this.grupoPedidoParaEmpresa.Text = "Pedido para empresa";
            // 
            // checkBoxPedidoParaEmpresa
            // 
            this.checkBoxPedidoParaEmpresa.AutoSize = true;
            this.checkBoxPedidoParaEmpresa.Location = new System.Drawing.Point(7, 30);
            this.checkBoxPedidoParaEmpresa.Name = "checkBoxPedidoParaEmpresa";
            this.checkBoxPedidoParaEmpresa.Size = new System.Drawing.Size(106, 17);
            this.checkBoxPedidoParaEmpresa.TabIndex = 19;
            this.checkBoxPedidoParaEmpresa.Text = "É para empresa?";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Responsável:";
            // 
            // textBoxDepartamento
            // 
            this.textBoxDepartamento.Enabled = false;
            this.textBoxDepartamento.Location = new System.Drawing.Point(83, 55);
            this.textBoxDepartamento.Name = "textBoxDepartamento";
            this.textBoxDepartamento.Size = new System.Drawing.Size(154, 20);
            this.textBoxDepartamento.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Departamento:";
            // 
            // grupoFormaDePagamento
            // 
            this.grupoFormaDePagamento.Controls.Add(this.comboBoxFormaDePagamento);
            this.grupoFormaDePagamento.Location = new System.Drawing.Point(13, 505);
            this.grupoFormaDePagamento.Name = "grupoFormaDePagamento";
            this.grupoFormaDePagamento.Size = new System.Drawing.Size(199, 46);
            this.grupoFormaDePagamento.TabIndex = 19;
            this.grupoFormaDePagamento.TabStop = false;
            this.grupoFormaDePagamento.Text = "Forma de pagamento";
            // 
            // labelValorTotal
            // 
            this.labelValorTotal.AutoSize = true;
            this.labelValorTotal.Location = new System.Drawing.Point(13, 633);
            this.labelValorTotal.Name = "labelValorTotal";
            this.labelValorTotal.Size = new System.Drawing.Size(61, 13);
            this.labelValorTotal.TabIndex = 20;
            this.labelValorTotal.Text = "Valor Total:";
            // 
            // botaoCancelar
            // 
            this.botaoCancelar.Location = new System.Drawing.Point(309, 652);
            this.botaoCancelar.Name = "botaoCancelar";
            this.botaoCancelar.Size = new System.Drawing.Size(75, 23);
            this.botaoCancelar.TabIndex = 22;
            this.botaoCancelar.Text = "Cancelar";
            this.botaoCancelar.UseVisualStyleBackColor = true;
            // 
            // labelValorTotalExibido
            // 
            this.labelValorTotalExibido.AutoSize = true;
            this.labelValorTotalExibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValorTotalExibido.Location = new System.Drawing.Point(79, 622);
            this.labelValorTotalExibido.Name = "labelValorTotalExibido";
            this.labelValorTotalExibido.Size = new System.Drawing.Size(0, 24);
            this.labelValorTotalExibido.TabIndex = 23;
            // 
            // botaoAdicionarPedido
            // 
            this.botaoAdicionarPedido.Location = new System.Drawing.Point(390, 652);
            this.botaoAdicionarPedido.Name = "botaoAdicionarPedido";
            this.botaoAdicionarPedido.Size = new System.Drawing.Size(75, 23);
            this.botaoAdicionarPedido.TabIndex = 24;
            this.botaoAdicionarPedido.Text = "Adicionar";
            this.botaoAdicionarPedido.UseVisualStyleBackColor = true;
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.Enabled = false;
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(50, 19);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(121, 21);
            this.comboBoxItem.TabIndex = 0;
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Location = new System.Drawing.Point(8, 26);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(30, 13);
            this.labelItem.TabIndex = 1;
            this.labelItem.Text = "Item:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBoxSabores);
            this.groupBox1.Controls.Add(this.botaoAdicionarSabor);
            this.groupBox1.Controls.Add(this.comboBoxSabores);
            this.groupBox1.Location = new System.Drawing.Point(6, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 95);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sabores";
            // 
            // comboBoxSabores
            // 
            this.comboBoxSabores.Enabled = false;
            this.comboBoxSabores.FormattingEnabled = true;
            this.comboBoxSabores.Location = new System.Drawing.Point(5, 19);
            this.comboBoxSabores.Name = "comboBoxSabores";
            this.comboBoxSabores.Size = new System.Drawing.Size(204, 21);
            this.comboBoxSabores.TabIndex = 3;
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
            // 
            // listBoxSabores
            // 
            this.listBoxSabores.Enabled = false;
            this.listBoxSabores.FormattingEnabled = true;
            this.listBoxSabores.Location = new System.Drawing.Point(5, 47);
            this.listBoxSabores.Name = "listBoxSabores";
            this.listBoxSabores.Size = new System.Drawing.Size(416, 43);
            this.listBoxSabores.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(321, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Remover Sabor";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelTamanho
            // 
            this.labelTamanho.AutoSize = true;
            this.labelTamanho.Location = new System.Drawing.Point(8, 144);
            this.labelTamanho.Name = "labelTamanho";
            this.labelTamanho.Size = new System.Drawing.Size(55, 13);
            this.labelTamanho.TabIndex = 3;
            this.labelTamanho.Text = "Tamanho:";
            // 
            // radioButtonPizzaPequena
            // 
            this.radioButtonPizzaPequena.AutoSize = true;
            this.radioButtonPizzaPequena.Location = new System.Drawing.Point(69, 141);
            this.radioButtonPizzaPequena.Name = "radioButtonPizzaPequena";
            this.radioButtonPizzaPequena.Size = new System.Drawing.Size(68, 17);
            this.radioButtonPizzaPequena.TabIndex = 4;
            this.radioButtonPizzaPequena.TabStop = true;
            this.radioButtonPizzaPequena.Text = "Pequena";
            this.radioButtonPizzaPequena.UseVisualStyleBackColor = true;
            // 
            // radioButtonPizzaMedia
            // 
            this.radioButtonPizzaMedia.AutoSize = true;
            this.radioButtonPizzaMedia.Location = new System.Drawing.Point(143, 141);
            this.radioButtonPizzaMedia.Name = "radioButtonPizzaMedia";
            this.radioButtonPizzaMedia.Size = new System.Drawing.Size(54, 17);
            this.radioButtonPizzaMedia.TabIndex = 5;
            this.radioButtonPizzaMedia.TabStop = true;
            this.radioButtonPizzaMedia.Text = "Média";
            this.radioButtonPizzaMedia.UseVisualStyleBackColor = true;
            // 
            // radioButtonPizzaGrande
            // 
            this.radioButtonPizzaGrande.AutoSize = true;
            this.radioButtonPizzaGrande.Location = new System.Drawing.Point(203, 141);
            this.radioButtonPizzaGrande.Name = "radioButtonPizzaGrande";
            this.radioButtonPizzaGrande.Size = new System.Drawing.Size(60, 17);
            this.radioButtonPizzaGrande.TabIndex = 6;
            this.radioButtonPizzaGrande.TabStop = true;
            this.radioButtonPizzaGrande.Text = "Grande";
            this.radioButtonPizzaGrande.UseVisualStyleBackColor = true;
            // 
            // RealizarPedido_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 680);
            this.Controls.Add(this.botaoAdicionarPedido);
            this.Controls.Add(this.labelValorTotalExibido);
            this.Controls.Add(this.botaoCancelar);
            this.Controls.Add(this.labelValorTotal);
            this.Controls.Add(this.textBoxDocumentoNotaFiscal);
            this.Controls.Add(this.grupoFormaDePagamento);
            this.Controls.Add(this.textBoxCnpjEmpresa);
            this.Controls.Add(this.grupoPedidoParaEmpresa);
            this.Controls.Add(this.checkBoxNotaFiscal);
            this.Controls.Add(this.listBoxItensPedido);
            this.Controls.Add(this.grupoAdicionarItemPedido);
            this.Controls.Add(this.comboBoxTipoProduto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.lblCliente);
            this.Name = "RealizarPedido_Dialog";
            this.Text = "Realizar Pedido";
            this.grupoAdicionarItemPedido.ResumeLayout(false);
            this.grupoAdicionarItemPedido.PerformLayout();
            this.grupoPedidoParaEmpresa.ResumeLayout(false);
            this.grupoPedidoParaEmpresa.PerformLayout();
            this.grupoFormaDePagamento.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTipoProduto;
        private System.Windows.Forms.GroupBox grupoAdicionarItemPedido;
        private System.Windows.Forms.ListBox listBoxItensPedido;
        private System.Windows.Forms.RadioButton radioButtonPizzaGrande;
        private System.Windows.Forms.RadioButton radioButtonPizzaMedia;
        private System.Windows.Forms.RadioButton radioButtonPizzaPequena;
        private System.Windows.Forms.Label labelTamanho;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDepartamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grupoFormaDePagamento;
        private System.Windows.Forms.Label labelValorTotal;
        private System.Windows.Forms.Button botaoCancelar;
        private System.Windows.Forms.Label labelValorTotalExibido;
        private System.Windows.Forms.Button botaoAdicionarPedido;
    }
}