namespace KamilBlog.Areas.Admin.ViewModels.Contact
{
    public class ListViewModel
    {
        public ListViewModel(int id, string name, string email, string phoneNumber, string text, DateTime creadetAt)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Text = text;
            CreadetAt = creadetAt;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Text { get; set; }
        public DateTime CreadetAt { get; set; }
    }
}
