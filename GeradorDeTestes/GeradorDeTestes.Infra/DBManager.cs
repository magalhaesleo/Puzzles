﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace GeradorDeTestes.Infra
{

    public class DBManager
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["GERADORDETESTE"].ConnectionString;

        private static string _providerName = ConfigurationManager.AppSettings.Get("DataProvider");

        private static DbProviderFactory _providerType = DbProviderFactories.GetFactory(_providerName);

        public void Insert(string sql, Dictionary<string, object> dictionary)
        {
            InitializeConnection(sql, dictionary);
        }

        public void Update(string sql, Dictionary<string, object> dictionary)
        {
            InitializeConnection(sql, dictionary);
        }

        public void Delete(string sql, Dictionary<string, object> dictionary)
        {
            InitializeConnection(sql, dictionary);
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

        //ok
        public IList<T> GetAll<T>(String sql, Func<IDataReader, T> convertRelactionalData)
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

        // Connection SQL
        public static void InitializeConnection(string sql, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, ParameterPrefix);
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                using (DbCommand command = _providerType.CreateCommand())
                {

                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, parms);
                    connection.Open();

                    command.ExecuteScalar();
                }
            }
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


