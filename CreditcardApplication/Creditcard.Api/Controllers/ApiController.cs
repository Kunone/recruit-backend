using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Creditcard.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        protected string GetUserId()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims;
            return claims.FirstOrDefault(claims => claims.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
