using AutoMapper;
using MediatR;
using MRKT.Common.Application.Context.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Identity.Application.Addresses.Queries.GetCustomerAddressList
{
    public class GetCustomerAddressListQueryHandler : IRequestHandler<GetCustomerAddressListQuery, GetCustomerAddressListVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerAddressListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCustomerAddressListVM> Handle(GetCustomerAddressListQuery request, CancellationToken cancellationToken)
        {
            return new GetCustomerAddressListVM();
        }
    }
}
