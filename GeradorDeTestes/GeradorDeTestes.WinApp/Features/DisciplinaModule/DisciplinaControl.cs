using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain;
using GeradorDeTestes.Applications;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    public partial class DisciplinaControl : UserControl
    {
        DisciplinaService _disciplinaService = new DisciplinaService();
        public DisciplinaControl()
        {
            InitializeComponent();
        }

        private void btnCadastrarDisciplina_Click(object sender, EventArgs e)
        {
            _disciplinaService.AdicionarDisciplina(Adicionar());
            //Adicionar
        }

        public Disciplina Adicionar()
        {
            CadastroDisciplina dialog = new CadastroDisciplina();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                return dialog.NovaDisciplina;
            }
            else throw new Exception("Não foi possível criar uma disciplina.");

        }

        private void btnEditarDisciplina_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluirDisciplina_Click(object sender, EventArgs e)
        {

        }
    }
}
