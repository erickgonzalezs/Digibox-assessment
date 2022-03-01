using Application.Interfaces.Persistence;
using Domain.Entities;
using GoalIt.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class CustomerRepositoryAsync : GenericRepositoryAsync<CustomerEntity>, ICustomerRepositoryAsync

  {
    public CustomerRepositoryAsync(DbContext dbContext) : base(dbContext)
    {
    }
  }
}