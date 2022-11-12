using FitTalksDemo.DualContainer.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FitTalksDemo.DualContainer.Data.Contexts
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = default!;

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
