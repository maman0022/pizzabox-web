using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Domain.Models.PizzasTypes
{
  [XmlInclude(typeof(Mushrooms))]
  [XmlInclude(typeof(Onions))]
  public class VeggiePizza : APizzaType
  {
    public VeggiePizza()
    {
      Name = "Veggie Pizza";
    }
  }
}
