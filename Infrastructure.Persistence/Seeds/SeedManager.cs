using System;
using System.Collections.Generic;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Persistence.Seeds
{
  public static class SeedManager
  {
    public async static void InitializeDatabase(IApplicationBuilder app, IWebHostEnvironment env)
    {
      using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

      var context = serviceScope.ServiceProvider.GetRequiredService<CustomersDbContext>();
      await context.Database.MigrateAsync();
      if (!context.Customers.Any() && env.EnvironmentName == "Development")
      {
        Console.WriteLine($"Adding 4 items to Customer for {env.EnvironmentName} Ambient...");
        List<CustomerEntity> customers = new List<CustomerEntity>
        {
          new CustomerEntity
          {
            CreatedAt = DateTime.Now,
            Name = "First Customer",
            StatusId = 1,
          },
          new CustomerEntity 
          {
            CreatedAt = DateTime.Now,
            Name = "Second Customer",
            StatusId = 1,
          },
          new CustomerEntity
          {
            CreatedAt = DateTime.Now,
            Name = "Third Customer",
            StatusId = 1,
          },
          new CustomerEntity
          {
            CreatedAt = DateTime.Now,
            Name = "Fourth Customer",
            StatusId = 1,
          },
        };
        await context.Customers.AddRangeAsync();
        await context.SaveChangesAsync();
      }
    }
  }
}