using CreditcardApi.Helps;
using CreditcardApi.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditcardApi.Tests
{
    public class EncryptionTest
    {
        [Theory]
        [InlineData("1234123412341111")]
        [InlineData("0234123412341100")]
        [InlineData("123")]
        [InlineData("023")]
        [InlineData("020")]
        public void Encryption_Valid(string originalText)
        {
            var cipherText = SymetricEncryptionHelper.Encrypt(originalText);
            var plainText = SymetricEncryptionHelper.Decrypt(cipherText);

            Assert.Equal(originalText, plainText);
        }
    }
}
