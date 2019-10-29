using MRKT.Common.Domain.Common.Concrete.ValueObjects;
using MRKT.Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MRKT.Common.Domain.ValueObjects
{
    public class EmailAddress : ValueObject
    {
        public string Email { get; private set; }

        private EmailAddress() { }
        public static EmailAddress For(string emailAddressString)
        {
            var emailAddress = new EmailAddress();

            try
            {
                string pattern = @"^([a-zA-Z0-9._-]+)@([a-zA-Z0-9.-]{2,})\.([a-zA-Z]{2,6})$";
                Match match = Regex.Match(emailAddressString, pattern, RegexOptions.IgnoreCase);

                if (!match.Success)
                {
                    throw new Exception();
                }

                emailAddress.Email = emailAddressString;
            }
            catch (Exception ex)
            {
                throw new InvalidEmailAddressrException(emailAddressString, ex);
            }

            return emailAddress;
        }

        public static implicit operator string(EmailAddress emailAddress)
        {
            return emailAddress.ToString();
        }

        public static explicit operator EmailAddress(string emailAddress)
        {
            return For(emailAddress);
        }

        public override string ToString()
        {
            return $"{Email}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Email;
        }
    }
}
