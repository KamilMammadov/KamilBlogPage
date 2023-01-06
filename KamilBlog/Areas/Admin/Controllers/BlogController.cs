using KamilBlog.Areas.Admin.ViewModels;
using KamilBlog.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamilBlog.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogController : Controller
    {
        private readonly DataContext _dbContext;


        public BlogController(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
       
        
        [HttpGet("list", Name = "admin-blog-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dbContext.Blogs.Select(b => new ListViewModel(b.Id, b.Name, b.ContentName, b.Content, b.CreadetAt)).ToListAsync();
            return View(model);
        }
    }
}
