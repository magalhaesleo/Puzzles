using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain.helpers;
using GeradorDeTestes.Domain.helpers.ButtonsEnable;
using GeradorDeTestes.Domain.helpers.ToolStripVisible;
using GeradorDeTestes.Applications;

namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    class TesteGerenciadorFormulario : GerenciadorFormulario
    {
        TesteService _testeService;
        DisciplinaService _disciplinaService;
        MateriaService _materiaService;
        TesteControl _testeControl;

        public TesteGerenciadorFormulario()
        {
            _testeService = new TesteService();
            _materiaService = new MateriaService();
            _disciplinaService = new DisciplinaService();
        }

        public override void Adicionar()
        {
            CadastroTeste dialogTeste = new CadastroTeste(_materiaService.SelecionarTodasMaterias(), _disciplinaService.SelecionarTodasDisciplinas());

            DialogResult resultado = dialogTeste.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    //_testeService.AdicionarTeste(dialogTeste.NovaSerie);
                    //MessageBox.Show("Teste gerado");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            //AtualizarListagem();
        }

        public override void AtualizarListagem()
        {
            throw new NotImplementedException();
        }

        public override UserControl CarregarListControl()
        {
            if (_testeControl == null)
                _testeControl = new TesteControl();

            // AtualizarListagem();
            return _testeControl;
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override string ObtemTipo()
        {
            return "Teste";
        }

        public override ButtonsVisible ObtemVisibleButtons()
        {
            return new ButtonsVisible
            {
                btnAdicionar = true,
                btnEditar = false,
                btnExcluir = true
            };
        }

        public override ButtonsEnable ObtemEnableButtons()
        {
            return new ButtonsEnable
            {
                btnAdicionar = true,
                btnEditar = false,
                btnExcluir = false
            };
        }

        public override ToolStripVisible ObtemVisibleToolStrip()
        {
            return new ToolStripVisible
            {
                toolStripBotoes = true
            };
        }
    }
}
