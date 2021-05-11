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
    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }
  }
}
