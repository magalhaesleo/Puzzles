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

        public override void Adicionar()
        {
            CadastroSerie dialogSerie = new CadastroSerie();

            DialogResult resultado = dialogSerie.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    obterSerieService().AdicionarSerie(dialogSerie.NovaSerie);
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
            throw new NotImplementedException();
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
            _serieControl.listarSeries(obterSerieService().SelecionarTodasSeries());
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
    }
}
