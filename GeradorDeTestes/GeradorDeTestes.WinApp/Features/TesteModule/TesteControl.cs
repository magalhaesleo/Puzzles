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

namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    public partial class TesteControl : UserControl
    {
        public TesteControl()
        {
            InitializeComponent();
        }

        internal void listarTestes(List<Teste> listTestes)
        {
            listTeste.Items.Clear();
            foreach (Teste teste in listTestes)
            {
                listTeste.Items.Add(teste);
            }
        }

        internal Teste retornaTesteSelecionadaNoListBox()
        {
            return (Teste)listTeste.SelectedItem;
        }

        private void listTeste_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTeste.SelectedIndex >= 0)
            {
                ControleDeReferencia.ReferenciaFormularioPrincipal.btnExcluir.Enabled = true;
            }
        }
    }
}
