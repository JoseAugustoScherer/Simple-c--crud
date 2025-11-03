using firstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> FirstAPI { get; set; }
    }
}