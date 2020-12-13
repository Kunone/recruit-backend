using Creditcard.Api.Controllers;
using Creditcard.DataContract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Creditcard.Tests
{
    public class ControllerTest
    {
        [Fact]
        public async void Post_Card_Model_State()
        {
            var controller = new ControllerBase()
            TryValidateModel(new CardViewModel()
            {

            })
        }
    }
}
