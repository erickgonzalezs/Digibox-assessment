using AutoMapper;

namespace Application.Interfaces.Persistence
{
  public interface ICustomerUnitOfWork
  {
    ICustomerRepositoryAsync CustomerRepositoryAsync { get; set; }
    IMapper Mapper { get; set; }
  }
}