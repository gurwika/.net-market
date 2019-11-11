
using Microsoft.AspNetCore.Identity;
using MRKT.Common.Domain.Entities.Identity;
using MRKT.Common.Domain.Enumarations.Application;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Entities.Application
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string PersonalId { get; protected set; }

        public virtual Seller Seller { get; private set; }
        public virtual Customer Customer { get; private set; }

        public ApplicationUser(string email, string firstName, string lastName, string personalId)
        {
            Email = email;
            UserName = email;
            FirstName = firstName;
            LastName = lastName;
            PersonalId = personalId;
        }

        public void Update(string firstName, string lastName, string personalId)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalId = personalId;
        }
    }
}
