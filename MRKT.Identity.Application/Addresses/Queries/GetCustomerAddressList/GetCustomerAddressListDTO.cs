using MRKT.Common.Domain.Entities.Application;
using AutoMapper;
using System;
using MRKT.Common.Application.Common.Mappings.Abstraction;

namespace MRKT.Identity.Application.Addresses.Queries.GetCustomerAddressList
{
    public class GetCustomerAddressListDTO : IMapFrom<Address>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, GetCustomerAddressListDTO>();
        }
    }
}
