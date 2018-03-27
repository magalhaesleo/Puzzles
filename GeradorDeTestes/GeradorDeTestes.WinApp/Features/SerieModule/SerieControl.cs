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

namespace GeradorDeTestes.WinApp.Features.SerieModule
{
    public partial class SerieControl : UserControl
    {
        public SerieControl()
        {
            InitializeComponent();
        }

        public void listarSeries(List<Serie> listSeries)
        {
            listSerie.Items.Clear();

            foreach (var item in listSeries)
            {
                listSerie.Items.Add(item);
            }
        }

        public Serie retornaSerieSelecionadaNoListBox()
        {
            return listSerie.SelectedItem as Serie;
        }
    }
}
