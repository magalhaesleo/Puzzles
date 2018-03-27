using GeradorDeTestes.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.Features.MateriaModule
{
    class MateriaGerenciadorFormulario : GerenciadorFormulario
    {
        MateriaService _materiaService;
        MateriaControl _materiaControl;
        DisciplinaService _disciplinaService;
        SerieService _serieService;
        public MateriaGerenciadorFormulario()
        {
            _disciplinaService = new DisciplinaService();
            _serieService = new SerieService();
            //inicializar service
        }

        public override void Adicionar()
        {
            CadastroMateria dialogMateria = new CadastroMateria(_disciplinaService.SelecionarTodasDisciplinas(), _serieService.SelecionarTodasSeries());

            DialogResult resultado = dialogMateria.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    obterMateriaService().AdicionarMateria(dialogMateria.NovaMateria);
                    MessageBox.Show("Matéria adicionada");
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
            if (_materiaControl == null)
                _materiaControl = new MateriaControl();
            AtualizarListagem();
            return _materiaControl;
        }

        public override void AtualizarListagem()
        {
            _materiaControl.listarMaterias(obterMateriaService().SelecionarTodasMaterias());
        }

        public override string ObtemTipo()
        {
            return "Materia";
        }

        private MateriaService obterMateriaService()
        {
            if (_materiaService == null)
            {
                return new MateriaService();
            }
            else
            {
                return _materiaService;
            }
        }
    }
}
