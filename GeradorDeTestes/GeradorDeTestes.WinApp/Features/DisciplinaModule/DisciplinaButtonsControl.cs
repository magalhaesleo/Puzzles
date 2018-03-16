using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    public partial class DisciplinaButtonsControl : UserControl
    {
        public DisciplinaGerenciadorFormulario GerenciadorDeDisciplina { get; set; }
        public DisciplinaButtonsControl(DisciplinaGerenciadorFormulario gerenciadorDeDisciplina)
        {
            GerenciadorDeDisciplina = gerenciadorDeDisciplina;
            InitializeComponent();
        }

        private void btnCadastrarDisciplina_Click(object sender, EventArgs e)
        {
            ChamarDialogDisciplina();          
        }


        public void ChamarDialogDisciplina()
        {
            CadastroDisciplina dialogDisciplina = new CadastroDisciplina();

            DialogResult resultado = dialogDisciplina.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                GerenciadorDeDisciplina.Adicionar(dialogDisciplina.NovaDisciplina);
            }
            else throw new Exception("Não foi possível criar uma disciplina.");

        }

    }
}
