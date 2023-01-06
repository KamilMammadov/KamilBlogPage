using KamilBlog.Areas.Client.ViewModels.About;
using KamilBlog.Database;
using KamilBlog.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamilBlog.Areas.Client.Controllers
{
    [Area("client")]
    public class AboutController : Controller
    {
        private readonly DataContext _dataContext;

        public AboutController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("List", Name = "client-about-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model= new AboutListViewModel();
            var about = await _dataContext.Abouts.FirstOrDefaultAsync(a => a.Id == 1);
            if (about == null)
            return View(model);

                model = new AboutListViewModel
            {
                Name = about.Name,
                ContentName = about.ContentName,
                Content = about.Content,

            };
            return View(model);
        }
    }
}
