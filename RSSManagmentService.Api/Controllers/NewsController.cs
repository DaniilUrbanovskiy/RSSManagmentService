using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSSManagmentService.Api.Dto.Request;
using RSSManagmentService.BLL;
using System.Security.Claims;

namespace RSSManagmentService.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _newsService;

        private readonly UserService _userService;

        private readonly IMapper _mapper;

        public NewsController(NewsService newsService, UserService userService, IMapper mapper)
        {
            _newsService = newsService;          
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPut("read")]
        public async Task<IActionResult> SetNewsAsReadAsync(NewsDto input)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _newsService.SetNewsAsReadAsync(input.NewsIds, userId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUnreadNewsByDateAsync([FromHeader]DateFilterDto input)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetByIdAsync(userId);

            var newsList = await _newsService.GetUnreadNewsByDateAsync(input.DateFilter, user);
            var response = newsList.Select(x => _mapper.Map<Dto.Response.NewsDto>(x));
            return Ok(response);
        }
    }
}