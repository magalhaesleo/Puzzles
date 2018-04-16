using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Domain.Interfaces.Questoes;
using GeradorDeTestes.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Data
{
    public class QuestaoDAO : IQuestaoRepository
    {
        private DBManager _dbManager;
        private static AlternativaDAO _alternativaDao;
        private static int _quantidade;

        public QuestaoDAO()
        {
            this._dbManager = new DBManager();
            _alternativaDao = new AlternativaDAO();
        }

        #region Scripts SQL


        public const string _sqlInsert = @"INSERT INTO TBQUESTAO
                                                           (IDMATERIA,ENUNCIADO,BIMESTRE)
                                                      VALUES
                                                            ({0}IDMATERIA,
                                                             {0}ENUNCIADO,
                                                             {0}BIMESTRE
                                                            );SELECT SCOPE_IDENTITY()";

        public const string _sqlSelectAll = @"SELECT TBQ.ID[ID_QUESTAO],
                                            TBQ.ENUNCIADO[ENUNCIADO_QUESTAO],
                                            TBQ.BIMESTRE[BIMESTRE_QUESTAO],
                                            TBM.NOME [NOME_MATERIA] ,
                                            TBM.ID [ID_MATERIA],
                                            TBS.ID [ID_SERIE],
                                            TBS.NUMERO[NUMERO_SERIE],
                                            TBD.ID[ID_DISCIPLINA],
                                            TBD.NOME[NOME_DISCIPLINA]
                                            FROM TBQUESTAO AS TBQ
                                            JOIN TBMATERIA AS TBM ON TBQ.IDMATERIA = TBM.Id
                                            JOIN TBSERIE AS TBS ON TBM.IDSERIE = TBS.ID
                                            JOIN TBDISCIPLINA AS TBD ON TBM.IDDISCIPLINA = TBD.ID
  ";

        public const string _sqlSelectQuestaoPorMateria = @"SELECT *
                                                            FROM TBQUESTAO 
                                                            WHERE IDMATERIA = {0}IDMATERIA";

        public const string _sqlUpdate = @"UPDATE TBQUESTAO
                                                        SET ENUNCIADO = {0}ENUNCIADO,
                                                            BIMESTRE = {0}BIMESTRE,
                                                            IDMATERIA = {0}IDMATERIA
                                                            WHERE ID = {0}ID";

   
        public static string _sqlDelete = @"DELETE FROM TBQUESTAO
                                             WHERE ID = {0}ID";

        public static string _sqlSelectQuantidadeDeQuestoesPorMateria = @"SELECT count(1)[QUANTIDADE] 
                                                            FROM TBQUESTAO 
                                                            WHERE IDMATERIA = {0}IDMATERIA";
        #endregion Scripts SQL

        
        #region Métodos
        public int Add(Questao questao)
        {
            try
            {
                return _dbManager.Insert(_sqlInsert, RetornaDictionaryDeQuestao(questao));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Excluir(Questao questao)
        {
            try
            {
                _dbManager.Delete(_sqlDelete, RetornaDictionaryDeQuestao(questao));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(Questao questao)
        {
            try
            {
                _dbManager.Update(_sqlUpdate, RetornaDictionaryDeQuestao(questao));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Questao> GetAll()
        {
            try
            {
                return _dbManager.GetAll(_sqlSelectAll, FormaObjetoQuestao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Questao> SelecionarQuestoesPorMateria(int idMateria)
        {
            return _dbManager.GetByID(_sqlSelectQuestaoPorMateria, FormaObjetoQuestao, new Dictionary<string, object> { { "IDMATERIA", idMateria } });
        }

        public List<int> VerificarQuantidadeDeQuestoesPorMateria(int idMateria)
        {
            return _dbManager.GetByID(_sqlSelectQuantidadeDeQuestoesPorMateria, FormaQuantidade, new Dictionary<string, object> { { "IDMATERIA", idMateria }});
        }



        #endregion

        #region Montar e ler objeto Questão
        private Dictionary<string, object> RetornaDictionaryDeQuestao(Questao questao)
        {
            
            return new Dictionary<string, object>
            {
                { "ID", questao.Id },
                { "ENUNCIADO", questao.Enunciado },
                { "IDMATERIA", questao.Materia.Id },
                { "BIMESTRE", questao.Bimestre }
              
            };

        }

   

        Dictionary<string, object> IQuestaoRepository.RetornaDictionaryDeQuestao(Questao questao)
        {
            throw new NotImplementedException();
        }

        Func<IDataReader, Questao> IQuestaoRepository.FormaObjetoQuestao(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        Func<IDataReader, Questao> IQuestaoRepository.FormaQuantidade(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public static Func<IDataReader, Questao> FormaObjetoQuestao = reader =>

        new Questao
        {
            Id = Convert.ToInt32(reader["ID_QUESTAO"]),
            Enunciado = Convert.ToString(reader["ENUNCIADO_QUESTAO"]),
            Bimestre = Convert.ToInt32(reader["BIMESTRE_QUESTAO"]),

            Alternativas = _alternativaDao.PegarAlternativasDaQuestaoPorID(Convert.ToInt32(reader["ID_QUESTAO"])),

            Materia = new Materia()
            {
                Id = Convert.ToInt32(reader["ID_MATERIA"]),
                Nome = Convert.ToString(reader["NOME_MATERIA"]),
                
                Serie = new Serie()
                {
                    Id = Convert.ToInt32(reader["ID_SERIE"]),
                    Numero = Convert.ToInt32(reader["NUMERO_SERIE"])
                },

                 Disciplina = new Disciplina()
                 {
                     Id = Convert.ToInt32(reader["ID_DISCIPLINA"]),
                     Nome = Convert.ToString(reader["NOME_DISCIPLINA"]),
                 }
            },

            

        };

        public static Func<IDataReader, int> FormaQuantidade = reader =>

          _quantidade = Convert.ToInt32(reader["QUANTIDADE"]);
        };

        #endregion

    }


