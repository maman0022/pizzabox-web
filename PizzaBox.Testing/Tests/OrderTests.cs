using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Sizes;
using PizzaBox.Domain.Models.Toppings;
using PizzaBox.Domain.Models.PizzasTypes;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class OrderTests
  {
    [Fact]
    public void Test_Order()
    {
      var order = new Order();
      var pizza = new Pizza();
      pizza.Toppings = new List<ATopping>();
      pizza.Toppings.Add(new Mushrooms());
      pizza.Type = new CustomPizza();
      pizza.Size = new Medium();
      pizza.Crust = new Pan();
      order.Pizzas = new List<Pizza>();
      order.Pizzas.Add(pizza);
      order.Store = new ChicagoStore();
      order.Customer = new Customer("Test");

      Assert.True(order.Pizzas[0].Type.Name.Equals("Custom Pizza"));
      Assert.True(order.Pizzas[0].Crust.Name.Equals("Pan"));
      Assert.True(order.Pizzas[0].Toppings[0].Name.Equals("Mushrooms"));
      Assert.True(order.Pizzas[0].TotalCost.Equals(CostOfPizza(pizza)));
      Assert.True(order.Customer.Name.Equals("Test"));

      decimal CostOfPizza(Pizza pizza)
      {
        return pizza.Crust.Price + pizza.Size.Price + pizza.Toppings.Sum(t => t.Price);
      }
    }
  }
}