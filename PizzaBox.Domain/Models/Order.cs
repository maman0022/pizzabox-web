using System.Collections.Generic;
using System.Linq;
using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public Customer Customer { get; set; }
    public AStore Store { get; set; }
    public List<Pizza> Pizzas { get; set; }
    private List<ATopping> _toppings { get; set; }
    public DateTime orderTime { get; set; }
    public decimal TotalCost
    {
      get
      {
        decimal orderTotal = 0.00m;
        foreach (var pizza in Pizzas)
        {
          orderTotal += pizza.TotalCost;
        }
        return orderTotal;
      }
    }
    public Order()
    {

    }
    public Order(List<ATopping> Toppings)
    {
      _toppings = Toppings;
    }
  }
}
