namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// has a Name and Price property
  /// </summary>
  public class AComponent : AModel
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
