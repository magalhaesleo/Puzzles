using System;
using System.Collections.Generic;
using System.Data;
using GeradorDeTestes.Domain.Entidades;

namespace GeradorDeTestes.Infra.Data
{
    public class SerieDAO
    {
        private DBManager _dbManager;

        public SerieDAO()
        {
            this._dbManager = new DBManager();
        }

        #region Scripts SQL


        public const string _sqlInsert = @"INSERT INTO TBSERIE
                                                           (NUMERO)
                                                      VALUES
                                                            ({0}NUMERO)";

        public const string _sqlSelectAll = @"SELECT ID
                                                    ,NUMERO
                                                FROM TBSERIE";

        public const string _sqlUpdate = @"UPDATE TBSERIE
                                                        SET NUMERO = {0}NUMERO
                                             WHERE ID = {0}ID";

        public static string _sqlDelete = @"DELETE FROM TBSERIE
                                             WHERE ID = {0}ID";

        #endregion Scripts SQL


        public void Add(Serie serie)
        {
            try
            {
                _dbManager.Insert(_sqlInsert, RetornaDictionaryDeSerie(serie));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Excluir(Serie serie)
        {
            try
            {
                _dbManager.Delete(_sqlDelete, RetornaDictionaryDeSerie(serie));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Serie serie)
        {            
            try
            {
                _dbManager.Update(_sqlUpdate, RetornaDictionaryDeSerie(serie));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Serie> GetAll()
        {
            try
            {
                return _dbManager.GetAll(_sqlSelectAll, FormaObjetoSerie);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Dictionary<string, object> RetornaDictionaryDeSerie(Serie serie)
        {
            return new Dictionary<string, object>
            {
                { "ID", serie.Id },
                { "NUMERO", serie.Numero }
            };
        }

        private static Func<IDataReader, Serie> FormaObjetoSerie = reader =>

          new Serie
          {
              Id = Convert.ToInt32(reader["ID"]),
              Numero = Convert.ToInt32(reader["NUMERO"])
          };
    }
}
