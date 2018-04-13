using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Applications
{
    public class QuestaoService : IService<Questao>
    {
        private QuestaoDAO _questaoDAO;
        private AlternativaService _alternativaService;

        public QuestaoService()
        {
            _questaoDAO = new QuestaoDAO();
            _alternativaService = new AlternativaService();
        }

        public List<Questao> selecionarQuestoesPorMateria(int idMateria)
        {
            return _questaoDAO.SelecionarQuestoesPorMateria(idMateria);
        }

        public List<int> VerificarQuantidadeDeQuestoesPorMateria(int idMateria)
        {
           return _questaoDAO.VerificarQuantidadeDeQuestoesPorMateria(idMateria);
        }

        public int Adicionar(Questao questao)
        {
            try
            {
                var idQuestao = _questaoDAO.Add(questao);
                return idQuestao;
                foreach (var alternativa in questao.Alternativas)
                {
                    alternativa.IdQuestao = idQuestao;
                    _alternativaService.Adicionar(alternativa);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Questao questao)
        {
            _questaoDAO.Editar(questao);

            if (questao.Alternativas.Count > 0)
            {

                foreach (var alternativa in questao.Alternativas)
                {
                    _alternativaService.Adicionar(alternativa);
                }
            }
        }

        public void Excluir(Questao questao)
        {
            try
            {
                _questaoDAO.Excluir(questao);
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
                return _questaoDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
