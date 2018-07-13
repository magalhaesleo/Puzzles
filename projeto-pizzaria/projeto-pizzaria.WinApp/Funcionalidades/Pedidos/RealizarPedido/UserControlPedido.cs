using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;

namespace projeto_pizzaria.WinApp.Funcionalidades.Pedidos.RealizarPedido
{
    public partial class UserControlPedido : UserControl
    {
        public UserControlPedido()
        {
            InitializeComponent();
        }

        internal void AtualizarListaDePedidos(IEnumerable<Pedido> listaDePedidos)
        {
            dataGridViewPedidos.DataSource = listaDePedidos.ToList();
        }

        private void dataGridViewPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
