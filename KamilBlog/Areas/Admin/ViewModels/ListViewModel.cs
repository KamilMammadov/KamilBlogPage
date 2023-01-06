namespace KamilBlog.Areas.Admin.ViewModels
{
    public class ListViewModel
    {
        public ListViewModel(int id, string name, string contentName, string content, DateTime creadetAt)
        {
            Id = id;
            Name = name;
            ContentName = contentName;
            Content = content;
            CreadetAt = creadetAt;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentName { get; set; }
        public string Content { get; set; }
        public DateTime CreadetAt { get; set; }
    }
}
