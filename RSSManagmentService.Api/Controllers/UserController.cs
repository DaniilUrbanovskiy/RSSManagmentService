using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSSManagmentService.Api.Dto;
using RSSManagmentService.Api.Dto.Model;
using RSSManagmentService.Api.Dto.Responses;
using RSSManagmentService.Api.Infrastructure;
using RSSManagmentService.BLL;
using RSSManagmentService.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace RSSManagmentService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("registr")]
        public async Task<IActionResult> RegistrAsync([FromBody] UserRegistrDto input)
        {
            try
            {
                var user = _mapper.Map<User>(input);
                await _userService.RegistrationAsync(user);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(new WebServiceError(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto input)
        {
            try
            {
                var user = _mapper.Map<User>(input);
                user = await _userService.LoginAsync(user);
                var tokenResponse = JwtHealper.CreateToken(user);
                var token = new TokenResponse(new JwtSecurityTokenHandler().WriteToken(tokenResponse));

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new WebServiceError(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}
