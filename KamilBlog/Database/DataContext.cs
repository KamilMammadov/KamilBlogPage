using KamilBlog.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace KamilBlog.Database
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options)
          : base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
    }
}
