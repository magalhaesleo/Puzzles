using GeradorDeTestes.Domain.helpers;
using GeradorDeTestes.Domain.helpers.ButtonsEnable;
using GeradorDeTestes.Domain.helpers.ToolStripVisible;
using GeradorDeTestes.WinApp.Features.DisciplinaModule;
using GeradorDeTestes.WinApp.Features.MateriaModule;
using GeradorDeTestes.WinApp.Features.QuestaoModule;
using GeradorDeTestes.WinApp.Features.SerieModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp
{
    public partial class Principal : Form
    {
        private GerenciadorFormulario _gerenciador;

        private DisciplinaGerenciadorFormulario _gerenciadorDisciplina;
        private MateriaGerenciadorFormulario _gerenciadorMateria;
        private SerieGerenciadorFormulario _gerenciadorSerie;
        private QuestaoGerenciadorFormulario _gerenciadorQuestao;

        public Principal()
        {
            InitializeComponent();
            toolStripBotoes.Visible = false;
        }

        private void gerenciadorDeDisciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(obterGerenciadorDisciplina());
        }

        private void CarregarGerenciador(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;

            definirPropriedadeEnableDosBotoes(_gerenciador.ObtemEnableButtons());
            definirPropriedadeVisibleDosBotoes(_gerenciador.ObtemVisibleButtons());
            definirPropriedadeVisibleToolStrip(_gerenciador.ObtemVisibleToolStrip());
            

            UserControl userControlType = _gerenciador.CarregarListControl();

            labelTipoCadastro.Text = "Gerenciador de " + _gerenciador.ObtemTipo();
            btnAdicionar.Text = "Adicionar " + _gerenciador.ObtemTipo();
            btnEditar.Text = "Editar " + _gerenciador.ObtemTipo();
            btnExcluir.Text = "Excluir " + _gerenciador.ObtemTipo();
            //tela.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();

            panelControl.Controls.Add(userControlType);
        }

        private void deDisciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(obterGerenciadorDisciplina());
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(obterGerenciadorMateria());
        }

        private void questaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(obterGerenciadorQuestao());
        }

        private void sérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(obterGerenciadorSerie());
         }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Adicionar();
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
                _gerenciador.Editar();
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
                _gerenciador.Excluir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DisciplinaGerenciadorFormulario obterGerenciadorDisciplina()
        {
            if (_gerenciadorDisciplina == null)
            {
                return _gerenciadorDisciplina = new DisciplinaGerenciadorFormulario();
            }
            else
            {
                return _gerenciadorDisciplina;
            }
        }
        private SerieGerenciadorFormulario obterGerenciadorSerie()
        {
            if (_gerenciadorSerie == null)
            {
                return _gerenciadorSerie = new SerieGerenciadorFormulario();
            }
            else
            {
                return _gerenciadorSerie;
            }
        }
        private MateriaGerenciadorFormulario obterGerenciadorMateria()
        {
            if (_gerenciadorMateria == null)
            {
                return _gerenciadorMateria = new MateriaGerenciadorFormulario();
            }
            else
            {
                return _gerenciadorMateria;
            }
        }

        private QuestaoGerenciadorFormulario obterGerenciadorQuestao()
        {
            if (_gerenciadorQuestao == null)
            {
                return _gerenciadorQuestao = new QuestaoGerenciadorFormulario();
            }
            else
            {
                return _gerenciadorQuestao;
            }
        }
        private void definirPropriedadeVisibleDosBotoes(ButtonsVisible buttonsVisible)
        {
            btnAdicionar.Visible = buttonsVisible.btnAdicionar;
            btnEditar.Visible = buttonsVisible.btnEditar;
            btnExcluir.Visible = buttonsVisible.btnExcluir;
        }

        private void definirPropriedadeEnableDosBotoes(ButtonsEnable buttonsEnable)
        {
            btnAdicionar.Enabled = buttonsEnable.btnAdicionar;
            btnEditar.Enabled = buttonsEnable.btnEditar;
            btnExcluir.Enabled = buttonsEnable.btnExcluir;
        }
        private void definirPropriedadeVisibleToolStrip(ToolStripVisible toolStripVisible)
        {
            toolStripBotoes.Visible = toolStripVisible.toolStripBotoes;
        }
    }
}
