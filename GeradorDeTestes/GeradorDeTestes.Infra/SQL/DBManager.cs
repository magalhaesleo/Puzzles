using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace GeradorDeTestes.Infra.SQL
{

    public class DBManager
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["GERADORDETESTE"].ConnectionString;

        private static string _providerName = ConfigurationManager.AppSettings.Get("DataProvider");

        private static DbProviderFactory _providerType = DbProviderFactories.GetFactory(_providerName);

        public int Insert(string sql, Dictionary<string, object> dictionary)
        {
           return InitializeConnection(sql, dictionary);
        }

        public void Update(string sql, Dictionary<string, object> dictionary)
        {
            InitializeConnection(sql, dictionary);
        }

        public void Delete(string sql, Dictionary<string, object> dictionary)
        {
            InitializeConnection(sql, dictionary);
        }

        public List<T> GetByID<T>(String sql, Func<IDataReader, T> convertRelactionalData, Dictionary<string, object> dictionary)
        {
            sql = string.Format(sql, ParameterPrefix);
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = _providerType.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, dictionary);
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var list = new List<T>();

                    while (reader.Read())
                    {
                        var obj = convertRelactionalData(reader);
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }

        //ok
        public List<T> GetAll<T>(String sql, Func<IDataReader, T> convertRelactionalData)
        {
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = _providerType.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var list = new List<T>();

                    while (reader.Read())
                    {
                        var obj = convertRelactionalData(reader);
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }
        public static void SetParameters(DbCommand command, Dictionary<string, object> dictionary)
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

       
        // Connection AND execute SQL
        public static int InitializeConnection(string sql, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, ParameterPrefix);
            int idAux;
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                using (DbCommand command = _providerType.CreateCommand())
                {

                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, parms);
                    connection.Open();

                idAux = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return idAux;
        }

        public static string ParameterPrefix
        {
            get
            {
                switch (_providerName)
                {
                    // Microsoft Access não tem suporte a esse tipo de comando
                    case "System.Data.OleDb": return "@";
                    case "System.Data.SqlClient": return "@";
                    case "System.Data.OracleClient": return ":";
                    case "MySql.Data.MySqlClient": return "?";

                    default:
                        return "@";
                }
            }
        }
    }

}


