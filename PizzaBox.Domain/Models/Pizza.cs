using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Pizza : AModel
  {
    public APizzaType Type { get; set; }
    public ACrust Crust { get; set; }
    public ASize Size { get; set; }
    public ToppingsList ToppingsList { get; set; }
    public decimal TotalCost
    {
      get
      {
        return Crust.Price + Size.Price + ToppingsList.total;
      }
    }
    public Pizza()
    {
      ToppingsList = new ToppingsList();
    }
  }
}
