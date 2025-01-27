using WebsiteBuilderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebsiteBuilderAPI.Data
{
    namespace WebsiteBuilderAPI.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            // Define tables
            public DbSet<User> Users { get; set; }
            public DbSet<Website> Websites { get; set; }
            public DbSet<Template> Templates { get; set; }
        }
    }


}
