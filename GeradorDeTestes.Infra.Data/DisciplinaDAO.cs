using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Data
{
    public class DisciplinaDAO
    {
        #region Scripts SQL

        /// <summary>
        /// Scripts para manipulação das tabelas do banco de dados
        /// </summary>
        public const string _sqlInsert = @"INSERT INTO DISCIPLINA
                                                           (NOME)
                                                      VALUES
                                                            ({0}NOME";

        #endregion Scripts SQL


        public Disciplina Add(Disciplina disciplina)
        {
            Disciplina.Id = DBManager.Insert(_sqlInsert, Take(disciplina));

            return disciplina;
        }

        private Dictionary<string, object> Take(Disciplina disciplina)
        {
            return new Dictionary<string, object>
            {
                { "ID", disciplina.Id },
                { "TITLE", disciplina.Title }
            };
        }
    }
}
