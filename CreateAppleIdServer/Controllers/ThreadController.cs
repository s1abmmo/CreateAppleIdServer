using Microsoft.AspNetCore.Mvc;

namespace CreateAppleIdServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThreadController : ControllerBase
    {
        [HttpGet("StartThread")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
