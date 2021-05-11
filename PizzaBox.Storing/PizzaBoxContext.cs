using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.PizzasTypes;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Domain.Models.Sizes;
using PizzaBox.Domain.Models.Toppings;
using PizzaBox.Domain.Models.Stores;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizzaType> PizzaTypes { get; set; }
    public DbSet<ACrust> Crusts { get; set; }
    public DbSet<ASize> Sizes { get; set; }
    public DbSet<ATopping> Toppings { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public PizzaBoxContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AStore>().HasKey(e => e.EntityId);
      modelBuilder.Entity<ChicagoStore>().HasBaseType<AStore>();
      modelBuilder.Entity<NewYorkStore>().HasBaseType<AStore>();

      modelBuilder.Entity<APizzaType>().HasKey(e => e.EntityId);
      modelBuilder.Entity<CustomPizza>().HasBaseType<APizzaType>();
      modelBuilder.Entity<MeatPizza>().HasBaseType<APizzaType>();
      modelBuilder.Entity<VeggiePizza>().HasBaseType<APizzaType>();

      modelBuilder.Entity<ACrust>().HasKey(e => e.EntityId);
      modelBuilder.Entity<Thin>().HasBaseType<ACrust>();
      modelBuilder.Entity<Pan>().HasBaseType<ACrust>();
      modelBuilder.Entity<Stuffed>().HasBaseType<ACrust>();

      modelBuilder.Entity<ASize>().HasKey(e => e.EntityId);
      modelBuilder.Entity<Small>().HasBaseType<ASize>();
      modelBuilder.Entity<Medium>().HasBaseType<ASize>();
      modelBuilder.Entity<Large>().HasBaseType<ASize>();

      modelBuilder.Entity<ATopping>().HasKey(e => e.EntityId);
      modelBuilder.Entity<Onions>().HasBaseType<ATopping>();
      modelBuilder.Entity<Mushrooms>().HasBaseType<ATopping>();
      modelBuilder.Entity<Pepperoni>().HasBaseType<ATopping>();
      modelBuilder.Entity<Sausage>().HasBaseType<ATopping>();

      modelBuilder.Entity<Customer>().HasKey(e => e.EntityId);
      modelBuilder.Entity<Customer>().Property(e => e.Name);

      modelBuilder.Entity<Order>().HasKey(e => e.EntityId);

      modelBuilder.Entity<Pizza>().HasKey(e => e.EntityId);

      //seeding

      modelBuilder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore() { EntityId = 1, Name = "1234 Main Street, Chicago, IL" }
      });

      modelBuilder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 2, Name = "801 128th Street, New York City, NY" }
      });

      modelBuilder.Entity<Small>().HasData(new Small() { EntityId = 1 });
      modelBuilder.Entity<Medium>().HasData(new Medium() { EntityId = 2 });
      modelBuilder.Entity<Large>().HasData(new Large() { EntityId = 3 });

      modelBuilder.Entity<Thin>().HasData(new Thin() { EntityId = 1 });
      modelBuilder.Entity<Pan>().HasData(new Pan() { EntityId = 2 });
      modelBuilder.Entity<Stuffed>().HasData(new Stuffed() { EntityId = 3 });

      modelBuilder.Entity<Onions>().HasData(new Onions() { EntityId = 1 });
      modelBuilder.Entity<Mushrooms>().HasData(new Mushrooms() { EntityId = 2 });
      modelBuilder.Entity<Pepperoni>().HasData(new Pepperoni() { EntityId = 3 });
      modelBuilder.Entity<Sausage>().HasData(new Sausage() { EntityId = 4 });

      modelBuilder.Entity<MeatPizza>().HasData(new MeatPizza() { EntityId = 1, Name = "Meat Pizza" });
      modelBuilder.Entity<VeggiePizza>().HasData(new VeggiePizza() { EntityId = 2, Name = "Veggie Pizza" });
      modelBuilder.Entity<CustomPizza>().HasData(new CustomPizza() { EntityId = 3, Name = "Custom Pizza" });
    }
  }
}