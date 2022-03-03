using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries;
using DigiboxAssessment.Test.Helpers.Mocks;
using FluentAssertions;
using GoalIt.Core.Application.Exceptions;
using Infrastructure.Customer.QueryHandlers;
using Xunit;

namespace DigiboxAssessment.Test.IntregationTest.Handlers.Fails.Queries
{
  public class CustomerQueryHandlerTest
  {
    [Fact]
    public async Task Get_Customer_ArrayByte_Addenda_ByCustomerID_Fail()
    {
      //Arrange
      CustomerMocks mocks = new();
      GetCustomerByIdQuery query = new("incorrectId");
      GetCustomerByIdQueryHandler handler = new (mocks.UnitOfWork, mocks.CustomerXmlService);
      //Act
      Func<Task> act = async () => { await handler.Handle(query, CancellationToken.None); };
      //Assert
      await act.Should().ThrowAsync<NotFoundException>();
    }
  }
}