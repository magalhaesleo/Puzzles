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
        private QuestaoDAO _questaoDAO;
        private static int _limit;

        public TesteDAO()
        {
            _questaoDAO = new QuestaoDAO();
            this._dbManager = new DBManager();
        }

        #region Scripts SQL


        public const string _sqlInsert = @"INSERT INTO TBTESTE
                              (NOME, DATAGERACAO, IDMATERIA)
                                                     VALUES
                                                           ({0}NOME,
                                                            {0}DATAGERACAO,
                                                             {0}IDMATERIA); SELECT SCOPE_IDENTITY()";

        public const string _sqlInsertTBTesteQuestao = @"INSERT INTO TBTESTEQUESTOES
                               (IDQUESTAO, IDTESTE, POSICAONOTESTE)
                                                      VALUES
                                                            ({0}IDQUESTAO,
                                                             {0}IDTESTE,
															 {0}POSICAONOTESTE
                                                            )";

        public const string _sqlSelectAll = @"SELECT TBT.ID[IDTESTE],
                                                TBT.NOME[NOMETESTE],
                                                TBT.DATAGERACAO[DATAGERACAO],
                                                TBT.IDMATERIA[IDMATERIA],
                                                TBM.NOME[NOME_MATERIA] 
                                                FROM TBTESTE TBT 
                                                JOIN TBMATERIA AS TBM 
                                                ON TBT.IDMATERIA = TBM.Id ";


        public static string _sqlDelete = @"DELETE FROM TBTESTE
                                             WHERE ID = {0}ID";

       
        public static string _sqlSelectQuestaoPorTeste = @"SELECT 
                                                        TBQ.ID[ID_QUESTAO],
                                                        TBQ.ENUNCIADO[ENUNCIADO_QUESTAO],
                                                        TBQ.BIMESTRE[BIMESTRE_QUESTAO],
                                                        TBM.NOME[NOME_MATERIA],
                                                        TBTQ.POSICAONOTESTE[POSICAO_TESTE] 
                                                        FROM TBTESTEQUESTOES AS TBTQ
                                                        JOIN TBQUESTAO AS TBQ ON TBTQ.IDQUESTAO = TBQ.Id
                                                        JOIN TBMATERIA AS TBM ON TBQ.IDMATERIA = TBM.Id
                                                        WHERE TBTQ.IDTESTE = {0}IDTESTE ORDER BY TBTQ.POSICAONOTESTE";

      

        public static string _sqlSelectRespostasPorTeste = @"SELECT TBTQ.POSICAONOTESTE[QUESTAO_TESTE],
                                                    TBA.LETRA[RESPOSTA] 
                                                    FROM TBTESTEQUESTOES AS TBTQ
                                                    JOIN TBQUESTAO AS TBQ ON TBTQ.IDQUESTAO = TBQ.Id
                                                    JOIN TBTESTE AS TBT ON TBTQ.IDTESTE = TBT.Id
                                                    JOIN TBALTERNATIVA AS TBA ON TBA.IDQUESTAO = TBQ.Id
                                                    WHERE TBA.CORRETA = 1 AND TBTQ.IDTESTE = {0}IDTESTE
                                                    ORDER BY TBTQ.POSICAONOTESTE ASC";

        #endregion Scripts SQL

        public int Add(Teste teste)
        {
            try
            {
                return _dbManager.Insert(_sqlInsert, RetornaDictionaryDeTeste(teste));
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

        public List<Questao> PegarQuestoesAleatoriasPorMateria(int limit, int idMateria)
        {
              string _sqlSelecionaQuestoesAleatorias = @"SELECT TOP " + limit + @" TBQ.ID[ID_QUESTAO],TBQ.ENUNCIADO[ENUNCIADO_QUESTAO],
                                                            TBQ.BIMESTRE[BIMESTRE_QUESTAO], TBM.NOME[NOME_MATERIA],
                                                            TBM.ID [ID_MATERIA],
                                                            TBS.ID [ID_SERIE],
                                                            TBS.NUMERO[NUMERO_SERIE],
                                                            TBD.ID[ID_DISCIPLINA],
                                                            TBD.NOME[NOME_DISCIPLINA]
                                                            FROM TBQUESTAO AS TBQ 
                                                            JOIN TBMATERIA AS TBM ON TBQ.IDMATERIA = TBM.Id
                                                            JOIN TBSERIE AS TBS ON TBM.IDSERIE = TBS.ID
                                                            JOIN TBDISCIPLINA AS TBD ON TBM.IDDISCIPLINA = TBD.ID
                                                            WHERE TBM.Id = {0}IDMATERIA AND 
                                                            TBQ.BIMESTRE in (1, 2, 3, 4)
                                                            ORDER BY NEWID()";
            try
            {
                return _dbManager.GetByID(_sqlSelecionaQuestoesAleatorias, QuestaoDAO.FormaObjetoQuestao, new Dictionary<string, object> { { "IDMATERIA", idMateria } });
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


        public List<Questao> PegarQuestoesPorTeste(int idTeste)
        {
            try
            {
                return _dbManager.GetByID(_sqlSelectQuestaoPorTeste, QuestaoDAO.FormaObjetoQuestao, new Dictionary<string, object> { { "IDTESTE", idTeste } });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Resposta> PegarRespostasPorTeste(int idTeste)
        {
            try
            {
                return _dbManager.GetByID(_sqlSelectRespostasPorTeste, FormaObjetoResposta, new Dictionary<string, object> { { "IDTESTE", idTeste } });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

          private static Func<IDataReader, Teste> FormaObjetoTeste = reader =>

          new Teste
          {
              Id = Convert.ToInt32(reader["IDTESTE"]),
              Nome = Convert.ToString(reader["NOMETESTE"]),
              DataGeracao = Convert.ToDateTime(reader["DATAGERACAO"]),
              Materia = new Materia
              {
                  Id = Convert.ToInt32(reader["IDMATERIA"]),
                  Nome = Convert.ToString(reader["NOME_MATERIA"])
              }

          };


          private static Func<IDataReader, Resposta> FormaObjetoResposta = reader =>

          new Resposta
          {
             Numero = Convert.ToInt32(reader["QUESTAO_TESTE"]),
             Letra = Convert.ToChar(reader["RESPOSTA"])
          };


    }
}

