using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class PizzasRepository : IRepository<Pizza>
  {
    private readonly PizzaBoxContext _context;

    public PizzasRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Pizza entry)
    {
      var result = _context.Pizzas.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<Pizza> Select(Func<Pizza, bool> filter)
    {
      return _context.Pizzas.Where(filter);
    }

    public Pizza Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
