using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creditcard.Api.Controllers
{
    [ApiController]
    [Route("api/credit-cards")]
    public class CreditcardController : ControllerBase
    {
        public CreditcardController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("hello world");
        }
    }
}
