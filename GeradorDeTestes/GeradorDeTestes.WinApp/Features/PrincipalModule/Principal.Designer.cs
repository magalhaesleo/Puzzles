﻿namespace GeradorDeTestes.WinApp
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deDisciplinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sérieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl = new System.Windows.Forms.Panel();
            this.toolStripBotoes = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnExportarTeste = new System.Windows.Forms.ToolStripButton();
            this.btnGerarGabarito = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStripBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deDisciplinaToolStripMenuItem,
            this.materiaToolStripMenuItem,
            this.questaoToolStripMenuItem,
            this.sérieToolStripMenuItem,
            this.testeToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.ajudaToolStripMenuItem.Text = "Gerenciador";
            // 
            // deDisciplinaToolStripMenuItem
            // 
            this.deDisciplinaToolStripMenuItem.Name = "deDisciplinaToolStripMenuItem";
            this.deDisciplinaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deDisciplinaToolStripMenuItem.Text = "Disciplina";
            this.deDisciplinaToolStripMenuItem.Click += new System.EventHandler(this.deDisciplinaToolStripMenuItem_Click);
            // 
            // materiaToolStripMenuItem
            // 
            this.materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            this.materiaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.materiaToolStripMenuItem.Text = "Matéria";
            this.materiaToolStripMenuItem.Click += new System.EventHandler(this.materiaToolStripMenuItem_Click);
            // 
            // questaoToolStripMenuItem
            // 
            this.questaoToolStripMenuItem.Name = "questaoToolStripMenuItem";
            this.questaoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.questaoToolStripMenuItem.Text = "Questão";
            this.questaoToolStripMenuItem.Click += new System.EventHandler(this.questaoToolStripMenuItem_Click);
            // 
            // sérieToolStripMenuItem
            // 
            this.sérieToolStripMenuItem.Name = "sérieToolStripMenuItem";
            this.sérieToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sérieToolStripMenuItem.Text = "Série";
            this.sérieToolStripMenuItem.Click += new System.EventHandler(this.sérieToolStripMenuItem_Click);
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testeToolStripMenuItem.Text = "Teste";
            this.testeToolStripMenuItem.Click += new System.EventHandler(this.testeToolStripMenuItem_Click);
            // 
            // panelControl
            // 
            this.panelControl.Location = new System.Drawing.Point(12, 66);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(825, 282);
            this.panelControl.TabIndex = 1;
            // 
            // toolStripBotoes
            // 
            this.toolStripBotoes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripBotoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnEditar,
            this.btnExcluir,
            this.btnExportarTeste,
            this.btnGerarGabarito,
            this.toolStripSeparator1,
            this.labelTipoCadastro});
            this.toolStripBotoes.Location = new System.Drawing.Point(0, 24);
            this.toolStripBotoes.Name = "toolStripBotoes";
            this.toolStripBotoes.Size = new System.Drawing.Size(849, 39);
            this.toolStripBotoes.TabIndex = 2;
            this.toolStripBotoes.Visible = false;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Padding = new System.Windows.Forms.Padding(8);
            this.btnAdicionar.Size = new System.Drawing.Size(94, 36);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.ToolTipText = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(8);
            this.btnEditar.Size = new System.Drawing.Size(73, 36);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(8);
            this.btnExcluir.Size = new System.Drawing.Size(77, 36);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnExportarTeste
            // 
            this.btnExportarTeste.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarTeste.Image")));
            this.btnExportarTeste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportarTeste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportarTeste.Name = "btnExportarTeste";
            this.btnExportarTeste.Padding = new System.Windows.Forms.Padding(8);
            this.btnExportarTeste.Size = new System.Drawing.Size(116, 36);
            this.btnExportarTeste.Text = "Exportar Teste";
            this.btnExportarTeste.Click += new System.EventHandler(this.btnVisualizarTeste_Click);
            // 
            // btnGerarGabarito
            // 
            this.btnGerarGabarito.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarGabarito.Image")));
            this.btnGerarGabarito.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGerarGabarito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGerarGabarito.Name = "btnGerarGabarito";
            this.btnGerarGabarito.Padding = new System.Windows.Forms.Padding(8);
            this.btnGerarGabarito.Size = new System.Drawing.Size(119, 36);
            this.btnGerarGabarito.Text = "Gerar Gabarito";
            this.btnGerarGabarito.Click += new System.EventHandler(this.btnGerarGabarito_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(0, 36);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 360);
            this.Controls.Add(this.toolStripBotoes);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de Testes";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripBotoes.ResumeLayout(false);
            this.toolStripBotoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ToolStripMenuItem deDisciplinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sérieToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripBotoes;
        public System.Windows.Forms.ToolStripButton btnAdicionar;
        public System.Windows.Forms.ToolStripButton btnEditar;
        public System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton btnExportarTeste;
        public System.Windows.Forms.ToolStripButton btnGerarGabarito;
    }
}

