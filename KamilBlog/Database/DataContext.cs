using Microsoft.EntityFrameworkCore;

namespace KamilBlog.Database
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options)
          : base(options)
        {

        }
    }
}
