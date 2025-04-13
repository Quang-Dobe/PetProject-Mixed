using Microsoft.EntityFrameworkCore;
using PetProject.Razor.Domain.Entitities;

namespace PetProject.Razor.Persistence
{
    public class IfsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        public IfsDbContext(DbContextOptions<IfsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
