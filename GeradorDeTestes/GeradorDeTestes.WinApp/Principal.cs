using GeradorDeTestes.WinApp.Features.DisciplinaModule;
using GeradorDeTestes.WinApp.Features.MateriaModule;
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
        //private QuestaoGerenciadorFormulario _gerenciadorQuestao;

        public Principal()
        {
            InitializeComponent();
        }

        private void gerenciadorDeDisciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(_gerenciadorDisciplina);
        }

        private void CarregarGerenciador(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;

            UserControl list = _gerenciador.CarregarListControl();
            labelTipoCadastro.Text = "Gerenciador de " + _gerenciador.ObtemTipo();
            btnAdicionar.Text = "Adicionar " + _gerenciador.ObtemTipo();
            btnEditar.Text = "Editar " + _gerenciador.ObtemTipo();
            btnExcluir.Text = "Excluir " + _gerenciador.ObtemTipo();
            //tela.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();

            panelControl.Controls.Add(list);
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
            // CarregarGerenciador(_gerenciadorQuestao);
        }

        private void sérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGerenciador(obterGerenciadorSerie());
            btnEditar.Enabled = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            _gerenciador.Adicionar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _gerenciador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _gerenciador.Excluir();
        }

        private DisciplinaGerenciadorFormulario obterGerenciadorDisciplina()
        {
            if (_gerenciadorDisciplina == null)
            {
                return new DisciplinaGerenciadorFormulario();
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
                return new SerieGerenciadorFormulario();
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
                return new MateriaGerenciadorFormulario();
            }
            else
            {
                return _gerenciadorMateria;
            }
        }

    }
}
