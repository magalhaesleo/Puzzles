using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Application
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

        public Teste AdicionarTeste(Teste teste)
        {
            
            var random = new Random();
            try
            {
             var idTeste = _testeDAO.Add(teste);
             var listQuestoes = _questaoService.selecionarQuestoesPorMateria(teste.Materia.Id);

                for (int i = 0; i < teste.NumeroDeQuestoes; i++)
                {
                    var posicao = random.Next(1,listQuestoes.Count);
                    _testeDAO.AddTesteQuestao(listQuestoes[posicao].Id, idTeste, i);
                }
            }

            
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


           
           
            



            return teste;
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


       
    }
}

