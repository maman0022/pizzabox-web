using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class CustomersRepository : IRepository<Customer>
  {
    private readonly PizzaBoxContext _context;

    public CustomersRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Customer entry)
    {
      var result = _context.Customers.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<Customer> Select(Func<Customer, bool> filter)
    {
      return _context.Customers.Where(filter);
    }

    public Customer Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
