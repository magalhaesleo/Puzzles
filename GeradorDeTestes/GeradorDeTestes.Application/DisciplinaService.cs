using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.Applications
{
    public class DisciplinaService
    {

        private DisciplinaDAO _disciplinaDAO;

        public DisciplinaService()
        {
            _disciplinaDAO = new DisciplinaDAO();

        }

        public Disciplina AdicionarDisciplina(Disciplina disciplina)
        {
            
            try
            {
                disciplina.Validate();
                validarExistenciaDisciplina(disciplina);
                _disciplinaDAO.Add(disciplina);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return disciplina;
        }

        public Disciplina AtualizarDisciplina(Disciplina disciplina)
        {
            try
            {
                disciplina.Validate();
                validarExistenciaDisciplina(disciplina);
                _disciplinaDAO.Editar(disciplina);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return disciplina;
        }

        public Disciplina ExcluirDisciplina(Disciplina disciplina)
        {
            try
            {
                _disciplinaDAO.Excluir(disciplina);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return disciplina;
        }

        
       public List<Disciplina> SelecionarTodasDisciplinas()
        {
          return  _disciplinaDAO.GetAll();

         }
        

        public Disciplina SelecionarDisciplina(int id)
        {
            try
            {

            }
            catch
            {

            }

            //getById
            return new Disciplina();
        }

        private void validarExistenciaDisciplina(Disciplina disciplina)
        {
            var listDisciplinas = SelecionarTodasDisciplinas();

            foreach (var disciplinaListada in listDisciplinas)
            {
                if (disciplinaListada.Nome == disciplinaListada.Nome)
                {
                    throw new Exception("A disciplina já esta cadastrada no banco de dados");
                }
            }
        }


    }
}
