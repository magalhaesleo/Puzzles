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
using GeradorDeTestes.Application.IoC;
using GeradorDeTestes.WinApp.IoC;

namespace GeradorDeTestes.WinApp.Features.TesteModule
{

   public class TesteGerenciadorFormulario : GerenciadorFormulario
    {
        ButtonsEnable _buttonsEnable;

        public TesteGerenciadorFormulario()
        {
            _buttonsEnable = new ButtonsEnable();
        }

        public override void Adicionar()
        {
            CadastroTeste dialogTeste = new CadastroTeste(IOCService.MateriaService.GetAll(), IOCService.DisciplinaService.GetAll(), IOCService.TesteService, IOCService.QuestaoService);

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

                        Teste testeAdicionado = dialogTeste.Teste;
                        IOCService.TesteService.Adicionar(testeAdicionado);
                        IOCService.TesteService.ExportarPDF(testeAdicionado, path);
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
            IOCuserControl.TesteControl.listarTestes(IOCService.TesteService.GetAll());
        }


        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            Teste testeSelecionadaNoListBox = IOCuserControl.TesteControl.retornaTesteSelecionadaNoListBox();

            try
            {
                DialogResult resultado = MessageBox.Show("Deseja excluir o teste: " + Convert.ToString(testeSelecionadaNoListBox.Nome) + "?", "Atenção", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == resultado)
                {
                    IOCService.TesteService.Excluir(testeSelecionadaNoListBox);
                    MessageBox.Show("Teste excluído com sucesso");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExcluir.Enabled = _buttonsEnable.btnExcluir;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExportarTeste.Enabled = _buttonsEnable.btnExportar;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnGerarGabarito.Enabled = _buttonsEnable.btnGerarGabarito;

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
                    Teste testeSelecionadaNoListBox = IOCuserControl.TesteControl.retornaTesteSelecionadaNoListBox();
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;
                        testeSelecionadaNoListBox = IOCService.TesteService.CarregarQuestoesTeste(testeSelecionadaNoListBox);
                        switch (rbSelecionado)
                        {
                            case 1:
                                IOCService.TesteService.ExportarPDF(testeSelecionadaNoListBox, path);
                                break;
                            case 2:
                                IOCService.TesteService.ExportarXMLTeste(testeSelecionadaNoListBox, path);
                                break;
                            case 3:
                                IOCService.TesteService.ExportarCSVTeste(testeSelecionadaNoListBox, path);
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
            Teste testeSelecionadaNoListBox = IOCuserControl.TesteControl.retornaTesteSelecionadaNoListBox();
            try
            {

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "PDF File |*.pdf";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;
                    IOCService.TesteService.GerarPDFGabarito(testeSelecionadaNoListBox, path);
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
                btnExportar = true,
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
                btnExportar = false,
                btnGerarGabarito = false
            };
        }

        public void DefinirEnableButtons(ButtonsEnable buttonsEnable)
        {
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnGerarGabarito.Enabled = buttonsEnable.btnGerarGabarito;
            ControleDeReferencia.ReferenciaFormularioPrincipal.btnExportarTeste.Enabled = buttonsEnable.btnExportar;
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

        public override UserControl CarregarListControl()
        {
            return IOCuserControl.TesteControl;
        }
    }
}
