using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
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
        ProcessOrder(orderModel);
        return View("Order");
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

    [HttpPost]
    public IActionResult Add(OrderModel orderModel)
    {
      var customerName = CustomerNamePresent(Request);
      if (!customerName.Item1)
      {
        return Redirect("/");
      }
      if (ViewData["orders"] == null)
      {
        var orders = new List<OrderModel>();
        orders.Add(orderModel);
        ViewData["orders"] = orders;
      }
      else
      {
        var orders = ViewData["orders"] as List<OrderModel>;
        orders.Add(orderModel);
        ViewData["orders"] = orders;
      }
      var newOrderModel = new OrderModel();
      newOrderModel.CustomerName = customerName.Item2;
      newOrderModel.Load(_unitOfWork);
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

    private void ProcessOrder(OrderModel orderModel)
    {
      var order = new Order();
      var pizza = new Pizza();
      pizza.Toppings = new List<ATopping>();
      order.Pizzas = new List<Pizza>();

      order.orderTime = DateTime.Now;
      order.Customer = new Customer(orderModel.CustomerName);
      order.Store = _unitOfWork.Stores.Select(s => s.Name == orderModel.SelectedStore).First();

      foreach (var topping in orderModel.SelectedToppings)
      {
        pizza.Toppings.Add(_unitOfWork.Toppings.Select(t => t.Name == topping).First());
      }
      pizza.Type = _unitOfWork.PizzaTypes.Select(t => t.Name == orderModel.SelectedPizzaType).First();
      pizza.Crust = _unitOfWork.Crusts.Select(c => c.Name == orderModel.SelectedCrust).First();
      pizza.Size = _unitOfWork.Sizes.Select(s => s.Name == orderModel.SelectedSize).First();

      order.Pizzas.Add(pizza);
      _unitOfWork.Orders.Insert(order);
      _unitOfWork.Save();
    }
  }
}
