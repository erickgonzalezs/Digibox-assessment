using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Command;
using Application.DTOs;
using Application.Queries;
using GoalIt.Core.Application.DTOs;
using GoalIt.Core.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Digibox.Api.Controllers.v1
{
  public class CustomerController : BaseApiController
  {
    /// <summary>
    /// Create Customer
    /// </summary>
    /// <remarks>
    ///   Evaluation point:  1.	Create a first endpoint to receive json data to store a customerId and customerName in database.
    /// </remarks>
    /// <returns></returns>
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [HttpPost()]
    public async Task<Response<string>> PostDigiBoxCustomer(
      [FromBody] CreateCustomerReqDto payload)
    {
      return await Mediator.Send(new CreateCustomerCommand(payload));
    }
    
    /// <summary>
    /// Get Customer List
    /// </summary>
    /// <remarks>
    ///   Evaluation point:  2.	Create a second endpoint to retrieve all the customers stored in the database.
    /// </remarks>
    /// <param name="filter"></param>
    /// <returns></returns>
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [HttpGet()]
    public async Task<Response<List<CustomerSimpleResDto>>> GetDigiBoxCustomers(
      [FromQuery] PaginatedFilteredReqDto filter)
    {
      return await Mediator.Send(new GetCustomerListQuery());
    }

    /// <summary>
    /// Get Customer List
    /// </summary>
    /// <remarks>
    ///   Evaluation point:  3.	Create a third endpoint that receive the customerId as parameter and retrieve the information of the customer
    ///                         (if exists) in xml format based on the schema of the Digibox Addenda https://aplicacion.digibox.com.mx/addenda/camposadicionales.xsd
    ///                         Recommended to use serialization and libraries to generate classes from XSD schemas)
    /// </remarks>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [HttpGet("{customerId}")]
    public async Task<Response<List<CustomerSimpleResDto>>> GetDigiBoxCustomerById(
      [FromRoute] string customerId)
    {
      return await Mediator.Send(new GetCustomerListQuery());
    }
    
  }
}