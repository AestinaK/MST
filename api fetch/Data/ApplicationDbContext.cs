using api_fetch.Models;
using App.User;
using App.User.Model;
using Microsoft.EntityFrameworkCore;

namespace api_fetch.Data
{
    public class ApplicationDbContext :DbContext
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor contextAccessor) : base(options)
        {
            _contextAccessor = contextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddUser();
            base.OnModelCreating(builder);
        }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<User> users { get; set; }
    }
}
