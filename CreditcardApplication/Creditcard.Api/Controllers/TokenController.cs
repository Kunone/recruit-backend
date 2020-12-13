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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] SigninViewModel userCred)
        {
            var token = _tokenService.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
