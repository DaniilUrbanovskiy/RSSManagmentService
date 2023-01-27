using AutoMapper;
using RSSManagmentService.Api.Dto;
using RSSManagmentService.Entities;

namespace RSSManagmentService.Api.Infrastructure
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<UserRegistrDto, User>();
            CreateMap<UserLoginDto, User>();
        }
    }
}
