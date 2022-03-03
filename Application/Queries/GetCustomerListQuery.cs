using System.Collections.Generic;
using Application.DTOs;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Application.Queries
{
  public class GetCustomerListQuery : IRequest<Response<List<CustomerSimpleResDto>>>
  {
  }
}