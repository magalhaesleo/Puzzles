using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.helpers;
using GeradorDeTestes.Domain.helpers.ButtonsEnable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain.helpers.ToolStripVisible;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    public class DisciplinaGerenciadorFormulario : GerenciadorFormulario
    {
        DisciplinaService _disciplinaService;
        DisciplinaControl _disciplinaControl;


        public DisciplinaGerenciadorFormulario()
        {
            _disciplinaService = new DisciplinaService();
        }

        public override void Adicionar()
        {
            CadastroDisciplina dialogDisciplina = new CadastroDisciplina(_disciplinaControl, true, _disciplinaService.SelecionarTodasDisciplinas());

            DialogResult resultado = dialogDisciplina.ShowDialog();

            if (DialogResult.OK == resultado)
            {
                try
                {
                    _disciplinaService.AdicionarDisciplina(dialogDisciplina.NovaDisciplina);
                    MessageBox.Show("Disciplina adicionada");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
               
            }

            AtualizarListagem();
        }

        public override UserControl CarregarListControl()
        {
            if (_disciplinaControl == null)
                _disciplinaControl = new DisciplinaControl();
            AtualizarListagem();
            return _disciplinaControl;
        }

        public override void Excluir()
        {
            var disciplinasSelecionadaNoListBox = _disciplinaControl.retornaItemSelecionadoNoListBox();
            try
            {

                DialogResult resultado = MessageBox.Show("Deseja excluir a disciplina?", disciplinasSelecionadaNoListBox.Nome, MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    _disciplinaService.ExcluirDisciplina(disciplinasSelecionadaNoListBox);
                    MessageBox.Show("Disciplina excluída! :)");
                }


                definirVisibleButtons(ObtemVisibleButtons());
                AtualizarListagem();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            definirEnableButtons(ObtemEnableButtons());
            AtualizarListagem();
        }

        public override void AtualizarListagem()
        {
            _disciplinaControl.listarDisciplinas(_disciplinaService.SelecionarTodasDisciplinas());
        }

        public override void Editar()
        {

            CadastroDisciplina disciplinaPopUp = new CadastroDisciplina(_disciplinaControl, false, _disciplinaService.SelecionarTodasDisciplinas());

            DialogResult resultado = disciplinaPopUp.ShowDialog();


            if (DialogResult.OK == resultado)
            {
                try
                {
                    _disciplinaService.AtualizarDisciplina(disciplinaPopUp.DisciplinaEditada);
                    MessageBox.Show("Disciplina editada!");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            definirEnableButtons(ObtemEnableButtons());
            AtualizarListagem();

        }

        public override string ObtemTipo()
        {
            return "Disciplina";
        }

        public override ButtonsVisible ObtemVisibleButtons()
        {
            return new ButtonsVisible
            {
                btnAdicionar = true,
                btnEditar = true,
                btnExcluir = true,
                btnVisualizarTeste = false,
                btnGerarGabarito = false
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

        public void definirEnableButtons(ButtonsEnable buttonsEnable)
        {
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExcluir.Enabled = buttonsEnable.btnExcluir;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnEditar.Enabled = buttonsEnable.btnEditar;
        }

        public void definirVisibleButtons(ButtonsVisible buttonsVisible)
        {
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnGerarGabarito.Visible = buttonsVisible.btnGerarGabarito;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnVisualizarTeste.Visible = buttonsVisible.btnVisualizarTeste;
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
