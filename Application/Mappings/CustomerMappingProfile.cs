using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
  public class CustomerMappingProfile:  AutoMapper.Profile
  {
    public CustomerMappingProfile()
    {
      CreateMap<CreateCustomerReqDto, CustomerEntity>()
        .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.CustomerName))
        .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.CustomerId))
        .ReverseMap();
      CreateMap<CustomerSimpleResDto, CustomerEntity>()
        .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.CustomerName))
        .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.CustomerId))
        .ReverseMap();
      CreateMap<CustomerToXmlResDto, CustomerEntity>()   
        .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.CustomerName))
        .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.CustomerId))
        .ReverseMap();
    }
  }
}