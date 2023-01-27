using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSSManagmentService.BLL;
using RSSManagmentService.Entities;
using System.Security.Claims;

namespace RSSManagmentService.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class NewslController : ControllerBase
    {
        private readonly NewsService _newsService;

        private readonly UserService _userService;

        private readonly IMapper _mapper;

        public NewslController(NewsService newsService, UserService userService, IMapper mapper)
        {
            _newsService = newsService;          
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SetNewsAsReadedAsync(string feedUrl)
        {
            //var user = await _userService.GetByIdAsync(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            //await _newsService.AddFeedUrlAsync(new FeedUrl
            //{
            //    Url = feedUrl,
            //    CreatedDate = DateTime.Now,
            //    User = user
            //});
            return Ok();
        }
    }
}