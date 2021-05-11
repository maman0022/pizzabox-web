using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PizzaBox.Storing;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class OrderHistoryController : Controller
  {
    private readonly UnitOfWork _unitOfWork;
    public OrderHistoryController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public IActionResult Index()
    {
      var customerName = CustomerNamePresent(Request);
      if (!customerName.Item1)
      {
        return Redirect("/");
      }

      var orderHistoryModel = new OrderHistoryModel();
      orderHistoryModel.CustomerName = customerName.Item2;
      orderHistoryModel.Load(_unitOfWork);

      return View("OrderHistory", orderHistoryModel);
    }
    private static (bool, string) CustomerNamePresent(HttpRequest request)
    {
      var query = request.Query["customername"];
      if (query.Count == 0 || query[0].Trim() == "")
      {
        return (false, "");
      }
      return (true, query[0]);
    }
  }
}
