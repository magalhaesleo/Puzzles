using GeradorDeTestes.Domain.helpers;
using GeradorDeTestes.Domain.helpers.ButtonsEnable;
using GeradorDeTestes.Domain.helpers.ToolStripVisible;
using GeradorDeTestes.Infra;
using GeradorDeTestes.WinApp.Features.DisciplinaModule;
using GeradorDeTestes.WinApp.Features.MateriaModule;
using GeradorDeTestes.WinApp.Features.QuestaoModule;
using GeradorDeTestes.WinApp.Features.SerieModule;
using GeradorDeTestes.WinApp.Features.TesteModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.WinApp.IoC;

namespace GeradorDeTestes.WinApp
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            toolStripBotoes.Visible = false;
        }

        private void CarregarGerenciador(GerenciadorFormulario gerenciador)
        {
            IOCgerenciadorFormulario.GerenciadorFormulario = gerenciador;

            definirPropriedadeEnableDosBotoes(IOCgerenciadorFormulario.GerenciadorFormulario.ObtemEnableButtons());
            definirPropriedadeVisibleDosBotoes(IOCgerenciadorFormulario.GerenciadorFormulario.ObtemVisibleButtons());
            definirPropriedadeVisibleToolStrip(IOCgerenciadorFormulario.GerenciadorFormulario.ObtemVisibleToolStrip());
            

            UserControl userControlType = IOCgerenciadorFormulario.GerenciadorFormulario.CarregarListControl();

            labelTipoCadastro.Text = "Gerenciador de " + IOCgerenciadorFormulario.GerenciadorFormulario.ObtemTipo();
            btnAdicionar.Text = "Adicionar " + IOCgerenciadorFormulario.GerenciadorFormulario.ObtemTipo();
            if (IOCgerenciadorFormulario.GerenciadorFormulario.ObtemTipo().Equals("Teste"))
            {
                btnAdicionar.Text = "Gerar " + IOCgerenciadorFormulario.GerenciadorFormulario.ObtemTipo();
            }
            btnEditar.Text = "Editar " + IOCgerenciadorFormulario.GerenciadorFormulario.ObtemTipo();
            btnExcluir.Text = "Excluir " + IOCgerenciadorFormulario.GerenciadorFormulario.ObtemTipo();
            //tela.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();

            panelControl.Controls.Add(userControlType);
        }

        private void deDisciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(IOCgerenciadorFormulario.DisciplinaGerenciadorFormulario);
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(IOCgerenciadorFormulario.MateriaGerenciadorFormulario);
        }

        private void questaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(IOCgerenciadorFormulario.QuestaoGerenciadorFormulario);
        }

        private void sérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(IOCgerenciadorFormulario.SerieGerenciadorFormulario);
         }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                IOCgerenciadorFormulario.GerenciadorFormulario.Adicionar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                IOCgerenciadorFormulario.GerenciadorFormulario.Editar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {            
            try
            {
                IOCgerenciadorFormulario.GerenciadorFormulario.Excluir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnVisualizarTeste_Click(object sender, EventArgs e)
        {
            IOCgerenciadorFormulario.TesteGerenciadorFormulario.ExportarTeste();
        }

        private void btnGerarGabarito_Click(object sender, EventArgs e)
        {
            IOCgerenciadorFormulario.TesteGerenciadorFormulario.GerarGabarito();
        }

        private void definirPropriedadeVisibleDosBotoes(ButtonsVisible buttonsVisible)
        {
            btnAdicionar.Visible = buttonsVisible.btnAdicionar;
            btnEditar.Visible = buttonsVisible.btnEditar;
            btnExcluir.Visible = buttonsVisible.btnExcluir;
            btnExportarTeste.Visible = buttonsVisible.btnExportar;
            btnGerarGabarito.Visible = buttonsVisible.btnGerarGabarito;
        }

        private void definirPropriedadeEnableDosBotoes(ButtonsEnable buttonsEnable)
        {
            btnAdicionar.Enabled = buttonsEnable.btnAdicionar;
            btnEditar.Enabled = buttonsEnable.btnEditar;
            btnExcluir.Enabled = buttonsEnable.btnExcluir;
            btnGerarGabarito.Enabled = buttonsEnable.btnGerarGabarito;
            btnExportarTeste.Enabled = buttonsEnable.btnExportar;
        }
        private void definirPropriedadeVisibleToolStrip(ToolStripVisible toolStripVisible)
        {
            toolStripBotoes.Visible = toolStripVisible.toolStripBotoes;
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(IOCgerenciadorFormulario.TesteGerenciadorFormulario);
        }
    }
}
