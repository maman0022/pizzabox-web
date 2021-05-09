using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Models
{
  public class ClientTypeModel
  {
    [Required(ErrorMessage = "Please select 'Owner' or 'Customer'")]
    [DataType(DataType.Text)]
    public string ClientType { get; set; }
    public string CustomerName { get; set; }
    public string ErrorMessage { get; set; }
  }
}