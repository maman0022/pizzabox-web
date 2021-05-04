using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.PizzasTypes
{
  public class CustomPizza : APizzaType
  {
    public CustomPizza()
    {
      Name = "Custom Pizza";
    }
  }
}
