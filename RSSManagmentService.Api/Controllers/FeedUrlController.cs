using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSSManagmentService.Api.Dto;
using RSSManagmentService.BLL;
using RSSManagmentService.Entities;
using System.Security.Claims;

namespace RSSManagmentService.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class FeedUrlController : ControllerBase
    {
        private readonly FeedUrlService _feedUrlService;

        private readonly UserService _userService;

        private readonly NewsService _newsService;

        private readonly IMapper _mapper;

        public FeedUrlController(
            FeedUrlService feedUrlService, 
            UserService userService, 
            NewsService newsService, 
            IMapper mapper)
        {
            _feedUrlService = feedUrlService;
            _userService = userService;
            _mapper = mapper;
            _newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedUrlAsync(FeedUrlDto input)
        {            
            var feedUrl = _mapper.Map<FeedUrl>(input);
            feedUrl.User = await _userService.GetByIdAsync(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            feedUrl = await _feedUrlService.AddFeedUrlAsync(feedUrl);

            await _newsService.AddNewsFromFeedUrlAsync(new News
            {
                FeedUrl = feedUrl,
                IsReaded = false
            });

            return Ok();
        }
    }
}