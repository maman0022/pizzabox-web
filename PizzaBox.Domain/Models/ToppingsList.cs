using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class ToppingsList : AModel
  {
    public List<long> ToppingIds { get; set; }
    public decimal total { get; set; } = 0.00m;
    public ToppingsList()
    {
      ToppingIds = new List<long>();
    }
    public ToppingsList(List<long> list)
    {
      ToppingIds = list;
    }
  }
}