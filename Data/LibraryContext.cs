using Microsoft.EntityFrameworkCore;
using RentCars.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RentCars.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Made> Made { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<Made>().ToTable("Made");
        }
    }
}
