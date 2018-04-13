using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    public partial class ExportarTesteDialog : Form
    {
        public ExportarTesteDialog()
        {
            InitializeComponent();
        }

        public int ObterFormatoSelecionado()
        {
            if (rbPDF.Checked)
            {
                return 1;
            }
            else if (rbXML.Checked)
            {
                return 2;
            }
            return 3;

        }
    }
}
