using System;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.Data;
using System.Collections.Generic;
using GeradorDeTestes.Domain.Interfaces;

namespace GeradorDeTestes.Applications
{
    public class AlternativaService : IService<Alternativa>
    {
        private AlternativaDAO _alternativaDao;

        public AlternativaService()
        {
            _alternativaDao = new AlternativaDAO();
        }

        public List<Alternativa> SelecionarAlternativasPorQuestao(int idQuestao)
        {
           return _alternativaDao.PegarAlternativasDaQuestaoPorID(idQuestao);
        }

        public int Adicionar(Alternativa alternativa)
        {
           return _alternativaDao.Add(alternativa);
        }

        public void Editar(Alternativa alternativa)
        {
            try
            {
                _alternativaDao.Editar(alternativa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir(Alternativa alternativa)
        {
            try
            {
                _alternativaDao.Excluir(alternativa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Alternativa> GetAll()
        {
            try
            {
                return _alternativaDao.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}