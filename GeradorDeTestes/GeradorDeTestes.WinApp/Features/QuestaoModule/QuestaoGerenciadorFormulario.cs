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
            CadastroQuestao dialogQuestao = new CadastroQuestao(_materiaService.GetAll());

            DialogResult resultado = dialogQuestao.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    _questaoService.Adicionar(dialogQuestao.NovaQuestao);
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
            _questaoControl.listarQuestoes(_questaoService.GetAll());
            _questaoControl.listaComboBoxes(_materiaService.GetAll());
        }

        public override UserControl CarregarListControl()
        {
            if (_questaoControl == null)
                _questaoControl = new QuestaoControl(_materiaService.GetAll());
            AtualizarListagem();
            return _questaoControl;
        }

        public override void Editar()
        {
            CadastroQuestao dialogQuestao = new CadastroQuestao(_materiaService.GetAll(), _questaoControl.RetornaQuestaoSelecionadaNoListBox());
       
             DialogResult resultado = dialogQuestao.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    _questaoService.Editar(dialogQuestao.QuestaoEditada);
                    MessageBox.Show("Questão atualizada com sucesso");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }

            definirEnableButtons(ObtemEnableButtons());
            AtualizarListagem();
        }

        public override void Excluir()
        {
            var questaoSelecionadaNoListBox = _questaoControl.RetornaQuestaoSelecionadaNoListBox();
            try
            {
                DialogResult resultado = MessageBox.Show("Tem certeze que deseja excluir essa questão?", "Informativo", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    _questaoService.Excluir(questaoSelecionadaNoListBox);
                }

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            definirEnableButtons(ObtemEnableButtons());
            AtualizarListagem();
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

        public void definirEnableButtons(ButtonsEnable buttonsEnable)
        {
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExcluir.Enabled = buttonsEnable.btnExcluir;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnEditar.Enabled = buttonsEnable.btnEditar;
        }

        public void definirVisibleButtons(ButtonsVisible buttonsVisible)
        {
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnGerarGabarito.Visible = buttonsVisible.btnGerarGabarito;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExportarTeste.Visible = buttonsVisible.btnVisualizarTeste;
        }
    }
}
