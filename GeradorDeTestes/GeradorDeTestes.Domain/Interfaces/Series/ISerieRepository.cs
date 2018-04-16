using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Interfaces.Series
{
    public interface ISerieRepository : IRepository<Serie>
    {
        Dictionary<string, object> RetornaDictionaryDeSerie(Serie serie);

        Func<IDataReader, Serie> FormaObjetoSerie(IDataReader reader);
    }
}
