using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.PizzasTypes;

namespace PizzaBox.Domain.Abstracts
{
  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(VeggiePizza))]
  public abstract class APizzaType : AModel
  {
    public string Name { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
