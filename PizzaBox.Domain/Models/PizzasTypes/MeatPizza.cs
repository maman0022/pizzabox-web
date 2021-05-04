using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Domain.Models.PizzasTypes
{
  [XmlInclude(typeof(Pepperoni))]
  [XmlInclude(typeof(Sausage))]

  public class MeatPizza : APizzaType
  {
    public MeatPizza()
    {
      Name = "Meat Pizza";
    }
  }
}
