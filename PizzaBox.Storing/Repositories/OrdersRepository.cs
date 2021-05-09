using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

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
      throw new System.NotImplementedException();
    }

    public Order Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
