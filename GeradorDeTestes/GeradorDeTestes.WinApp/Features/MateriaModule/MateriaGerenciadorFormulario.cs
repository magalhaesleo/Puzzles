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

namespace GeradorDeTestes.WinApp.Features.MateriaModule
{
    public class MateriaGerenciadorFormulario : GerenciadorFormulario
    {
        MateriaService _materiaService;
        MateriaControl _materiaControl;
        DisciplinaService _disciplinaService;
        SerieService _serieService;
        public MateriaGerenciadorFormulario()
        {
            _serieService = new SerieService();
            _disciplinaService = new DisciplinaService();
            _materiaService = new MateriaService();
        }

        public override void Adicionar()
        {
            CadastroMateria dialogMateria = new CadastroMateria(_disciplinaService.GetAll(), _serieService.GetAll(), _materiaControl, true, _materiaService);

            DialogResult resultado = dialogMateria.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    _materiaService.Adicionar(dialogMateria.NovaMateria);
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
            CadastroMateria dialogMateria = new CadastroMateria(_disciplinaService.GetAll(), _serieService.GetAll(), _materiaControl, false, _materiaService);

            DialogResult resultado = dialogMateria.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    _materiaService.Editar(dialogMateria.MateriaEditada);
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

            var materiaSelecionadaNoListBox = _materiaControl.RetornaMateriaSelecionadaNoListBox();
            try
            {
                DialogResult resultado = MessageBox.Show("Realmente deseja excluir a matéria?", "Informativo", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    _materiaService.Excluir(materiaSelecionadaNoListBox);
                }

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            definirEnableButtons(ObtemEnableButtons());
            AtualizarListagem();
        }

        public override UserControl CarregarListControl()
        {
            if (_materiaControl == null)
                _materiaControl = new MateriaControl();
            AtualizarListagem();
            return _materiaControl;
        }

        public override void AtualizarListagem()
        {
            _materiaControl.listarMaterias(_materiaService.GetAll());
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
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExportarTeste.Visible = buttonsVisible.btnVisualizarTeste;
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
