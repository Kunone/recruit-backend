using Autofac.Extras.Moq;
using Creditcard.DataContract;
using Creditcard.Repository;
using Creditcard.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Creditcard.Tests
{
    public class CreditcardServiceTest
    {
        [Fact]
        public void GetAllCards_ThrowEception()
        {
            using(var mock = AutoMock.GetLoose())
            {
                // 1. prepare parameter
                var userId = "";

                // 2. mock
                mock.Mock<ICreditcardRepository>()
                    .Setup(c => c.GetCards(userId))
                    .ReturnsAsync(new List<Card>());
                var cardService = mock.Create<CreditcardService>();

                // 3. action
                var ex = Record.ExceptionAsync(async () =>
                {
                    var result = await cardService.GetAllCards(userId);
                });
                Assert.NotNull(ex.Result);
                Assert.IsType<ArgumentNullException>(ex.Result);
                if (ex.Result is ArgumentNullException argEx)
                {
                    Assert.Equal("missing user id", argEx.ParamName);
                }
            }
        }

        [Theory]
        [InlineData(true, false, "missing card id")]
        [InlineData(false, true, "missing user id")]
        public void GetAllCard_ThrowEception(bool hasUserId, bool hasCardId, string expectedExceptionPara)
        {
            using (var mock = AutoMock.GetLoose())
            {
                // 1. prepare parameter
                string userId = hasUserId? Guid.NewGuid().ToString() : "";
                string cardId = hasCardId ? Guid.NewGuid().ToString() : "";

                // 2. mock
                mock.Mock<ICreditcardRepository>()
                    .Setup(c => c.GetCard(userId, cardId))
                    .ReturnsAsync(new Card());
                var cardService = mock.Create<CreditcardService>();

                // 3. action
                var ex = Record.ExceptionAsync(async () =>
                {
                    var result = await cardService.GetCard(userId, cardId);
                });
                Assert.NotNull(ex.Result);
                Assert.IsType<ArgumentNullException>(ex.Result);
                if (ex.Result is ArgumentNullException argEx)
                {
                    Assert.Equal(expectedExceptionPara, argEx.ParamName);
                }
            }
        }
    }
}
