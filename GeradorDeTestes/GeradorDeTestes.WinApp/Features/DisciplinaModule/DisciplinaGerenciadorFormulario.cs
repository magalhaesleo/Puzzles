using GeradorDeTestes.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    class DisciplinaGerenciadorFormulario : GerenciadorFormulario
    {

        DisciplinaService _disciplinaService = new DisciplinaService();

        public override void Adicionar()
        {

            CadastroDisciplina dialog = new CadastroDisciplina();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _disciplinaService.AdicionarDisciplina(dialog.NovaDisciplina);
            }
        }

        public override void CarregarListagem()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }
    }
}
