using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using Application.Interfaces.Persistence;
using AutoMapper;
using Domain.Entities;
using GoalIt.Core.Application.Exceptions;
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

    public async Task<Response<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
      if (request.Payload.CustomerId == null) throw new ApiException($"En ID no puede ser NULL");
      if (request.Payload.CustomerName == null) throw new ApiException($"El Name no puede ser NULL");
      CustomerEntity exist = await _customerUnitOfWork.CustomerRepositoryAsync.FindByIdAsync(request.Payload.CustomerId);
      if (exist != null)
        throw new ApiException($"El Cliente con el ID {exist.Id} ya había sido registrado previamente");
      var entity = _customerUnitOfWork.Mapper.Map<CustomerEntity>(request.Payload);
      entity.CreatedAt = DateTime.Now;
      await _customerUnitOfWork.CustomerRepositoryAsync.InsertOneAsync(entity);
      return new Response<string>($"Se ha registrado el cliente con el Id {entity.Id}", true);
    }
  }
}