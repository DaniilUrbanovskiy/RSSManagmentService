using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSSManagmentService.Api.Dto.Model;
using RSSManagmentService.Api.Dto.Request;
using RSSManagmentService.BLL;
using RSSManagmentService.Entities;
using System.Data;
using System.Net;
using System.Security.Claims;
using System.Xml;

namespace RSSManagmentService.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly FeedService _feedService;

        private readonly UserService _userService;

        private readonly NewsService _newsService;

        private readonly IMapper _mapper;

        public FeedController(
            FeedService feedService, 
            UserService userService, 
            NewsService newsService, 
            IMapper mapper)
        {
            _feedService = feedService;
            _userService = userService;
            _newsService = newsService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedAsync(FeedDto input)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var feed = _mapper.Map<Feed>(input);
            feed.User = await _userService.GetByIdAsync(userId);

            try
            {
                await _feedService.AddFeedAsync(feed);
                await _newsService.AddNewsFromFeedAsync(feed);
            }
            catch (XmlException)
            {
                return BadRequest(new WebServiceError(HttpStatusCode.BadRequest, "Incorrect feed url"));
            }
            catch (DuplicateNameException)
            {
                return BadRequest(new WebServiceError(HttpStatusCode.BadRequest, "Feed already exists"));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetFeedsAsync()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetByIdAsync(userId);

            var feeds = await _feedService.GetFeedsAsync(user);
            var response = feeds.Select(feed => _mapper.Map<Dto.Response.FeedDto>(feed));

            return Ok(response);
        }
    }
}