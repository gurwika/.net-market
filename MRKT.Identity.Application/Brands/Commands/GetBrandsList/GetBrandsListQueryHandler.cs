using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Domain.Common.Abstraction.Queries;
using MRKT.Common.Domain.Entities.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Identity.Application.Brands.Commands.GetBrandsList
{
    public class GetBrandsListQueryHandler : IQueryHandler<GetBrandsListQuery, GetBrandsListVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetBrandsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetBrandsListVM> Handle(GetBrandsListQuery request, CancellationToken cancellationToken)
        {
            var brands = await _context.Set<Brand>()
                                    .ProjectTo<GetBrandsListDto>(_mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);

            return new GetBrandsListVM
            {
                Brands = brands,
                Count = brands.Count
            };
        }
    }
}
