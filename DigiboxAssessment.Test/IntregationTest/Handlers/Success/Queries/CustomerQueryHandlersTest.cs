using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Queries;
using DigiboxAssessment.Test.Helpers.Mocks;
using FluentAssertions;
using GoalIt.Core.Application.Wrappers;
using Infrastructure.Customer.QueryHandlers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DigiboxAssessment.Test.IntregationTest.Handlers.Success.Queries
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
      var fileNameResult = $"{mocks.CustomerId01}-interface.xml";
      //Act
      await Get_Customer_ArrayByte_Addenda_ByCustomerID_Success();
      var result = new FileContentResult(LocalData, "application/octet-stream")
      {
        FileDownloadName = fileNameResult
      };
      //Assert
      result.FileDownloadName.Should().Be(fileNameResult);
      result.ContentType.Should().Be("application/octet-stream");
    }
  }
}