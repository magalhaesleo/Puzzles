using GeradorDeTestes.Application.IoC;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace GeradorDeTestes.Applications
{
    public class MateriaService : IService<Materia>
    {
       
       
        public int Adicionar(Materia materia)
        {
            try
            {
                ValidarExistenciaMateria(materia);
                return IOCdao.MateriaDAO.Add(materia);
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
                IOCdao.MateriaDAO.Editar(materia);
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
                List<Questao> listQuestoes = IOCService.QuestaoService.GetAll();
                foreach (Questao q in listQuestoes)
                {
                    if (q.Materia.Id == materia.Id)
                    {
                        throw new Exception("Não foi possivel excluir, a matéria esta sendo utilizada em uma questão!");
                    }
                }
                IOCdao.MateriaDAO.Excluir(materia);
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
                return IOCService.MateriaService.GetAll();
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
