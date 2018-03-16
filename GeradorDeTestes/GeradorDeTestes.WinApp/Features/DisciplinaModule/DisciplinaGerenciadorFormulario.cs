using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    public class DisciplinaGerenciadorFormulario : GerenciadorFormulario
    {

        DisciplinaService _disciplinaService = new DisciplinaService();
        DisciplinaControl _disciplinaControl;
        DisciplinaButtonsControl _disciplinaButtonsControl;

        public override void Adicionar(Object disciplina)
        {
            _disciplinaService.AdicionarDisciplina(disciplina as Disciplina);
        }

        public override UserControl CarregarButtonsControl()
        {
            if (_disciplinaButtonsControl == null)
                _disciplinaButtonsControl = new DisciplinaButtonsControl(this);

            return _disciplinaButtonsControl;
        }

        public override UserControl CarregarListControl()
        {
            if (_disciplinaControl == null)
                _disciplinaControl = new DisciplinaControl();

            return _disciplinaControl;
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }
    }
}
