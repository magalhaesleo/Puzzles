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

        private DisciplinaDAO _disciplinaDAO = new DisciplinaDAO();



        public Disciplina AdicionarDisciplina(Disciplina disciplina)
        {
            try
            {
                MessageBox.Show("Sucesso!");
            }
            catch
            {

            }

            return disciplina;
        }

        public Disciplina AtualizarDisciplina(Disciplina disciplina)
        {
            try
            {

            }
            catch
            {

            }

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

        /*
        public IList<Disciplina> SelecionarTodasDisciplinas()
        {
            try
            {

            }
            catch
            {

            }

            //getAll()
            //return new IList<Disciplina> lista;
        }
        */

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
