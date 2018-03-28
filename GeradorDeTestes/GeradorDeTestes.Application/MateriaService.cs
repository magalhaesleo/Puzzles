using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;

namespace GeradorDeTestes.Applications
{
    public class MateriaService
    {
        private MateriaDAO _materiaDAO;

        public MateriaService()
        {
            _materiaDAO = new MateriaDAO();
        }

        public Materia AdicionarMateria(Materia materia)
        {            
            try
            {
                validarExistenciaMateria(materia);
                _materiaDAO.Add(materia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return materia;
        }

        public Materia AtualizarMateria(Materia materia)
        {
            try
            {
                _materiaDAO.Editar(materia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return materia;
        }

        public Materia ExcluirMateria(Materia materia)
        {
            try
            {
                _materiaDAO.Excluir(materia);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return materia;
        }
                
       public List<Materia> SelecionarTodasMaterias()
        {
            try
            {
                return _materiaDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


       private void validarExistenciaMateria(Materia materia)
        {
            var listMaterias = SelecionarTodasMaterias();

            foreach (var materiaAtual in listMaterias)
            {
                if (materiaAtual.Nome == materia.Nome)
                {
                    throw new Exception("A materia já esta cadastrada no banco de dados");
                }
            }
       }
    }
}
