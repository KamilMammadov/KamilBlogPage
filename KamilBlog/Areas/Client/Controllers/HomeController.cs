using KamilBlog.Areas.Client.ViewModels.Contact;
using KamilBlog.Areas.Client.ViewModels.Blog;
using KamilBlog.Database;
using KamilBlog.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListViewModel = KamilBlog.Areas.Client.ViewModels.Blog.ListViewModel;

namespace KamilBlog.Areas.Client.Controllers
{

    [Area("client")]
    public class HomeController : Controller
    {
        private readonly DataContext _dbContext;

        public HomeController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("~/", Name = "client-home-index")]
        [HttpGet("index")]
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _dbContext.Blogs.OrderByDescending(b=>b.CreadetAt).Select(b => new ListViewModel(b.Id, b.Name, b.ContentName, b.Content, b.CreadetAt)).ToListAsync();

            return View(model);
        }
       
        
        
        [HttpGet("blog/{id}", Name = "client-home-blog")]
        public async Task<IActionResult> Blog([FromRoute]int id)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null)return NotFound();

            var newblog = new ListBlogViewModel
            {
                Name = blog.Name,
                ContentName = blog.ContentName,
                Content = blog.Content,
              

            };

            return View(newblog);
        }


        [HttpGet("contact",Name = "client-home-contact" )]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact", Name = "client-home-contact")]
        public async Task<IActionResult> ContactAsync(AddViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var message = new Contact
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Text = model.Text,
                CreadetAt = DateTime.Now
            };

            await _dbContext.Contacts.AddAsync(message);
            await _dbContext.SaveChangesAsync();
            return RedirectToRoute("client-home-contact");
        }
    }
}
