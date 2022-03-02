using System;
using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace DigiboxAssessment.Test.Helpers.Persistence.Seeds
{
  public static class CustomerSeed
  {
    public static void Seed(CustomersDbContext context)
    {
      List<CustomerEntity> customers = new()
      {
        new CustomerEntity
        {
          Id = "CustomerId01",
          Name = "Customer 01",
          CreatedAt = DateTime.Now,
          StatusId = 1
        },
        new CustomerEntity
        {
          Id = "CustomerId02",
          Name = "Customer 02",
          CreatedAt = DateTime.Now,
          StatusId = 1
        },
        new CustomerEntity
        {
          Id = "CustomerId03",
          Name = "Customer 03",
          CreatedAt = DateTime.Now,
          StatusId = 1
        },
        new CustomerEntity
        {
          Id = "CustomerId04",
          Name = "Customer 04",
          CreatedAt = DateTime.Now,
          StatusId = 1
        },
      };
      context.Customers.AddRange(customers);
      context.SaveChanges();
    }
  }
}