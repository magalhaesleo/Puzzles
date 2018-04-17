using System;
using System.Collections.Generic;
using System.Data;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces.Series;
using GeradorDeTestes.Infra.SQL;

namespace GeradorDeTestes.Infra.Data
{
    public class SerieRepository : ISerieRepository
    {
        private DBManager _dbManager;

        public SerieRepository()
        {
            this._dbManager = new DBManager();
        }

        #region Scripts SQL


        public const string _sqlInsert = @"INSERT INTO TBSERIE
                                                           (NUMERO)
                                                      VALUES
                                                            ({0}NUMERO); SELECT SCOPE_IDENTITY()";

        public const string _sqlSelectAll = @"SELECT ID
                                                    ,NUMERO
                                                FROM TBSERIE ORDER BY NUMERO ASC";

        public const string _sqlUpdate = @"UPDATE TBSERIE
                                                        SET NUMERO = {0}NUMERO
                                             WHERE ID = {0}ID";

        public static string _sqlDelete = @"DELETE FROM TBSERIE
                                             WHERE ID = {0}ID";

        #endregion Scripts SQL

        #region métodos
        public int Add(Serie serie)
        {
            try
            {
               return _dbManager.Insert(_sqlInsert, RetornaDictionaryDeSerie(serie));
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

        #endregion

        #region montar e ler objetos
        private Dictionary<string, object> RetornaDictionaryDeSerie(Serie serie)
        {
            return new Dictionary<string, object>
            {
                { "ID", serie.Id },
                { "NUMERO", serie.Numero }
            };
        }

        Dictionary<string, object> ISerieRepository.RetornaDictionaryDeSerie(Serie serie)
        {
            throw new NotImplementedException();
        }

        Func<IDataReader, Serie> ISerieRepository.FormaObjetoSerie(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Serie> FormaObjetoSerie = reader =>
          
           new Serie
          {
              Id = Convert.ToInt32(reader["ID"]),
              Numero = Convert.ToInt32(reader["NUMERO"])
          };
        #endregion
    }
}
