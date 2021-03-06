﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces.Materias;
using GeradorDeTestes.Infra.SQL;

namespace GeradorDeTestes.Infra.Data
{
    public class MateriaRepository : IMateriaRepository
    {
        private DBManager _dbManager;

        public MateriaRepository()
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
                                                            ); SELECT SCOPE_IDENTITY()";

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

        #endregion Scripts SQL

        #region métodos
        public int Add(Materia materia)
        {
            try
            {
                return _dbManager.Insert(_sqlInsert, RetornaDictionaryDeMateria(materia));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Excluir(Materia materia)
        {
            try
            {
                _dbManager.Delete(_sqlDelete, RetornaDictionaryDeMateria(materia));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Materia materia)
        {
            try
            {
                _dbManager.Update(_sqlUpdate, RetornaDictionaryDeMateria(materia));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Materia> GetAll()
        {
            try
            {
                return _dbManager.GetAll(_sqlSelectAll, FormaObjetoMateria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region montar e ler objetos
        private Dictionary<string, object> RetornaDictionaryDeMateria(Materia materia)
        {
            return new Dictionary<string, object>
            {
                { "ID", materia.Id },
                { "NOME", materia.Nome },
                { "IDDISCIPLINA", materia.Disciplina.Id },
                { "IDSERIE", materia.Serie.Id }
            };
        }

        public Dictionary<string, object> RetornaDictionaryDeMateria(Disciplina disciplina)
        {
            throw new NotImplementedException();
        }

        Func<IDataReader, Disciplina> IMateriaRepository.FormaObjetoMateria(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Materia> FormaObjetoMateria = reader =>

          new Materia
          {
              Id = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["NOME"]),

              Disciplina = new Disciplina()
              {
                  Id = Convert.ToInt32(reader["ID_DISCPLINA"]),
                  Nome = Convert.ToString(reader["NOME_DISCIPLINA"])
              },
              Serie = new Serie()
              {
                  Id = Convert.ToInt32(reader["ID_SERIE"]),
                  Numero = Convert.ToInt32(reader["NUMERO_SERIE"])
              }
          };
        #endregion

    }
}
