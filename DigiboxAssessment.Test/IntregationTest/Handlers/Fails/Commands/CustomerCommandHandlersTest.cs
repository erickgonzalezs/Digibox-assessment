using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using DigiboxAssessment.Test.Helpers.Mocks;
using FluentAssertions;
using GoalIt.Core.Application.Exceptions;
using Infrastructure.Customer.CommandHandlers;
using Xunit;

namespace DigiboxAssessment.Test.IntregationTest.Handlers.Fails.Commands
{
  public class CustomerCommandHandlersTest
  {
    [Fact]
    public async Task Create_Customer_Without_ID_Fail()
    {
      //Arrange
      CustomerMocks mocks = new();
      CreateCustomerCommand command = new (mocks.CreateCustomerWhitOutIdDto);
      CreateCustomerCommandHandler handler = new (mocks.UnitOfWork);
      //Act
      Func<Task> act = async () => { await handler.Handle(command, CancellationToken.None); };
      //Assert
      await act.Should().ThrowAsync<ApiException>().WithMessage("En ID no puede ser NULL");
      
    }
    [Fact]
    public async Task Create_Customer_Without_Name_Fail()
    {
      //Arrange
      CustomerMocks mocks = new();
      CreateCustomerCommand command = new (mocks.CreateCustomerWhitOutNameDto);
      CreateCustomerCommandHandler handler = new (mocks.UnitOfWork);
      //Act
      Func<Task> act = async () => { await handler.Handle(command, CancellationToken.None); };
      //Assert
      await act.Should().ThrowAsync<ApiException>().WithMessage("El Name no puede ser NULL");
    }
    [Fact]
    public async Task Create_Customer_Repeated_ID_Fail()
    {
      //Arrange
      CustomerMocks mocks = new();
      CreateCustomerCommand command = new (mocks.CreateCustomerRepeatedIdDto);
      CreateCustomerCommandHandler handler = new (mocks.UnitOfWork);
      //Act
      Func<Task> act = async () => { await handler.Handle(command, CancellationToken.None); };
      //Assert
      await act.Should().ThrowAsync<ApiException>()
        .WithMessage($"El Cliente con el ID {mocks.CreateCustomerRepeatedIdDto.CustomerId} ya había sido registrado previamente");
    }
  }
}