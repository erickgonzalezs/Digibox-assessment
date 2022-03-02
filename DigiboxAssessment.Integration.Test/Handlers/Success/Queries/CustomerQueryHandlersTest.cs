using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Queries;
using DigiboxAssessment.Integration.Test.Mocks;
using FluentAssertions;
using GoalIt.Core.Application.Wrappers;
using Infrastructure.Customer.QueryHandlers;
using Xunit;

namespace DigiboxAssessment.Integration.Test.Handlers.Success.Queries
{
  public class CustomerQueryHandlersTest
  {
    private byte[] LocalData { get; set; }
    [Fact]
    public async Task Get_Customer_List_Success()
    {
      //Arrange
      CustomerMocks mocks = new();
      GetCustomerListQuery query = new();
      GetCustomerListQueryHandler handler = new (mocks.UnitOfWork);
      //Act
      Response<List<CustomerSimpleResDto>> result = await handler.Handle(query, CancellationToken.None);
      //Assert
      result.Succeeded.Should().Be(true);
      result.Data.Should().HaveCount(4);
    }
    [Fact]
    public async Task Get_Customer_ArrayByte_Addenda_ByCustomerID_Success()
    {
      //Arrange
      CustomerMocks mocks = new();
      GetCustomerByIdQuery query = new(mocks.CustomerId01);
      GetCustomerByIdQueryHandler handler = new (mocks.UnitOfWork);
      //Act
      Response<byte[]> result = await handler.Handle(query, CancellationToken.None);
      LocalData = result.Data;
      //Assert
      result.Succeeded.Should().Be(true);
      result.Data.Should().BeOfType<byte[]>();
    }
    [Fact]
    public async Task Get_Customer_Addenda_ByCustomerID_Success()
    {
      //Arrange
      CustomerMocks mocks = new();
      //Act
      await Get_Customer_ArrayByte_Addenda_ByCustomerID_Success();
      //Assert
      
    }
  }
}