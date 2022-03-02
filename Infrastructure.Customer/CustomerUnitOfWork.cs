using Application.Interfaces.Persistence;
using AutoMapper;

namespace Infrastructure.Customer
{
  public class CustomerUnitOfWork : ICustomerUnitOfWork
  {
    public ICustomerRepositoryAsync CustomerRepositoryAsync { get; set; }
    public IMapper Mapper { get; set; }

    public CustomerUnitOfWork(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper)
    {
      CustomerRepositoryAsync = customerRepositoryAsync;
      Mapper = mapper;
    }
  }
}