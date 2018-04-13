using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Interfaces.Testes
{
    interface ITesteRepository : IRepository<Teste>
    {
     void AddTesteQuestao(int IdQuestao, int IdTeste, int PosicaoNoTeste);

        List<Questao> PegarQuestoesAleatoriasPorMateria(int quantidade, int idMateria);

        Dictionary<string, object> RetornaDictionaryDeTeste(Teste teste);

        List<Questao> PegarQuestoesPorTeste(int idTeste);

        List<Resposta> PegarRespostasPorTeste(int idTeste);

        Func<IDataReader, Teste> FormaObjetoTeste(IDataReader reader);

        Func<IDataReader, Resposta> FormaObjetoResposta(IDataReader reader);

    }
}
