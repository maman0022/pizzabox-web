using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Domain.Abstracts;
using System.Linq;

namespace PizzaBox.Client.Models
{
  public class OrderModel : IValidatableObject
  {
    [Required]
    [DataType(DataType.Text)]
    public string CustomerName { get; set; }
    public List<ACrust> Crusts { get; set; }
    public List<ASize> Sizes { get; set; }
    public List<ATopping> Toppings { get; set; }
    public List<AStore> Stores { get; set; }
    public List<APizzaType> PizzaTypes { get; set; }

    [Required(ErrorMessage = "Please select a crust")]
    [DataType(DataType.Text)]
    public string SelectedCrust { get; set; }

    [Required(ErrorMessage = "Please select a size")]
    [DataType(DataType.Text)]
    public string SelectedSize { get; set; }

    [Required(ErrorMessage = "Please select at least 2 toppings")]
    public List<string> SelectedToppings { get; set; }

    [Required(ErrorMessage = "Please select a store")]
    [DataType(DataType.Text)]
    public string SelectedStore { get; set; }

    [Required(ErrorMessage = "Please select a pizza type")]
    [DataType(DataType.Text)]
    public string SelectedPizzaType { get; set; }

    public void Load(UnitOfWork unitOfWork)
    {
      Crusts = unitOfWork.Crusts.Select(c => !string.IsNullOrWhiteSpace(c.Name)).ToList();
      Sizes = unitOfWork.Sizes.Select(s => !string.IsNullOrWhiteSpace(s.Name)).ToList();
      Toppings = unitOfWork.Toppings.Select(t => !string.IsNullOrWhiteSpace(t.Name)).ToList();
      Stores = unitOfWork.Stores.Select(s => !string.IsNullOrWhiteSpace(s.Name)).ToList();
      PizzaTypes = unitOfWork.PizzaTypes.Select(s => !string.IsNullOrWhiteSpace(s.Name)).ToList();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (SelectedToppings.Count < 2 || SelectedToppings.Count > 5)
      {
        var memberNames = new List<string>() { "SelectedToppings" } as IEnumerable<string>;
        yield return new ValidationResult("Please select at least 2 toppings", memberNames);
      }
    }
  }
}