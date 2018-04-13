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
using GeradorDeTestes.Domain.Entidades;

namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    class TesteGerenciadorFormulario : GerenciadorFormulario
    {
        TesteService _testeService;
        DisciplinaService _disciplinaService;
        MateriaService _materiaService;
        TesteControl _testeControl;
        QuestaoService _questaoService;

        public TesteGerenciadorFormulario()
        {
            _testeService = new TesteService();
            _materiaService = new MateriaService();
            _disciplinaService = new DisciplinaService();
            _questaoService = new QuestaoService();
        }

        public override void Adicionar()
        {
            CadastroTeste dialogTeste = new CadastroTeste(_materiaService.SelecionarTodasMaterias(), _disciplinaService.SelecionarTodasDisciplinas(), _testeService, _questaoService);

            DialogResult resultado = dialogTeste.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "PDF File |*.pdf";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog1.FileName;
                        _testeService.GerarTeste(dialogTeste.Teste, path);
                        MessageBox.Show("Teste gerado com sucesso");
                        System.Diagnostics.Process.Start(path);
                    }
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
            _testeControl.listarTestes(_testeService.SelecionarTodasTestes());
        }

        public override UserControl CarregarListControl()
        {
            if (_testeControl == null)
                _testeControl = new TesteControl();

            AtualizarListagem();
            return _testeControl;
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            Teste testeSelecionadaNoListBox = _testeControl.retornaTesteSelecionadaNoListBox();

            try
            {
                DialogResult resultado = MessageBox.Show("Deseja excluir o teste: " + Convert.ToString(testeSelecionadaNoListBox.Nome) + "?", "Atenção", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    _testeService.ExcluirTeste(testeSelecionadaNoListBox);
                    MessageBox.Show("Teste excluído com sucesso");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }



            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExcluir.Enabled = ObtemEnableButtons().btnExcluir;

            AtualizarListagem();
        }

        public void ExportarTeste()
        {
            ExportarTesteDialog dialogExportarTeste = new ExportarTesteDialog();

            DialogResult resultado = dialogExportarTeste.ShowDialog();

            if (resultado == DialogResult.OK)
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                int rbSelecionado = dialogExportarTeste.ObterFormatoSelecionado();
                switch (rbSelecionado)
                {
                    case 1:
                        saveFileDialog.Filter = "PDF File |*.pdf";
                        break;
                    case 2:
                        saveFileDialog.Filter = "XML File |*.xml";
                        break;
                    case 3:
                        saveFileDialog.Filter = "CSV File |*.csv";
                        break;
                    default:
                        throw new Exception("Formato selecionado não foi encontrado.");
                }

                try
                {
                    Teste testeSelecionadaNoListBox = _testeControl.retornaTesteSelecionadaNoListBox();
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;

                        switch (rbSelecionado)
                        {
                            case 1:
                                _testeService.GerarTeste(testeSelecionadaNoListBox, path);
                                //mudar?
                                break;
                            case 2:
                                _testeService.ExportarXMLTeste(testeSelecionadaNoListBox);
                                break;
                            case 3:
                                _testeService.ExportarCSVTeste(testeSelecionadaNoListBox);
                                break;
                            default:
                                throw new Exception("Formato selecionado não foi encontrado.");
                        }

                        MessageBox.Show("Teste exportado com sucesso");
                        System.Diagnostics.Process.Start(path);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            DefinirEnableButtons(ObtemEnableButtons());
            AtualizarListagem();
        }

        public void GerarGabarito()
        {
            Teste testeSelecionadaNoListBox = _testeControl.retornaTesteSelecionadaNoListBox();
            try
            {

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "PDF File |*.pdf";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;
                    _testeService.GerarPDFGabarito(testeSelecionadaNoListBox, path);
                    MessageBox.Show("Gabarito do teste: " + testeSelecionadaNoListBox.Nome + " gerado!");
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            DefinirEnableButtons(ObtemEnableButtons());
            AtualizarListagem();

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
                btnExcluir = true,
                btnVisualizarTeste = true,
                btnGerarGabarito = true
            };
        }

        public override ButtonsEnable ObtemEnableButtons()
        {
            return new ButtonsEnable
            {
                btnAdicionar = true,
                btnEditar = false,
                btnExcluir = false,
                btnVisualizarTeste = false,
                btnGerarGabarito = false
            };
        }

        public void DefinirEnableButtons(ButtonsEnable buttonsEnable)
        {
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnGerarGabarito.Enabled = buttonsEnable.btnGerarGabarito;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExportarTeste.Enabled = buttonsEnable.btnVisualizarTeste;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnAdicionar.Enabled = buttonsEnable.btnAdicionar;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnEditar.Enabled = buttonsEnable.btnEditar;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExcluir.Enabled = buttonsEnable.btnExcluir;

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
