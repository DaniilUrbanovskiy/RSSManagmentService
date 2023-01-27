using Microsoft.EntityFrameworkCore;
using RSSManagmentService.Entities;

namespace RSSManagmentService.DataAccess
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<FeedUrl> FeedUrls { get; set; }

        public DbSet<News> News { get; set; }
    }
}
