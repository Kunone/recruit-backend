using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditcardApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {

        public HealthCheckController()
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello World");
        }
    }
}
