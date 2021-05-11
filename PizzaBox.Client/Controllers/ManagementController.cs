using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PizzaBox.Storing;
using PizzaBox.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Controllers
{
  public class ManagementController : Controller
  {
    private readonly UnitOfWork _unitOfWork;
    public ManagementController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public IActionResult Index()
    {
      var ManagementModel = new ManagementModel();
      ManagementModel.LoadStores(_unitOfWork);
      return View("ViewOrders", ManagementModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ViewOrders(ManagementModel managementModel)
    {
      managementModel.LoadStores(_unitOfWork);

      if (ModelState.IsValid)
      {
        managementModel.LoadOrders(_unitOfWork);
        return View("ViewOrders", managementModel);
      }
      return View("ViewOrders", managementModel);
    }
  }
}
