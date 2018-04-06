using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Applications
{
   public class TesteService
    {
        private TesteDAO _testeDAO;
        private QuestaoService _questaoService;


        public TesteService()
        {
            _testeDAO = new TesteDAO();
            _questaoService = new QuestaoService();
        }

        public int AdicionarTeste(Teste teste)
        {
            int idTeste = 0;
           try
            {
            return idTeste =_testeDAO.Add(teste);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return idTeste;

        }

        public Teste ExcluirTeste(Teste teste)
        {
            try
            {
                _testeDAO.Excluir(teste);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return teste;
        }

        public List<Teste> SelecionarTodasTestes()
        {
            try
            {
                return _testeDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Questao> SelecionaQuestoesAleatorias(int limit, int idMateria)
        {
            try
            {
                return _testeDAO.PegarQuestoesAleatoriasPorMateria(limit, idMateria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void GerarTeste(Teste teste)
        {
            if (teste.Id==0) {
            var testeId = AdicionarTeste(teste);

            var x = 1;

            foreach (var questaoQueEstaSendoAdicionada in teste.Questoes)
            {
                _testeDAO.AddTesteQuestao(questaoQueEstaSendoAdicionada.Id, testeId, x);
                x++;
            }
            } else {
               var listQuestoesDoTeste = _testeDAO.PegarQuestoesPorTeste(teste.Id);
               
               foreach(var questao in listQuestoesDoTeste) {
                   questao.Alternativas = _alternativaService.PegarAlternativasDaQuestaoPorID(questao.Id);
               }
            }
        }


        public void _gerarGabarito(int idTeste) {
            _testeDAO._gerarGabarito(idTeste);
        }

        


    }
}

