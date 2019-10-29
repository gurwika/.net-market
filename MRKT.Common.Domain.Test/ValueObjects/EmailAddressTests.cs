using MRKT.Common.Domain.Exceptions;
using MRKT.Common.Domain.ValueObjects;
using Xunit;

namespace MRKT.Common.Domain.Test.ValueObjects
{
    public class EmailAddressTests
    {
        [Fact]
        public void ExplicitConversionFromStringToEmail()
        {
            var emailAddressString = "example@email.com";
            var emailAddress = (EmailAddress)emailAddressString;

            Assert.Equal(emailAddressString, emailAddress.ToString());
        }

        [Fact]
        public void ToStringShouldReturnCorrectEmail()
        {
            var emailAddressString = "example@email.com";
            var emailAddress = EmailAddress.For(emailAddressString);

            Assert.Equal(emailAddressString, emailAddress.ToString());
        }

        [Fact]
        public void ShouldInvalidEmailAddressrExceptionInvalidEmail()
        {
            Assert.Throws<InvalidEmailAddressrException>(() => (EmailAddress)"example@a.com");
        }
    }
}
