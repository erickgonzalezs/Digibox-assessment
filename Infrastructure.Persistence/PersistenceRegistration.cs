using System;
using Application.Interfaces.Persistence;
using GoalIt.Core.Application.Interfaces.Persistence;
using GoalIt.Core.Infrastructure.Persistence;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure.Persistence
{
  public static class PersistenceRegistration
  {
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      string connectionString = configuration.GetConnectionString("defaultConnection");

      bool enableDetailedErrors = configuration.GetValue<bool>("EnableDetailedErrors");
      bool enableSensitiveDataLogging = configuration.GetValue<bool>("EnableSensitiveDataLogging");
      if (configuration.GetValue<bool>("UseInMemoryDatabase"))
      {
        services.AddDbContext<CustomersDbContext>(options =>
          options.UseInMemoryDatabase("ApplicationDb")
            .EnableSensitiveDataLogging(enableSensitiveDataLogging)
            .EnableDetailedErrors(enableDetailedErrors));
        Console.WriteLine($"Using InMemory Db");
      }
      else
      {
        services.AddDbContext<CustomersDbContext>(options =>
          options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging(enableSensitiveDataLogging)
            .EnableDetailedErrors(enableDetailedErrors));
      }
      #region Repositories
      services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
      services.AddTransient<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
      #endregion
    }
  }
}