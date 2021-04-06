using BookSoft.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BookSoft.DAL.DataAccess
{
    public class DataService : IDataService
    {
        public string ConnectionString => _config.GetConnectionString("EtnaDb");
        private readonly IConfiguration _config;
        public DataService(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<T> LoadData<T, U>(string sqlCommand, U parameters)
        {
            using(IDbConnection conn = new SqlConnection(ConnectionString))
            {
                CommandType cmd = CommandType.Text;
                if (sqlCommand.StartsWith(TypeOfSqlCommand.sp.ToString()))
                {
                    cmd = CommandType.StoredProcedure;
                }
                var output = conn.Query<T>(sqlCommand, parameters, commandType: cmd);
                return output;
            }
        }

        public int SaveData<T>(string sqlCommand, T parameters)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                CommandType cmd = CommandType.Text;
                if (sqlCommand.StartsWith(TypeOfSqlCommand.sp.ToString()))
                {
                    cmd = CommandType.StoredProcedure;
                }
                var rows = conn.Execute(sqlCommand, parameters, commandType: cmd);
                return rows;
            }
        }
    }
}
