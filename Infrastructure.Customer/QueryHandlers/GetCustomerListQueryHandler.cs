using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Persistence;
using Application.Queries;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Infrastructure.Customer.QueryHandlers
{
  public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, Response<List<CustomerSimpleResDto>>>
  {
    private readonly ICustomerUnitOfWork _customerRepository;

    public GetCustomerListQueryHandler(ICustomerUnitOfWork customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public Task<Response<List<CustomerSimpleResDto>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }
  }
}