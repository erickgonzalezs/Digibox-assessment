using Application.Interfaces.Persistence;
using Digibox.Api.Controllers.v1;
using DigiboxAssessment.Test.Helpers.Persistence.Resources;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Moq;

namespace DigiboxAssessment.Test.Helpers.Mocks
{
  public class CustomerMocks: BaseContext
  {
    private readonly Mock<ICustomerUnitOfWork>  _customerUnitOfWork = new();
    private readonly Mock<CustomerController> _customerController = new Mock<CustomerController>();
    public CustomerController CustomerController { get; set; }
    public ICustomerUnitOfWork UnitOfWork { get; set; }
    public SharedMocks SharedMocks { get; set; }
    public string CustomerId01 { get; set; } = "CustomerId01";

    public CustomerMocks()
    {
      SharedMocks = new SharedMocks();
      _customerUnitOfWork.SetupGet(x => x.CustomerRepositoryAsync).Returns(new CustomerRepositoryAsync(_context));
      _customerUnitOfWork.SetupGet(x => x.Mapper).Returns(SharedMocks.Mapper);
      UnitOfWork = _customerUnitOfWork.Object;
      
      CustomerController = _customerController.Object;


    }
  }
  
}