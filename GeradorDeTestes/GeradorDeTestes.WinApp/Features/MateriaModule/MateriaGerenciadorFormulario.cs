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
                    //  _materiaService.AdicionarDisciplina(dialogDisciplina.NovaMateria);
                    MessageBox.Show("descomentar linha a cima Matéria adicionada");
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
            var materiaSelecionadaNoListBox = _materiaControl.RetornaMateriaSelecionadaNoListBox();

            CadastroMateria cadastroDialog = new CadastroMateria(materiaSelecionadaNoListBox);

            DialogResult result = cadastroDialog.ShowDialog();

            if ( DialogResult.OK == result)
            {
                try
                {
                    _materiaService.AtualizarMateria(cadastroDialog.NovaMateria);
                }catch(Exception e)
                {

                }
            }

            AtualizarListagem();
        }

        public override void Excluir()
        {
            
            var materiaSelecionadaNoListBox = _materiaControl.RetornaMateriaSelecionadaNoListBox();
            try
            {

                if (materiaSelecionadaNoListBox != null)
                {
                    DialogResult resultado = MessageBox.Show("Deseja excluir a matéria?", materiaSelecionadaNoListBox.Nome, MessageBoxButtons.YesNo);

                    if (DialogResult.Yes == resultado)
                    {
                        _materiaService.ExcluirMateria(materiaSelecionadaNoListBox);
                    }
                }
                else
                {
                    throw new Exception("Nenhuma matéria selecionada");
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

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
