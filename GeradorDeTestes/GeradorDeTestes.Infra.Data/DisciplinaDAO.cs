using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeradorDeTestes.Domain;

namespace GeradorDeTestes.Infra.Data
{
    public class DisciplinaDAO
    {
        #region Scripts SQL

        /// <summary>
        /// Scripts para manipulação das tabelas do banco de dados
        /// </summary>
        public const string _sqlInsert = @"INSERT INTO DISCIPLINA
                                                           (NOME)
                                                      VALUES
                                                            ({0}NOME";

        #endregion Scripts SQL

        /// <summary>
        /// Adiciona um novo product na base de dados
        /// </summary>
        /// <param name="product">É o product que será adicionado da base de dados</param>
        /// <returns>Retorna o novo product com os atributos atualizados (como id)</returns>
        public Disciplina Add(Disciplina disciplina)
        {
            disciplina.Id = DBManager.Insert(_sqlInsert, Take(disciplina));

            return disciplina;
        }

        /// <summary>
        /// Cria a lista de parametros do objeto product para passar para o comando Sql.
        /// </summary>
        /// <param name="product">Objeto produto passado por parâmetro.</param>
        /// <returns>Lista de parâmetros.</returns>
        private Dictionary<string, object> Take(Disciplina disciplina)
        {
            return new Dictionary<string, object>
            {
                { "ID", disciplina.Id },
                { "TITLE", disciplina.Nome }
            };
        }

        private static Func<IDataReader, Disciplina> Make = reader =>
          new Disciplina
          {
              Id = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["nome"])
          };
    }
}
