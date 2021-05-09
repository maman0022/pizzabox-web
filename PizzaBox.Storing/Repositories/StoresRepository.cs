using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class StoresRepository : IRepository<AStore>
  {
    private readonly PizzaBoxContext _context;

    public StoresRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(AStore entry)
    {
      var result = _context.Stores.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<AStore> Select(Func<AStore, bool> filter)
    {
      return _context.Stores.Where(filter);
    }

    public AStore Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
