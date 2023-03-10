using System.ComponentModel.DataAnnotations;

namespace KamilBlog.Areas.Admin.ViewModels
{
    public class AddViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContentName { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
