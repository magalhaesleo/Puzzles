using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
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

        DisciplinaService _disciplinaService;
        DisciplinaControl _disciplinaControl;
        DisciplinaButtonsControl _disciplinaButtonsControl;

        public DisciplinaGerenciadorFormulario()
        {
            _disciplinaService = new DisciplinaService();
            

           
        }

        public override void Adicionar(Object disciplina)
        {
            try
            {
                _disciplinaService.AdicionarDisciplina(disciplina as Disciplina);
                MessageBox.Show("Disciplina adicionada");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            AtualizarListagemDisciplinas();
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
            AtualizarListagemDisciplinas();
            return _disciplinaControl;
        }

        public override void Excluir(Object objeto)
        {
            _disciplinaService.ExcluirDisciplina(objeto as Disciplina);
        }

        public void AtualizarListagemDisciplinas()
        {
            _disciplinaControl.listarDisciplinas(_disciplinaService.SelecionarTodasDisciplinas());
        }
    }
}
