using AutoMapper;
using System;
using MRKT.Common.Domain.Entities.Identity;
using MRKT.Common.Application.Mappings.Abstraction;

namespace MRKT.Identity.Application.Brands.Commands.GetBrandsList
{
    public class GetBrandsListDto : IMapFrom<Brand>
    {
        public Guid Id { get; set; }
        public string DisplayName { get; protected set; }
        public string Description { get; protected set; }
        public string LogoUrl { get; protected set; }
        public string PublicUrl { get; protected set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Brand, GetBrandsListDto>();
        }
    }
}
