using System.Collections.Generic;

namespace MRKT.Identity.Application.Brands.Commands.GetBrandsList
{
    public class GetBrandsListVM
    {
        public IList<GetBrandsListDto> Brands { get; set; }
        public int Count { get; set; }
    }
}
