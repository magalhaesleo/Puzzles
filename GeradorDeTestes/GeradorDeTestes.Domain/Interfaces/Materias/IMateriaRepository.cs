using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Interfaces.Materias
{
    interface IMateriaRepository : IRepository<Materia>
    {
        Dictionary<string, object> RetornaDictionaryDeMateria(Disciplina disciplina);
        Func<IDataReader, Disciplina> FormaObjetoMateria(IDataReader reader);
    }
}
