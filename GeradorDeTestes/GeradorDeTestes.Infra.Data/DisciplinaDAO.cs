using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeradorDeTestes.Domain;
using GeradorDeTestes.Infra;

namespace GeradorDeTestes.Infra.Data
{
    public class DisciplinaDAO
    {
        private DBManager _dbManager;
        public DisciplinaDAO(DBManager dBManager)
        {
            this._dbManager = dBManager;
        }

        #region Scripts SQL

        
        public const string _sqlInsert = @"INSERT INTO TBDISCIPLINA
                                                           (NOME)
                                                      VALUES
                                                            (@NOME)";

        #endregion Scripts SQL


        public void Add(Disciplina disciplina)
        {   
            _dbManager.Insert(_sqlInsert, RetornaDictionaryDeDisciplina(disciplina));

            return;
        }

        private Dictionary<string, object> RetornaDictionaryDeDisciplina(Disciplina disciplina)
        {
            return new Dictionary<string, object>
            {
                { "ID", disciplina.Id },
                { "NOME", disciplina.Nome }
            };
        }

        private static Func<IDataReader, Disciplina> FormaObjetoDisciplina = reader =>
          new Disciplina
          {
              Id = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["NOME"])
          };
    }
}
