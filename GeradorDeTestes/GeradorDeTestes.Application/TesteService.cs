using GeradorDeTestes.Application.IoC;
using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces;
using GeradorDeTestes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Applications
{
    public class TesteService : IService<Teste>
    {

        public List<Questao> SelecionaQuestoesAleatorias(int limit, int idMateria)
        {
            try
            {
                return IOCdao.TesteDAO.PegarQuestoesAleatoriasPorMateria(limit, idMateria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Teste CarregarQuestoesTeste(Teste teste)
        {
            List<Questao> listQuestoesDoTeste = IOCdao.TesteDAO.PegarQuestoesPorTeste(teste.Id);

            foreach (var questao in listQuestoesDoTeste)
            {
                questao.Alternativas = IOCService.AlternativaService.SelecionarAlternativasPorQuestao(questao.Id);
            }
            teste.Questoes = listQuestoesDoTeste;

            return teste;
        }
        public List<Resposta> GerarListaDeRespostas(int idTeste)
        {
            return IOCdao.TesteDAO.PegarRespostasPorTeste(idTeste);
        }

        public void GerarPDFGabarito(Teste teste, string path)
        {
            IOCExportarTesteParaArquivo.ExportarTeste.GabaritoToPDF(teste, GerarListaDeRespostas(teste.Id), path);
        }

        public void ExportarXMLTeste(Teste teste, string path)
        {
            IOCExportarTesteParaArquivo.ExportarTeste.GerarXML(teste, path);
        }

        public void ExportarCSVTeste(Teste teste, string path)
        {
            IOCExportarTesteParaArquivo.ExportarTeste.GerarCSV(teste, path);
        }
        public void ExportarPDF(Teste teste, string path)
        {
            IOCExportarTesteParaArquivo.ExportarTeste.GerarPDF(teste, GerarListaDeRespostas(teste.Id), path);
        }

        public int Adicionar(Teste teste)
        {
            int idTeste = 0;
            try
            {
                return idTeste = IOCdao.TesteDAO.Add(teste);
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
                IOCdao.TesteDAO.Excluir(teste);
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
                return IOCdao.TesteDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

