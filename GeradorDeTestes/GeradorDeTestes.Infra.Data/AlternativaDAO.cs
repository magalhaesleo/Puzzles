using System;
using GeradorDeTestes.Domain.Entidades;
using System.Collections.Generic;
using System.Data;

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


        public const string _sqlInsert = @"INSERT INTO TBMATERIA
                                                           (NOME,IDDISCIPLINA,IDSERIE)
                                                      VALUES
                                                            ({0}NOME,
                                                             {0}IDDISCIPLINA,
                                                             {0}IDSERIE
                                                            )";

        public const string _sqlSelectAll = @"SELECT TBMATERIA.ID,TBMATERIA.NOME,
                                            TBSERIE.ID[ID_SERIE],
                                            TBSERIE.NUMERO[NUMERO_SERIE],
                                            TBDISCIPLINA.ID[ID_DISCPLINA],
                                            TBDISCIPLINA.NOME[NOME_DISCIPLINA]
                                            FROM TBMATERIA  JOIN TBSERIE ON TBSERIE.ID = TBMATERIA.IDSERIE
                                            JOIN TBDISCIPLINA ON TBDISCIPLINA.ID = TBMATERIA.IDDISCIPLINA";

        public const string _sqlUpdate = @"UPDATE TBMATERIA
                                                        SET NOME = {0}NOME,
                                                            IDSERIE = {0}IDSERIE,
                                                            IDDISCIPLINA = {0}IDDISCIPLINA
                                             WHERE ID = {0}ID";

        public static string _sqlDelete = @"DELETE FROM TBMATERIA
                                             WHERE ID = {0}ID";

        public static string _sqlGetByQuestaoID = @"Select * from TBALTERNATIVA where IDQUESTAO = {0}IDQUESTAO";

        #endregion Scripts SQL

        public List<Alternativa> PegarAlternativasDaQuestaoPorID(int ID)
        {
           return _dbManager.GetAll(_sqlGetByQuestaoID, FormaObjetoAlternativa);
        }

        public void Add(Alternativa alternativa)
        {
            try
            {
                _dbManager.Insert(_sqlInsert, RetornaDictionaryDeAlternativa(alternativa));
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
                { "ID", alternativa.Id },
                { "ENUNCIADO", alternativa.Enunciado},
                { "CORRETA", alternativa.Correta },
                { "IDQUESTAO", alternativa.IdQuestao }
            };
        }

        private static Func<IDataReader, Alternativa> FormaObjetoAlternativa = reader =>

          new Alternativa
          {
              Id = Convert.ToInt32(reader["Id"]),
              Enunciado = Convert.ToString(reader["ENUNCIADO"]),
              Correta = Convert.ToBoolean(reader["CORRETA"]),
              IdQuestao = Convert.ToInt32(reader["IDQUESTAO"])
              
          };


    }

}