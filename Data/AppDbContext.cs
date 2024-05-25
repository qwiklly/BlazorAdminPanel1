using BlazorAdminpanel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAdminpanel.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
		public DbSet<ApplicationUser> Users { get; set; }
		public DbSet<UsersCoordinates> Coordinates { get; set; }
	}
}
