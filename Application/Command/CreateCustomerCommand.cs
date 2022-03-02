using Application.DTOs;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Application.Command
{
  public class CreateCustomerCommand : IRequest<Response<string>>
  {
    public CreateCustomerReqDto Payload { get; set; }
    public CreateCustomerCommand(CreateCustomerReqDto payload)
    {
      Payload = payload;
    }
    
  }
}