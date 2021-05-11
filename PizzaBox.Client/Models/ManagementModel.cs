using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Domain.Models;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Abstracts;
using System.Linq;

namespace PizzaBox.Client.Models
{
  public class ManagementModel
  {
    [Required]
    [DataType(DataType.Text)]
    public string SelectedStore { get; set; }
    public List<AStore> Stores { get; set; }
    public List<Order> Orders { get; set; }
    public void LoadStores(UnitOfWork unitOfWork)
    {
      Stores = unitOfWork.Stores.Select(s => s.Name != null).ToList();
    }
    public void LoadOrders(UnitOfWork unitOfWork)
    {
      Orders = unitOfWork.Orders.Select(o => o.Store.Name == SelectedStore).ToList();
    }
  }
}