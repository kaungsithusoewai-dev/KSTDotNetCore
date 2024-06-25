using KSTDotNetCore.RestApi.Models;
using KSTDotNetCoreShare;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KSTDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController2 : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

      
        [HttpGet]

        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }


        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";

            AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            parameters[0] = new AdoDotNetParameter("@BlogId", id);
            var  item = _adoDotNetService.FirstOrDefaultQuery<BlogModel>(query, parameters);
            //SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            //connection.Open();



            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BLogId", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //connection.Close();
            if (item == null)
            {
                return NotFound("No data found");
            }
            
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
           
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Create Successful" : "Create failed";
            return Ok(message);

        }
    }
}
