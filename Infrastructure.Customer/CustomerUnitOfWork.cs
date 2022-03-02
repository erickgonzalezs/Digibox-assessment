using Application.Interfaces.Persistence;

namespace Infrastructure.Customer
{
  public class CustomerUnitOfWork : ICustomerUnitOfWork
  {
    public ICustomerRepositoryAsync CustomerRepositoryAsync { get; set; }

    public CustomerUnitOfWork(ICustomerRepositoryAsync customerRepositoryAsync)
    {
      CustomerRepositoryAsync = customerRepositoryAsync;
    }
  }
}