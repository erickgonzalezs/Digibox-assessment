using Domain.Entities;
using GoalIt.Core.Application.Interfaces.Persistence;

namespace Application.Interfaces.Persistence
{
  public interface ICustomerRepositoryAsync : IGenericRepositoryAsync<CustomerEntity>
  {
    
  }
}