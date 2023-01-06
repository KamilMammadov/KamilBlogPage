using KamilBlog.Areas.Admin.ViewModels;
using KamilBlog.Database;
using KamilBlog.Database.Models;
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

        #region Add

        [HttpGet("add", Name = "admin-blog-add")]
        public async Task<IActionResult> AddAsync()
        {
            var model = new AddViewModel();
            return View(model);
        }
        [HttpPost("add", Name = "admin-blog-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            var blog = new Blog
            {
                Name = model.Name,
                ContentName = model.ContentName,
                Content = model.Content,
                CreadetAt = DateTime.Now
            };

            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return RedirectToRoute("admin-blog-list");
        }
        #endregion

        #region Update
        [HttpGet("update/{id}", Name = "admin-blog-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {

            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (blog is null) return NotFound();

           

            var model = new UpdateViewModel
            {
                Name=blog.Name,
                ContentName=blog.ContentName,
                Content=blog.Content,
            };
            return View(model);
        }


        [HttpPost("update/{id}", Name = "admin-blog-update")]
        public async Task<IActionResult> UpdateAsync(UpdateViewModel model)
        {

            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == model.Id);
            if (blog is null) return NotFound();

            blog.Name = model.Name;
            blog.ContentName = model.ContentName;
            blog.Content = model.Content;
            await _dbContext.SaveChangesAsync();
            return RedirectToRoute("admin-blog-list");
        }
        #endregion

        [HttpPost("delete/{id}", Name = "admin-blog-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            var blog= await _dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (blog is null) return NotFound();

            _dbContext.Blogs.Remove(blog);
            await _dbContext.SaveChangesAsync();

            return RedirectToRoute("admin-blog-list");
        }
    }
}
