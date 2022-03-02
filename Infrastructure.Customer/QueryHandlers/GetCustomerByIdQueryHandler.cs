using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Application.Interfaces.Persistence;
using Application.Queries;
using Domain.Entities;
using GoalIt.Core.Application.Exceptions;
using GoalIt.Core.Application.Wrappers;
using MediatR;

namespace Infrastructure.Customer.QueryHandlers
{
  public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CamposAdicionales>>
  {
    private readonly ICustomerUnitOfWork _customerUnitOfWork;

    public GetCustomerByIdQueryHandler(ICustomerUnitOfWork customerUnitOfWork)
    {
      _customerUnitOfWork = customerUnitOfWork;
    }

    public async Task<Response<CamposAdicionales>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
      CustomerEntity exist = await _customerUnitOfWork.CustomerRepositoryAsync.FindByIdAsync(request.CustomerId);
      if (exist == null)
        throw new NotFoundException($"No se ha encontrado El Cliente con el ID {request.CustomerId}");
      //TODO Convert to XML 
      CamposAdicionales xml = new CamposAdicionales
      {
        CampoAdicional = new []
        {
          new CamposAdicionalesCampoAdicional
          {
            nombre = "CustomerId",
            valor = exist.Id
          },
          new CamposAdicionalesCampoAdicional
          {
            nombre = "CustomerName",
            valor = exist.Name
          },
        
        }
      };

      return new Response<CamposAdicionales>(xml);
    }
   
  }
}