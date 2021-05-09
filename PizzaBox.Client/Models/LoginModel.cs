using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;
using System.Linq;

namespace PizzaBox.Client.Models
{
  public class LoginModel
  {
    public List<AStore> Stores { get; set; }
    public string CustomerName { get; set; }
    public AStore SelectedStore { get; set; }
    public bool IsOwner { get; set; }
  }
}