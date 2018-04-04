using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.helpers;
using GeradorDeTestes.Domain.helpers.ButtonsEnable;
using GeradorDeTestes.Domain.helpers.ToolStripVisible;

namespace GeradorDeTestes.WinApp.Features.QuestaoModule
{
    public class QuestaoGerenciadorFormulario : GerenciadorFormulario
    {
        private MateriaService _materiaService;
        private QuestaoService _questaoService;
        public QuestaoGerenciadorFormulario()
        {
            _materiaService = new MateriaService();
            _questaoService = new QuestaoService();
        }

        public QuestaoControl _questaoControl { get; private set; }

        public override void Adicionar()
        {
            CadastroQuestao dialogQuestao = new CadastroQuestao(_materiaService.SelecionarTodasMaterias());

            DialogResult resultado = dialogQuestao.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    _questaoService.AdicionarQuestao(dialogQuestao.NovaQuestao);
                    MessageBox.Show("Questão adicionada com sucesso");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            AtualizarListagem();
        }

        public override void AtualizarListagem()
        {
            _questaoControl.listarQuestoes(_questaoService.SelecionarTodasQuestoes());
            _questaoControl.listaComboBoxes(_materiaService.SelecionarTodasMaterias());
        }

        public override UserControl CarregarListControl()
        {
            if (_questaoControl == null)
                _questaoControl = new QuestaoControl(_materiaService.SelecionarTodasMaterias());
            AtualizarListagem();
            return _questaoControl;
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
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

        public override string ObtemTipo()
        {
            return "Questão";
        }

        public override ButtonsVisible ObtemVisibleButtons()
        {
            return new ButtonsVisible
            {
                btnAdicionar = true,
                btnEditar = true,
                btnExcluir = true
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
