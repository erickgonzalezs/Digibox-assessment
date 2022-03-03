using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using Application.Queries;
using Domain.Entities;
using GoalIt.Core.Application.Exceptions;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Infrastructure.Customer.QueryHandlers
{
  public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<byte[]>>
  {
    private readonly ICustomerUnitOfWork _customerUnitOfWork;
    private readonly ICustomerXmlService _customerXmlService;

    public GetCustomerByIdQueryHandler(ICustomerUnitOfWork customerUnitOfWork, ICustomerXmlService customerXmlService)
    {
      _customerUnitOfWork = customerUnitOfWork;
      _customerXmlService = customerXmlService;
    }

    public async Task<Response<byte[]>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
      CustomerEntity exist = await _customerUnitOfWork.CustomerRepositoryAsync.FindByIdAsync(request.CustomerId);
      if (exist == null)
        throw new NotFoundException($"No se ha encontrado El Cliente con el ID {request.CustomerId}");
      CamposAdicionales xml = _customerXmlService.SerializeToClass(exist);
      byte[] bytes = _customerXmlService.XmlSerializeToByte(xml);
      return new Response<byte[]>(bytes);
    }
  }
  
}