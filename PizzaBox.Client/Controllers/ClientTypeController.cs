using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Controllers
{
  public class ClientTypeController : Controller
  {
    private readonly ILogger<ClientTypeController> _logger;

    public ClientTypeController(ILogger<ClientTypeController> logger)
    {
      _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
      return View("ClientType", new ClientTypeModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Check(ClientTypeModel clientTypeModel)
    {
      if (ModelState.IsValid)
      {
        if (clientTypeModel.ClientType == "owner")
        {
          return Redirect("/management/");
        }
        if (clientTypeModel.ClientType == "customer")
        {
          if (clientTypeModel.CustomerName == null || clientTypeModel.CustomerName.Trim() == "")
          {
            clientTypeModel.ErrorMessage = "Name cannot be empty";
            return View("ClientType", clientTypeModel);
          }
          return Redirect($"/order/index?customername={clientTypeModel.CustomerName}");
        }
      }
      return View("ClientType", clientTypeModel);
    }
  }
}
