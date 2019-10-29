using MRKT.Common.Domain.Common.Concrete.ValueObjects;
using MRKT.Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRKT.Common.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Suffix { get; private set; }
        public string Number { get; private set; }

        private PhoneNumber() { }

        public static PhoneNumber For(string phoneNumberString)
        {
            var phoneNumber = new PhoneNumber();

            try
            {
                var phoneNumberSegments = phoneNumberString.Split('-');

                phoneNumber.Suffix = phoneNumberSegments[0];
                phoneNumber.Number = phoneNumberSegments[1];
            }
            catch (Exception ex)
            {
                throw new InvalidPhoneNumberException(phoneNumber, ex);
            }

            return phoneNumber;
        }

        public static implicit operator string(PhoneNumber phoneNumber)
        {
            return phoneNumber.ToString();
        }

        public static explicit operator PhoneNumber(string phoneNumber)
        {
            return For(phoneNumber);
        }

        public override string ToString()
        {
            return $"{Suffix}-{Number}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Suffix;
            yield return Number;
        }
    }
}
