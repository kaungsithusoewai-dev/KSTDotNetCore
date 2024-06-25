using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KSTDotNetCoreShare
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;
public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<K> Query<K>(string query, params AdoDotNetParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            { //  foreach (var item in parameters)
              //    {
              //        cmd.Parameters.AddWithValue(item.Key, item.Value);
              // cmd.Parameters.AddRange(parameters.Select(item  => new SqlParameter(item.Key, item.Value)).ToArray());
                var parametersArray = parameters.Select(item => new SqlParameter(item.Key, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            List<K> lst = JsonConvert.DeserializeObject < List<K>>(json)!;
            return lst;
        }
        public K FirstOrDefaultQuery<K>(string query, params AdoDotNetParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                //foreach (var item in parameters)
                //{
                //    cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Key, item.Value)).ToArray());
                //}
                var parametersArray = parameters.Select(item => new SqlParameter( item.Key, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            List<K> lst = JsonConvert.DeserializeObject<List<K>>(json)!;
            return lst[0];
        }
        public int Execute<K>(string query, params AdoDotNetParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                //foreach (var item in parameters)
                //{
                //    cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Key, item.Value)).ToArray());
                //}
                var parametersArray = parameters.Select(item => new SqlParameter(item.Key, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            var result = cmd.ExecuteNonQuery();

            connection.Close();
            return result;
        }
    }

    public class AdoDotNetParameter
    {   
        public AdoDotNetParameter() { }
        public AdoDotNetParameter(string key, object value) {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
