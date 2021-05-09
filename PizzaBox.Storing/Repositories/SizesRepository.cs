using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class SizesRepository : IRepository<ASize>
  {
    private readonly PizzaBoxContext _context;

    public SizesRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(ASize entry)
    {
      var result = _context.Sizes.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<ASize> Select(Func<ASize, bool> filter)
    {
      return _context.Sizes.Where(filter);
    }

    public ASize Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
