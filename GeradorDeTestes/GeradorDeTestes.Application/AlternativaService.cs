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
            return IOCRepository.AlternativaRepository.PegarAlternativasDaQuestaoPorID(idQuestao);
        }

        public int Adicionar(Alternativa alternativa)
        {
            return IOCRepository.AlternativaRepository.Add(alternativa);
        }

        public void Editar(Alternativa alternativa)
        {
            try
            {
                IOCRepository.AlternativaRepository.Editar(alternativa);
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
                IOCRepository.AlternativaRepository.Excluir(alternativa);
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
                return IOCRepository.AlternativaRepository.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}