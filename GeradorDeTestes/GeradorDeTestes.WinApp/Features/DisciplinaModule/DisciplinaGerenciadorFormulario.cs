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
using GeradorDeTestes.Application.IoC;
using GeradorDeTestes.WinApp.IoC;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    public class DisciplinaGerenciadorFormulario : GerenciadorFormulario
    {

        public override void Adicionar()
        {
            CadastroDisciplina dialogDisciplina = new CadastroDisciplina(IoC.IOCuserControl.DisciplinaControl, true, IOCService.DisciplinaService.GetAll());

            DialogResult resultado = dialogDisciplina.ShowDialog();

            if (DialogResult.OK == resultado)
            {
                try
                {
                    IOCService.DisciplinaService.Adicionar(dialogDisciplina.NovaDisciplina);
                    MessageBox.Show("Disciplina adicionada");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
               
            }

            AtualizarListagem();
        }

        public override void Excluir()
        {
            var disciplinasSelecionadaNoListBox = IoC.IOCuserControl.DisciplinaControl.retornaItemSelecionadoNoListBox();
            try
            {

                DialogResult resultado = MessageBox.Show("Deseja excluir a disciplina?", disciplinasSelecionadaNoListBox.Nome, MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    IOCService.DisciplinaService.Excluir(disciplinasSelecionadaNoListBox);
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
            IoC.IOCuserControl.DisciplinaControl.listarDisciplinas(IOCService.DisciplinaService.GetAll());
        }

        public override void Editar()
        {

            CadastroDisciplina disciplinaPopUp = new CadastroDisciplina(IoC.IOCuserControl.DisciplinaControl, false, IOCService.DisciplinaService.GetAll());

            DialogResult resultado = disciplinaPopUp.ShowDialog();


            if (DialogResult.OK == resultado)
            {
                try
                {
                    IOCService.DisciplinaService.Editar(disciplinaPopUp.DisciplinaEditada);
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
                btnExportar = false,
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
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExportarTeste.Visible = buttonsVisible.btnExportar;
        }

        public override ToolStripVisible ObtemVisibleToolStrip()
        {
            return new ToolStripVisible
            {
                toolStripBotoes = true
            };
        }

        public override UserControl CarregarListControl()
        {
            return IOCuserControl.DisciplinaControl;
        }
    }
}
