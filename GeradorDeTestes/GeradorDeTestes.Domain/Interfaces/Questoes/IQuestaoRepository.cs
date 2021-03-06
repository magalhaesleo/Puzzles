﻿using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Interfaces.Questoes
{
  public  interface IQuestaoRepository : IRepository<Questao>
    {
        List<Questao> SelecionarQuestoesPorMateria(int IdMateria);
        List<int> VerificarQuantidadeDeQuestoesPorMateria(int IdMateria);
        Dictionary<string, object> RetornaDictionaryDeQuestao(Questao questao);
        Func<IDataReader, Questao> FormaObjetoQuestao(IDataReader reader);
        Func<IDataReader, Questao> FormaQuantidade(IDataReader reader);

        List<Questao> SelecionarQuestoesByFilter(int idMateria, String parametro);



    }
}
