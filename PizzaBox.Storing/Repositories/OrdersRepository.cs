using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using System.Data.SqlTypes;

namespace PizzaBox.Storing.Repositories
{
  public class OrdersRepository : IRepository<Order>
  {
    private readonly PizzaBoxContext _context;

    public OrdersRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Order entry)
    {
      var result = _context.Orders.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<Order> Select(Func<Order, bool> filter)
    {
      var orders =
       _context.Orders
        .Include(o => o.Customer)
        .Include(o => o.Store)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Toppings)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Size)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Crust)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Type);

      return orders.Where(filter);
    }

    public Order Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
