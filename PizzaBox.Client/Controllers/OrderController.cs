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
    public static List<OrderModel> ListOfOrderModels { get; set; } = new List<OrderModel>();
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
      ListOfOrderModels.Clear();
      var orderModel = new OrderModel();
      orderModel.CustomerName = customerName.Item2;
      orderModel.Load(_unitOfWork);
      return View("Order", orderModel);
    }

    [HttpGet]
    public IActionResult Check()
    {
      if (ListOfOrderModels.Count == 0)
      {
        return View("Order");
      }
      ProcessOrders(ListOfOrderModels);
      return Redirect("/checkout");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(OrderModel orderModel)
    {
      if (ModelState.IsValid)
      {
        ListOfOrderModels.Add(orderModel);
        ViewData["orders"] = ListOfOrderModels;
      }
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

    private void ProcessOrders(List<OrderModel> orders)
    {
      var completeOrder = new Order();
      completeOrder.Pizzas = new List<Pizza>();
      completeOrder.Customer = new Customer(orders[0].CustomerName);
      completeOrder.orderTime = DateTime.Now;
      completeOrder.Store = _unitOfWork.Stores.Select(s => s.Name == orders[0].SelectedStore).First();

      foreach (var order in orders)
      {
        var pizza = new Pizza();
        pizza.Toppings = new List<ATopping>();

        foreach (var topping in order.SelectedToppings)
        {
          pizza.Toppings.Add(_unitOfWork.Toppings.Select(t => t.Name == topping).First());
        }
        pizza.Type = _unitOfWork.PizzaTypes.Select(t => t.Name == order.SelectedPizzaType).First();
        pizza.Crust = _unitOfWork.Crusts.Select(c => c.Name == order.SelectedCrust).First();
        pizza.Size = _unitOfWork.Sizes.Select(s => s.Name == order.SelectedSize).First();

        completeOrder.Pizzas.Add(pizza);
      }

      _unitOfWork.Orders.Insert(completeOrder);
      _unitOfWork.Save();
    }
  }
}
