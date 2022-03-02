using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Application.Queries
{
  public class GetCustomerByIdQuery : IRequest<Response<string>>
  {
    public GetCustomerByIdQuery(string customerId)
    {
      CustomerId = customerId;
    }

    public string CustomerId { get; set; }
  }
}