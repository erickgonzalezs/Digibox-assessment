using Application.Interfaces.Persistence;
using DigiboxAssessment.Integration.Test.Persistence.Resources;
using Infrastructure.Persistence.Repositories;
using Moq;

namespace DigiboxAssessment.Integration.Test.Mocks
{
  public class CustomerMocks: BaseContext
  {
    private readonly Mock<ICustomerUnitOfWork>  _customerUnitOfWork = new();
    public ICustomerUnitOfWork UnitOfWork { get; set; }
    public SharedMocks SharedMocks { get; set; }
    public string CustomerId01 { get; set; } = "CustomerId01";

    public CustomerMocks()
    {
      SharedMocks = new SharedMocks();
      _customerUnitOfWork.SetupGet(x => x.CustomerRepositoryAsync).Returns(new CustomerRepositoryAsync(_context));
      _customerUnitOfWork.SetupGet(x => x.Mapper).Returns(SharedMocks.Mapper);
      UnitOfWork = _customerUnitOfWork.Object;
    }
  }
}