using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using GeradorDeTestes.Infra;
using GeradorDeTestes.Infra.Data;
using GeradorDeTestes.Infra.Exportação;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Applications
{
    public class TesteService : IService<Teste>
    {
        private TesteDAO _testeDAO;
        private QuestaoService _questaoService;
        private AlternativaService _alternativaService;
        private IRepository<Teste> _repositorio;
        private ExportarTesteParaArquivo _exportarTeste = new ExportarTesteParaArquivo();


        public TesteService()
        {
            //FAZER IOC (receber os 3 por parametro)
            _testeDAO = new TesteDAO();
            _questaoService = new QuestaoService();
            _alternativaService = new AlternativaService();
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
        public Teste CarregarQuestoesTeste(Teste teste)
        {
            List<Questao> listQuestoesDoTeste = _testeDAO.PegarQuestoesPorTeste(teste.Id);

            foreach (var questao in listQuestoesDoTeste)
            {
                questao.Alternativas = _alternativaService.SelecionarAlternativasPorQuestao(questao.Id);
            }
            teste.Questoes = listQuestoesDoTeste;

            return teste;
        }
        public void ExportarPDF(Teste teste, string path)
        {
            _exportarTeste.GerarPDF(teste, GerarListaDeRespostas(teste.Id), path);

        }


        public List<Resposta> GerarListaDeRespostas(int idTeste)
        {
            return _testeDAO.PegarRespostasPorTeste(idTeste);
        }

        public void GerarPDFGabarito(Teste teste, string path)
        {
            _exportarTeste.GabaritoToPDF(teste, GerarListaDeRespostas(teste.Id), path);
        }

        public void ExportarXMLTeste(Teste teste, string path)
        {
            _exportarTeste.GerarXML(teste, path);
        }

        public void ExportarCSVTeste(Teste teste, string path)
        {
            _exportarTeste.GerarCSV(teste, path);
        }

        public int Adicionar(Teste teste)
        {
            try
            {
                teste.Id = _testeDAO.Add(teste);
                int x = 1;

                foreach (Questao questaoQueEstaSendoAdicionada in teste.Questoes)
                {
                    _testeDAO.AddTesteQuestao(questaoQueEstaSendoAdicionada.Id, teste.Id, x);
                    x++;
                }

                return teste.Id;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Teste entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Teste teste)
        {
            try
            {
                _testeDAO.Excluir(teste);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Teste> GetAll()
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

