using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Data
{

    public class TesteDAO
    {

        private DBManager _dbManager;

        public TesteDAO()
        {
            this._dbManager = new DBManager();
        }

        #region Scripts SQL


        public const string _sqlInsert = @"INSERT INTO TBTESTE
                              (NOME, DATAGERACAO, IDMATERIA)
                                                     VALUES
                                                           ({0}NOME,
                                                            {0}DATAGERACAO,
                                                             {0}IDMATERIA
                                                           )";

        public const string _sqlInsertTBTesteQuestao = @"INSERT INTO TBTESTEQUESTOES
                               (IDQUESTAO, IDTESTE, POSICAONOTESTE)
                                                      VALUES
                                                            ({0}IDQUESTAO,
                                                             {0}IDTESTE,
															 {0}POSICAONOTESTE
                                                            )";

        public const string _sqlSelectAll = @"SELECT TBT.NOME,
                                                TBT.DATAGERACAO,
                                                IDMATERIA,TBM.NOME[NOME_MATERIA] 
                                                FROM TBTESTE TBT 
                                                JOIN TBMATERIA AS TBM 
                                                ON TBT.IDMATERIA = TBM.Id ";


        public static string _sqlDelete = @"DELETE FROM TBTESTE
                                             WHERE ID = {0}ID";



        #endregion Scripts SQL

        public void Add(Teste teste)
        {
            try
            {
                _dbManager.Insert(_sqlInsert, RetornaDictionaryDeTeste(teste));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void AddTesteQuestao(int IdQuestao, int IdTeste, int PosicaoNoTeste)
        {
            try
            {
                _dbManager.Insert(_sqlInsertTBTesteQuestao, new Dictionary<string, object>
                {
                    { "IDQUESTAO", IdQuestao },
                    { "IDTESTE", IdTeste },
                    { "POSICAONOTESTE", PosicaoNoTeste }
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir(Teste teste)
        {
            try
            {
                _dbManager.Delete(_sqlDelete, RetornaDictionaryDeTeste(teste));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Teste> GetAll()
        {
            try
            {
                return _dbManager.GetAll(_sqlSelectAll, FormaObjetoTeste);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Dictionary<string, object> RetornaDictionaryDeTeste(Teste teste)
        {
            return new Dictionary<string, object>
            {
                { "ID", teste.Id },
                { "NOME", teste.Nome},
                { "DATAGERACAO", teste.DataGeracao },
                { "IDMATERIA", teste.Materia.Id }
            };
        }

        private static Func<IDataReader, Teste> FormaObjetoTeste = reader =>

          new Teste
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["NOME"]),
              DataGeracao = Convert.ToDateTime(reader["DATAGERACAO"]),
              Materia = new Materia
              {
                  Id = Convert.ToInt32(reader["IDMATERIA"]),
                  Nome = Convert.ToString(reader["NOME_MATERIA"])
              }

          };




    }
}

