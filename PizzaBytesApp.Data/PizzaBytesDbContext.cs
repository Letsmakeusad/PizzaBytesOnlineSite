namespace PizzaBytesApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PizzaBytesApp.Data.Models;

    public class PizzaBytesDbContext : IdentityDbContext<User>
    {
        public PizzaBytesDbContext(DbContextOptions<PizzaBytesDbContext> options)
            : base(options)
        {
        }
           
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }

        
            

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            builder
                .Entity<Order>()
                .HasOne(o => o.Pizza)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PizzaId);
                 

            base.OnModelCreating(builder);

        }
    }
}
 