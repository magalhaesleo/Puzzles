using System;
using GeradorDeTestes.Domain.Entidades;
using System.Collections.Generic;
using System.Data;
using GeradorDeTestes.Infra.SQL;

namespace GeradorDeTestes.Infra.Data
{
    public class AlternativaDAO
    {

        private DBManager _dbManager;

        public AlternativaDAO()
        {
            this._dbManager = new DBManager();
        }

        #region Scripts SQL


        public const string _sqlInsert = @"INSERT INTO TBALTERNATIVA
                                                           (ENUNCIADO, CORRETA, IDQUESTAO,LETRA)
                                                      VALUES
                                                            ({0}ENUNCIADO,
                                                             {0}CORRETA,
                                                             {0}IDQUESTAO,
                                                             {0}LETRA
                                                            ); SELECT SCOPE_IDENTITY()";

        public const string _sqlSelectAll = @"SELECT * FROM TBALTERNATIVA";

        public const string _sqlUpdate = @"UPDATE TBALTERNATIVA
                                                        SET ENUNCIADO = {0}ENUNCIADO,
                                                            CORRETA = {0}CORRETA,
                                                            IDQUESTAO = {0}IDQUESTAO,
                                                            LETRA = {0}LETRA
                                             WHERE ID = {0}ID";

        public static string _sqlDelete = @"DELETE FROM TBALTERNATIVA
                                             WHERE ID = {0}ID";

        public static string _sqlGetByQuestaoID = @"Select * from TBALTERNATIVA where IDQUESTAO = {0}IDQUESTAO";

        #endregion Scripts SQL

        public List<Alternativa> PegarAlternativasDaQuestaoPorID(int ID)
        {
            return _dbManager.GetByID(_sqlGetByQuestaoID, FormaObjetoAlternativa, new Dictionary<string, object> { { "IDQUESTAO", ID } });
        }

        public int Add(Alternativa alternativa)
        {
            try
            {
              return  _dbManager.Insert(_sqlInsert, RetornaDictionaryDeAlternativa(alternativa));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Excluir(Alternativa alternativa)
        {
            try
            {
                _dbManager.Delete(_sqlDelete, RetornaDictionaryDeAlternativa(alternativa));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Alternativa alternativa)
        {
            try
            {
                _dbManager.Update(_sqlUpdate, RetornaDictionaryDeAlternativa(alternativa));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Alternativa> GetAll()
        {
            try
            {
                return _dbManager.GetAll(_sqlSelectAll, FormaObjetoAlternativa);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Dictionary<string, object> RetornaDictionaryDeAlternativa(Alternativa alternativa)
        {
            return new Dictionary<string, object>
            {
                {"ID", alternativa.Id },
                { "ENUNCIADO", alternativa.Enunciado},
                { "CORRETA", alternativa.Correta },
                { "IDQUESTAO", alternativa.IdQuestao },
                { "LETRA", alternativa.Letra},
            };
        }

        private static Func<IDataReader, Alternativa> FormaObjetoAlternativa = reader =>
            
            new Alternativa
            {
                Id = Convert.ToInt32(reader["Id"]),
                Enunciado = Convert.ToString(reader["ENUNCIADO"]),
                Correta = Convert.ToBoolean(reader["CORRETA"]),
                IdQuestao = Convert.ToInt32(reader["IDQUESTAO"]),
                Letra = Convert.ToChar(reader["LETRA"])
            };



}
}




