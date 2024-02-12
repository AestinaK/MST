using System.Reflection;
using System.Security.Claims;
using api_fetch.Models;
using App.Base.GenericModel;
using App.Base.GenericModel.Interface;
using App.Expenses;
using App.Setup;
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
            builder.AddSetup();
            builder.AddRoot();
           AddSafeDeleteGlobalQuery(builder);
            base.OnModelCreating(builder);
        }
        //public DbSet<Roles> roles { get; set; }
        //public DbSet<Employee> employees { get; set; }
        public DbSet<User> users { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaveChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSaveChanges()
        {
            HandleSoftDelete();
            HandleInsertedData();
            HandleUpdatedData();
        }
        private void HandleUpdatedData()
        {
            var updatedData = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var item in updatedData)
            {
                if (item.Entity is IGenericModel model)
                {
                    model.RecDate = DateTime.UtcNow;
                }
            }
        }
        private void HandleInsertedData()
        {
            var insertedData = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var item in insertedData)
            {
                if (item.Entity is IUserModel model)
                {
                    if (model.UserId <= 0)
                    {
                        long.TryParse(_contextAccessor.HttpContext.User.FindFirstValue("Id")
                            .FirstOrDefault().ToString(), out var userId);
                        model.UserId = userId;
                    }
                }
            }
        }
        private void HandleSoftDelete()
        {
            var deletedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);
            foreach (var item in deletedEntries)
            {
                item.State = EntityState.Modified;
                if(item.Entity is not ISoftDelete model) continue;
                model.RecStatus = 'D';
                Entry(model).Property(nameof(model.RecStatus)).IsModified = true;
            }
        }
        
        private void AddSafeDeleteGlobalQuery(ModelBuilder builder)
        {
            foreach (var type in builder.Model.GetEntityTypes())
            {
                if (type.BaseType == null && typeof(ISoftDelete).IsAssignableFrom(type.ClrType))
                {
                    var method = SetGlobalQueryMethod.MakeGenericMethod(type.ClrType);
                    method.Invoke(this, new object[] { builder });
                }
            }
        }
        
        static readonly MethodInfo SetGlobalQueryMethod = typeof(ApplicationDbContext)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");
        public void SetGlobalQuery<T>(ModelBuilder builder) where T : GenericModel
        {
            builder.Entity<T>().HasQueryFilter(e => e.RecStatus == 'A');
        }
    }
}
