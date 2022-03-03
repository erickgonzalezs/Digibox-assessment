using Application.DTOs;
using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
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
    private readonly Mock<ICustomerXmlService> _customerXmlService = new();
    public CreateCustomerReqDto CreateCustomerOkDto { get; set; }
    public CreateCustomerReqDto CreateCustomerWhitOutIdDto { get; set; }
    public CreateCustomerReqDto CreateCustomerWhitOutNameDto { get; set; }
    public CreateCustomerReqDto CreateCustomerRepeatedIdDto { get; set; }
    public ICustomerUnitOfWork UnitOfWork { get; set; }
    public ICustomerXmlService CustomerXmlService { get; set; }
    public SharedMocks SharedMocks { get; set; }
    public string CustomerId01 { get; set; } = "CustomerId01";

    public CustomerMocks()
    {
      SharedMocks = new SharedMocks();
      _customerUnitOfWork.SetupGet(x => x.CustomerRepositoryAsync).Returns(new CustomerRepositoryAsync(_context));
      _customerUnitOfWork.SetupGet(x => x.Mapper).Returns(SharedMocks.Mapper);
      UnitOfWork = _customerUnitOfWork.Object;
      CustomerXmlService = _customerXmlService.Object;
      CreateCustomerOkDto = new CreateCustomerReqDto
      {
        CustomerName = "Customer Test",
        CustomerId = "abcdefghijklmnopqrs"
      };
      CreateCustomerWhitOutIdDto = new CreateCustomerReqDto
      {
        CustomerName = "Customer Test",
      };
      CreateCustomerWhitOutNameDto = new CreateCustomerReqDto
      {
        CustomerId = "abcdefghijklmnopqrstuv",
      };
      CreateCustomerRepeatedIdDto  = new CreateCustomerReqDto
      {
        CustomerName = "Customer Test",
        CustomerId = "CustomerId01"
      };
    }
  }
  
}