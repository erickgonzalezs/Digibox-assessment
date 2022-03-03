using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using DigiboxAssessment.Test.Helpers.Mocks;
using FluentAssertions;
using GoalIt.Core.Application.Wrappers;
using Infrastructure.Customer.CommandHandlers;
using Xunit;

namespace DigiboxAssessment.Test.IntregationTest.Handlers.Success.Commands
{
  public class CustomerCommandHandlersTest
  {
    [Fact]
    public async Task Create_Customer_Success()
    {
      //Arrange
      CustomerMocks mocks = new();
      CreateCustomerCommand command = new (mocks.CreateCustomerOkDto);
      CreateCustomerCommandHandler handler = new (mocks.UnitOfWork);
      //Act
      Response<string> result = await handler.Handle(command, CancellationToken.None);
      //Assert
      result.Succeeded.Should().Be(true);
      result.Message.Should().Contain(mocks.CreateCustomerOkDto.CustomerId);
    }
  }
}