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
    }
}
