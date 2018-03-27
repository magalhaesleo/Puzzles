using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.Features.MateriaModule
{
    public partial class CadastroMateria : Form
    {
        public CadastroMateria(List<Disciplina> listDisciplina, List<Serie> listSerie)
        {
            InitializeComponent();
            popularComboBoxDisciplina(listDisciplina);
            popularComboBoxSerie(listSerie);
        }
        public CadastroMateria()
        {
            InitializeComponent();
        }

        public Materia NovaMateria
        {
            get
            {
                var materia = new Materia();
                materia.Nome = txtMateria.Text;

                return materia;
            }
        }

        public void popularComboBoxDisciplina(List<Disciplina> list)
        {
            foreach (var item in list)
            {
                cmbDisciplina.Items.Add(item);
            }
        }

        public void popularComboBoxSerie(List<Serie> list)
        {
            //list.Sort();

            foreach (var item in list)
            {
                cmbSerie.Items.Add(item);
            }
        }
    }
}
