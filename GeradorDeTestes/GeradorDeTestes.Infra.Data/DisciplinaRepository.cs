using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces.Disciplinas;
using GeradorDeTestes.Infra;
using GeradorDeTestes.Infra.SQL;

namespace GeradorDeTestes.Infra.Data
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private DBManager _dbManager;

        public DisciplinaRepository()
        {
            this._dbManager = new DBManager();
        }

        #region Scripts SQL

        
        public const string _sqlInsert = @"INSERT INTO TBDISCIPLINA
                                                           (NOME)
                                                      VALUES
                                                            ({0}NOME); SELECT SCOPE_IDENTITY()";

        public const string _sqlSelectAll = @"SELECT ID
                                                    ,NOME
                                                FROM TBDISCIPLINA";

        public const string _sqlSelect = @"SELECT ID
                                                    NOME
                                                 FROM TBDISCIPLINA
                                                 WHERE TITLE LIKE {0}WORD";

        public const string _sqlUpdate = @"UPDATE TBDISCIPLINA
                                                        SET NOME = {0}NOME
                                             WHERE ID = {0}ID";

        public static string _sqlDelete = @"DELETE FROM TBDISCIPLINA
                                             WHERE ID = {0}ID";

        #endregion Scripts SQL

        #region métodos
        public int Add(Disciplina disciplina)
        {
            try
            {
               return _dbManager.Insert(_sqlInsert, RetornaDictionaryDeDisciplina(disciplina));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public void Excluir(Disciplina disciplina)
        {
            _dbManager.Delete(_sqlDelete, RetornaDictionaryDeDisciplina(disciplina));
        }

        public void Editar(Disciplina disciplina)
        {
            _dbManager.Update(_sqlUpdate, RetornaDictionaryDeDisciplina(disciplina));
        }
        public List<Disciplina> GetAll()
        {
            return _dbManager.GetAll(_sqlSelectAll, FormaObjetoDisciplina);
        }

        #endregion

        #region montar e ler objetos
        Dictionary<string, object> RetornaDictionaryDeDisciplina(Disciplina disciplina)
        {
            return new Dictionary<string, object>
            {
                { "ID", disciplina.Id },
                { "NOME", disciplina.Nome }
            };
        }

      
        Func<IDataReader, Disciplina> IDisciplinaRepository.FormaObjetoDisciplina(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, object> IDisciplinaRepository.RetornaDictionaryDeDisciplina(Disciplina disciplina)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Disciplina> FormaObjetoDisciplina = reader =>
         
          new Disciplina
          {
              Id = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["NOME"])
          };
        #endregion
    }
}
