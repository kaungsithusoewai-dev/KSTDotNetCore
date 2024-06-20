using KSTDotNetCore.RestApi.EFDbContext;
using KSTDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KSTDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public BlogController()
        {
            _appDbContext = new AppDbContext();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _appDbContext.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var lst = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (lst == null)
            {
                return NotFound("No data found");
            }
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _appDbContext.Blogs.Add(blog);
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return NotFound("No data found");

            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found");

            }
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found");

            }
            _appDbContext.Blogs.Remove(item);
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    } 
    }




