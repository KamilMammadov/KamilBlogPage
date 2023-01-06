using KamilBlog.Database;
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

    }
}
