using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Interfaces.Alternativas
{
    public interface IAlternativaRepository : IRepository<Alternativa>
    {
        List<Alternativa> PegarAlternativasDaQuestaoPorID(int ID);
        Dictionary<string, object> RetornaDictionaryDeAlternativa(Alternativa alternativa);
        Func<IDataReader, Alternativa> FormaObjetoAlternativa(IDataReader reader);



    }
}
