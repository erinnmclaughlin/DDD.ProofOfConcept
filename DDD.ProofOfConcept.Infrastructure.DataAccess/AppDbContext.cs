using DDD.ProofOfConcept.Application.CustomerManagement.Entities;
using DDD.ProofOfConcept.Application.UserManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.ProofOfConcept.Infrastructure.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<CustomerDetail> CustomerDetails => Set<CustomerDetail>();
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerDetail>().ToTable("Customers");
            builder.Entity<User>().ToTable("Users");

            builder.Entity<CustomerDetail>().OwnsOne(x => x.Location);
            builder.Entity<CustomerDetail>().Property(x => x.CompanyName).IsRequired();
            builder.Entity<User>().HasIndex(x => x.Username).IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
