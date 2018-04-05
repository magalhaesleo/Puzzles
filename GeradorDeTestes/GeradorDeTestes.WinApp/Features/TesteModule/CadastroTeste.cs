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

namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    public partial class CadastroTeste : Form
    {
        private List<Materia> _listMaterias;
        private List<Disciplina> _listDisciplinas;

        public CadastroTeste(List<Materia> listMaterias, List<Disciplina> listDisciplinas)
        {
            InitializeComponent();

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

        private void popularComboBoxes()
        {
            

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
    }
}
