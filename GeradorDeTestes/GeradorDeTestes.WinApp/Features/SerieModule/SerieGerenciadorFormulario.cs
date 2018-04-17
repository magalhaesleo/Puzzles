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
using GeradorDeTestes.Domain.Entidades;

namespace GeradorDeTestes.WinApp.Features.SerieModule
{
    public class SerieGerenciadorFormulario : GerenciadorFormulario
    {

        public override void Adicionar()
        {
            CadastroSerie dialogSerie = new CadastroSerie(IOCService.SerieService.GetAll());

            DialogResult resultado = dialogSerie.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    IOCService.SerieService.Adicionar(dialogSerie.NovaSerie);
                    MessageBox.Show("Série adicionada");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            AtualizarListagem();
        }

        //O processo de edição não esta presente para a entidade série
        /*public override void Editar()
        {
            throw new NotImplementedException();
        }*/

        public override void Excluir()
        {
            Serie serieSelecionadaNoListBox = IOCuserControl.SerieControl.retornaSerieSelecionadaNoListBox();

            try
            {
                DialogResult resultado = MessageBox.Show("Deseja excluir a serie de número: " + Convert.ToString(serieSelecionadaNoListBox.Numero) + "?", "Atenção", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    IOCService.SerieService.Excluir(serieSelecionadaNoListBox);
                    MessageBox.Show("Série excluída com sucesso");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }



            definirEnableButtons(ObtemEnableButtons());
            AtualizarListagem();
        }


        public override void AtualizarListagem()
        {
            IOCuserControl.SerieControl.listarSeries(IOCService.SerieService.GetAll());
        }

        public override string ObtemTipo()
        {
            return "Série";
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

        public override void Editar()
        {
            throw new NotImplementedException();
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
            return IOCuserControl.SerieControl;
        }
    }
}
