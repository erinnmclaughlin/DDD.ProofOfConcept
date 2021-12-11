using DDD.ProofOfConcept.Application.CustomerManagement.Entities;
using DDD.ProofOfConcept.Application.UserManagement.Entities;
using DDD.ProofOfConcept.Domain.CustomerManagement.Entities;
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

            builder.Entity<Customer>().OwnsOne(x => x.Location);
            builder.Entity<Customer>().Property(x => x.CompanyName).IsRequired();
            builder.Entity<User>().HasIndex(x => x.Username).IsUnique();

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("AppDb");
            base.OnConfiguring(builder);
        }
    }
}
