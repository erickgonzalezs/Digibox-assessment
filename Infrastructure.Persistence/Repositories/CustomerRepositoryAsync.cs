using Application.Interfaces.Persistence;
using Domain.Entities;
using GoalIt.Core.Infrastructure.Persistence;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
  public class CustomerRepositoryAsync : GenericRepositoryAsync<CustomerEntity>, ICustomerRepositoryAsync

  {
    public CustomerRepositoryAsync(CustomersDbContext dbContext) : base(dbContext)
    {
    }
  }
}