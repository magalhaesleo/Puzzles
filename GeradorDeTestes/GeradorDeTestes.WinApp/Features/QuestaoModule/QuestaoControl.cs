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

        public QuestaoControl(List<Materia> materias)
        {
            InitializeComponent();
            _materias = materias;

            popularComboBoxes();
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

        private void cmbDisciplina_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (_materias[(cmbMateria.SelectedIndex + 1)] != null)
            {
                cmbMateria.Items.Clear();
            }

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;
            foreach (Materia materia in _materias)
            {
                if (materia.Disciplina.Id == disciplina.Id)
                {
                    cmbMateria.Items.Add(materia);
                }
            }

            cmbMateria.Enabled = true;
        }
    }
}
