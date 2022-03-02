using System;
using DigiboxAssessment.Test.Helpers.Mocks;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DigiboxAssessment.Test.Helpers.Persistence.Resources
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