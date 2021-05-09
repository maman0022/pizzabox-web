using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Domain.Abstracts
{
  [XmlInclude(typeof(Sausage))]
  [XmlInclude(typeof(Pepperoni))]
  [XmlInclude(typeof(Mushrooms))]
  [XmlInclude(typeof(Onions))]

  public class ATopping : AComponent
  {
    public ICollection<Pizza> Pizza { get; set; }
  }
}
