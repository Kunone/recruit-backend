using Creditcard.Service;
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
        private readonly ICreditcardService _creditcardService;

        public CreditcardController(ICreditcardService creditcardService)
        {
            _creditcardService = creditcardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = Guid.NewGuid().ToString();
            var result = await _creditcardService.GetAllCards(userId);
            return Ok(result);
        }
    }
}
