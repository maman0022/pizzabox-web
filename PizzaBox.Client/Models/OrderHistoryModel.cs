using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class OrderHistoryModel
  {
    public string CustomerName { get; set; }
    public List<Order> Orders { get; set; }
    public void Load(UnitOfWork unitOfWork)
    {
      Orders = unitOfWork.Orders.Select(o => o.Customer.Name == CustomerName) as List<Order>;
    }
  }
}