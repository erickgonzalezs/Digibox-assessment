using GoalIt.Core.Application.Interfaces.Services;
using GoalIt.Core.Infrastructure.Services;
using Infrastructure.Customer;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digibox.Api
{
  public static class InfrastructureExtensions
  {
    public static void AddRelatedInfrastructures(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddTransient<IDateTimeService, DateTimeService>();
      services.AddPersistenceInfrastructure(configuration);
      services.AddCustomerInfrastructure(configuration);
    }
  }
}