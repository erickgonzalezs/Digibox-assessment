using System.Collections.Generic;
using System.Threading.Tasks;
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
    public async Task<Response<List<CustomerSimpleResDto>>> GetRatingsReport(
      [FromQuery] PaginatedFilteredReqDto filter)
    {
      string route = Request.Path.Value;
      return await Mediator.Send(new GetCustomerListQuery());
    }
  }
}