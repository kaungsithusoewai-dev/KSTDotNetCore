using Dapper;
using KSTDotNetCore.RestApi.Models;
using KSTDotNetCoreShare;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KSTDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController2 : ControllerBase
    { 

        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            var lst2 = _dapperService.Query<BlogModel>(query);
            return Ok(lst2);
        }


        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
           var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlogs(BlogModel blog)
        {
           
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            int result = _dapperService.Execute(query,blog);

            string message = result > 0 ? "Saving Successful" : "Saving failed";
            return Ok(message);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(int id,BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
        
           blog.BlogId= id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating Successful" : "Update failed";
            return Ok(message);
        }


        [HttpPatch("{id}")]
        public IActionResult PatchBlogs(int id,BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if (conditions.Length == 0) {
                
                return NotFound("No data to update");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogId = id;
                    string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {conditions}
 WHERE BlogId = @BlogId";
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating Successful" : "Update failed";
            return Ok(message);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlogs(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new BlogModel { BlogId = id });

            string message = result > 0 ? "Deleting Successful" : "Deleting failed";
            return Ok(message);
        }
        private BlogModel FindById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";
            var item = _dapperService.FirstOrDefaultQuery<BlogModel>(query, new BlogModel { BlogId = id });
            return item;
        } 
    }
}
