using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class LoginController : Controller
  {
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
      _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
      return View("Login", new LoginModel());
    }
  }
}
