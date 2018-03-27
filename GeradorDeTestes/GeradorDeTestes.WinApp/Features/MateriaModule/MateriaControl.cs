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

namespace GeradorDeTestes.WinApp.Features.MateriaModule
{
    public partial class MateriaControl : UserControl
    {
        public MateriaControl()
        {
            InitializeComponent();
        }

        public void listarMaterias(List<Materia> listMaterias)
        {
            listMateria.Items.Clear();
            foreach (var item in listMaterias)
            {
                listMateria.Items.Add(item);
            }
        }
    }
}
