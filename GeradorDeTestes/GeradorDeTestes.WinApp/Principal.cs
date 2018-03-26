using GeradorDeTestes.WinApp.Features.DisciplinaModule;
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
        public Principal()
        {
            InitializeComponent();
            _gerenciadorDisciplina = new DisciplinaGerenciadorFormulario();
            //Trocar para iniciar na janela de Geração de Testes
            CarregarCadastro(_gerenciadorDisciplina);
        }

        private void gerenciadorDeDisciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_gerenciadorDisciplina);
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;

            UserControl buttonsControl = _gerenciador.CarregarButtonsControl();
            UserControl tela = _gerenciador.CarregarListControl();


            buttonsControl.Dock = DockStyle.Fill;
            tela.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();
            panelButtons.Controls.Clear();

            panelControl.Controls.Add(tela);
            panelButtons.Controls.Add(buttonsControl);
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
