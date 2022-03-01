using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using GoalIt.Core.Application.Exceptions;
using GoalIt.Core.Application.Wrappers;
using Microsoft.AspNetCore.Http;

namespace Digibox.Api
{
  public class ErrorHandlerMiddleware
  {
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception error)
      {
        HttpResponse response = context.Response;
        response.ContentType = "application/json";
        var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };
        switch (error)
        {
          case ApiException e:
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            responseModel.Errors = e.Errors;
            break;
          case NotFoundException e:
            response.StatusCode = (int)HttpStatusCode.NotFound;
            break;
          case ValidationException e:
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            responseModel.Errors = e.Errors;
            break;
          case KeyNotFoundException e:
            response.StatusCode = (int)HttpStatusCode.NotFound;
            break;
          case EntityException e:
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            responseModel.Errors = e.Errors;
            break;
          default:
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            break;
        }
        string result = JsonSerializer.Serialize(responseModel);
        try
        {
          await response.WriteAsync(result);
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          throw;
        }
      }
    }
  }
}