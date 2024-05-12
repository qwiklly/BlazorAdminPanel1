using BlazorAdminpanel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAdminpanel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
