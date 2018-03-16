using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    public partial class CadastroDisciplina : Form
    {
        public CadastroDisciplina()
        {
            InitializeComponent();
        }

        public Disciplina NovaDisciplina
        {
            get
            {
                var disciplina = new Disciplina();
                disciplina.Nome = txtNome.Text;

                return disciplina;
            }
        }
    }
}
