using System.Collections.Generic;

namespace MRKT.Identity.Application.Addresses.Queries.GetCustomerAddressList
{
    public class GetCustomerAddressListVM
    {
        public IList<GetCustomerAddressListDTO> Categories { get; set; }
        public int Count { get; set; }
    }
}
