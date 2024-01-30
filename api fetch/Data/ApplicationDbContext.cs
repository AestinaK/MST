using api_fetch.Models;
using Microsoft.EntityFrameworkCore;

namespace api_fetch.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Roles> roles { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<User> users { get; set; }
    }
}
