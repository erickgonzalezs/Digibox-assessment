using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using Application.Interfaces.Persistence;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Infrastructure.Customer.CommandHandlers
{
  public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<string>>
  {
    private readonly ICustomerUnitOfWork _customerUnitOfWork;

    public CreateCustomerCommandHandler(ICustomerUnitOfWork customerRepository)
    {
      _customerUnitOfWork = customerRepository;
    }

    public Task<Response<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }
  }
}