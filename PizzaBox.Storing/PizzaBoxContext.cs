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
    private readonly IConfiguration _configuration;
    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizzaType> PizzaTypes { get; set; }
    public DbSet<ACrust> Crusts { get; set; }
    public DbSet<ASize> Sizes { get; set; }
    public DbSet<ATopping> Toppings { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public PizzaBoxContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      builder.Entity<APizzaType>().HasKey(e => e.EntityId);
      builder.Entity<CustomPizza>().HasBaseType<APizzaType>();
      builder.Entity<MeatPizza>().HasBaseType<APizzaType>();
      builder.Entity<VeggiePizza>().HasBaseType<APizzaType>();

      builder.Entity<ACrust>().HasKey(e => e.EntityId);
      builder.Entity<Thin>().HasBaseType<ACrust>();
      builder.Entity<Pan>().HasBaseType<ACrust>();
      builder.Entity<Stuffed>().HasBaseType<ACrust>();

      builder.Entity<ASize>().HasKey(e => e.EntityId);
      builder.Entity<Small>().HasBaseType<ASize>();
      builder.Entity<Medium>().HasBaseType<ASize>();
      builder.Entity<Large>().HasBaseType<ASize>();

      builder.Entity<ATopping>().HasKey(e => e.EntityId);
      builder.Entity<Onions>().HasBaseType<ATopping>();
      builder.Entity<Mushrooms>().HasBaseType<ATopping>();
      builder.Entity<Pepperoni>().HasBaseType<ATopping>();
      builder.Entity<Sausage>().HasBaseType<ATopping>();

      builder.Entity<Customer>().HasKey(e => e.EntityId);
      builder.Entity<Customer>().Property(e => e.Name);

      builder.Entity<Order>().HasKey(e => e.EntityId);

      builder.Entity<Pizza>().HasKey(e => e.EntityId);

      //seeding

      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore() { EntityId = 1, Name = "1234 Main Street, Chicago, IL" }
      });

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 2, Name = "801 128th Street, New York City, NY" }
      });

      builder.Entity<Small>().HasData(new Small() { EntityId = 1 });
      builder.Entity<Medium>().HasData(new Medium() { EntityId = 2 });
      builder.Entity<Large>().HasData(new Large() { EntityId = 3 });

      builder.Entity<Thin>().HasData(new Thin() { EntityId = 1 });
      builder.Entity<Pan>().HasData(new Pan() { EntityId = 2 });
      builder.Entity<Stuffed>().HasData(new Stuffed() { EntityId = 3 });

      builder.Entity<Onions>().HasData(new Onions() { EntityId = 1 });
      builder.Entity<Mushrooms>().HasData(new Mushrooms() { EntityId = 2 });
      builder.Entity<Pepperoni>().HasData(new Pepperoni() { EntityId = 3 });
      builder.Entity<Sausage>().HasData(new Sausage() { EntityId = 4 });

      builder.Entity<MeatPizza>().HasData(new MeatPizza() { EntityId = 1, Name = "Meat Pizza" });
      builder.Entity<VeggiePizza>().HasData(new VeggiePizza() { EntityId = 2, Name = "Veggie Pizza" });
      builder.Entity<CustomPizza>().HasData(new CustomPizza() { EntityId = 3, Name = "Custom Pizza" });
    }
  }
}