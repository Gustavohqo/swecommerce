using data.Mapping;
using model;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class Context : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Promotion> Promotion { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new PromotionMapping());
        }
            
    }
}