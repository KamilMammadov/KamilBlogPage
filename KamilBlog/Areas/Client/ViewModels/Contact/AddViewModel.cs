using System.ComponentModel.DataAnnotations;

namespace KamilBlog.Areas.Client.ViewModels.Contact
{
    public class AddViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
