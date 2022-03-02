using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Interfaces.Persistence;

namespace Infrastructure.Customer
{
  public static class ServicesRegistration
  {
    public static void AddCustomerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddMediatR(Assembly.GetExecutingAssembly());
      services.AddTransient<ICustomerUnitOfWork, CustomerUnitOfWork>();
      
    }
  }
}