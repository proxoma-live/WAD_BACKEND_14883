using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14883.Models;

namespace WAD_BACKEND_14883.Data.Migrations
{
    public class NewspaperAppDbContext:DbContext
    {
        public NewspaperAppDbContext(DbContextOptions<NewspaperAppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
