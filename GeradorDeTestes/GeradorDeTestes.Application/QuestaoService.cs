using GeradorDeTestes.Application.IoC;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Applications
{
    public class QuestaoService : IService<Questao>
    {
   
        public List<Questao> selecionarQuestoesPorMateria(int idMateria)
        {
            return IOCdao.QuestaoDAO.SelecionarQuestoesPorMateria(idMateria);
        }

        public List<int> VerificarQuantidadeDeQuestoesPorMateria(int idMateria)
        {
            return IOCdao.QuestaoDAO.VerificarQuantidadeDeQuestoesPorMateria(idMateria);
        }

        public int Adicionar(Questao questao)
        {
            try
            {
                var idQuestao = IOCdao.QuestaoDAO.Add(questao);
                
                foreach (var alternativa in questao.Alternativas)
                {
                    alternativa.IdQuestao = idQuestao;
                    IOCService.AlternativaService.Adicionar(alternativa);
                }
                return idQuestao;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Questao questao)
        {
            IOCdao.QuestaoDAO.Editar(questao);

            if (questao.Alternativas.Count > 0)
            {

                foreach (var alternativa in questao.Alternativas)
                {
                    IOCService.AlternativaService.Adicionar(alternativa);
                }
            }
        }

        public void Excluir(Questao questao)
        {
            try
            {
                IOCdao.QuestaoDAO.Excluir(questao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Questao> GetAll()
        {
            try
            {
                return IOCdao.QuestaoDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
