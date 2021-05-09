using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using System.Linq;

namespace PizzaBox.Domain.Models
{
  public class Pizza : AModel
  {
    public APizzaType Type { get; set; }
    public ACrust Crust { get; set; }
    public ASize Size { get; set; }
    public List<ATopping> Toppings { get; set; }
    public ICollection<Order> Order { get; set; }
    public decimal TotalCost
    {
      get
      {
        return Crust.Price + Size.Price + Toppings.Sum(t => t.Price);
      }
    }
  }
}
