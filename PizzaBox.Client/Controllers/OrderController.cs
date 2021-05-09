using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Storing;
using Microsoft.AspNetCore.Http;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly ILogger<OrderController> _logger;
    private readonly UnitOfWork _unitOfWork;
    public OrderController(ILogger<OrderController> logger, UnitOfWork unitOfWork)
    {
      _logger = logger;
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
      var orderModel = new OrderModel();
      orderModel.CustomerName = customerName.Item2;
      orderModel.Load(_unitOfWork);
      return View("Order", orderModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public object Check(OrderModel orderModel)
    {
      if (ModelState.IsValid)
      {
        return "valid";
      }

      var customerName = CustomerNamePresent(Request);
      if (!customerName.Item1)
      {
        return Redirect("/");
      }
      orderModel.CustomerName = customerName.Item2;
      orderModel.Load(_unitOfWork);
      return View("Order", orderModel);
    }

    private (bool, string) CustomerNamePresent(HttpRequest request)
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
