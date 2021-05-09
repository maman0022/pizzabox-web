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
  public class NotFoundController : Controller
  {
    private readonly ILogger<NotFoundController> _logger;

    public NotFoundController(ILogger<NotFoundController> logger)
    {
      _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }
  }
}
