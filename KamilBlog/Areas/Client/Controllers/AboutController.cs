using KamilBlog.Database;
using Microsoft.AspNetCore.Mvc;

namespace KamilBlog.Areas.Client.Controllers
{
    public class AboutController : Controller
    {
        private readonly DataContext _dataContext;

        public AboutController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("index", Name = "client-about-index")]

        public async Task<IActionResult> Index()
        {
            var model= 
            return View();
        }
    }
}
