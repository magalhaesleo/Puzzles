using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Interfaces.Disciplinas
{
    interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Dictionary<string, object> RetornaDictionaryDeDisciplina(Disciplina disciplina);
        Func<IDataReader, Disciplina> FormaObjetoDisciplina(IDataReader reader);
    }
}
