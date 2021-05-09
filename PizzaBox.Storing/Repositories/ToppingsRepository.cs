using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class ToppingsRepository : IRepository<ATopping>
  {
    private readonly PizzaBoxContext _context;

    public ToppingsRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(ATopping entry)
    {
      var result = _context.Toppings.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<ATopping> Select(Func<ATopping, bool> filter)
    {
      return _context.Toppings.Where(filter);
    }

    public ATopping Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
