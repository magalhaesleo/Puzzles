﻿using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.helpers;
using GeradorDeTestes.Domain.helpers.ButtonsEnable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain.helpers.ToolStripVisible;

namespace GeradorDeTestes.WinApp.Features.SerieModule
{
    class SerieGerenciadorFormulario : GerenciadorFormulario
    {

        SerieService _serieService;
        SerieControl _serieControl;

        public SerieGerenciadorFormulario()
        {
            _serieService = new SerieService();
        }

        public override void Adicionar()
        {
            CadastroSerie dialogSerie = new CadastroSerie(_serieService.SelecionarTodasSeries());

            DialogResult resultado = dialogSerie.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    _serieService.AdicionarSerie(dialogSerie.NovaSerie);
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
            var serieSelecionadaNoListBox = _serieControl.retornaSerieSelecionadaNoListBox();

            try
            {
                DialogResult resultado = MessageBox.Show("Deseja excluir a serie de número: " + Convert.ToString(serieSelecionadaNoListBox.Numero) + "?", "Atenção", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    _serieService.ExcluirSerie(serieSelecionadaNoListBox);
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

        public override UserControl CarregarListControl()
        {
            if (_serieControl == null)
                _serieControl = new SerieControl();

            AtualizarListagem();
            return _serieControl;
        }

        public override void AtualizarListagem()
        {
            _serieControl.listarSeries(_serieService.SelecionarTodasSeries());
        }

        public override string ObtemTipo()
        {
            return "Série";
        }

        private SerieService obterSerieService()
        {
            if (_serieService == null)
            {
                return new SerieService();
            }
            else
            {
                return _serieService;
            }
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
    }
}
