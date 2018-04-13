using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;

namespace GeradorDeTestes.Applications
{
    public class MateriaService : IService<Materia>
    {
        private MateriaDAO _materiaDAO;
        private QuestaoService _questaoService;

        public MateriaService()
        {
            _materiaDAO = new MateriaDAO();
            _questaoService = new QuestaoService();
        }

        public int Adicionar(Materia materia)
        {
            try
            {
                ValidarExistenciaMateria(materia);
             return _materiaDAO.Add(materia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Materia materia)
        {
            try
            {
                _materiaDAO.Editar(materia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir(Materia materia)
        {
            try
            {
                List<Questao> listQuestoes = _questaoService.GetAll();
                foreach (Questao q in listQuestoes)
                {
                    if (q.Materia.Id == materia.Id)
                    {
                        throw new Exception("Não foi possivel excluir, a matéria esta sendo utilizada em uma questão!");
                    }
                }
                _materiaDAO.Excluir(materia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Materia> GetAll()
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

        public void ValidarExistenciaMateria(Materia materia)
        {
            var listMaterias = GetAll();

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
