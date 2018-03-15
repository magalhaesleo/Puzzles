using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Data;

namespace GeradorDeTestes.Infra
{
    public static class DBManager
    {

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["GeradorDeTestes"].ConnectionString;

        private static readonly string _providerName = ConfigurationManager.AppSettings.Get("DataProvider");

        private static DbProviderFactory _providerType = DbProviderFactories.GetFactory(_providerName);

        /*

        private DbConnection _connection = _providerType.CreateConnection();
        private DbDataReader _reader;
        private static DbCommand _command =_providerType.CreateCommand();
        private DbParameter _parameter;


       //Criando parametro ProviderName que irá retornar o valor da variável _dataProvider
        public string ProviderName { get { return _providerName; } }

        //Criando parametro ConnectionString que irá retornar a String de conexão com o Banco
        public string ConnectionString { get { return _connectionString; } }

        //Criando o parametro BDCommand, que irá criar um DBCommand para o DbProviderFactory
        public DbCommand Command { get { return _providerType.CreateCommand(); } }

        //Criando o parametro DbCOnnection, que irá retornar a criação da conexão
        public DbConnection Connection { get { return _providerType.CreateConnection(); } }
        */

        public static void Insert(string sql, Dictionary<string, object> dictionary)
        {
           InitializeConnection(sql, dictionary).ExecuteScalar();
        }

        public static void Update(string sql, Dictionary<string, object> dictionary)
        {
            InitializeConnection(sql, dictionary).ExecuteScalar();
        }

        public static void Delete(string sql, Dictionary<string, object> dictionary)
        {
            InitializeConnection(sql, dictionary).ExecuteScalar();
        }

        private static void SetParameters(this DbCommand command, Dictionary<string, object> dictionary)
        {
            if (dictionary != null)
            {

                foreach (var item in dictionary)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = item.Key;
                    dbParameter.Value = item.Value;
                    command.Parameters.Add(dbParameter);
                }
            }
        }

        //ok
        public static IQueryable<T> GetAll<T>(String sql, Func<IDataReader, T> convertRelactionalData)
        {
            using (DbCommand retCommand = InitializeConnection(sql))
            {

                var reader = retCommand.ExecuteReader();

                var list = new List<T>();

                while (reader.Read())
                {
                    var obj = convertRelactionalData(reader);
                    list.Add(obj);
                }

                return list.AsQueryable();
            }
        }

        // Connection SQL
        private static DbCommand InitializeConnection(string sql, Dictionary<string, object> parms = null)
        {
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = _providerType.CreateCommand())
                {

                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, parms);
                    connection.Open();

                    return command;
                }

            }


        }

    }
}
