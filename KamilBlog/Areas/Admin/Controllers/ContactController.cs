using KamilBlog.Areas.Admin.ViewModels;
using KamilBlog.Areas.Admin.ViewModels.Contact;
using KamilBlog.Database;
using KamilBlog.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListViewModel = KamilBlog.Areas.Admin.ViewModels.Contact.ListViewModel;
using UpdateViewModel = KamilBlog.Areas.Admin.ViewModels.Contact.DetailViewModel;

namespace KamilBlog.Areas.Admin.Controllers
{

    [Area("admin")]
    public class ContactController : Controller
    {
        private readonly DataContext _dataContext;

        public ContactController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("contact/list", Name = "admin-contact-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Contacts
                .Select(c => new ListViewModel(c.Id, c.Name,c.Email, c.PhoneNumber, c.Text, c.CreadetAt))
                .ToListAsync();

            return View(model);
        }

     

        [HttpGet("detail/{id}", Name = "admin-contact-detail")]
        public async Task<IActionResult> DetailAsync([FromRoute] int id)
        {

            var message = await _dataContext.Contacts.FirstOrDefaultAsync(b => b.Id == id);
            if (message is null) return NotFound();



            var model = new DetailViewModel
            {
                Name=message.Name,
                Email=message.Email,
                PhoneNumber=message.PhoneNumber,
                Text=message.Text,
            };
            return View(model);
        }


        [HttpPost("delete/{id}", Name = "admin-contact-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var contact = await _dataContext.Contacts.FirstOrDefaultAsync(b => b.Id == id);
            if (contact is null) return NotFound();

            _dataContext.Contacts.Remove(contact);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-contact-list");
        }

    }
}
