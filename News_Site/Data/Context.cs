using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News_Site.Models;

namespace News_Site.Data
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
    }
}
