using GeradorDeTestes.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            CadastroSerie dialogSerie = new CadastroSerie();

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
                AtualizarListagem();
            }
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            var serieSelecionadaNoListBox = _serieControl.retornaSerieSelecionadaNoListBox();
            try
            {

                if (serieSelecionadaNoListBox != null)
                {
                    DialogResult resultado = MessageBox.Show("Deseja excluir a matéria?", Convert.ToString(serieSelecionadaNoListBox.Numero), MessageBoxButtons.YesNo);

                    if (DialogResult.Yes == resultado)
                    {
                        _serieService.ExcluirSerie(serieSelecionadaNoListBox);
                        MessageBox.Show("Série excluída com sucesso");
                    }
                }
                else
                {
                    throw new Exception("Nenhuma série selecionada");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
    }
}
