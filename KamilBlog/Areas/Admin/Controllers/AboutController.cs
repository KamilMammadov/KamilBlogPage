using KamilBlog.Database;
using KamilBlog.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamilBlog.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {
        private readonly DataContext _dataContext;

        public AboutController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("about/list", Name = "admin-about-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Abouts.FirstOrDefaultAsync(a => a.Id == 1);
            if (model is null) return NotFound();
          
            return View(model);
        }
        [HttpGet("update/{id}", Name = "admin-about-update")]
        public async Task<IActionResult> UpdateAsync()
        {
            var model = await _dataContext.Abouts.FirstOrDefaultAsync(a => a.Id == 1);
            if (model is null) return NotFound();

            return View(model);
        }
        [HttpPost("update/{id}", Name = "admin-about-update")]
        public async Task<IActionResult> UpdateAsync(About about)
        {
            var model = await _dataContext.Abouts.FirstOrDefaultAsync(a => a.Id == about.Id);
            if (model is null) return NotFound();

            model.Name = about.Name;
            model.ContentName = about.ContentName;
            model.Content=about.Content;

            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-about-list");
        }

    }
}
