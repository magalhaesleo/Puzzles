using GeradorDeTestes.Applications;
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

namespace GeradorDeTestes.WinApp.Features.MateriaModule
{
    public class MateriaGerenciadorFormulario : GerenciadorFormulario
    {
        public override void Adicionar()
        {
            CadastroMateria dialogMateria = new CadastroMateria(true);

            DialogResult resultado = dialogMateria.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    IOCService.MateriaService.Adicionar(dialogMateria.NovaMateria);
                    MessageBox.Show("Matéria adicionada com sucesso");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            AtualizarListagem();
        }

        public override void Editar()
        {
            CadastroMateria dialogMateria = new CadastroMateria(false);

            DialogResult resultado = dialogMateria.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    IOCService.MateriaService.Editar(dialogMateria.MateriaEditada);
                    MessageBox.Show("Matéria atualizada com sucesso");
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

            var materiaSelecionadaNoListBox = IoC.IOCuserControl.MateriaControl.RetornaMateriaSelecionadaNoListBox();
            try
            {
                DialogResult resultado = MessageBox.Show("Realmente deseja excluir a matéria?", "Informativo", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    IOCService.MateriaService.Excluir(materiaSelecionadaNoListBox);
                }

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
            IoC.IOCuserControl.MateriaControl.listarMaterias(IOCService.MateriaService.GetAll());
        }

        public override string ObtemTipo()
        {
            return "Materia";
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
            AtualizarListagem();
            return IOCuserControl.MateriaControl;
        }
    }
}
