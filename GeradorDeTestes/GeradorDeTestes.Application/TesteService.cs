using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Infra;
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
        private AlternativaService _alternativaService;


        public TesteService()
        {
            //FAZER IOC (receber os 3 por parametro)
            _testeDAO = new TesteDAO();
            _questaoService = new QuestaoService();
            _alternativaService = new AlternativaService();
        }

        public int AdicionarTeste(Teste teste)
        {
            int idTeste = 0;
            try
            {
                return idTeste = _testeDAO.Add(teste);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

        public void GerarTeste(Teste teste, string path)
        {
            if (teste.Id == 0)
            {
                teste.Id = AdicionarTeste(teste);

                var x = 1;

                foreach (var questaoQueEstaSendoAdicionada in teste.Questoes)
                {
                    _testeDAO.AddTesteQuestao(questaoQueEstaSendoAdicionada.Id, teste.Id, x);
                    x++;
                }

            }
            else
            {
                List<Questao> listQuestoesDoTeste = _testeDAO.PegarQuestoesPorTeste(teste.Id);

                foreach (var questao in listQuestoesDoTeste)
                {
                    questao.Alternativas = _alternativaService.SelecionarAlternativasPorQuestao(questao.Id);
                }
                teste.Questoes = listQuestoesDoTeste;
            }

            List<Resposta> gabarito = GerarListaDeRespostas(teste.Id);

            GeraPDF geraPdf = new GeraPDF(teste, gabarito);
            geraPdf.TesteToPDF(path);
        }


        public List<Resposta> GerarListaDeRespostas(int idTeste)
        {
            return _testeDAO.PegarRespostasPorTeste(idTeste);
        }

        public void GerarPDFGabarito(Teste teste, string path)
        {
            List<Resposta> gabarito = GerarListaDeRespostas(teste.Id);
            GeraPDF geraPdf = new GeraPDF(teste, gabarito);
            geraPdf.GeraGabarito(path);
        }

        public void ExportarXMLTeste(Teste teste)
        {
            //chamar respoitry
        }

        public void ExportarCSVTeste(Teste teste)
        {
            //chamar respoitry
        }


    }
}

