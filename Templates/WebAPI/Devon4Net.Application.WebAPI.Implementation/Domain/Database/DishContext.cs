using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Database
{
    /// <summary>
    /// Context definition
    /// </summary>
    public class DishContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public DishContext(DbContextOptions<DishContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("Overwriting OnConfiguring;");
        }

        /// <summary>
        /// Dbset
        /// </summary>
        public virtual DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish>().OwnsOne(a => a.Image);
            modelBuilder.Entity<Dish>().OwnsMany(a => a.Category);
        }
    }
}