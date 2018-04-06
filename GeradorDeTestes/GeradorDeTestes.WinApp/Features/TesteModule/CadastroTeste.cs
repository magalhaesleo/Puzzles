using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Applications;

namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    public partial class CadastroTeste : Form
    {
        private List<Materia> _listMaterias;
        private List<Disciplina> _listDisciplinas;
        private TesteService _serviceTeste;
        private QuestaoService _questaoService;

        public Teste Teste
        {
            get
            {
                Teste teste = new Teste();
                teste.Id = 0;
                teste.Nome = txtNome.Text; 
                teste.Materia = (Materia)cmbMateria.SelectedItem;
                teste.NumeroDeQuestoes = (int)numQuestoes.Value;
                teste.DataGeracao = DateTime.Parse(txtData.Text);
                teste.Questoes = _serviceTeste.SelecionaQuestoesAleatorias((int)numQuestoes.Value, teste.Materia.Id);

                return teste;
            }
        }

        public CadastroTeste(List<Materia> listMaterias, List<Disciplina> listDisciplinas, TesteService serviceTeste,QuestaoService questaoService)
        {
            InitializeComponent();

            _serviceTeste = serviceTeste;
            _questaoService = questaoService;
            txtData.Text = string.Format("{0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            this._listMaterias = listMaterias;
            _listDisciplinas = listDisciplinas;
            cmbDisciplina.Items.Clear();
            cmbMateria.Items.Clear();

            foreach (Disciplina disciplina in _listDisciplinas)
            {
                cmbDisciplina.Items.Add(disciplina);
            }
        }


        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.Enabled = true;
            cmbMateria.Items.Clear();
            Disciplina disciplinaSelecionada = (Disciplina)cmbDisciplina.SelectedItem;
            foreach (Materia materia in _listMaterias)
            {
                if (disciplinaSelecionada.Id == materia.Disciplina.Id)
                    cmbMateria.Items.Add(materia);
            }

        }

        public void ValidarPreenchimentoDosCampos()
        {
            if (cmbDisciplina.SelectedItem == null)
            {
                cmbDisciplina.BackColor = Color.Red;
                throw new Exception("A disciplina deve ser selecionada");
            }

            if (cmbMateria.SelectedItem == null)
            {
                cmbMateria.BackColor = Color.Red;
                throw new Exception("A matéria deve ser selecionada");
            }

            if ( txtNome.Text.Length < 5)
            {
                txtNome.BackColor = Color.Red;
                throw new Exception("O nome do teste deve possuir mais que 5 caracteres.");
            }

            if (txtNome.Text.Length > 50)
            {
                txtNome.BackColor = Color.Red;
                throw new Exception("O nome do teste deve possuir menos de 50 caracteres.");
            }
        }

        private void btnGerarTeste_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarPreenchimentoDosCampos();
                Teste.Validar();
               
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            numQuestoes.Enabled = true;
            Materia materia = (Materia)cmbMateria.SelectedItem;
            List<int> quantidadeDeQuestoes = _questaoService.VerificarQuantidadeDeQuestoesPorMateria(materia.Id);
            numQuestoes.Maximum = (int)quantidadeDeQuestoes[0];
            if((int)quantidadeDeQuestoes[0] < 1)
            {
                numQuestoes.Enabled = false;
            }else
            {
                if((int)quantidadeDeQuestoes[0] > 30)
                {
                    numQuestoes.Maximum = 30;
                }
                numQuestoes.Enabled = true;
            }
        }
    }
}
