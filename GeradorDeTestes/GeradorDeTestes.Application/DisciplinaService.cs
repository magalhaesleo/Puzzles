using GeradorDeTestes.Domain;
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
                _disciplinaDAO.Add(disciplina);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível gravar a disciplina no banco de dados");
            }
            return disciplina;
        }

        public Disciplina AtualizarDisciplina(Disciplina disciplina)
        {
            
            return disciplina;
        }

        public Disciplina ExcluirDisciplina(Disciplina disciplina)
        {
            try
            {

            }
            catch
            {

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



    }
}
