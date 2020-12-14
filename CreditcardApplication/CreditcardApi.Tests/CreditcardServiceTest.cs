using Autofac.Extras.Moq;
using CreditcardApi.DataContract;
using CreditcardApi.Repository;
using CreditcardApi.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditcardApi.Tests
{
    public class CreditcardServiceTest
    {
        [Fact]
        public async Task GetAllCards_Valid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // 1. arrange
                var userId = Guid.NewGuid().ToString();
                List<Card> cards = new List<Card>()
                {
                    new Card()
                    {
                        CardNumber = "m5EUbDvUbksT9LYW1v8AOyL0X2IIPQqDfI1ZfFTiJuQ=",
                        CVC = "mhS2tPsAk1GysMZtXBXhaQ==",
                        Name = "Kun Wang",
                        ExpiryDate = DateTime.Now.AddDays(10)
                    }
                };

                // 2. mock
                mock.Mock<ICreditcardRepository>()
                    .Setup(c => c.GetCards(userId))
                    .ReturnsAsync(cards);
                var cardService = mock.Create<CreditcardService>();

                // 3. action
                var results = await cardService.GetAllCards(userId);

                // 4. assert
                Assert.True(results.Any());
                Assert.Single(results);

                var resultCard = results.ToList().FirstOrDefault();

                Assert.Equal(cards[0].CardNumber, resultCard.CardNumber);
                Assert.Equal(cards[0].CVC, resultCard.CVC);
                Assert.Equal(cards[0].Name, resultCard.Name);
                Assert.Equal(cards[0].ExpiryDate, resultCard.ExpiryDate);
            }
        }

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
