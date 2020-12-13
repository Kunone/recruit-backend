using Autofac.Extras.Moq;
using AutoMapper;
using Creditcard.Api.Controllers;
using Creditcard.Api.Mapper;
using Creditcard.DataContract;
using Creditcard.Repository;
using Creditcard.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Creditcard.Tests
{
    public class ControllerTest
    {
        private static IMapper _mapper;
        public ControllerTest()
        {
            if(_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new CardMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async Task CreditcardController_Card_Post_Valid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // 1. arrange
                var userId = Guid.NewGuid().ToString();
                var cardView = new CardViewModel()
                {
                    CardNumber = "1234123412341111",
                    CVC = "123",
                    Name = "Kun Wang",
                    ExpiryDate = DateTime.Now.AddDays(10)
                };
                var claims = new List<Claim>(){
                    new Claim(ClaimTypes.NameIdentifier, userId)
                };

                // 2. mock
                var httpContext = mock.Mock<HttpContext>();
                httpContext.Setup(c => c.User)
                    .Returns(new TestPrincipal(new Claim(ClaimTypes.NameIdentifier, userId)));

                mock.Mock<ICreditcardRepository>()
                    .Setup(c => c.SaveCard(new Card()));
                var cardService = mock.Create<CreditcardService>();

                var context = new ControllerContext(
                    new ActionContext(httpContext.Object, new RouteData(), new ControllerActionDescriptor()));

                CreditcardController cardController = new CreditcardController(cardService, _mapper)
                {
                    ControllerContext = context
                };
                 var result = await cardController.SaveCard(cardView);
                
                Assert.IsType<OkObjectResult>(result);
            }
        }
    }

    public class TestPrincipal : ClaimsPrincipal
    {
        public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
        {
        }
    }
    public class TestIdentity : ClaimsIdentity
    {
        public TestIdentity(params Claim[] claims) : base(claims)
        {
        }
    }
}
