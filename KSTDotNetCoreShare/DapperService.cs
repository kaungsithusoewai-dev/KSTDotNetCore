using Dapper;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace KSTDotNetCoreShare
{
    public class DapperService
    {
        private readonly string _connectionString;
        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<K> Query<K>(string query, object? param= null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var lst = db.Query<K>(query, param).ToList();
            return lst;
        }
        public K FirstOrDefaultQuery<K>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.Query<K>(query, param).FirstOrDefault();
            return item!;
        }
        public int Execute(string query, object? param = null)
        {
            using IDbConnection db =new SqlConnection(_connectionString);
            var result = db.Execute(query,param);
          return result;
        }
    } 
}

