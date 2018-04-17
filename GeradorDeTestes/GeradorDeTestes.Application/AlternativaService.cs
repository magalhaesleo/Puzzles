using System;
using GeradorDeTestes.Domain.Entidades;
using System.Collections.Generic;
using GeradorDeTestes.Domain.Interfaces;
using GeradorDeTestes.Application.IoC;

namespace GeradorDeTestes.Applications
{
    public class AlternativaService : IService<Alternativa>
    {

        public List<Alternativa> SelecionarAlternativasPorQuestao(int idQuestao)
        {
            return IOCdao.AlternativaDAO.PegarAlternativasDaQuestaoPorID(idQuestao);
        }

        public int Adicionar(Alternativa alternativa)
        {
            return IOCdao.AlternativaDAO.Add(alternativa);
        }

        public void Editar(Alternativa alternativa)
        {
            try
            {
                IOCdao.AlternativaDAO.Editar(alternativa);
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
                IOCdao.AlternativaDAO.Excluir(alternativa);
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
                return IOCdao.AlternativaDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}