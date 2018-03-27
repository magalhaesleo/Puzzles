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
        //  MateriaService _materiaService;
        MateriaControl _materiaControl;

        public MateriaGerenciadorFormulario()
        {
            //inicializar service
        }

        public override void Adicionar()
        {
            CadastroMateria dialogMateria = new CadastroMateria();

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
            //AtualizarListagem();
            return _materiaControl;
        }

        public override void AtualizarListagem()
        {
            // _materiaControl.listarMaterias(_materiaService.SelecionarTodasMaterias());
        }

        public override string ObtemTipo()
        {
            return "Materia";
        }
    }
}
