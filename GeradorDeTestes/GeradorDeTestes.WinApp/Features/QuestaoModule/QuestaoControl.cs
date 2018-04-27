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
using GeradorDeTestes.Application.IoC;

namespace GeradorDeTestes.WinApp.Features.QuestaoModule
{
    public partial class QuestaoControl : UserControl
    {
        private List<Questao> _listaQuestoes;

        public List<Materia> ListMaterias { get; set; }
        public QuestaoControl()
        {
            InitializeComponent();

            ListMaterias = IOCService.MateriaService.GetAll();

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

            foreach (Materia materia in ListMaterias)
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

            foreach (Materia materia in ListMaterias)
            {
                if (materia.Disciplina.Id == disciplina.Id)
                {
                    cmbMateria.Items.Add(materia);
                }
            }

            cmbMateria.Enabled = true;
            txtQuestaoFiltro.Enabled = false;
            btnBuscar.Enabled = false;
        }

        public void listaComboBoxes(List<Materia> listaMaterias)
        {
            ListMaterias = listaMaterias;
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

            txtQuestaoFiltro.Enabled = true;
            btnBuscar.Enabled = true;

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPorFiltro();
        }

        private void txtQuestaoFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarPorFiltro();
            }
        }

        private void BuscarPorFiltro()
        {
            listQuestao.Items.Clear();
            Materia materia = (Materia)cmbMateria.SelectedItem;
            foreach (Questao questao in IOCService.QuestaoService.SelecionarQuestoesPorFiltro(materia.Id, txtQuestaoFiltro.Text))
            {
                listQuestao.Items.Add(questao);
            }
        }

        private void txtQuestaoFiltro_TextChanged(object sender, EventArgs e)
        {
            BuscarPorFiltro();
        }
    }
}
