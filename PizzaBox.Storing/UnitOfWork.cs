using PizzaBox.Storing.Repositories;

namespace PizzaBox.Storing
{
  public class UnitOfWork
  {
    private readonly PizzaBoxContext _context;

    public CrustsRepository Crusts { get; }
    public CustomersRepository Customers { get; }
    public OrdersRepository Orders { get; }
    public PizzasRepository Pizzas { get; }
    public PizzaTypesRepository PizzaTypes { get; }
    public SizesRepository Sizes { get; }
    public StoresRepository Stores { get; }
    public ToppingsRepository Toppings { get; }

    public UnitOfWork(PizzaBoxContext context)
    {
      _context = context;

      Crusts = new CrustsRepository(_context);
      Customers = new CustomersRepository(_context);
      Orders = new OrdersRepository(_context);
      Pizzas = new PizzasRepository(_context);
      PizzaTypes = new PizzaTypesRepository(_context);
      Sizes = new SizesRepository(_context);
      Stores = new StoresRepository(_context);
      Toppings = new ToppingsRepository(_context);
    }

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}