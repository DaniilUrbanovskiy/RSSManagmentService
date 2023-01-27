using AutoMapper;
using RSSManagmentService.Entities;

namespace RSSManagmentService.Api.Infrastructure
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Dto.Request.UserRegistrDto, User>();

            CreateMap<Dto.Request.UserLoginDto, User>();

            CreateMap<Dto.Request.FeedDto, Feed>();

            CreateMap<Feed, Dto.Response.FeedDto>();

            CreateMap<News, Dto.Response.NewsDto>().ForMember(news => news.FeedUrl, config => config.MapFrom(x => x.Feed.Url));
        }

        private static string MapFeedUrl(Feed feed) 
        {
            return feed.Url;
        }
    }
}
