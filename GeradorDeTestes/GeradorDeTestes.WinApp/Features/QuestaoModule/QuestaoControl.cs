using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain.Entidades;

namespace GeradorDeTestes.WinApp.Features.QuestaoModule
{
    public partial class QuestaoControl : UserControl
    {
        private List<Materia> _materias;
        private List<Questao> _listaQuestoes;

        public List<Materia> ListMaterias { get { return _materias; } set { this._materias = value; } }
        public QuestaoControl(List<Materia> materias = null)
        {
            InitializeComponent();
            ListMaterias = materias;

            popularComboBoxes();
        }

        public void listarQuestoes(List<Questao> listQuestoes)
        {
            _listaQuestoes = listQuestoes;
            listQuestao.Items.Clear();
            foreach (Questao questao in listQuestoes)
            {
                listQuestao.Items.Add(questao);
            }
        }

        private void popularComboBoxes()
        {
            cmbDisciplina.Items.Clear();
            cmbMateria.Items.Clear();

            foreach (Materia materia in _materias)
            {
                if (cmbDisciplina.FindString(materia.Disciplina.ToString()) != 0)
                {
                    cmbDisciplina.Items.Add(materia.Disciplina);
                }
                cmbMateria.Items.Add(materia);
            }

            cmbMateria.Enabled = false;

        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbMateria.Items.Clear();
            listQuestao.Items.Clear();

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;
            
            foreach (Questao questao in _listaQuestoes)
            {
                if (disciplina.Id == questao.Materia.Disciplina.Id)
                    listQuestao.Items.Add(questao);
            }

            foreach (Materia materia in _materias)
            {
                if (materia.Disciplina.Id == disciplina.Id)
                {
                    cmbMateria.Items.Add(materia);
                }
            }

            cmbMateria.Enabled = true;
        }

        public void listaComboBoxes(List<Materia> listaMaterias)
        {
            _materias = listaMaterias;
            popularComboBoxes();
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            listQuestao.Items.Clear();
            foreach (Questao questao in _listaQuestoes)
            {
                Materia materia = (Materia)cmbMateria.SelectedItem;
                if (materia.Id == questao.Materia.Id)
                    listQuestao.Items.Add(questao);
            }
        }

        private void listQuestao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listQuestao.SelectedIndex >= 0)
            {
                ControleDeReferencia.ReferenciaFormularioPrincipal.btnExcluir.Enabled = true;
                ControleDeReferencia.ReferenciaFormularioPrincipal.btnEditar.Enabled = true;
            }
        }

        public Questao RetornaQuestaoSelecionadaNoListBox()
        {
            return listQuestao.SelectedItem as Questao;
        }
    }
}
