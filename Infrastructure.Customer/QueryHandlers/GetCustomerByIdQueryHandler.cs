using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Persistence;
using Application.Queries;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Infrastructure.Customer.QueryHandlers
{
  public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<string>>
  {
    private readonly ICustomerUnitOfWork _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerUnitOfWork customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public Task<Response<string>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }
  }
}