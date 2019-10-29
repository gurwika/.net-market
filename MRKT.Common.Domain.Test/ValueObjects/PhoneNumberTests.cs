using MRKT.Common.Domain.Exceptions;
using MRKT.Common.Domain.ValueObjects;
using Xunit;

namespace MRKT.Common.Domain.Test.ValueObjects
{
    public class PhoneNumberTests
    {
        [Fact]
        public void ShouldHaveCorrectSuffixAndNumber()
        {
            var phoneNumber = PhoneNumber.For("577-348094");

            Assert.Equal("577", phoneNumber.Suffix);
            Assert.Equal("348094", phoneNumber.Number);
        }

        [Fact]
        public void ExplicitConversionFromStringToPhoneNumber()
        {
            var phoneNumberString = "577-348094";
            var phoneNumber = (PhoneNumber)phoneNumberString;

            Assert.Equal("577", phoneNumber.Suffix);
            Assert.Equal("348094", phoneNumber.Number);
        }

        [Fact]
        public void ToStringShouldReturnCorrectNumber()
        {
            var phoneNumberString = "577-348094";
            var phoneNumber = PhoneNumber.For(phoneNumberString);

            Assert.Equal(phoneNumberString, phoneNumber.ToString());
        }

        [Fact]
        public void ShouldInvalidPhoneNumberExceptionForInvalidPhoneNumber()
        {
            Assert.Throws<InvalidPhoneNumberException>(() => (PhoneNumber)"577348094");
        }
    }
}
