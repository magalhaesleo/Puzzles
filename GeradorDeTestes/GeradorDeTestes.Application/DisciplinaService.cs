using GeradorDeTestes.Application.IoC;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.Applications
{
    public class DisciplinaService : IService<Disciplina>
    {

        public int Adicionar(Disciplina disciplina)
        {
            try
            {
                validarExistenciaDisciplina(disciplina);
                return IOCRepository.DisciplinaRepository.Add(disciplina);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Disciplina disciplina)
        {
            try
            {
                IOCRepository.DisciplinaRepository.Editar(disciplina);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir(Disciplina disciplina)
        {
            try
            {
                List<Materia> listmateria = IOCRepository.MateriaRepository.GetAll();
                foreach (Materia materia in listmateria)
                {
                    if (materia.Disciplina.Id == disciplina.Id)
                    {
                        throw new Exception("Não foi possivel excluir, a disciplina esta sendo utilizada!");
                    }
                }
                IOCRepository.DisciplinaRepository.Excluir(disciplina);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Disciplina> GetAll()
        {
            try
            {
                return IOCRepository.DisciplinaRepository.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return IOCRepository.DisciplinaRepository.GetAll();
            }
        }

        private void validarExistenciaDisciplina(Disciplina disciplina)
        {
            var listDisciplinas = GetAll();

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
