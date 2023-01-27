using Microsoft.AspNetCore.Mvc;

namespace RSSManagmentService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RssController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserUrls()
        {
            return Ok();
        }
    }
}