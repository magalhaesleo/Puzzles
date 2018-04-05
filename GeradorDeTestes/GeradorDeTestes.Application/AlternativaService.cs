using System;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.Data;
using System.Collections.Generic;

namespace GeradorDeTestes.Applications
{
    public class AlternativaService
    {
        private AlternativaDAO _alternativaDao;

        public AlternativaService()
        {
            _alternativaDao = new AlternativaDAO();
        }
        internal void AdicionarAlternativa(Alternativa alternativa)
        {
            _alternativaDao.Add(alternativa);
        }

        public Alternativa AtualizarAlternativa(Alternativa alternativa)
        {
            try
            {
                _alternativaDao.Editar(alternativa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return alternativa;
        }

        public Alternativa ExcluirAlternativa(Alternativa alternativa)
        {
            try
            {
                _alternativaDao.Excluir(alternativa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return alternativa;
        }

        public List<Alternativa> SelecionarTodasAlternativas()
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

        public List<Alternativa> SelecionarAlternativasPorQuestao(int idQuestao)
        {
           return _alternativaDao.PegarAlternativasDaQuestaoPorID(idQuestao);
        }
    }
}