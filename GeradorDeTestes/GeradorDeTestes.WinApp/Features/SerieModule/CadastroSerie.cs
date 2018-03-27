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

namespace GeradorDeTestes.WinApp.Features.SerieModule
{
    public partial class CadastroSerie : Form
    {
        public CadastroSerie()
        {
            InitializeComponent();
        }

        public Serie NovaSerie
        {
            get
            {
                var serie = new Serie();
                serie.Numero = (int)numSerie.Value;
                return serie;
            }
        }

    }
}
