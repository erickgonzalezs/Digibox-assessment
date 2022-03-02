using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Persistence;
using Application.Queries;
using Domain.Entities;
using GoalIt.Core.Application.Exceptions;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Infrastructure.Customer.QueryHandlers
{
  public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<string>>
  {
    private readonly ICustomerUnitOfWork _customerUnitOfWork;

    public GetCustomerByIdQueryHandler(ICustomerUnitOfWork customerUnitOfWork)
    {
      _customerUnitOfWork = customerUnitOfWork;
    }

    public async Task<Response<string>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
      CustomerEntity exist = await _customerUnitOfWork.CustomerRepositoryAsync.FindByIdAsync(request.CustomerId);
      if (exist == null)
        throw new NotFoundException($"No se ha encontrado El Cliente con el ID {request.CustomerId}");
      //TODO Convert to XML 
      return new Response<string>($"Test");
    }
  }
}