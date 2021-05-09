using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaTypesRepository : IRepository<APizzaType>
  {
    private readonly PizzaBoxContext _context;

    public PizzaTypesRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(APizzaType entry)
    {
      var result = _context.PizzaTypes.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<APizzaType> Select(Func<APizzaType, bool> filter)
    {
      return _context.PizzaTypes.Where(filter);
    }

    public APizzaType Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
