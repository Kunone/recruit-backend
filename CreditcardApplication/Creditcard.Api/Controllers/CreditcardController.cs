using Creditcard.DataContract;
using Creditcard.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creditcard.Api.Controllers
{
    [ApiController]
    [Route("api/credit-cards")]
    [Authorize]
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

        [HttpPost]
        public async Task<IActionResult> SaveCard([FromBody] CardViewModel cardViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            return Ok(true);
        }
    }
}
