using Microsoft.AspNetCore.Mvc;

namespace KamilBlog.Areas.Admin.Controllers
{

    [Area("admin")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
