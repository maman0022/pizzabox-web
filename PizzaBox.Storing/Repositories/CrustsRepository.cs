using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class CrustsRepository : IRepository<ACrust>
  {
    private readonly PizzaBoxContext _context;

    public CrustsRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(ACrust entry)
    {
      var result = _context.Crusts.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<ACrust> Select(Func<ACrust, bool> filter)
    {
      return _context.Crusts.Where(filter);
    }

    public ACrust Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
