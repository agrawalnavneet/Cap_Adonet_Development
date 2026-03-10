using Microsoft.EntityFrameworkCore;
using Project9.Models;
using Project9.Models;

namespace Project9.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentAccount> UserAccounts { get; set; }
    }
}