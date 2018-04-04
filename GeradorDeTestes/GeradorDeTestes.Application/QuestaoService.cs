using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Applications
{
    class QuestaoService
    {
        private QuestaoDAO _questaoDAO;
        private AlternativaService _alternativaService;

        public QuestaoService()
        {
            _questaoDAO = new QuestaoDAO();
            _alternativaService = new AlternativaService();
        }

        public Questao AdicionarQuestao(Questao questao)
        {
            

            try
            {
                var idQuestao = _questaoDAO.Add(questao);
                foreach (var alternativa in questao.Alternativas)
                {
                    alternativa.IdQuestao = idQuestao;
                    _alternativaService.AdicionarAlternativa(alternativa);
                }
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return questao;
        }

        internal List<Questao> selecionarQuestoesPorMateria(int idMateria)
        {
          return  _questaoDAO.SelecionarQuestoesPorMateria(idMateria);
         }
        

        public Questao AtualizarQuestao(Questao questao)
        {
            try
            {
                _questaoDAO.Editar(questao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return questao;
        }

        public Questao ExcluirQuestao(Questao questao)
        {
            try
            {
                _questaoDAO.Excluir(questao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return questao;
        }

        public List<Questao> SelecionarTodasQuestoes()
        {
            try
            {
                return _questaoDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


      
    }
}
