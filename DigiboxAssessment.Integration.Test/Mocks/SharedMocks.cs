using Application.Mappings;
using MediatR;
using Moq;
using AutoMapper;
using AutoMapper.Configuration;
namespace DigiboxAssessment.Integration.Test.Mocks
{
  public class SharedMocks
  {
    private readonly Mock<IMediator> _mediatrMock = new();
    public IMediator Mediator { get; set; }
    public IMapper Mapper { get; set; }

    public SharedMocks()
    {
      MapperConfigurationExpression cfg = new ();
      cfg.AddProfile(new CustomerMappingProfile());
      MapperConfiguration config = new (cfg);
      Mapper = new Mapper(config);
      Mediator = _mediatrMock.Object;
    }
  }
}