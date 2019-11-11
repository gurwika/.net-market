using MediatR;
using MRKT.Common.Domain.Common.Abstraction.Commands;
using MRKT.Common.Domain.Enumarations.Customer;
using System;

namespace MRKT.Identity.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICommand
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public string Password { get; set; }
        public DateTime birthDate { get; set; }
        public CustomerGender gender { get; set; }
}
}
