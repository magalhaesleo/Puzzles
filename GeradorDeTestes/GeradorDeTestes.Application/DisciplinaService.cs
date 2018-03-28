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
        private MateriaDAO _materiaDAO;
        public DisciplinaService()
        {
            _disciplinaDAO = new DisciplinaDAO();
            _materiaDAO = new MateriaDAO();

        }

        public Disciplina AdicionarDisciplina(Disciplina disciplina)
        {
            
            try
            {
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
                List<Materia> listmateria = _materiaDAO.GetAll();
                foreach (Materia materia in listmateria)
                {
                    if (materia.Disciplina.Id == disciplina.Id)
                    {
                        throw new Exception("Não foi possivel excluir, a disciplina esta sendo utilizada!");
                    }
                }
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
            try
            {
                return _disciplinaDAO.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return _disciplinaDAO.GetAll();
            }

         }
        
        private void validarExistenciaDisciplina(Disciplina disciplina)
        {
            var listDisciplinas = SelecionarTodasDisciplinas();

            foreach (var disciplinaListada in listDisciplinas)
            {
                if (disciplinaListada.Nome == disciplina.Nome)
                {
                    throw new Exception("A disciplina já esta cadastrada no banco de dados");
                }
            }
        }


    }
}
