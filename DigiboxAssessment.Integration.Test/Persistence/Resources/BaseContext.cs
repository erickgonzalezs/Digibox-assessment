using System;
using DigiboxAssessment.Integration.Test.Mocks;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DigiboxAssessment.Integration.Test.Persistence.Resources
{
  public class BaseContext: IDisposable
  {
    protected readonly CustomersDbContext _context;

    public BaseContext()
    {
      SharedMocks mocks = new SharedMocks();
      var options = new DbContextOptionsBuilder<CustomersDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

      this._context = new CustomersDbContext(options);
      this._context.Database.EnsureCreated();

      DbInitializer.Initialize(this._context);
    }
    public void Dispose()
    {
     
      this._context.Database.EnsureDeleted();
      this._context.Dispose();
    }
  }
}