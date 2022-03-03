using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Persistence;
using Application.Queries;
using Domain.Entities;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Infrastructure.Customer.QueryHandlers
{
  public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, Response<List<CustomerSimpleResDto>>>
  {
    private readonly ICustomerUnitOfWork _customerUnitOfWork;

    public GetCustomerListQueryHandler(ICustomerUnitOfWork customerUnitOfWork)
    {
      _customerUnitOfWork = customerUnitOfWork;
    }

    public async Task<Response<List<CustomerSimpleResDto>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
    {
      List<CustomerEntity> customerList = await _customerUnitOfWork.CustomerRepositoryAsync.GetAllAsync();
      var customersMapped = _customerUnitOfWork.Mapper.Map<List<CustomerSimpleResDto>>(customerList);
      return new Response<List<CustomerSimpleResDto>>(customersMapped);
    }
  }
}